using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformExample
{
    public interface iCalculatorPresenter : iPresenter
    {
        event EventHandler btnClick_MainOperation;
        event KeyPressEventHandler keyPress_MainOperation;

        string TextMainOperation { get; set; }
        string TextSelected_MainOperation { get; }

        int SelectionStart_TextMain { get; }
        int SelectionLength_TextMain { get; }

        void SetFocusToControl();
    }

}
