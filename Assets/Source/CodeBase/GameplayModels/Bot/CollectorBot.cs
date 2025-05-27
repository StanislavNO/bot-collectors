using Source.CodeBase.GameplayModels.Bot.BotFSM;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Source.CodeBase.GameplayModels.Bot
{
    public class CollectorBot : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private MeshRenderer _renderer;

        private BotStateMachine _botStateMachine;

        [field: SerializeField] public NavMeshAgent Agent { get; private set; }
        public BotData Data { get; private set; }
        public BotMediator Mediator { get; private set; }

        [Inject]
        private void Construct(
            BotStateMachine botStateMachine,
            BotData botData,
            BotMediator botMediator)
        {
            _botStateMachine = botStateMachine;
            Data = botData;
            Mediator = botMediator;

            Mediator.Init(this);
            Data.Init(transform);
            _botStateMachine.Init(this);
        }

        public void SetMaterial(Material material) => _renderer.material = material;
    }
}