using System.Collections.Generic;
using Source.CodeBase.Controllers;
using Source.CodeBase.GameplayModels.Bot;
using Source.CodeBase.GameplayModels.Bot.BotFSM.State;

namespace Source.CodeBase.Infrastructure.Services.Factories
{
    public class StateFactory
    {
        private readonly IResourceFinder _finder;
        
        public StateFactory(IResourceFinder finder)
        {
            _finder = finder;
        }

        public List<IState> Create(CollectorBot bot, IStateSwitcher stateSwitcher)
        {
            return new List<IState>()
            {
                new CollectionState(stateSwitcher, bot, bot.Mediator, bot.Data),
                new HomecomingState(stateSwitcher, bot, bot.Data),
                new MoveToTargetState(stateSwitcher, bot, bot.Agent , bot.Mediator, bot.Data),
                new ResourceSearchState(bot, _finder, stateSwitcher, bot.Data)
            };
        }
    }
}