using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class NotFound : Exception
    {
        public NotFound() : base() { }

        public NotFound(string message) : base(message) { }

        public NotFound(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
