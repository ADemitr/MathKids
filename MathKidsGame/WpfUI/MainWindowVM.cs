using System.ComponentModel;

namespace WpfUI
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private string _record = "Hello World";
        public string Record
        {
            get { return _record; }
            set { _record =  value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
