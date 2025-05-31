using System;

namespace Source.CodeBase.Infrastructure.Presenters
{
    public interface ISpawnSpeedPresenter
    {
        event Action<float> OnSpawnSpeedChanged;
    }
}