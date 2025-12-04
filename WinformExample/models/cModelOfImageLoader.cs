using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace WinformExample
{
    public class cModelOfImageLoader
    {
        [DllImport("CppDLL.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetGaussianBluredImage@@YAXPEAE0HHH@Z")]
        public static extern void GetGaussianBluredImage(byte[] byteArrOriginal, byte[] byteArrOutput, int nHeight, int nWidth, int nMemLen);

        private iImageLoadPresenter inter;
        public cModelOfImageLoader(iImageLoadPresenter presenter)
        {
            inter = presenter;
            inter.btnImageLoadClick += btnImageLoad_Click;
        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                // 처음 이미지를 로드한다.
                Image imageRead = Image.FromFile(dlg.FileName);

                Image imageFiltered;

                inter.ImageOriginal = imageRead;

                Bitmap bmp = (Bitmap)imageRead;
                Bitmap newBmp;

                int nHeight = bmp.Height;
                int nWidth = bmp.Width;

                int bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int stride = nWidth * bytesPerPixel;
                byte[] imageData = new byte[stride * nHeight];
                byte[] outputData = new byte[stride * nHeight];

                System.Drawing.Imaging.BitmapData bitmapData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, nWidth, nHeight),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

                Marshal.Copy(bitmapData.Scan0, imageData, 0, imageData.Length);

                bmp.UnlockBits(bitmapData);

                GetGaussianBluredImage(imageData, outputData, nHeight, nWidth, stride * nHeight);

                newBmp = new Bitmap(nWidth, nHeight);
                System.Drawing.Imaging.BitmapData bitmapAfterData = newBmp.LockBits(new System.Drawing.Rectangle(0, 0, nWidth, nHeight),
                    System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);

                Marshal.Copy(outputData, 0, bitmapAfterData.Scan0, outputData.Length);

                newBmp.UnlockBits(bitmapAfterData);

                imageFiltered = newBmp;

                inter.ImageFiltered = imageFiltered;

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"ImageLoader - Button Clicked : Image {dlg.FileName}");
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        public void SaveData(string sPathToSave)
        {

        }
        public void LoadData(string sPathToLoad)
        {

        }
    }
}
