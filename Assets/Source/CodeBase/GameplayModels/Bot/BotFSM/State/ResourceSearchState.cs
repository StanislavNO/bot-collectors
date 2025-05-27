using System.Collections;
using Source.CodeBase.Controllers;
using UnityEngine;

namespace Source.CodeBase.GameplayModels.Bot.BotFSM.State
{
    public class ResourceSearchState : IState
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IResourceFinder _resourceFinder;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly BotMediator _mediator;
        private readonly BotData _data;

        private readonly WaitForSeconds _delay = new(2);
        private Coroutine _coroutine;

        public ResourceSearchState(
            ICoroutineRunner coroutineRunner,
            IResourceFinder resourceFinder,
            IStateSwitcher stateSwitcher,
            BotData data)
        {
            _coroutineRunner = coroutineRunner;
            _resourceFinder = resourceFinder;
            _stateSwitcher = stateSwitcher;
            _data = data;
        }

        public void Enter()
        {
            _mediator.StartFindResource();
            _coroutine = _coroutineRunner.StartCoroutine(FindResource());
        }

        public void Exit()
        {
            _coroutineRunner.StopCoroutine(_coroutine);
            _mediator.StopFindResource();
        }

        private IEnumerator FindResource()
        {
            var target = _resourceFinder.FindFirstResource(_data.Position);

            yield return _delay;

            _data.Resource = target;
            _data.CanCollect = true;
            _data.Target = _data.Resource.Position;

            Switch();
        }

        private void Switch() =>
            _stateSwitcher.SwitchState<MoveToTargetState>();
    }
}