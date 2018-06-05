using System;

namespace DGI
{
    public class BrowserController
    {
        private string URI;

        public BrowserController(string URI)
        {
            if (IsValidUri(URI))
            {
                this.URI = URI;
            }
            else
            {
                throw new UriFormatException("Provided a wrong URI format!");
            }
        }

        private bool IsValidUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return false;
            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        public bool OpenBrowser()
        {
            try
            {
                System.Diagnostics.Process.Start(URI);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
