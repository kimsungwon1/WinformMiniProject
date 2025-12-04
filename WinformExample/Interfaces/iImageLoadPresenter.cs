using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinformExample
{
    public interface iImageLoadPresenter : iPresenter
    {
        event EventHandler btnImageLoadClick;
        Image ImageOriginal { set; }
        Image ImageFiltered { set; }
    }
}
