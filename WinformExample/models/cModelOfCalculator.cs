using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinformExample
{
    public class cModelOfCalculator
    {
        private iCalculatorPresenter inter;
        private eCalculatorState m_eCalculatorState { get; set; }
        private eOperatorType m_eOperatorType { get; set; }
        private double m_dFirstOperand { get; set; }
        private double m_dSecondOperand { get; set; }
        // 계산기 상태
        public enum eCalculatorState
        {
            FirstDigitTyping, // 첫 글자를 입력 중
            CalculatorTyped,  // 연산자 입력했음
            SecondDigitTyping // 둘째 글자를 입력 중
        }
        // 연산자 타입
        public enum eOperatorType
        {
            DivideRest,
            Divide,
            Multi,
            Minus,
            Plus
        }

        public cModelOfCalculator(iCalculatorPresenter inter)
        {
            m_eCalculatorState = eCalculatorState.FirstDigitTyping;
            m_dFirstOperand = 0.0;
            m_dSecondOperand = 0.0;
            this.inter = inter;
            inter.btnClick_MainOperation += btnClick;
            inter.keyPress_MainOperation += keyPress;
            inter.SetFocusToControl();
        }

        public void SaveData(string sPathToSave)
        {
            try
            {
                Stream stream = new FileStream(sPathToSave, FileMode.OpenOrCreate);
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write((int)m_eCalculatorState);
                    writer.Write((int)m_eOperatorType);
                    writer.Write(m_dFirstOperand);
                    writer.Write(m_dSecondOperand);
                    writer.Write(inter.TextMainOperation);
                }
                cLogger.Instance.AddLog(eLogType.SYSTEM, $"Calculator - Saved");
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
                    m_eCalculatorState = (eCalculatorState)reader.ReadInt32();
                    m_eOperatorType = (eOperatorType)reader.ReadInt32();
                    m_dFirstOperand = reader.ReadDouble();
                    m_dSecondOperand = reader.ReadDouble();
                    inter.TextMainOperation = reader.ReadString();
                }
                cLogger.Instance.AddLog(eLogType.SYSTEM, $"Calculator - Loaded");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            try
            {
                Button btnSender = (Button)sender;

                int pastSelectionStart = inter.SelectionStart_TextMain;
                int pastSelectionLength = inter.SelectionLength_TextMain;

                if (pastSelectionLength > 0)
                {
                    string sNewText = inter.TextMainOperation;
                    sNewText = sNewText.Remove(pastSelectionStart, pastSelectionLength);
                    inter.TextMainOperation = sNewText;
                }
                if (btnSender != null)
                {
                    bool isTyped = input(btnSender.Text);
                    inter.SetFocusToControl();

                    if (isTyped)
                    {
                        // 커서가 있다면
                        string sNewText = inter.TextMainOperation;
                        inter.TextMainOperation = sNewText + btnSender.Text;
                    }
                }

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"Calculator - Button Clicked : {btnSender.Text} button");
            }
            catch(Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string sKey = new string(e.KeyChar, 1);
                bool isTyped = input(sKey);
                if (isTyped)
                {
                    inter.TextMainOperation = inter.TextMainOperation += sKey;
                }

                cLogger.Instance.AddLog(eLogType.USER_ACTION, $"Calculator - Key Pressed : {e.KeyChar}");
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
        }

        private bool input(string sTyped)
        {
            try
            {
                int nDigit;

                if (!(char.IsDigit(sTyped[0]) || isCalculator(sTyped[0]) || sTyped == "=" || sTyped == "C" || sTyped == "<X" || sTyped == "\r" ||
                    (sTyped[0] == '.' && isInsertingPointPossible())) && sTyped[0] != '\b')
                {
                    return false;
                }
                // 숫자 입력 or 소수점 입력
                if (int.TryParse(sTyped, out nDigit) || sTyped == ".")
                {
                    if (m_eCalculatorState == eCalculatorState.CalculatorTyped)
                    {
                        m_eCalculatorState = eCalculatorState.SecondDigitTyping;
                        inter.TextMainOperation = "";
                    }
                    if (sTyped == ".")
                    {
                        if (!isInsertingPointPossible())
                        {
                            return false;
                        }
                        if (string.IsNullOrEmpty(inter.TextMainOperation))
                        {
                            inter.TextMainOperation += "0.";
                            return false;
                        }
                    }
                }
                else
                {
                    // Clear
                    if (sTyped == "C")
                    {
                        inter.TextMainOperation = "";

                        if (m_eCalculatorState == eCalculatorState.SecondDigitTyping)
                        {
                            m_eCalculatorState = eCalculatorState.CalculatorTyped;
                        }
                        else if (m_eCalculatorState == eCalculatorState.CalculatorTyped)
                        {
                            m_eCalculatorState = eCalculatorState.FirstDigitTyping;
                            inter.TextMainOperation = m_dFirstOperand.ToString();
                        }
                        return false;
                    }
                    // 한낱말 지우기
                    else if (sTyped == "<X" || sTyped == "\b")
                    {
                        string newText = inter.TextMainOperation;
                        if (!string.IsNullOrEmpty(newText))
                        {
                            inter.TextMainOperation = newText.Remove(newText.Length - 1);
                        }

                        return false;
                    }
                    // 등호
                    else if (sTyped == "=" || sTyped == "\r")
                    {
                        // 만약 현재 첫 피연산자 입력 중이거나 연산자 입력했을때 -> 바로 첫 숫자를 결과로
                        if (m_eCalculatorState == eCalculatorState.CalculatorTyped || m_eCalculatorState == eCalculatorState.FirstDigitTyping)
                        {
                            // 결과값을 바로 첫 피연산자로 만들어내고 상태를 처음으로 되돌리기 위해 caculate 호출.
                            m_eOperatorType = eOperatorType.Plus;
                            if (m_eCalculatorState == eCalculatorState.FirstDigitTyping)
                            {
                                SetOperandFromText(true);
                            }
                            m_dSecondOperand = 0.0;
                            calculate();
                        }
                        else
                        {
                            // 두번째 피연산자 가져온 뒤 연산
                            SetOperandFromText(false);
                            calculate();
                        }
                        return false;
                    }
                    // 연산자
                    else
                    {
                        // 첫 피연산자 입력 중 연산자 입력 (제일 일반적인 경우)
                        if (m_eCalculatorState == eCalculatorState.FirstDigitTyping)
                        {
                            m_eCalculatorState = eCalculatorState.CalculatorTyped;
                            // 텍스트박스에 아무것도 없다면 0을 가져온다.
                            if (inter.TextMainOperation == "")
                            {
                                m_dFirstOperand = 0.0;
                            }
                            else
                            {
                                SetOperandFromText(true);
                            }
                        }
                        // 둘째 피연산자 입력 중 연산자 입력 -> 바로 첫째, 그 전 연산자, 둘째를 가져와 계산한 뒤
                        // 그 결과를 첫 피연산자로 두고 연산자 입력
                        else if (m_eCalculatorState == eCalculatorState.SecondDigitTyping)
                        {
                            eOperatorType pastCalculatorType = m_eOperatorType;
                            calculate();
                            SetOperandFromText(true);
                            m_eOperatorType = pastCalculatorType;
                            m_eCalculatorState = eCalculatorState.SecondDigitTyping;
                        }

                        // 연산자 타입 정함
                        setCalculatorType(sTyped);

                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                cLogger.Instance.AddLog(eLogType.ERROR, exception.Message);
            }
            return true;
        }

        private bool isCalculator(char key)
        {
            return key == '*' || key == '-' || key == '+' || key == '%' || key == '/';
        }

        private bool isInsertingPointPossible()
        {
            string sCurrentText = inter.TextMainOperation;
            if (sCurrentText.Contains('.'))
                return false;
            return true;
        }


        // 만약 연산자를 입력했으면 연산자 타입을 정하고 연산자를 텍스트에 출력
        private void setCalculatorType(string sTyped)
        {
            if (sTyped == "%")
            {
                m_eOperatorType = eOperatorType.DivideRest;
            }
            else if (sTyped == "/")
            {
                m_eOperatorType = eOperatorType.Divide;
            }
            else if (sTyped == "*")
            {
                m_eOperatorType = eOperatorType.Multi;
            }
            else if (sTyped == "-")
            {
                m_eOperatorType = eOperatorType.Minus;
            }
            else if (sTyped == "+")
            {
                m_eOperatorType = eOperatorType.Plus;
            }

            inter.TextMainOperation = sTyped;
        }

        // 등호 호출 시 계산하는 함수
        private void calculate()
        {
            double dNewOperand = 0.0;
            switch (m_eOperatorType)
            {
                case eOperatorType.DivideRest:
                    dNewOperand = m_dFirstOperand % m_dSecondOperand;
                    break;
                case eOperatorType.Divide:
                    dNewOperand = m_dFirstOperand / m_dSecondOperand;
                    break;
                case eOperatorType.Minus:
                    dNewOperand = m_dFirstOperand - m_dSecondOperand;
                    break;
                case eOperatorType.Multi:
                    dNewOperand = m_dFirstOperand * m_dSecondOperand;
                    break;
                case eOperatorType.Plus:
                    dNewOperand = m_dFirstOperand + m_dSecondOperand;
                    break;
            }
            inter.TextMainOperation = dNewOperand.ToString();

            // 첫 연산자 입력 상태로 되돌아가기
            m_eCalculatorState = eCalculatorState.FirstDigitTyping;

            cLogger.Instance.AddLog(eLogType.INFO, $"Calculator - Result Calculated : {dNewOperand}");
        }

        // true면 firstOperand를 텍스트로부터 세팅, false면 secondOperand를
        public void SetOperandFromText(bool isFirstOperand)
        {
            double dOut;
            if (double.TryParse(inter.TextMainOperation, out dOut))
            {
                if (isFirstOperand)
                {
                    m_dFirstOperand = dOut;
                }
                else
                {
                    m_dSecondOperand = dOut;
                }
            }
        }
    }
}
