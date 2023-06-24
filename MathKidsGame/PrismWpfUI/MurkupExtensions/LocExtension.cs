using System;
using System.Reflection;
using System.Windows.Markup;
using System.Resources;
using System.Threading;

namespace PrismWpfUI.MurkupExtensions
{
    public class LocExtension : MarkupExtension
    {
        private string _value;

        public LocExtension(string value)
        {
            _value = value;

            var ci = Thread.CurrentThread.CurrentCulture;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {

            ResourceManager rm = new ResourceManager("PrismWpfUI.Resources.Strings",
                Assembly.GetExecutingAssembly());

            return rm.GetString(_value);
        }
    }
}
