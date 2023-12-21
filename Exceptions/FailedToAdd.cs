using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class FailedToAdd : Exception
    {
        public FailedToAdd() : base() { }

        public FailedToAdd(string message) : base(message) { }

        public FailedToAdd(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
