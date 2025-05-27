using System;

namespace Source.CodeBase.View
{
    public interface IStartSignal
    {
        event Action OnStartClicked;
    }
}