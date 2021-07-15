using Prism.Mvvm;

namespace WpfUI.ViewModel
{
    public class MainWindowVM : BindableBase
    {
        public MainWindowVM()
        {

        }

        private string _record = "Hello World";
        public string Record
        {
            get { return _record; }
            set { _record =  value; }
        }

    }
}
