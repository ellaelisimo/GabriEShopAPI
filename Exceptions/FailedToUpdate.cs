using System.Globalization;

namespace GabriEShopAPI.Exceptions
{
    public class FailedToUpdate : Exception
    {
        public FailedToUpdate() : base() { }

        public FailedToUpdate(string message) : base(message) { }

        public FailedToUpdate(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
