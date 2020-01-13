using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
using System.Runtime.InteropServices;
using Rectangle = System.Drawing.Rectangle;

namespace AnalizaMorfologicznaObrazow_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy FiltryXY.xaml
    /// </summary>
    public partial class FiltryXY : Page

    {
       
        Bitmap bmp;
        public FiltryXY()
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


                // bitmapImage = new BitmapImage(new Uri(op.FileName));
                bmp = new Bitmap(op.FileName);
                ImgPhoto.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            }
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (XFilter.SelectedItem.ToString().Length > 0 && YFilter.SelectedItem.ToString().Length > 0)
                {
                    Filter(XFilter.SelectedItem.ToString(), YFilter.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("2 filters must be selected");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" Something went wrong ! :(");
            }

        }
        public void Filter(string xfilter, string yfilter)
        {
            double[,] xFilterMatrix;
            double[,] yFilterMatrix;
            switch (xfilter)
            {
                case "Laplacian3x3":
                    xFilterMatrix = FilterMatrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    xFilterMatrix = FilterMatrix.Laplacian5x5;
                    break;
                case "LaplacianOfGaussian":
                    xFilterMatrix = FilterMatrix.LaplacianOfGaussian;
                    break;
                case "Gaussian3x3":
                    xFilterMatrix = FilterMatrix.Gaussian3x3;
                    break;
                case "Gaussian5x5Type1":
                    xFilterMatrix = FilterMatrix.Gaussian5x5Type1;
                    break;
                case "Gaussian5x5Type2":
                    xFilterMatrix = FilterMatrix.Gaussian5x5Type2;
                    break;
                case "Sobel3x3Horizontal":
                    xFilterMatrix = FilterMatrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    xFilterMatrix = FilterMatrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    xFilterMatrix = FilterMatrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    xFilterMatrix = FilterMatrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    xFilterMatrix = FilterMatrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    xFilterMatrix = FilterMatrix.Kirsch3x3Vertical;
                    break;
                default:
                    xFilterMatrix = FilterMatrix.Laplacian3x3;
                    break;
            }

            switch (yfilter)
            {
                case "Laplacian3x3":
                    yFilterMatrix = FilterMatrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    yFilterMatrix = FilterMatrix.Laplacian5x5;
                    break;
                case "LaplacianOfGaussian":
                    yFilterMatrix = FilterMatrix.LaplacianOfGaussian;
                    break;
                case "Gaussian3x3":
                    yFilterMatrix = FilterMatrix.Gaussian3x3;
                    break;
                case "Gaussian5x5Type1":
                    yFilterMatrix = FilterMatrix.Gaussian5x5Type1;
                    break;
                case "Gaussian5x5Type2":
                    yFilterMatrix = FilterMatrix.Gaussian5x5Type2;
                    break;
                case "Sobel3x3Horizontal":
                    yFilterMatrix = FilterMatrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    yFilterMatrix = FilterMatrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    yFilterMatrix = FilterMatrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    yFilterMatrix = FilterMatrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    yFilterMatrix = FilterMatrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    yFilterMatrix = FilterMatrix.Kirsch3x3Vertical;
                    break;
                default:
                    yFilterMatrix = FilterMatrix.Laplacian3x3;
                    break;
            }

            if (ImgPhoto.Source.Height > 0) //pictureBoxPreview.Image.Size.Height > 0) (
            {
                BitmapData newbitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                byte[] pixelbuff = new byte[Math.Abs(newbitmapData.Stride) * newbitmapData.Height];
                byte[] resultbuff = new byte[Math.Abs(newbitmapData.Stride) * newbitmapData.Height];
                Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
                bmp.UnlockBits(newbitmapData);

                double blueX = 0.0;
                double greenX = 0.0;
                double redX = 0.0;

                double blueY = 0.0;
                double greenY = 0.0;
                double redY = 0.0;

                double blueTotal = 0.0;
                double greenTotal = 0.0;
                double redTotal = 0.0;

                int filterOffset = 1;
                int calcOffset = 0;

                int byteOffset = 0;
                
                for (int offsetY = filterOffset; offsetY < bmp.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX < bmp.Width - filterOffset; offsetX++)
                    {
                        blueX = greenX = redX = 0;
                        blueY = greenY = redY = 0;

                        blueTotal = greenTotal = redTotal = 0.0;

                        byteOffset = offsetY * newbitmapData.Stride + offsetX * 4;

                        for (int filterY = -1; filterY <= filterOffset; filterY++)

                        {
                            for (int filterX = -1; filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset + (filterX * 4) + (filterY * newbitmapData.Stride);

                                blueX += (double)(pixelbuff[calcOffset]) * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                                greenX += (double)(pixelbuff[calcOffset + 1]) * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                                redX += (double)(pixelbuff[calcOffset + 2]) * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                                blueY += (double)(pixelbuff[calcOffset]) * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                                greenY += (double)(pixelbuff[calcOffset + 1]) * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                                redY += (double)(pixelbuff[calcOffset + 2]) * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                            }

                        }

                        blueTotal = 0;
                        greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                        redTotal = 0;

                        if (blueTotal > 255) { blueTotal = 255; }
                        else if (blueTotal < 0) { blueTotal = 0; }

                        if (greenTotal > 255) { greenTotal = 255; }
                        else if (greenTotal < 0) { greenTotal = 0; }

                        try
                        {

                            if (greenTotal < Convert.ToInt32(ThresholdSlider.Value))
                            {
                                greenTotal = 0;
                            }
                            else
                            {
                                greenTotal = 255;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }


                        if (redTotal > 255) { redTotal = 255; }
                        else if (redTotal < 0) { redTotal = 0; }
                        resultbuff[byteOffset] = (byte)(blueTotal);
                        resultbuff[byteOffset + 1] = (byte)(greenTotal);
                        resultbuff[byteOffset + 2] = (byte)(redTotal);
                        resultbuff[byteOffset + 3] = 255;
                    }

                }
               
                Bitmap resultbitmap = new Bitmap(bmp.Width, bmp.Height);

                BitmapData resultData = resultbitmap.LockBits(new Rectangle(0, 0, resultbitmap.Width, resultbitmap.Height),
                ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
                resultbitmap.UnlockBits(resultData);
                ImgResult.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(resultbitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
               
            }

            else
            {
                MessageBox.Show("You must load an image");
            }
        }

        private void BtnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png;*.bmp|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "BMP(*.bmp)|*.bmp|" +
              "Portable Network Graphic (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream saveStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)ImgResult.Source));
                encoder.Save(saveStream);
                saveStream.Close();
            }
        }
    }
}