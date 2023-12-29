using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class CannotBeDeleted : Exception
    {
        public CannotBeDeleted() : base() { }

        public CannotBeDeleted(string message) : base(message) { }

        public CannotBeDeleted(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
