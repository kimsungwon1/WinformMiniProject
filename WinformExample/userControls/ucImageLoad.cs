using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;


namespace WinformExample
{
    public partial class ucImageLoad : UserControl, iImageLoadPresenter
    {
        public ucImageLoad()
        {
            try
            {
                InitializeComponent();
                EventInitialize();
                m_modelOfImageLoader = new cModelOfImageLoader(this);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        private void EventInitialize()
        {
            this.btnImageLoad.Click += new System.EventHandler(this.btnImageLoad_Click);
        }

        private cModelOfImageLoader m_modelOfImageLoader;

        public event EventHandler btnImageLoadClick;
        public Image ImageOriginal
        {
            set
            {
                pbMainPicture.Image = value;
            }
        }
        public Image ImageFiltered
        {
            set
            {
                pbImageFiltered.Image = value;
            }
        }


        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            try
            {
                btnImageLoadClick(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        public void SaveData(string sPathToSave)
        {
            try
            {
                m_modelOfImageLoader.SaveData(sPathToSave);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        public void LoadData(string sPathToLoad)
        {
            try
            {
                m_modelOfImageLoader.LoadData(sPathToLoad);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
    }
}
