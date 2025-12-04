using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinformExample
{
    public class cModelOfLogViewer
    {
        private iLogViewerPresenter m_LogViewerPresenter;

        private string m_sFullPath; // 현재 파일의 절대경로
        private List<string> m_sListLines = new List<string>(); // 모든 로그의 줄
        public cModelOfLogViewer(iLogViewerPresenter presenter)
        {
            try
            {
                m_LogViewerPresenter = presenter;
                m_LogViewerPresenter.fileSystemWatcherChanged += FileSystemWatcher_Changed;
                m_LogViewerPresenter.btnAddFilterClick += BtnAddFilter_Click;
                m_LogViewerPresenter.btnDeleteFilterClick += BtnDeleteFilter_Click;
                m_LogViewerPresenter.btnOpenFileClick += BtnOpenFile_Click;
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
                Stream stream = new FileStream(sPathToSave, FileMode.OpenOrCreate);
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    int nFilterCount = m_LogViewerPresenter.FiltersItemsOfListView.Count;
                    writer.Write(nFilterCount);
                    foreach(ListViewItem filterItem in m_LogViewerPresenter.FiltersItemsOfListView)
                    {
                        writer.Write(filterItem.Text);
                    }
                }

                cLogger.Instance.AddLog(eLogType.SYSTEM, $"LogViewer - Saved");
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
                    int nFilterCount = reader.ReadInt32();
                    for(int i = 0; i < nFilterCount; i++)
                    {
                        string sNewFilter = reader.ReadString();
                        m_LogViewerPresenter.FiltersItemsOfListView.Add(sNewFilter);
                    }
                }
                // 로그 오픈
                OpenLog("..\\..\\app.log");
                cLogger.Instance.AddLog(eLogType.SYSTEM, $"LogViewer - Loaded");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void OpenLog(string sFilePath)
        {
            IEnumerable<string> sEnumerableLines = File.ReadLines(sFilePath, Encoding.UTF8);

            string sDirectoryPath = Path.GetFullPath(sFilePath);

            m_LogViewerPresenter.MainTextBox.Clear(); // 현 텍스트 UI 초기화
            m_sListLines.Clear(); // 현 로그들 초기화

            // 가져온 파일의 로그들 할당
            foreach (string sLine in sEnumerableLines)
            {
                m_sListLines.Add(sLine);
            }

            // 로그들을 필터링
            List<string> sListFilteredLines = FilterStringList(m_sListLines);
            // 필터된 로그들을 UI에 표현
            foreach (string sLine in sListFilteredLines)
            {
                m_LogViewerPresenter.MainTextBox.Text += sLine + "\n";
            }
            m_sFullPath = sDirectoryPath;
            m_LogViewerPresenter.PathOfFileSystemWatcher = m_sFullPath.Substring(0, sDirectoryPath.LastIndexOf('\\')); // 파일의 이름 제외한 디렉터리 경로만 가져오기
            m_LogViewerPresenter.FileTitleLabel = Path.GetFileNameWithoutExtension(m_sFullPath); // 제목(파일 이름) 표시
        }

        // fileSystemWatcher가 해당 파일이 발견됬는지 확인
        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                // 해당 파일만 검사하기 위해 타 파일 거르기
                if (e.FullPath == m_sFullPath)
                {
                    // 파일로부터 로그들 가져오기
                    IEnumerable<string> sEnumerableLines = File.ReadLines(m_sFullPath, Encoding.UTF8);
                    // 만약 파일의 로그가 추가었다면
                    if (sEnumerableLines.Count() > m_sListLines.Count)
                    {
                        List<string> sListLines = new List<string>();

                        // 추가된 로그 가져오기
                        for (int i = 0; i < sEnumerableLines.Count() - m_sListLines.Count; i++)
                        {
                            sListLines.Add(sEnumerableLines.ElementAt(m_sListLines.Count() + i));
                        }

                        // 로그를 프로그램에 추가
                        foreach (string arrLine in sListLines)
                        {
                            m_sListLines.Add(arrLine);
                        }
                        // 추가할 로그를 필터링
                        List<string> sListAddFiltedLines = FilterStringList(sListLines);

                        // 추가할 필터된 로그들을 표현
                        foreach (string sNewLine in sListAddFiltedLines)
                        {
                            m_LogViewerPresenter.MainTextBox.AppendText(sNewLine + "\n");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dl = new OpenFileDialog();
                dl.InitialDirectory = "c:\\";
                dl.Filter = "txt files (*.txt)|*.txt;*.log|All files (*.*)|*.*";
                dl.FilterIndex = 1;
                dl.RestoreDirectory = true;
                if (dl.ShowDialog() == DialogResult.OK)
                {
                    cLogger.Instance.AddLog(eLogType.SYSTEM, $"LogViewer - File Opened. Path : {dl.FileName}");

                    OpenLog(dl.FileName);
                }
                else
                {
                    cLogger.Instance.AddLog(eLogType.SYSTEM, $"LogViewer - File Opening Canceled.");
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void InitializeWithFilter()
        {
            List<string> listFiltered = FilterStringList(m_sListLines);

            // inter.MainTextBox.Clear();
            m_LogViewerPresenter.MainTextBox.SuspendLayout();

            StringBuilder sb = new StringBuilder(1024 * 1024);

            foreach (string sLine in listFiltered)
            {
                sb.AppendLine(sLine);
                // inter.MainTextBox.Text += sLine + "\n";
            }

            m_LogViewerPresenter.MainTextBox.Text = sb.ToString();

            m_LogViewerPresenter.MainTextBox.ResumeLayout();
        }

        private void BtnAddFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(m_LogViewerPresenter.InputTextToAddFilter))
                {
                    m_LogViewerPresenter.FiltersItemsOfListView.Add(m_LogViewerPresenter.InputTextToAddFilter);
                    m_LogViewerPresenter.ClearInputTextToAddFilter();

                    InitializeWithFilter();
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void BtnDeleteFilter_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection selectedItems = m_LogViewerPresenter.lvFiltersSelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    m_LogViewerPresenter.FiltersItemsOfListView.Remove(item);
                }
                InitializeWithFilter();
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        // 필터 함수 - 걸러진 목록을 리턴값으로
        private List<string> FilterStringList(List<string> sList)
        {
            HashSet<string> listFilters = new HashSet<string>();
            List<string> listResult = new List<string>();

            foreach (ListViewItem perItem in m_LogViewerPresenter.FiltersItemsOfListView)
            {
                listFilters.Add(perItem.Text);
            }
            foreach(string sLine in sList)
            {
                bool bPass = true;

                foreach(string filter in listFilters)
                {
                    if(sLine.Contains(filter))
                    {
                        bPass = false;
                        break;
                    }
                }

                if (bPass)
                    listResult.Add(sLine);
            }

            return listResult;
        }

    }
}
