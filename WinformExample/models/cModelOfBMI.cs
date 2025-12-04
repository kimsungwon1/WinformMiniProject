using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinformExample
{
    public class cModelOfBMI
    {
        private iBMIPresenter m_BMIPresenter;
        private double m_dBmi = 0.0;

        public cModelOfBMI(iBMIPresenter presenter)
        {
            try
            {
                m_BMIPresenter = presenter;
                m_BMIPresenter.btnCalculateClick += calculate;
            }
            catch(Exception exception)
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
                    int nHeight = 0;
                    int nWeight = 0;
                    int.TryParse(m_BMIPresenter.TextTbHeight, out nHeight);
                    int.TryParse(m_BMIPresenter.TextTbWeight, out nWeight);
                    writer.Write(nHeight);
                    writer.Write(nWeight);
                    writer.Write(m_dBmi);
                }
                cLogger.Instance.AddLog(eLogType.SYSTEM, "BMI - Saved");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        public void LoadData(string sPathToSave)
        {
            try
            {
                Stream stream = new FileStream(sPathToSave, FileMode.OpenOrCreate);
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    int nHeight; int nWeight;
                    nHeight = reader.ReadInt32();
                    nWeight = reader.ReadInt32();
                    m_dBmi = reader.ReadDouble();
                    m_BMIPresenter.TextTbHeight = nHeight.ToString();
                    m_BMIPresenter.TextTbWeight = nWeight.ToString();
                    m_BMIPresenter.TextLbResult = m_dBmi.ToString();
                    CalculateResult();
                    cLogger.Instance.AddLog(eLogType.SYSTEM, "BMI - Loaded");
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
        private void CalculateResult()
        {
            // barValue : m_bmiTrackBar의 값            
            string sWeightType;
            if (m_dBmi < 18.5)
            {
                if (m_dBmi <= 16)
                {
                    m_BMIPresenter.ValueBmiTkbar = 0;
                }
                else if (m_dBmi <= 16.8)
                {
                    m_BMIPresenter.ValueBmiTkbar = 1;
                }
                else
                {
                    m_BMIPresenter.ValueBmiTkbar = 2;
                }
                sWeightType = "저체중";
            }
            else if (m_dBmi < 23.0)
            {
                m_BMIPresenter.ValueBmiTkbar = (int)((m_dBmi - 18.5) / 0.9) + 2;
                sWeightType = "정상";
            }
            else if (m_dBmi < 25.0)
            {
                m_BMIPresenter.ValueBmiTkbar = (int)((m_dBmi - 23.0) / 0.9) + 6;
                sWeightType = "과체중";
            }
            else
            {
                int nValue = (int)((m_dBmi - 25) / 0.9) + 8; 
                if(nValue > 10)
                {
                    nValue = 10;
                }
                m_BMIPresenter.ValueBmiTkbar = nValue;
                sWeightType = "비만";
            }

            m_BMIPresenter.TextLbResult = $" - BMI 지수 [{m_dBmi}]로 {sWeightType}입니다.";
            cLogger.Instance.AddLog(eLogType.INFO, $"BMI - BMI : {m_dBmi}, {sWeightType}");
        }
        // 계산
        private void calculate(object sender, EventArgs e)
        {
            try
            {
                // bmi = 몸무게(kg) / 키(m) / 키(m)
                // heightText의 단위는 cm이므로 100을 두번 나누어야함
                double dHeight = 0; double dWeight = 0;
                double.TryParse(m_BMIPresenter.TextTbHeight, out dHeight);
                double.TryParse(m_BMIPresenter.TextTbWeight, out dWeight);

                double dDivide = dHeight * dHeight / 10000;
                m_dBmi = dWeight / dDivide;
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception);
            }
        }
    }
}
