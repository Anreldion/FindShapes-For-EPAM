using Find.Services.Interfaces;
using System;

namespace Find.Services
{
    public class AppCloser : IAppCloser
    {
        public void Close()
        {
            Environment.Exit(0);
        }
    }
}
