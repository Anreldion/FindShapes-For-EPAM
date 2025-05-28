using System;

namespace Find.ViewModels
{
    public interface IClosable
    {
        event Action RequestClose;
    }
}
