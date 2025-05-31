using System.Collections;
using Source.CodeBase.GameData;
using UnityEngine;

namespace Source.CodeBase.GameplayModels.Bot.BotFSM.State
{
    public class HomecomingState : IState
    {
        private readonly IStateSwitcher _switcher;
        private readonly ICoroutineRunner _runner;
        private readonly BotData _data;
        private readonly BotMediator _mediator;
        private readonly Score _score;

        private readonly float _dropSpeed = 2;
        private readonly WaitForSeconds _delay;

        public HomecomingState(
            IStateSwitcher switcher,
            ICoroutineRunner runner,
            BotData data, 
            BotMediator mediator, 
            Score score)
        {
            _switcher = switcher;
            _runner = runner;
            _data = data;
            _mediator = mediator;
            _score = score;
            
            _delay = new WaitForSeconds(_dropSpeed);
        }

        public void Enter()
        {
            _mediator.StartHoming(_dropSpeed);
            _runner.StartCoroutine(DropResource());
        }


        public void Exit()
        {
            _mediator.StopHoming();
        }

        private IEnumerator DropResource()
        {
            yield return _delay;
            
            _score.Add(_data.Fraction);
            Switch();
        }

        private void Switch() =>
            _switcher.SwitchState<ResourceSearchState>();
    }
}