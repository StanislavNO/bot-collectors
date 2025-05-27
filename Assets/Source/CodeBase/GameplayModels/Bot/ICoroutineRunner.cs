using System.Collections;
using UnityEngine;

namespace Source.CodeBase.GameplayModels.Bot
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}