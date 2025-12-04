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
            InitializeComponent();
            eventInitialize();
            model = new cModelOfImageLoader(this);
        }
        private void eventInitialize()
        {
            this.btnImageLoad.Click += new System.EventHandler(this.btnImageLoad_Click);
        }

        private cModelOfImageLoader model;

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
            if(btnImageLoadClick == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "ImageLoad - Image Loading Button Event is null");
                throw new NullReferenceException("ImageLoad - Image Loading Button Event is null");
            }
            btnImageLoadClick(sender, e);
        }
        public void SaveData(string sPathToSave)
        {
            model.SaveData(sPathToSave);
        }
        public void LoadData(string sPathToLoad)
        {
            model.LoadData(sPathToLoad);
        }
    }
}
