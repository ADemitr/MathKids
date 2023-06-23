using Prism.Commands;

namespace PrismWpfUI.Core
{
    public interface IApplicationCommands
    {
        CompositeCommand Naviagte { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand Naviagte { get; } = new CompositeCommand();
    }
}
