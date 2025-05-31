using System;
using Source.CodeBase.GameData;
using Source.CodeBase.GameplayModels.GameplayResources;
using Source.CodeBase.Infrastructure.Presenters;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.GameplayModels.Bot
{
    public class BotData 
    {
        private Transform _bot;

        public Resource Resource { get; set; }
        public bool CanCollect { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 HomePosition { get; set; }
        public Fraction Fraction { get; set; }

        public Vector3 Position => _bot.position;

        public void Init(Transform bot)
        {
            _bot = bot;
        }
    }
}