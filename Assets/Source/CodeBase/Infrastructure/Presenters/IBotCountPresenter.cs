using System;

namespace Source.CodeBase.Infrastructure.Presenters
{
    public interface IBotCountPresenter
    {
        event Action<int> OnBotCountChanged;
    }
}