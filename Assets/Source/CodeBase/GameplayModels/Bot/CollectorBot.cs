using System;
using Source.CodeBase.GameData;
using Source.CodeBase.GameplayModels.Bot.BotFSM;
using Source.CodeBase.Infrastructure.Presenters;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Source.CodeBase.GameplayModels.Bot
{
    public class CollectorBot : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private MeshRenderer _renderer;

        private BotStateMachine _botStateMachine;
        private IBotSpeedPresenter _speedPresenter;

        [field: SerializeField] public Transform ViewModel { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public NavMeshAgent Agent { get; private set; }
        public BotData Data { get; private set; }
        public BotMediator Mediator { get; private set; }

        [Inject]
        private void Construct(
            BotStateMachine botStateMachine,
            BotData botData,
            BotMediator botMediator,
            IBotSpeedPresenter speedPresenter)
        {
            _botStateMachine = botStateMachine;
            Data = botData;
            Mediator = botMediator;
            _speedPresenter = speedPresenter;

            Mediator.Init(this);
            Data.Init(transform);
            _botStateMachine.Init(this);
        }

        private void Start()
        {
            _speedPresenter.OnBotSpeedChanged += BotSpeedChanged;
        }

        private void OnDestroy()
        {
            _speedPresenter.OnBotSpeedChanged -= BotSpeedChanged;
        }

        private void OnEnable() => _botStateMachine.Enable();

        public void SetMaterial(Material material) => _renderer.material = material;

        public void SetFraction(Fraction fraction) => Data.Fraction = fraction;

        public void Collect() => Data.Resource.Collect();

        private void BotSpeedChanged(float speed) => Agent.speed = speed;
    }
}