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
            try
            {
                InitializeComponent();
                EventInitialize();
                m_modelOfLogViewer = new cModelOfLogViewer(this);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void EventInitialize()
        {
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            this.tbMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMain_KeyPress);
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            this.btnDeleteFilter.Click += new System.EventHandler(this.btnDeleteFilter_Click);
            this.tbFilterInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        private cModelOfLogViewer m_modelOfLogViewer;

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
            try
            {
                fileSystemWatcherChanged(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                btnOpenFileClick(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddFilterClick(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            try
            {
                btnDeleteFilterClick(sender, e);
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void tbMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    btnAddFilterClick(sender, e);
                    e.Handled = true;
                }
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
                m_modelOfLogViewer.SaveData(sPathToSave);
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
                m_modelOfLogViewer.LoadData(sPathToLoad);
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
                SaveData("../../Save/LogViewer.txt");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
    }
}
