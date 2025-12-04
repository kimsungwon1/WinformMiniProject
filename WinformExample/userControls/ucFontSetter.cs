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
            try
            {
                InitializeComponent();
                EventInitialize();

                ColumnHeader header = new ColumnHeader();
                header.Width = lvNodes.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
                lvNodes.Columns.Add(header);

                m_ModelOfFontSetter = new cModelOfFontSetter(this);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void EventInitialize()
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
            this.Load += new System.EventHandler(this.Load_Initialize);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        private cModelOfFontSetter m_ModelOfFontSetter;

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
            try
            {
                cbxFontCombo.Items.Add(str);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        public void AddLvNode(string sNodeText)
        {
            try
            {
                ListViewItem newItem = new ListViewItem(sNodeText);
                lvNodes.Items.Add(newItem);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        public void AddTncTreeNode(string sNodeText)
        {
            try
            {
                tvNodes.Nodes.Add(sNodeText, sNodeText);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        public TreeNode GetTreeNodeByString(string sNodeText)
        {
            try
            {
                TreeNode[] found = TreeNodes_All.Find(sNodeText, true);
                if (found.Count() == 0)
                {
                    return null;
                }
                else
                {
                    return found[0];
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
                return null;
            }
        }
        public void ClearLvNode()
        {
            try
            {
                lvNodes.Clear();
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        // 초기화 로드
        private void Load_Initialize(object sender, EventArgs e)
        {
            try
            {
                initializeLoad(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        // 볼드체 체크
        private void boldCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                boldCheck__CheckedChanged(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        // 이탤릭체 체크
        private void italicCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                italicCheck__CheckedChanged(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddRootClick(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        private void btnAddChild_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddChildClick(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void cbxFontCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedFontChanged(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void tkBarTest_Scroll(object sender, EventArgs e)
        {
            try
            {
                tkBarTestScroll(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            try
            {
                btnModalClick(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnModaless_Click(object sender, EventArgs e)
        {
            try
            {
                btnModalessClick(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnMessageBox_Click(object sender, EventArgs e)
        {
            try
            {
                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Button Clicked : MessageBox UI");
                MessageBox.Show(tbFontTest.Text, "MessageBox Text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                m_ModelOfFontSetter.SaveData(sPathToSave);
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
                m_ModelOfFontSetter.LoadData(sPathToLoad);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            try
            {
                btnDeleteNodeClick(sender, e);
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
                SaveData("../../Save/FontSetter.txt");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
    }
}
