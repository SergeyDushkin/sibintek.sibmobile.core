using System.Threading.Tasks;

namespace sibintek.sibmobile.core
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}
