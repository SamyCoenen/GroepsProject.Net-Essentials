using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leren

    // Window helper, sluiten van meerdere schermen
    // Date: 29/04/15 - Last edit: 29/04/15
    // Author: Timothy Vanderaerden

{
    class WindowHelper
    {
        public WindowHelper()
        {

        }

        public void CloseWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 1; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }
        }
    }
}
