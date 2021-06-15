using System;
using System.Globalization;

namespace Test
{
    public class AppExceptionHelper : Exception
    {
        public AppExceptionHelper() : base() { }

        public AppExceptionHelper(string message) : base(message) { }

        public AppExceptionHelper(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
