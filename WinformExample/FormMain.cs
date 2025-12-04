using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinformExample
{
    enum eTabType
    {
        FontSetter,
        BMI,
        ImageLoad,
        Calculator,
        LogViewer
    }
    public partial class FormMain : Form
    {
        private Dictionary<eTabType, iPresenter> dicTabs;

        public FormMain()
        {
            InitializeComponent();
            
            dicTabs = new Dictionary<eTabType, iPresenter>();

            initializeControls();
        }

        private iPresenter getTab(eTabType eType)
        {
            switch(eType)
            {
                case eTabType.BMI:
                    return new ucBMI();
                case eTabType.Calculator:
                    return new ucCalculator();
                case eTabType.FontSetter:
                    return new ucFontSetter();
                case eTabType.ImageLoad:
                    return new ucImageLoad();
                case eTabType.LogViewer:
                    return new ucLogViewer();
                default:
                    return null;
            }
        }

        private void initializeControls()
        {
            foreach(eTabType eType in Enum.GetValues(typeof(eTabType)))
            {
                iPresenter iTab = getTab(eType);
                dicTabs.Add(eType, iTab);

                Control control = iTab as Control;
                
                tcMainTab.TabPages[(int)eType].Controls.Add(control);

                control.Anchor = AnchorStyles.None;
                control.Dock = DockStyle.Fill;
            }
        }

        private void tcMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tcMainTab.TabPages[tcMainTab.SelectedIndex].Controls[0].Focus();
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader("../../Save/Data.txt"))
                {
                    string sType = reader.ReadLine();

                    eTabType eCurrentTab;
                    Enum.TryParse(sType, out eCurrentTab);
                    tcMainTab.SelectedIndex = (int)eCurrentTab;

                    foreach (KeyValuePair<eTabType, iPresenter> vKeyValue in dicTabs)
                    {
                        eTabType eType = vKeyValue.Key;
                        iPresenter presenter = vKeyValue.Value;
                        presenter.LoadData($"../../Save/{eType.ToString()}.txt");
                    }
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void saveWhenClosing()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("../../Save/Data.txt"))
                {
                    writer.Write(((eTabType)tcMainTab.SelectedIndex).ToString());

                    foreach (KeyValuePair<eTabType, iPresenter> vKeyValue in dicTabs)
                    {
                        eTabType eType = vKeyValue.Key;
                        iPresenter presenter = vKeyValue.Value;
                        presenter.SaveData($"../../Save/{eType.ToString()}.txt");
                    }
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveWhenClosing();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveWhenClosing();
        }
    }
}
