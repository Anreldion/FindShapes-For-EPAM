using System;

namespace Find.Services.Interfaces
{
    public interface IClosable
    {
        event Action RequestClose;
    }
}
