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
        private iFontSettterPresenter inter;
        // 트리 뷰에 노드로 할당할 랜덤 아이디.
        private readonly Random randomNodeID;

        public cModelOfFontSetter(iFontSettterPresenter presenter)
        {
            inter = presenter;
            randomNodeID = new Random();

            inter.initializeLoad += loadInitialize;
            inter.boldCheck__CheckedChanged += boldCheck_CheckedChanged;
            inter.btnAddChildClick += btnAddChild_Click;
            inter.btnAddRootClick += btnAddRoot_Click;
            inter.btnDeleteNodeClick += btnDeleteNode_Click;
            inter.btnModalClick += btnModal_Click;
            inter.btnModalessClick += btnModaless_Click;
            inter.italicCheck__CheckedChanged += italicCheck_CheckedChanged;
            inter.selectedFontChanged += selectFontCombo;
            inter.tkBarTestScroll += tkBarTest_Scroll;
        }

        public void SaveData(string sPathToSave)
        {
            try
            {
                Stream stream = new FileStream(sPathToSave, FileMode.OpenOrCreate);
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(inter.TextFontComboSelected);
                    writer.Write(inter.CheckedBold);
                    writer.Write(inter.CheckedItalic);
                    writer.Write(inter.TextBoxFontTest);
                    writer.Write(inter.ValueTkbar);
                    writer.Write(inter.CountAllNodes);
                    foreach (TreeNode node in inter.TreeNodes_All)
                    {
                        saveNodeFromTree(writer, node, null);
                    }
                }

                cLogger.Instance.AddLog(eLogType.SYSTEM, $"FontSetter - Saved");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
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
                    inter.CheckedBold = reader.ReadBoolean();
                    inter.CheckedItalic = reader.ReadBoolean();
                    inter.TextBoxFontTest = reader.ReadString();
                    inter.ValueTkbar = reader.ReadInt32();
                    int nNodeCount = reader.ReadInt32();
                    // TreeNode 불러오기
                    for(int i = 0; i < nNodeCount; i++)
                    {
                        loadNode(reader);
                    }
                    sendToListFromTree();
                    tkBarTest_Scroll(null, null);
                }

                cLogger.Instance.AddLog(eLogType.SYSTEM, $"FontSetter - Loaded");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }
        private void saveNodeFromTree(BinaryWriter writer, TreeNode node, TreeNode father)
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
                saveNodeFromTree(writer, child, node);
            }
        }
        private void loadNode(BinaryReader reader)
        {
            string sNodeText = reader.ReadString();
            string sFather = reader.ReadString();
            if (sFather == "null")
            {
                inter.AddTncTreeNode(sNodeText);
                sendToListFromTree();
            }
            else
            {
                TreeNode tnFatherNode = inter.GetTreeNodeByString(sFather);
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
                inter.AddComboItem(font.Name);

                if (sText == font.Name)
                {
                    inter.IndexFontComboSelected = index;
                }
                index++;
            }
        }

        // 초기화 로드
        private void loadInitialize(object sender, EventArgs e)
        {
            try
            {
                string currentFontName = "";
                
                currentFontName = inter.TextFontCurrentName;

                int index = 0;
                FontFamily[] arrFonts = FontFamily.Families;
                foreach (FontFamily font in arrFonts)
                {
                    inter.AddComboItem(font.Name);

                    if (currentFontName == font.Name)
                    {
                        inter.IndexFontComboSelected = index;
                    }
                    index++;
                }

                cLogger.Instance.AddLog(eLogType.SYSTEM, $"FontSetter - Initialized");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        // 볼드체 체크
        private void boldCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FontStyle fontStyle = inter.FontCurrent.Style;
                string sFontName = inter.FontCurrent.SystemFontName;

                if (inter.CheckedBold)
                {
                    // 볼드체 할당
                    fontStyle |= FontStyle.Bold;
                }
                else
                {
                    // 볼드체 빼기
                    fontStyle ^= FontStyle.Bold;
                }
                // 만약 폰트 선택박스에서 선택된게 있으면
                if (inter.IndexFontComboSelected >= 0)
                {
                    // 폰트타입 할당
                    sFontName = inter.TextFontComboSelected;// (string)cbxFontCombo.SelectedItem;
                }

                inter.FontCurrent = new Font(sFontName, 8, fontStyle);

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Bold Checked {inter.CheckedBold}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        // 이탤릭체 체크
        private void italicCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FontStyle fontStyle = inter.FontCurrent.Style;
                string sFontName = inter.FontCurrent.SystemFontName;

                if (inter.CheckedItalic)
                {
                    // 이탤릭 할당
                    fontStyle |= FontStyle.Italic;
                }
                else
                {
                    // 이탤릭 빼기
                    fontStyle ^= FontStyle.Italic;
                }


                if (inter.IndexFontComboSelected >= 0)
                {
                    sFontName = inter.TextFontComboSelected;
                }

                inter.FontCurrent = new Font(sFontName, inter.FontCurrent.SizeInPoints, fontStyle);

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Italic Checked {inter.CheckedItalic}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void sendToListFromTree()
        {
            inter.ClearLvNode();
            foreach (TreeNode node in inter.TreeNodes_All)
                sendToListFromTree(node);
        }

        private void sendToListFromTree(TreeNode Node)
        {
            string sMiddleStr = " - depth : ";
            inter.AddLvNode(Node.Text + sMiddleStr + Node.FullPath.Count(f => f == '\\').ToString());

            foreach (TreeNode node in Node.Nodes)
            {
                sendToListFromTree(node);
            }
        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            try
            {
                string sNewNode = randomNodeID.Next().ToString();
                inter.AddTncTreeNode(sNewNode);
                sendToListFromTree();

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Root Node Added : {sNewNode}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }
        private void btnAddChild_Click(object sender, EventArgs e)
        {
            try
            {
                if (inter.TreeNodeSelected == null)
                {
                    MessageBox.Show("노드를 선택하세요.", "TreeView Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sNewNode = randomNodeID.Next().ToString();
                inter.TreeNodeSelected.Nodes.Add(sNewNode);
                inter.TreeNodeSelected.Expand();
                sendToListFromTree();

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Child Node Added : {sNewNode}, Parent : {inter.TreeNodeSelected.Text}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void sendLogWithDeletingNodes(TreeNode node)
        {
            foreach(TreeNode childNode in node.Nodes)
            {
                sendLogWithDeletingNodes(childNode);
            }

            cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Tree Node <{node.Text}> deleted");
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            try
            {
                if(inter.TreeNodeSelected == null)
                {
                    MessageBox.Show("노드를 선택하세요.", "TreeView Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                sendLogWithDeletingNodes(inter.TreeNodeSelected);
                inter.TreeNodes_All.Remove(inter.TreeNodeSelected);
                sendToListFromTree();
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void selectFontCombo(object sender, EventArgs e)
        {
            try
            {
                if (inter.IndexFontComboSelected < 0)
                {
                    return;
                }

                inter.FontCurrent = new Font(inter.TextFontComboSelected, 8, inter.FontCurrent.Style);

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - Font Selected : {inter.TextFontComboSelected}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void tkBarTest_Scroll(object sender, EventArgs e)
        {
            try
            {
                inter.ValuePgbar = (int)((double)inter.ValueTkbar / inter.MaxValueTkbar * inter.MaxValuePgbar);

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"FontSetter - TrackBar Scrolled : {inter.ValueTkbar}, ProgressBar Value : {inter.ValuePgbar}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void btnModal_Click(object sender, EventArgs e)
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
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void btnModaless_Click(object sender, EventArgs e)
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
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }
    }
}
