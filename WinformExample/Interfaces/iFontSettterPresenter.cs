using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WinformExample
{
    public interface iFontSettterPresenter : iPresenter
    {
        event EventHandler initializeLoad;
        event EventHandler boldCheck__CheckedChanged;
        event EventHandler italicCheck__CheckedChanged;
        event EventHandler btnAddRootClick;
        event EventHandler btnAddChildClick;
        event EventHandler btnDeleteNodeClick;
        event EventHandler selectedFontChanged;
        event EventHandler tkBarTestScroll;
        event EventHandler btnModalClick;
        event EventHandler btnModalessClick;

        Font FontCurrent { get; set; }
        string TextFontCurrentName { get; }
        string TextFontComboSelected { get; }
        string TextBoxFontTest { get; set; }
        bool CheckedBold { get; set; }
        bool CheckedItalic { get; set; }
        int IndexFontComboSelected { get; set; }
        int CountAllNodes { get; }
        int ValuePgbar { get; set; }
        int ValueTkbar { get; set; }
        int MaxValuePgbar { get; }
        int MaxValueTkbar { get; }
        TreeNodeCollection TreeNodes_All { get; }
        TreeNode TreeNodeSelected { get; }
        TreeNode GetTreeNodeByString(string sNodeText);
        void AddComboItem(string str);
        void AddLvNode(string sNodeText);
        void AddTncTreeNode(string sNodeText);
        void ClearLvNode();
    }
}
