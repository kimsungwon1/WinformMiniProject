using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinformExample
{
    public interface iLogViewerPresenter : iPresenter
    {
        event FileSystemEventHandler fileSystemWatcherChanged;
        event EventHandler btnOpenFileClick;
        event EventHandler btnAddFilterClick;
        event EventHandler btnDeleteFilterClick;

        RichTextBox MainTextBox { get; }
        ListView.ListViewItemCollection FiltersItemsOfListView { get; }
        ListView.SelectedListViewItemCollection lvFiltersSelectedItems { get; }
        string PathOfFileSystemWatcher { set; }
        string FileTitleLabel { set; }
        string InputTextToAddFilter { get; }
        void ClearInputTextToAddFilter();
    }
}
