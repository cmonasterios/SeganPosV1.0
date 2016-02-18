using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Text;

namespace DisplayManager.Providers
{
    public class DisplayCollection : ProviderCollection
    {
        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("The provider parameter cannot be null.");

            if (!(provider is DisplayManagerBase))
                throw new ArgumentException("The provider parameter must be of type MyProviderProvider.");

            base.Add(provider);
        }

        new public DisplayManagerBase this[string name]
        {
            get { return (DisplayManagerBase)base[name]; }
        }

        public void CopyTo(DisplayManagerBase[] array, int index)
        {
            base.CopyTo(array, index);
        }
    }
}
