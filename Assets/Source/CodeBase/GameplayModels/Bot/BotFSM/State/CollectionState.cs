using System.Collections;
using UnityEngine;

namespace Source.CodeBase.GameplayModels.Bot.BotFSM.State
{
    public class CollectionState : IState
    {
        private readonly IStateSwitcher _switcher;
        private readonly ICoroutineRunner _runner;
        private readonly BotMediator _mediator;
        private readonly BotData _data;

        private readonly float _collectionSpeed = 2f;
        private readonly WaitForSeconds _delay;
        private Coroutine _coroutine;

        public CollectionState(
            IStateSwitcher switcher,
            ICoroutineRunner runner,
            BotMediator mediator,
            BotData data)
        {
            _switcher = switcher;
            _runner = runner;
            _mediator = mediator;
            _data = data;
            _delay = new WaitForSeconds(_collectionSpeed);
        }

        public void Enter()
        {
            _mediator.StartCollection(_collectionSpeed);
            _coroutine = _runner.StartCoroutine(Collection());
        }

        public void Exit()
        {
            _mediator.StopCollection();
            _runner.StopCoroutine(_coroutine);
        }

        private IEnumerator Collection()
        {
            yield return _delay;
            _data.CanCollect = false;
            _data.Target = _data.HomePosition;
            Switch();
        }

        private void Switch() =>
            _switcher.SwitchState<MoveToTargetState>();
    }
}