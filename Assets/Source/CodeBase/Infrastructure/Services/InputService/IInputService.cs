using System;
using UnityEngine;

namespace Source.CodeBase.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        event Action<Vector3> OnClick;
    }
}