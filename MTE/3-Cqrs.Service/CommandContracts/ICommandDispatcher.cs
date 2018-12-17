namespace _3_Cqrs.Service.CommandContracts
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
