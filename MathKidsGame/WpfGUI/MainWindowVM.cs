﻿using Prism.Mvvm;

namespace WpfGUI
{
    public class MainWindowVM : BindableBase
    {
        private string _record = "Hello World";
        public string Record
        {
            get { return _record; }
            set { _record =  value; }
        }

    }
}
