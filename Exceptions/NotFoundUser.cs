using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class NotFoundUser : Exception
    {
        public NotFoundUser() : base() { }

        public NotFoundUser(string message) : base(message) { }

        public NotFoundUser(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
