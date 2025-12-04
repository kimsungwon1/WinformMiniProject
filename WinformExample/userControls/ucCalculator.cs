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
        private cModelOfCalculator model;

        public event EventHandler btnClick_MainOperation;
        public event KeyPressEventHandler keyPress_MainOperation;

        public ucCalculator()
        {
            InitializeComponent();
            eventInitialize();
            model = new cModelOfCalculator(this);
        }

        private void eventInitialize()
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
        }
        public void SaveData(string sPathToSave)
        {
            model.SaveData(sPathToSave);
        }
        public void LoadData(string sPathToLoad)
        {
            model.LoadData(sPathToLoad);
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
            tbBackground.Focus();
        }
        private void ucCalculator_Enter(object sender, EventArgs e)
        {
            tbBackground.Focus();
        }

        private void btnCalBtn_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            if(btnClick_MainOperation == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "Calculator - Calculate Button Event is null");
                throw new NullReferenceException("Calculator - Calculate Button Event is null");
            }

            btnClick_MainOperation(sender, e);
        }
        
        private void btn_Enter(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            tbBackground.Focus();
        }

        private void tbBackground_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnClick_MainOperation == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "Calculator - Key Input Event is null");
                throw new NullReferenceException("Calculator - Key Input Event is null");
            }

            keyPress_MainOperation(sender, e);
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData("../../Save/Calculator.txt");
        }
    }
}
