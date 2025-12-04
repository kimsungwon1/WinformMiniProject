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
        private Dictionary<eTabType, iPresenter> m_dicTabs;

        public FormMain()
        {
            try
            {
                InitializeComponent();

                m_dicTabs = new Dictionary<eTabType, iPresenter>();

                InitializeControls();
                EventInitialize();
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void EventInitialize()
        {
            this.tcMainTab.SelectedIndexChanged += new System.EventHandler(this.tcMainTab_SelectedIndexChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
        }

        private iPresenter GetTabPresenter(eTabType eType)
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
        private TabPage GetTabPage(eTabType eType)
        {
            switch (eType)
            {
                case eTabType.BMI:
                    return tpBMI;
                case eTabType.Calculator:
                    return tpCalculator;
                case eTabType.FontSetter:
                    return tpFontSetter;
                case eTabType.ImageLoad:
                    return tpImageLoader;
                case eTabType.LogViewer:
                    return tpLogViewer;
                default:
                    return null;
            }
        }

        private void InitializeControls()
        {
            foreach(eTabType eType in Enum.GetValues(typeof(eTabType)))
            {
                iPresenter iTab = GetTabPresenter(eType);
                m_dicTabs.Add(eType, iTab);

                Control control = iTab as Control;
                TabPage tp = GetTabPage(eType);

                tp.Controls.Add(control);

                control.Anchor = AnchorStyles.None;
                control.Dock = DockStyle.Fill;
            }
        }

        private void tcMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tcMainTab.SelectedTab.Controls[0].Focus();
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
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
                    if(Enum.TryParse(sType, out eCurrentTab))
                    {
                        tcMainTab.SelectedIndex = (int)eCurrentTab;
                    }
                    else
                    {
                        tcMainTab.SelectedIndex = 0;
                    }

                    foreach (KeyValuePair<eTabType, iPresenter> vKeyValue in m_dicTabs)
                    {
                        eTabType eType = vKeyValue.Key;
                        iPresenter presenter = vKeyValue.Value;
                        presenter.LoadData($"../../Save/{eType.ToString()}.txt");
                    }
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void SaveWhenClosed()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("../../Save/Data.txt"))
                {
                    writer.Write(((eTabType)tcMainTab.SelectedIndex).ToString());

                    foreach (KeyValuePair<eTabType, iPresenter> vKeyValue in m_dicTabs)
                    {
                        eTabType eType = vKeyValue.Key;
                        iPresenter presenter = vKeyValue.Value;
                        presenter.SaveData($"../../Save/{eType.ToString()}.txt");
                    }
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveWhenClosed();
        }
    }
}
