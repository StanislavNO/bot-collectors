using System.Collections.Generic;
using Source.CodeBase.Controllers;
using Source.CodeBase.GameData;
using Source.CodeBase.GameplayModels.Bot;
using Source.CodeBase.GameplayModels.Bot.BotFSM.State;

namespace Source.CodeBase.Infrastructure.Services.Factories
{
    public class StateFactory
    {
        private readonly IResourceFinder _finder;
        private readonly Score _score;

        public StateFactory(IResourceFinder finder, Score score)
        {
            _finder = finder;
            _score = score;
        }

        public List<IState> Create(CollectorBot bot, IStateSwitcher stateSwitcher)
        {
            return new List<IState>()
            {
                new ResourceSearchState(bot, _finder, stateSwitcher, bot.Data, bot.Mediator),
                new CollectionState(stateSwitcher, bot, bot.Mediator, bot.Data),
                new HomecomingState(stateSwitcher, bot, bot.Data, bot.Mediator, _score),
                new MoveToTargetState(stateSwitcher, bot, bot.Agent, bot.Mediator, bot.Data)
            };
        }
    }
}