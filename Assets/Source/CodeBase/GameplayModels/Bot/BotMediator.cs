using Source.CodeBase.Infrastructure.Services.AnimationService;
using UnityEngine;

namespace Source.CodeBase.GameplayModels.Bot
{
    public class BotMediator
    {
        private const string IS_FINDED = "IsFinded";
        private const string IS_IDLING = "IsIdling";

        private readonly AnimationService _animatorService;

        private Animator _animator;
        private CollectorBot _collector;

        public BotMediator(AnimationService animatorService)
        {
            _animatorService = animatorService;
        }

        public void Init(CollectorBot bot)
        {
            _collector = bot;
            _animator = bot.Animator;
        }

        public void StartFindResource()
        {
            _animator.SetBool(IS_FINDED, true);
            _animator.SetBool(IS_IDLING, false);
        }

        public void StopFindResource()
        {
            _animator.SetBool(IS_FINDED, false);
            _animator.SetBool(IS_IDLING, true);
        }

        public void StartMoveToTarget()
        {
        }

        public void StopMoveToTarget()
        {
        }

        public void StartCollection(float duration)
        {
            _animatorService.ShowBound(_collector.Data.Resource.transform, duration, 0f);
            _animatorService.ChangeScale(_collector.ViewModel, duration, 1.8f);
            _animator.enabled = false;
        }

        public void StopCollection()
        {
            _collector.Collect();
        }

        public void StartHoming(float duration)
        {
            _animatorService.ChangeScale(_collector.ViewModel, duration, 1f);
        }

        public void StopHoming()
        {
            _animator.enabled = true;
        }
    }
}