using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class NotFoundItem : Exception
    {
        public NotFoundItem() : base() { }

        public NotFoundItem(string message) : base(message) { }

        public NotFoundItem(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
