using Source.CodeBase.GameplayModels.GameplayResources;
using UnityEngine;

namespace Source.CodeBase.GameplayModels.Bot
{
    public class BotData
    {
        private Transform _bot;

        public Resource Resource;
        public bool CanCollect;
        public int Speed;
        public Vector3 Target;
        public Vector3 HomePosition;
        
        public Vector3 Position => _bot.position;

        public void Init(Transform bot)
        {
            _bot = bot;
        }
    }
}