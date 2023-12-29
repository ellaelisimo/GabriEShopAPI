using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class NotFoundShop : Exception
    {
        public NotFoundShop() : base() { }

        public NotFoundShop(string message) : base(message) { }

        public NotFoundShop(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
