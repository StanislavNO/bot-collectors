namespace Source.CodeBase.GameplayModels.Bot
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}