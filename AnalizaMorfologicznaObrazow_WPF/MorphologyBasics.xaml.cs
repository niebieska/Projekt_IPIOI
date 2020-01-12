using Microsoft.Win32;
using MorphologicalEdgeDetection;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace AnalizaMorfologicznaObrazow_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy PodstawyMorfologi.xaml
    /// </summary>
    public partial class PodstawyMorfologi : Page
    {
       private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;

        public PodstawyMorfologi()
        {
            InitializeComponent();
            cmbEdgeOptions.SelectedIndex = 0;
            cmbEdgeOptions.Items.Add(ExtBitmap.MorphologyEdgeType.None);
            cmbEdgeOptions.Items.Add(ExtBitmap.MorphologyEdgeType.EdgeDetection);
            cmbEdgeOptions.Items.Add(ExtBitmap.MorphologyEdgeType.SharpenEdgeDetection);

            cmbEdgeOptions.SelectedIndex = 0;
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
                               
               originalBitmap= new Bitmap(op.FileName);
               previewBitmap = originalBitmap.CopyToSquareCanvas(originalBitmap.Width);
               
                ImgPhoto.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(previewBitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ApplyFilter(true);
            }
        }

        private void ApplyFilter(bool preview)
        {
            if (previewBitmap == null || cmbFilterSize.SelectedIndex == -1)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = previewBitmap;
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                if (cmbFilterSize.SelectedItem.ToString() == "None")
                {
                    bitmapResult = selectedSource;
                }
                else
                {
                    int filterSize = 0;

                    ExtBitmap.MorphologyEdgeType edgeType = ((ExtBitmap.MorphologyEdgeType)cmbEdgeOptions.SelectedItem);
                    MessageBox.Show(cmbFilterSize.SelectedItem.ToString() + "" + Int32.TryParse(cmbFilterSize.SelectedItem.ToString(), out filterSize) );
                    int a = cmbFilterSize.SelectedItem.ToString().Length;
                     String s = cmbFilterSize.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:","");



                    if (Int32.TryParse(s, out filterSize))
                        

                    {
                       
                        if (rdDilate.IsChecked == true)
                        {
                            bitmapResult = selectedSource.DilateAndErodeFilter(filterSize, ExtBitmap.MorphologyType.Dilation, (bool)chkB.IsChecked, (bool)chkG.IsChecked, (bool)chkR.IsChecked, edgeType);
                        }
                        else if (rdErode.IsChecked == true)
                        {
                            bitmapResult = selectedSource.DilateAndErodeFilter(filterSize, ExtBitmap.MorphologyType.Erosion, (bool)chkB.IsChecked, (bool)chkG.IsChecked, (bool)chkR.IsChecked, edgeType);
                        }
                        else if (rdOpen.IsChecked == true)
                        {
                            bitmapResult = selectedSource.OpenMorphologyFilter(filterSize, (bool)chkB.IsChecked, (bool)chkG.IsChecked, (bool)chkR.IsChecked);
                        }
                        else if (rdClose.IsChecked == true)
                        {
                            bitmapResult = selectedSource.CloseMorphologyFilter(filterSize, (bool)chkB.IsChecked, (bool)chkG.IsChecked, (bool)chkR.IsChecked);
                        }
                    }
                }
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    ImgResult.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmapResult.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()); ;
                }
                else
                {
                    resultBitmap = bitmapResult;
                }
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

       
        private void cmbFilterSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter(true); MessageBox.Show("I'm comming home !");
        }

        private void FilterValueChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter(true);
        }

        private void FilterValueChangedEventHandler(object sender, RoutedEventArgs e)
        {
            ApplyFilter(true);
        }
    }
}
