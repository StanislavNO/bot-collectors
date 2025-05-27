using System;
using Source.CodeBase.Infrastructure.Presenters;
using Zenject;

namespace Source.CodeBase.GameData
{
    public class SessionData : IInitializable, IDisposable
    {
        private readonly IBotCountPresenter _botCountPresenter;
        
        public int BotCount { get; private set; } = 1;

        public SessionData(IBotCountPresenter botCountPresenter)
        {
            _botCountPresenter = botCountPresenter;
        }

        public void Initialize()
        {
            _botCountPresenter.OnBotCountChanged += Update;
        }

        public void Dispose()
        {
            _botCountPresenter.OnBotCountChanged -= Update;
        }

        private void Update(int botCount)
        {
            BotCount = botCount;
        }
    }
}