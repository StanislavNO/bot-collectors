using UnityEngine.AI;

namespace Source.CodeBase.GameplayModels.Bot.BotFSM.State
{
    public class HomecomingState : IState
    {
        private readonly IStateSwitcher _switcher;
        private readonly ICoroutineRunner _runner;
        private readonly BotData _data;


        public HomecomingState(
            IStateSwitcher switcher,
            ICoroutineRunner runner,
            BotData data) 
        {
            _switcher = switcher;
            _runner = runner;
            _data = data;
        }
        
        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}