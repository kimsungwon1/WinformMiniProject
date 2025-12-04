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
        private iLogViewerPresenter inter;

        private string m_sFullPath; // 현재 파일의 절대경로
        private List<string> m_sListLines = new List<string>(); // 모든 로그의 줄
        public cModelOfLogViewer(iLogViewerPresenter presenter)
        {
            inter = presenter;
            inter.fileSystemWatcherChanged += fileSystemWatcher_Changed;
            inter.btnAddFilterClick += btnAddFilter_Click;
            inter.btnDeleteFilterClick += btnDeleteFilter_Click;
            inter.btnOpenFileClick += btnOpenFile_Click;
        }

        public void SaveData(string sPathToSave)
        {
            try
            {
                Stream stream = new FileStream(sPathToSave, FileMode.OpenOrCreate);
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    int nFilterCount = inter.FiltersItemsOfListView.Count;
                    writer.Write(nFilterCount);
                    foreach(ListViewItem filter in inter.FiltersItemsOfListView)
                    {
                        writer.Write(filter.Text);
                    }
                }

                cLogger.Instance.AddLog(eLogType.SYSTEM, $"LogViewer - Saved");
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
                    int nFilterCount = reader.ReadInt32();
                    for(int i = 0; i < nFilterCount; i++)
                    {
                        string sNewFilter = reader.ReadString();
                        inter.FiltersItemsOfListView.Add(sNewFilter);
                    }
                }
                // 로그 오픈
                openLog("..\\..\\app.log");
                cLogger.Instance.AddLog(eLogType.SYSTEM, $"LogViewer - Loaded");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void openLog(string sFilePath)
        {
            IEnumerable<string> sEnumerableLines = File.ReadLines(sFilePath, Encoding.UTF8);

            string sDirectoryPath = Path.GetFullPath(sFilePath);

            inter.MainTextBox.Clear(); // 현 텍스트 UI 초기화
            m_sListLines.Clear(); // 현 로그들 초기화

            // 가져온 파일의 로그들 할당
            foreach (string sLine in sEnumerableLines)
            {
                m_sListLines.Add(sLine);
            }

            // 로그들을 필터링
            List<string> sListFilteredLines = filterStringList(m_sListLines);
            // 필터된 로그들을 UI에 표현
            foreach (string sLine in sListFilteredLines)
            {
                inter.MainTextBox.Text += sLine + "\n";
            }
            m_sFullPath = sDirectoryPath;
            inter.PathOfFileSystemWatcher = m_sFullPath.Substring(0, sDirectoryPath.LastIndexOf('\\')); // 파일의 이름 제외한 디렉터리 경로만 가져오기
            inter.FileTitleLabel = Path.GetFileNameWithoutExtension(m_sFullPath); // 제목(파일 이름) 표시
        }

        // fileSystemWatcher가 해당 파일이 발견됬는지 확인
        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
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
                        List<string> sListAddFiltedLines = filterStringList(sListLines);

                        // 추가할 필터된 로그들을 표현
                        foreach (string sNewLine in sListAddFiltedLines)
                        {
                            inter.MainTextBox.AppendText(sNewLine + "\n");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
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

                    openLog(dl.FileName);
                }
                else
                {
                    cLogger.Instance.AddLog(eLogType.SYSTEM, $"LogViewer - File Opening Canceled.");
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void initializeWithFilter()
        {
            List<string> listFiltered = filterStringList(m_sListLines);

            inter.MainTextBox.Clear();
            foreach (string sLine in listFiltered)
            {
                inter.MainTextBox.Text += sLine + "\n";
            }
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(inter.InputTextToAddFilter))
                {
                    inter.FiltersItemsOfListView.Add(inter.InputTextToAddFilter);
                    inter.ClearInputTextToAddFilter();

                    initializeWithFilter();
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection selectedItems = inter.lvFiltersSelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    inter.FiltersItemsOfListView.Remove(item);
                }
                initializeWithFilter();
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        // 필터 함수 - 걸러진 목록을 리턴값으로
        private List<string> filterStringList(List<string> sList)
        {
            List<string> sListFilters = new List<string>();
            List<string> sListResult = new List<string>();
            ListView.ListViewItemCollection items = inter.FiltersItemsOfListView;

            // 필터 단어를 리스트로부터 가져옴
            foreach (ListViewItem item in items)
            {
                sListFilters.Add(item.Text);
            }

            // 리스트로부터 로그를 가져옴
            foreach (string perLine in sList)
            {
                // 필터 단어를 포함 안해야지만 통과할 수 있다
                bool isNotContain = true;
                foreach (string sFilterLine in sListFilters)
                {
                    if (perLine.Contains(sFilterLine))
                    {
                        isNotContain = false;
                    }
                }
                if (isNotContain)
                {
                    sListResult.Add(perLine);
                }
            }
            // 걸러진 리스트 반환
            return sListResult;
        }

    }
}
