using System;

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
