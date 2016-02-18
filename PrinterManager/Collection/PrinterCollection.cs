using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterManager.Providers
{
    public class PrinterCollection : ProviderCollection
    {
        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("The provider parameter cannot be null.");

            if (!(provider is PrinterProviderBase))
                throw new ArgumentException("The provider parameter must be of type MyProviderProvider.");

            base.Add(provider);
        }

        new public PrinterProviderBase this[string name]
        {
            get { return (PrinterProviderBase)base[name]; }
        }

        public void CopyTo(PrinterProviderBase[] array, int index)
        {
            base.CopyTo(array, index);
        }
    }
}
