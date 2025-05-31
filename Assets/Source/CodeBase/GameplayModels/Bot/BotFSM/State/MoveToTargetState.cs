using System.Collections;
using Source.CodeBase.Infrastructure.Presenters;
using UnityEngine;
using UnityEngine.AI;

namespace Source.CodeBase.GameplayModels.Bot.BotFSM.State
{
    public class MoveToTargetState : IState
    {
        private const float TARGET_MIN_DISTANCE = 1.5f;

        private readonly IStateSwitcher _switcher;
        private readonly ICoroutineRunner _runner;
        private readonly NavMeshAgent _agent;
        private readonly BotMediator _mediator;
        private readonly BotData _data;
        private readonly Transform _bot;

        private Coroutine _coroutine;

        public MoveToTargetState(
            IStateSwitcher switcher,
            ICoroutineRunner runner,
            NavMeshAgent agent,
            BotMediator mediator,
            BotData data)
        {
            _switcher = switcher;
            _runner = runner;
            _agent = agent;
            _mediator = mediator;
            _data = data;
            _bot = agent.transform;
        }

        public void Enter()
        {
            _agent.isStopped = false;
            _mediator.StartMoveToTarget();
            _agent.SetDestination(_data.Target);
            _coroutine = _runner.StartCoroutine(StopTargetComplied());
        }

        public void Exit()
        {
            _agent.isStopped = true;
            _mediator.StopMoveToTarget();
            _runner.StopCoroutine(_coroutine);
        }

        private IEnumerator StopTargetComplied()
        {
            bool isTargetComplied = false;
            Vector3 targetPosition = new(
                _data.Target.x,
                _agent.transform.position.y,
                _data.Target.z);

            while (isTargetComplied == false)
            {
                isTargetComplied = Vector3.Distance
                    (_bot.position, targetPosition) <= TARGET_MIN_DISTANCE;

                yield return null;
            }

            _agent.isStopped = true;
            Switch();
        }

        private void Switch()
        {
            if (_data.CanCollect)
                _switcher.SwitchState<CollectionState>();
            else
                _switcher.SwitchState<HomecomingState>();
        }
    }
}