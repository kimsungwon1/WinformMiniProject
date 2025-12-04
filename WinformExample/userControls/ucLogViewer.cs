using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinformExample
{
    public partial class ucLogViewer : UserControl, iLogViewerPresenter
    {
        public ucLogViewer()
        {
            InitializeComponent();
            eventInitialize();
            model = new cModelOfLogViewer(this);


        }
        private void eventInitialize()
        {
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            this.tbMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMain_KeyPress);
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            this.btnDeleteFilter.Click += new System.EventHandler(this.btnDeleteFilter_Click);
            this.tbFilterInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        private cModelOfLogViewer model;

        public event FileSystemEventHandler fileSystemWatcherChanged;
        public event EventHandler btnOpenFileClick;
        public event EventHandler btnAddFilterClick;
        public event EventHandler btnDeleteFilterClick;
        
        public RichTextBox MainTextBox
        {
            get
            {
                return tbMain;
            }
        }
        public ListView.ListViewItemCollection FiltersItemsOfListView
        {
            get
            {
                return lvFilters.Items;
            }
        }
        public ListView.SelectedListViewItemCollection lvFiltersSelectedItems
        {
            get
            {
                return lvFilters.SelectedItems;
            }
        }
        public string PathOfFileSystemWatcher
        {
            set
            {
                fileSystemWatcher.Path = value;
            }
        }
        public string FileTitleLabel
        {
            set
            {
                lbFileTitle.Text = value;
            }
        }
        public string InputTextToAddFilter
        {
            get
            {
                return tbFilterInput.Text;
            }
        }
        public void ClearInputTextToAddFilter()
        {
            tbFilterInput.Clear();
        }

        // fileSystemWatcher가 해당 파일이 발견됬는지 확인
        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (fileSystemWatcherChanged == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "LogViewer - FileSystem Change Event is null");
                throw new NullReferenceException("LogViewer - FileSystem Change Event is null");
            }
            fileSystemWatcherChanged(sender, e);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (btnOpenFileClick == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "LogViewer - File Open Button Event is null");
                throw new NullReferenceException("LogViewer - File Button Event is null");
            }

            btnOpenFileClick(sender, e);
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            if (btnAddFilterClick == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "LogViewer - Filter Add Button Event is null");
                throw new NullReferenceException("LogViewer - Filter Add Button Event is null");
            }

            btnAddFilterClick(sender, e);
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            if (btnDeleteFilterClick == null)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, "LogViewer - Filter Delete Button Event is null");
                throw new NullReferenceException("LogViewer - Filter Delete Button Event is null");
            }

            btnDeleteFilterClick(sender, e);
        }

        private void tbMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                if (btnAddFilterClick == null)
                {
                    cLogger.Instance.AddLog(eLogType.ERROR, "LogViewer - Filter Add Button Event is null");
                    throw new NullReferenceException("LogViewer - Filter Add Button Event is null");
                }
                btnAddFilterClick(sender, e);
                e.Handled = true;
            }
        }
        public void SaveData(string sPathToSave)
        {
            model.SaveData(sPathToSave);
        }
        public void LoadData(string sPathToLoad)
        {
            model.LoadData(sPathToLoad);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData("../../Save/LogViewer.txt");
        }
    }
}
