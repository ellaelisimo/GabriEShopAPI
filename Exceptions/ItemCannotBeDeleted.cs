using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class ItemCannotBeDeleted : Exception
    {
        public ItemCannotBeDeleted() : base() { }

        public ItemCannotBeDeleted(string message) : base(message) { }

        public ItemCannotBeDeleted(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
