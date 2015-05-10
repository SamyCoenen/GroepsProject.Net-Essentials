using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leren

    // Window helper
    // Date: 29/04/15 - Last edit: 07/05/15
    // Author: Timothy Vanderaerden

{
    class WindowHelper
    {
        public WindowHelper()
        {

        }

        // sluiten van meerdere forms
        public void CloseWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }
        }
    }
}
