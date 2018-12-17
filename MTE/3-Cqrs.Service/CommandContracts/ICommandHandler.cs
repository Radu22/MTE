namespace _3_Cqrs.Service.CommandContracts
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
