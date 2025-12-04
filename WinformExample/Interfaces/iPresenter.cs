using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformExample
{
    public interface iPresenter
    {
        void SaveData(string sPathToSave);
        void LoadData(string sPathToLoad);
    }
}
