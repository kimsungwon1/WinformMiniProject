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
    public partial class ucCalculator : UserControl, iCalculatorPresenter
    {
        private cModelOfCalculator m_modelOfCalculator;

        public event EventHandler btnClick_MainOperation;
        public event KeyPressEventHandler keyPress_MainOperation;

        public ucCalculator()
        {
            try
            {
                InitializeComponent();
                EventInitialize();
                m_modelOfCalculator = new cModelOfCalculator(this);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void EventInitialize()
        {
            this.btnPoint.Click += this.btnCalBtn_Click;
            this.btnPoint.Enter += this.btn_Enter;
            this.btnEqual.Click += this.btnCalBtn_Click;
            this.btnEqual.Enter += this.btn_Enter;
            this.btnZero.Click += this.btnCalBtn_Click;
            this.btnZero.Enter += this.btn_Enter;
            this.btnPlus.Click += this.btnCalBtn_Click;
            this.btnPlus.Enter += this.btn_Enter;
            this.btnThree.Click += this.btnCalBtn_Click;
            this.btnThree.Enter += this.btn_Enter;
            this.btnTwo.Click += this.btnCalBtn_Click;
            this.btnTwo.Enter += this.btn_Enter;
            this.btnOne.Click += this.btnCalBtn_Click;
            this.btnOne.Enter += this.btn_Enter;
            this.btnMinus.Click += this.btnCalBtn_Click;
            this.btnMinus.Enter += this.btn_Enter;
            this.btnSix.Click += this.btnCalBtn_Click;
            this.btnSix.Enter += this.btn_Enter;
            this.btnFive.Click += this.btnCalBtn_Click;
            this.btnFive.Enter += this.btn_Enter;
            this.btnFour.Click += this.btnCalBtn_Click;
            this.btnFour.Enter += this.btn_Enter;
            this.btnMulti.Click += this.btnCalBtn_Click;
            this.btnMulti.Enter += this.btn_Enter;
            this.btnNine.Click += this.btnCalBtn_Click;
            this.btnNine.Enter += this.btn_Enter;
            this.btnEight.Click += this.btnCalBtn_Click;
            this.btnEight.Enter += this.btn_Enter;
            this.btnSeven.Click += this.btnCalBtn_Click;
            this.btnSeven.Enter += this.btn_Enter;
            this.btnDivide.Click += this.btnCalBtn_Click;
            this.btnDivide.Enter += this.btn_Enter;
            this.btnGetRest.Click += this.btnCalBtn_Click;
            this.btnGetRest.Enter += this.btn_Enter;
            this.btnBackSpace.Click += this.btnCalBtn_Click;
            this.btnBackSpace.Enter += this.btn_Enter;
            this.btnClear.Click += this.btnCalBtn_Click;
            this.btnClear.Enter += this.btn_Enter;
            this.tbBackground.KeyPress += this.tbBackground_KeyPress;
            this.Enter += this.ucCalculator_Enter;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }
        public void SaveData(string sPathToSave)
        {
            try
            {
                m_modelOfCalculator.SaveData(sPathToSave);
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
                m_modelOfCalculator.LoadData(sPathToLoad);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        public string TextMainOperation
        {
            get
            {
                return tbMainOperation.Text;
            }
            set
            {
                tbMainOperation.Text = value;
            }
        }
        public int SelectionStart_TextMain
        {
            get
            {
                return tbMainOperation.SelectionStart;
            }
        }
        public int SelectionLength_TextMain
        {
            get
            {
                return tbMainOperation.SelectionLength;
            }
        }
        public string TextSelected_MainOperation
        {
            get
            {
                return tbMainOperation.SelectedText;
            }
        }
        public void SetFocusToControl()
        {
            try
            {
                tbBackground.Focus();
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        private void ucCalculator_Enter(object sender, EventArgs e)
        {
            try
            {
                tbBackground.Focus();
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnCalBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnSender = (Button)sender;

                btnClick_MainOperation(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        
        private void btn_Enter(object sender, EventArgs e)
        {
            try
            {
                tbBackground.Focus();
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void tbBackground_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                keyPress_MainOperation(sender, e);
                e.Handled = true;
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
                SaveData("../../Save/Calculator.txt");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
    }
}
