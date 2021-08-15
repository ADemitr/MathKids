using Prism.Commands;
using Prism.Mvvm;

namespace WpfUI.ViewModel
{
    public class MainWindowVW : BindableBase
    {
        public DelegateCommand GameMaxInARow { get; }
        public DelegateCommand EditSettings { get; }

        public MainWindowVW()
        {
        }
    }
}