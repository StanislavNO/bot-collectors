using System.Collections.Generic;
using System.Linq;
using Source.CodeBase.Infrastructure.Services.Factories;

namespace Source.CodeBase.GameplayModels.Bot.BotFSM
{
    public class BotStateMachine : IStateSwitcher
    {
        private readonly StateFactory _factory;
        
        private List<IState> _states;
        private IState _currentState;

        public BotStateMachine(StateFactory factory)
        {
            _factory = factory;
        }

        public void Init(CollectorBot collectorBot)
        {
            _states = _factory.Create(collectorBot, this);
        }

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}