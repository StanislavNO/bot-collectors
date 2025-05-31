using System;
using Source.CodeBase.GameplayModels.Bot;
using Source.CodeBase.GameplayModels.Camera;
using Source.CodeBase.Infrastructure.Services.InputService;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Controllers
{
    public class BotCameraSetter : IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly Camera _camera;
        private readonly CameraBotFollower _follower;
        
        public BotCameraSetter(IInputService inputService, CameraBotFollower follower)
        {
            _inputService = inputService;
            _follower = follower;
            _camera = Camera.main;
        }


        public void Initialize()
        {
            
            _inputService.OnClick += OnPlayerClick;
        }

        public void Dispose()
        {
            _inputService.OnClick -= OnPlayerClick;
        }

        private void OnPlayerClick(Vector3 mousePosition)
        {
            var ray = _camera.ScreenPointToRay(mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.TryGetComponent(out CollectorBot bot))
                    _follower.SetTarget(bot.transform);
            }
        }
    }
}