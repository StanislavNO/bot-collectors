using System;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Infrastructure.Services.InputService
{
    public class StandaloneInput : IInputService, ITickable
    {
        public event Action<Vector3> OnClick;
        
        public void Tick()
        {
            if(Input.GetMouseButtonDown(0))
                OnClick?.Invoke(Input.mousePosition);
        }
    }
}