using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class ItemAlreadyExists : Exception
    {
        public ItemAlreadyExists() : base() { }

        public ItemAlreadyExists(string message) : base(message) { }

        public ItemAlreadyExists(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
