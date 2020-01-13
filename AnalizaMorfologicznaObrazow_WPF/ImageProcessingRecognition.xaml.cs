using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rectangle = System.Drawing.Rectangle;

namespace AnalizaMorfologicznaObrazow_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy ImageProcessingRecognition.xaml
    /// </summary>
    public partial class ImageProcessingRecognition : Page
    {
        Bitmap bmp;
        public ImageProcessingRecognition()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png;*.bmp|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "BMP(*.bmp)|*.bmp|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {


                bmp = new Bitmap(op.FileName);
                ImgPhoto.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            }
        }

        private void CheckImage()
        {
            if (ImgPhoto.Source.Height > 0)
            {
                BitmapData newbitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                byte[] pixelbuff = new byte[Math.Abs(newbitmapData.Stride) * newbitmapData.Height];
                byte[] resultbuff = new byte[Math.Abs(newbitmapData.Stride) * newbitmapData.Height];
                Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
                bmp.UnlockBits(newbitmapData);

                int licznik = 0;
                float size211 = 0;

                for (int counter = 0; counter < pixelbuff.Length; counter++)
                {
                    if (pixelbuff[counter] == 211) size211++;
                    if (pixelbuff[counter] == 255 || pixelbuff[counter] == 211 || pixelbuff[counter] == 0) licznik++;
                }
                if (licznik == pixelbuff.Length) textBoxResult.Text = "Image processed by XY Filters, completed recognition is not avaiable";
                else if (size211 / pixelbuff.Length > 0.015 || size211 / pixelbuff.Length > 0.005) textBoxResult.Text = "Image processed by Morphology Basics, completed recognition is not avaiable";
                else textBoxResult.Text = "Original Image ";

            }
        }

        private void BtnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            CheckImage();
        }
    }
}
