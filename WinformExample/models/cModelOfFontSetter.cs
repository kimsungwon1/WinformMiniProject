using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace WinformExample
{
    public class cModelOfFontSetter
    {
        private iFontSettterPresenter m_FontSetterPresenter;
        // 트리 뷰에 노드로 할당할 랜덤 아이디.
        private readonly Random randomNodeID;

        public cModelOfFontSetter(iFontSettterPresenter presenter)
        {
            m_FontSetterPresenter = presenter;
            randomNodeID = new Random();

            m_FontSetterPresenter.initializeLoad += LoadInitialize;
            m_FontSetterPresenter.boldCheck__CheckedChanged += BoldCheck_CheckedChanged;
            m_FontSetterPresenter.btnAddChildClick += BtnAddChild_Click;
            m_FontSetterPresenter.btnAddRootClick += BtnAddRoot_Click;
            m_FontSetterPresenter.btnDeleteNodeClick += BtnDeleteNode_Click;
            m_FontSetterPresenter.btnModalClick += BtnModal_Click;
            m_FontSetterPresenter.btnModalessClick += BtnModaless_Click;
            m_FontSetterPresenter.italicCheck__CheckedChanged += ItalicCheck_CheckedChanged;
            m_FontSetterPresenter.selectedFontChanged += SelectFontCombo;
            m_FontSetterPresenter.tkBarTestScroll += TkBarTest_Scroll;
        }

        public void SaveData(string sPathToSave)
        {
            try
            {
                Stream stream = new FileStream(sPathToSave, FileMode.OpenOrCreate);
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(m_FontSetterPresenter.TextFontComboSelected);
                    writer.Write(m_FontSetterPresenter.CheckedBold);
                    writer.Write(m_FontSetterPresenter.CheckedItalic);
                    writer.Write(m_FontSetterPresenter.TextBoxFontTest);
                    writer.Write(m_FontSetterPresenter.ValueTkbar);
                    writer.Write(m_FontSetterPresenter.CountAllNodes);
                    foreach (TreeNode node in m_FontSetterPresenter.TreeNodes_All)
                    {
                        SaveNodeFromTree(writer, node, null);
                    }
                }

                cLogger.Instance.AddLog(eLogType.SYSTEM, $"FontSetter - Saved");
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
                Stream stream = new FileStream(sPathToLoad, FileMode.OpenOrCreate);
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    string sFontText = reader.ReadString();
                    SetFontIndexFromString(sFontText);
                    m_FontSetterPresenter.CheckedBold = reader.ReadBoolean();
                    m_FontSetterPresenter.CheckedItalic = reader.ReadBoolean();
                    m_FontSetterPresenter.TextBoxFontTest = reader.ReadString();
                    m_FontSetterPresenter.ValueTkbar = reader.ReadInt32();
                    int nNodeCount = reader.ReadInt32();
                    // TreeNode 불러오기
                    for(int i = 0; i < nNodeCount; i++)
                    {
                        LoadNode(reader);
                    }
                    SendToListFromTree();
                    TkBarTest_Scroll(null, null);
                }

                cLogger.Instance.AddLog(eLogType.SYSTEM, $"FontSetter - Loaded");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        private void SaveNodeFromTree(BinaryWriter writer, TreeNode node, TreeNode father)
        {
            writer.Write(node.Text);
            string sFather;
            if (father == null)
            {
                sFather = "null";
            }
            else
            {
                sFather = father.Text;
            }
            writer.Write(sFather);
            foreach (TreeNode child in node.Nodes)
            {
                SaveNodeFromTree(writer, child, node);
            }
        }
        private void LoadNode(BinaryReader reader)
        {
            string sNodeText = reader.ReadString();
            string sFather = reader.ReadString();
            if (sFather == "null")
            {
                m_FontSetterPresenter.AddTncTreeNode(sNodeText);
                SendToListFromTree();
            }
            else
            {
                TreeNode tnFatherNode = m_FontSetterPresenter.GetTreeNodeByString(sFather);
                if (tnFatherNode != null)
                {
                    tnFatherNode.Nodes.Add(sNodeText, sNodeText);
                    tnFatherNode.Expand();
                }
            }
        }
        private void SetFontIndexFromString(string sText)
        {
            int index = 0;
            FontFamily[] arrFonts = FontFamily.Families;
            foreach (FontFamily font in arrFonts)
            {
                m_FontSetterPresenter.AddComboItem(font.Name);

                if (sText == font.Name)
                {
                    m_FontSetterPresenter.IndexFontComboSelected = index;
                }
                index++;
            }
        }

        // 초기화 로드
        private void LoadInitialize(object sender, EventArgs e)
        {
            try
            {
                string currentFontName = "";
                
                currentFontName = m_FontSetterPresenter.TextFontCurrentName;

                int index = 0;
                FontFamily[] arrFonts = FontFamily.Families;
                foreach (FontFamily font in arrFonts)
                {
                    m_FontSetterPresenter.AddComboItem(font.Name);

                    if (currentFontName == font.Name)
                    {
                        m_FontSetterPresenter.IndexFontComboSelected = index;
                    }
                    index++;
                }

                cLogger.Instance.AddLog(eLogType.SYSTEM, $"FontSetter - Initialized");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        // 볼드체 체크
        private void BoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FontStyle fontStyle = m_FontSetterPresenter.FontCurrent.Style;
                string sFontName = m_FontSetterPresenter.FontCurrent.SystemFontName;

                // 볼드체 빼기/더하기
                fontStyle ^= FontStyle.Bold;
                
                // 만약 폰트 선택박스에서 선택된게 있으면
                if (m_FontSetterPresenter.IndexFontComboSelected >= 0)
                {
                    // 폰트타입 할당
                    sFontName = m_FontSetterPresenter.TextFontComboSelected;// (string)cbxFontCombo.SelectedItem;
                }

                m_FontSetterPresenter.FontCurrent = new Font(sFontName, 8, fontStyle);

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Bold Checked {m_FontSetterPresenter.CheckedBold}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        // 이탤릭체 체크
        private void ItalicCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FontStyle fontStyle = m_FontSetterPresenter.FontCurrent.Style;
                string sFontName = m_FontSetterPresenter.FontCurrent.SystemFontName;
                
                // 이탤릭 빼기/더하기
                fontStyle ^= FontStyle.Italic;

                if (m_FontSetterPresenter.IndexFontComboSelected >= 0)
                {
                    sFontName = m_FontSetterPresenter.TextFontComboSelected;
                }

                m_FontSetterPresenter.FontCurrent = new Font(sFontName, m_FontSetterPresenter.FontCurrent.SizeInPoints, fontStyle);

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Italic Checked {m_FontSetterPresenter.CheckedItalic}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void SendToListFromTree()
        {
            m_FontSetterPresenter.ClearLvNode();
            foreach (TreeNode node in m_FontSetterPresenter.TreeNodes_All)
                SendToListFromTree(node);
        }

        private void SendToListFromTree(TreeNode Node)
        {
            string sMiddleStr = " - depth : ";
            m_FontSetterPresenter.AddLvNode(Node.Text + sMiddleStr + Node.FullPath.Count(f => f == '\\').ToString());

            foreach (TreeNode node in Node.Nodes)
            {
                SendToListFromTree(node);
            }
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            try
            {
                string sNewNode = randomNodeID.Next().ToString();
                m_FontSetterPresenter.AddTncTreeNode(sNewNode);
                SendToListFromTree();

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Root Node Added : {sNewNode}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_FontSetterPresenter.TreeNodeSelected == null)
                {
                    MessageBox.Show("노드를 선택하세요.", "TreeView Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sNewNode = randomNodeID.Next().ToString();
                m_FontSetterPresenter.TreeNodeSelected.Nodes.Add(sNewNode);
                m_FontSetterPresenter.TreeNodeSelected.Expand();
                SendToListFromTree();

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Child Node Added : {sNewNode}, Parent : {m_FontSetterPresenter.TreeNodeSelected.Text}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void SendLogWithDeletingNodes(TreeNode node)
        {
            foreach(TreeNode childNode in node.Nodes)
            {
                SendLogWithDeletingNodes(childNode);
            }

            cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Tree Node <{node.Text}> deleted");
        }

        private void BtnDeleteNode_Click(object sender, EventArgs e)
        {
            try
            {
                if(m_FontSetterPresenter.TreeNodeSelected == null)
                {
                    MessageBox.Show("노드를 선택하세요.", "TreeView Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SendLogWithDeletingNodes(m_FontSetterPresenter.TreeNodeSelected);
                m_FontSetterPresenter.TreeNodes_All.Remove(m_FontSetterPresenter.TreeNodeSelected);
                SendToListFromTree();
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void SelectFontCombo(object sender, EventArgs e)
        {
            try
            {
                if (m_FontSetterPresenter.IndexFontComboSelected < 0)
                {
                    return;
                }

                m_FontSetterPresenter.FontCurrent = new Font(m_FontSetterPresenter.TextFontComboSelected, 8, m_FontSetterPresenter.FontCurrent.Style);

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Font Selected : {m_FontSetterPresenter.TextFontComboSelected}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void TkBarTest_Scroll(object sender, EventArgs e)
        {
            try
            {
                m_FontSetterPresenter.ValuePgbar = (int)((double)m_FontSetterPresenter.ValueTkbar / m_FontSetterPresenter.MaxValueTkbar * m_FontSetterPresenter.MaxValuePgbar);

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - TrackBar Scrolled : {m_FontSetterPresenter.ValueTkbar}, ProgressBar Value : {m_FontSetterPresenter.ValuePgbar}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = new Form();
                frm.Text = "Modal Form";
                frm.Width = 300;
                frm.Height = 100;
                frm.BackColor = Color.Red;
                frm.ShowDialog();

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Button Clicked : Modal UI");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = new Form();
                frm.Text = "Modaless Form";
                frm.Width = 300;
                frm.Height = 300;
                frm.BackColor = Color.Green;
                frm.Show();

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Button Clicked : Modaless UI");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
    }
}
