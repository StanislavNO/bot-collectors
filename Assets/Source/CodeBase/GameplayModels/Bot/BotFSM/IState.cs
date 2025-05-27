namespace Source.CodeBase.GameplayModels.Bot
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}