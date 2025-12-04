using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformExample
{
    public partial class ucBMI : UserControl, iBMIPresenter
    {
        private cModelOfBMI model;

        public event EventHandler btnCalculateClick;
        public ucBMI()
        {
            InitializeComponent();
            initializeEvents();
            model = new cModelOfBMI(this);
        }

        private void initializeEvents()
        {
            this.btnCalculateBMI.Click += new System.EventHandler(this.btnCalculateBMI_Click);
            this.tbHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHeight_KeyPress);
            this.tbWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWeight_KeyPress);
        }

        public string TextTbWeight
        {
            get
            {
                return tbWeight.Text;
            }
            set
            {
                tbWeight.Text = value;
            }
        }
        public string TextTbHeight
        {
            get
            {
                return tbHeight.Text;
            }
            set
            {
                tbHeight.Text = value;
            }
        }
        public string TextLbResult
        {
            set
            {
                lbResult.Text = value;
            }
        }
        public int ValueBmiTkbar
        {
            get
            {
                return tkBarBMI.Value;
            }
            set
            {
                tkBarBMI.Value = value;
            }
        }
        public int MaxValueBmiTkbar
        {
            get
            {
                return tkBarBMI.Maximum;
            }
        }
        
        private void btnCalculateBMI_Click(object sender, EventArgs e)
        {
            if(btnCalculateClick == null)
            {
                throw new NullReferenceException("BMI - Calculate Button event is null");
            }
            btnCalculateClick(sender, e);
        }

        public void SaveData(string sPathToSave)
        {
            model.SaveData(sPathToSave);
        }
        public void LoadData(string sPathToLoad)
        {
            model.LoadData(sPathToLoad);
        }

        private void tbHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void tbWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData("../../Save/BMI.txt");
        }
    }
}
