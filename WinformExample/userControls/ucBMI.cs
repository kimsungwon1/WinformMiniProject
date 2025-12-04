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
        private cModelOfBMI m_modelOfBMI;

        public event EventHandler btnCalculateClick;
        public ucBMI()
        {
            try
            {
                InitializeComponent();
                EventInitialize();
                m_modelOfBMI = new cModelOfBMI(this);
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void EventInitialize()
        {
            this.btnCalculateBMI.Click += new System.EventHandler(this.btnCalculateBMI_Click);
            this.tbHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHeight_KeyPress);
            this.tbWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWeight_KeyPress);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            try
            {
                btnCalculateClick(sender, e);
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        public void SaveData(string sPathToSave)
        {
            try
            {
                m_modelOfBMI.SaveData(sPathToSave);
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        public void LoadData(string sPathToLoad)
        {
            try
            {
                m_modelOfBMI.LoadData(sPathToLoad);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void tbHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void tbWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData("../../Save/BMI.txt");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
    }
}
