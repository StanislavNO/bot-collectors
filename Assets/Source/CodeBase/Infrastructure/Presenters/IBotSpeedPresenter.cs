using System;

namespace Source.CodeBase.Infrastructure.Presenters
{
    public interface IBotSpeedPresenter
    {
        event Action<float> OnBotSpeedChanged;
    }
}