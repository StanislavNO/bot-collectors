using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

namespace Source.CodeBase.GameplayModels.Bot.BotFSM.State
{
    public class MoveToTargetState : IState
    {
        private const float TARGET_MIN_DISTANCE = 1f;
        
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
            _mediator.StartMoveToTarget();
            _agent.SetDestination(_data.Target);
            _coroutine = _runner.StartCoroutine(StopTargetComplied());
        }

        public void Exit()
        {
            _mediator.StopMoveToTarget();
            _runner.StopCoroutine(_coroutine);
        }

        private IEnumerator StopTargetComplied()
        {
            Vector3 targetPosition = new(
                _data.Target.x, 
                _agent.transform.position.y, 
                _data.Target.z);
            
            bool isTargetComplied = 
                (targetPosition - _bot.position).sqrMagnitude 
                <= TARGET_MIN_DISTANCE * TARGET_MIN_DISTANCE;

            if (isTargetComplied)
                Switch();
            
            yield return null;
        }

        private void Switch()
        {
            if(_data.CanCollect)
                _switcher.SwitchState<CollectionState>();
            else
                _switcher.SwitchState<HomecomingState>();
        }
    }
}