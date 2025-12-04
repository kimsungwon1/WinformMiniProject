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
        private iBMIPresenter inter;
        private double m_dBmi = 0.0;

        public cModelOfBMI(iBMIPresenter presenter)
        {
            inter = presenter;
            inter.btnCalculateClick += calculate;
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
                    int.TryParse(inter.TextTbHeight, out nHeight);
                    int.TryParse(inter.TextTbWeight, out nWeight);
                    writer.Write(nHeight);
                    writer.Write(nWeight);
                    writer.Write(m_dBmi);
                }
                cLogger.Instance.AddLog(eLogType.SYSTEM, "BMI - Saved");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
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
                    inter.TextTbHeight = nHeight.ToString();
                    inter.TextTbWeight = nWeight.ToString();
                    inter.TextLbResult = m_dBmi.ToString();
                    calculateResult();
                    cLogger.Instance.AddLog(eLogType.SYSTEM, "BMI - Loaded");
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }
        private void calculateResult()
        {
            // barValue : m_bmiTrackBar의 값            
            string sWeightType;
            if (m_dBmi < 18.5)
            {
                if (m_dBmi <= 16)
                {
                    inter.ValueBmiTkbar = 0;
                }
                else if (m_dBmi <= 16.8)
                {
                    inter.ValueBmiTkbar = 1;
                }
                else
                {
                    inter.ValueBmiTkbar = 2;
                }
                sWeightType = "저체중";
            }
            else if (m_dBmi < 23.0)
            {
                inter.ValueBmiTkbar = (int)((m_dBmi - 18.5) / 0.9) + 2;
                sWeightType = "정상";
            }
            else if (m_dBmi < 25.0)
            {
                inter.ValueBmiTkbar = (int)((m_dBmi - 23.0) / 0.9) + 6;
                sWeightType = "과체중";
            }
            else
            {
                int nValue = (int)((m_dBmi - 25) / 0.9) + 8; 
                if(nValue > 10)
                {
                    nValue = 10;
                }
                inter.ValueBmiTkbar = nValue;
                sWeightType = "비만";
            }

            inter.TextLbResult = $" - BMI 지수 [{m_dBmi}]로 {sWeightType}입니다.";
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
                double.TryParse(inter.TextTbHeight, out dHeight);
                double.TryParse(inter.TextTbWeight, out dWeight);

                double dDivide = dHeight * dHeight / 10000;
                m_dBmi = dWeight / dDivide;

                calculateResult();
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }
    }
}
