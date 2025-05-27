using System;
using System.Collections.Generic;
using Source.CodeBase.Configs;
using Source.CodeBase.GameData;
using Source.CodeBase.GameplayModels.Bot;
using Source.CodeBase.Infrastructure.Services.Factories;
using Source.CodeBase.View;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Controllers
{
    public class BotSpawner : IInitializable, IDisposable
    {
        private readonly IStartSignal _startSignal;
        private readonly SessionData _sessionData;
        private readonly GameSetting _gameSetting;
        private readonly BotFactory _botFactory;
        private readonly Map _map;

        public BotSpawner(
            IStartSignal startSignal,
            SessionData sessionData,
            GameSetting gameSetting,
            BotFactory botFactory, Map map)
        {
            _startSignal = startSignal;
            _sessionData = sessionData;
            _gameSetting = gameSetting;
            _botFactory = botFactory;
            _map = map;
        }

        public void Initialize() => _startSignal.OnStartClicked += OnGameStarting;
        public void Dispose() => _startSignal.OnStartClicked -= OnGameStarting;

        private void OnGameStarting()
        {
            Spawn(_map.OneFractionSpawnPoint, _sessionData.BotCount, _gameSetting.OneFractionMaterial);
            Spawn(_map.TwoFractionSpawnPoint, _sessionData.BotCount, _gameSetting.TwoFractionMaterial);
        }

        private void Spawn(Vector3 spawnPosition, int count, Material fraction)
        {
            List<CollectorBot> bots = _botFactory.Get(count, fraction);

            foreach (var bot in bots)
            {
                bot.transform.position = spawnPosition;

                var newPosition = new Vector3(
                    spawnPosition.x,
                    spawnPosition.y,
                    spawnPosition.z) + Vector3.forward;

                spawnPosition = newPosition;
                bot.gameObject.SetActive(true);
            }
        }
    }
}