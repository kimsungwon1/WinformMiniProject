using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformExample
{
    public interface iBMIPresenter : iPresenter
    {
        event EventHandler btnCalculateClick;
        string TextTbWeight { get; set; }
        string TextTbHeight { get; set; }
        string TextLbResult { set; }
        int ValueBmiTkbar { get; set; }
        int MaxValueBmiTkbar { get; }
    }
}
