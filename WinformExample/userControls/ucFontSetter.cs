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
    public delegate void StringEventHandler(string sText);
    public partial class ucFontSetter : UserControl, iFontSettterPresenter
    {
        public ucFontSetter()
        {
            InitializeComponent();
            eventInitialize();

            ColumnHeader header = new ColumnHeader();
            header.Width = lvNodes.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            lvNodes.Columns.Add(header);

            model = new cModelOfFontSetter(this);
        }

        private void eventInitialize()
        {
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            this.btnAddRoot.Click += new System.EventHandler(this.btnAddRoot_Click);
            this.btnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click);
            this.btnMessageBox.Click += new System.EventHandler(this.btnMessageBox_Click);
            this.btnModaless.Click += new System.EventHandler(this.btnModaless_Click);
            this.btnModal.Click += new System.EventHandler(this.btnModal_Click);
            this.tkBarTest.Scroll += new System.EventHandler(this.tkBarTest_Scroll);
            this.cbItalicCheck.CheckedChanged += new System.EventHandler(this.italicCheck_CheckedChanged);
            this.cbBoldCheck.CheckedChanged += new System.EventHandler(this.boldCheck_CheckedChanged);
            this.cbxFontCombo.SelectedIndexChanged += new System.EventHandler(this.cbxFontCombo_SelectedIndexChanged);
            this.Load += new System.EventHandler(this.load);
        }

        private cModelOfFontSetter model;

        public event EventHandler initializeLoad;
        public event EventHandler boldCheck__CheckedChanged;
        public event EventHandler italicCheck__CheckedChanged;
        public event EventHandler btnAddRootClick;
        public event EventHandler btnAddChildClick;
        public event EventHandler btnDeleteNodeClick;
        public event EventHandler selectedFontChanged;
        public event EventHandler tkBarTestScroll;
        public event EventHandler btnModalClick;
        public event EventHandler btnModalessClick;

        public string TextFontCurrentName {
            get
            {
                return this.Font.Name;
            }
        }
        public string TextFontComboSelected {
            get
            {
                return (string)cbxFontCombo.SelectedItem;
            }
        }
        public int IndexFontComboSelected
        {
            get
            {
                return cbxFontCombo.SelectedIndex;
            }
            set
            {
                cbxFontCombo.SelectedIndex = value;
            }
        }
        public string TextBoxFontTest
        {
            get
            {
                return tbFontTest.Text;
            }
            set
            {
                tbFontTest.Text = value;
            }
        }
        public Font FontCurrent
        {
            get
            {
                return tbFontTest.Font;
            }
            set
            {
                tbFontTest.Font = value;
            }
        }
        public bool CheckedBold
        {
            get
            {
                return cbBoldCheck.Checked;
            }
            set
            {
                cbBoldCheck.Checked = value;
            }
        }
        public bool CheckedItalic
        {
            get
            {
                return cbItalicCheck.Checked;
            }
            set
            {
                cbItalicCheck.Checked = value;
            }
        }
        public int CountAllNodes
        {
            get
            {
                return tvNodes.GetNodeCount(true);
            }
        }
        public TreeNodeCollection TreeNodes_All
        {
            get
            {
                return tvNodes.Nodes;
            }
        }
        public TreeNode TreeNodeSelected
        {
            get
            {
                return tvNodes.SelectedNode;
            }
        }
        public int ValuePgbar
        {
            get
            {
                return pgbarTest.Value;
            }
            set
            {
                pgbarTest.Value = value;
            }
        }
        public int MaxValuePgbar
        {
            get
            {
                return pgbarTest.Maximum;
            }
        }
        public int ValueTkbar
        {
            get
            {
                return tkBarTest.Value;
            }
            set
            {
                tkBarTest.Value = value;
            }
        }
        public int MaxValueTkbar
        {
            get
            {
                return tkBarTest.Maximum;
            }
        }

        public void AddComboItem(string str)
        {
            cbxFontCombo.Items.Add(str);
        }
        public void AddLvNode(string sNodeText)
        {
            ListViewItem newItem = new ListViewItem(sNodeText);
            lvNodes.Items.Add(newItem);
        }
        public void AddTncTreeNode(string sNodeText)
        {
            tvNodes.Nodes.Add(sNodeText, sNodeText);
        }
        public TreeNode GetTreeNodeByString(string sNodeText)
        {
            TreeNode[] found = TreeNodes_All.Find(sNodeText, true);
            if(found.Count() == 0)
            {
                return null;
            }
            else
            {
                return found[0];
            }
        }
        public void ClearLvNode()
        {
            lvNodes.Clear();
        }
        // 초기화 로드
        private void load(object sender, EventArgs e)
        {
            if(initializeLoad == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Initialize event is null");
                throw new NullReferenceException("FontSetter - Initialize event is null");
            }
            
            initializeLoad(sender, e);
        }

        // 볼드체 체크
        private void boldCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (boldCheck__CheckedChanged == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Bold Checkbox Change Event is null");
                throw new NullReferenceException("FontSetter - Bold Checkbox Change Event is null");
            }

            boldCheck__CheckedChanged(sender, e);
        }

        // 이탤릭체 체크
        private void italicCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (italicCheck__CheckedChanged == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Italic Checkbox Change Event is null");
                throw new NullReferenceException("FontSetter - Italic Checkbox Change Event is null");
            }

            italicCheck__CheckedChanged(sender, e);
        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            if (btnAddRootClick == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Root Node Add Button Event is null");
                throw new NullReferenceException("FontSetter - Root Node Add Button Event is null");
            }

            btnAddRootClick(sender, e);
        }
        private void btnAddChild_Click(object sender, EventArgs e)
        {
            if (btnAddChildClick == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Child Node Add Button Event is null");
                throw new NullReferenceException("FontSetter - Child Node Add Button Event is null");
            }

            btnAddChildClick(sender, e);
        }

        private void cbxFontCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedFontChanged == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Font Change Event is null");
                throw new NullReferenceException("FontSetter - Font Change Event is null");
            }

            selectedFontChanged(sender, e);
        }

        private void tkBarTest_Scroll(object sender, EventArgs e)
        {
            if(tkBarTestScroll == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Trackbar Scroll Event is null");
                throw new NullReferenceException("FontSetter - Trackbar Scroll Event is null");
            }

            tkBarTestScroll(sender, e);
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            if(btnModalClick == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Modal Generate Button Event is null");
                throw new NullReferenceException("FontSetter - Modal Generate Button Event is null");
            }

            btnModalClick(sender, e);
        }

        private void btnModaless_Click(object sender, EventArgs e)
        {
            if (btnModalessClick == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "FontSetter - Modaless Generate Button Event is null");
                throw new NullReferenceException("FontSetter - Modaless Generate Button Event is null");
            }

            btnModalessClick(sender, e);
        }

        private void btnMessageBox_Click(object sender, EventArgs e)
        {
            cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Button Clicked : MessageBox UI");
            MessageBox.Show(tbFontTest.Text, "MessageBox Text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void SaveData(string sPathToSave)
        {
            model.SaveData(sPathToSave);
        }
        public void LoadData(string sPathToLoad)
        {
            model.LoadData(sPathToLoad);
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            btnDeleteNodeClick(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData("../../Save/FontSetter.txt");
        }
    }
}
