using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leren
{
    class LoginException:ApplicationException
    {
        public LoginException(string message)
            : base(message)
        {

        }
    }
}
