using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class AlreadyExists : Exception
    {
        public AlreadyExists() : base() { }

        public AlreadyExists(string message) : base(message) { }

        public AlreadyExists(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
