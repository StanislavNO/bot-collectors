using DG.Tweening;
using UnityEngine;

namespace Source.CodeBase.Infrastructure.Services.AnimationService
{
    public class AnimationService
    {
        public void ShowBound(Transform transform, float duration, float targetScale)
        {
            transform
                .DOScale(targetScale, duration)
                .SetEase(Ease.InBounce);
        }

        public void ChangeScale(Transform obj, float duration, float targetScale)
        {
            obj
                .DOScale(targetScale, duration)
                .SetEase(Ease.OutSine);
        }
    }
}