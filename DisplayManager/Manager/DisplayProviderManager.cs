using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Text;
using System.Web.Configuration;

namespace DisplayManager.Providers
{
  public static class DisplayProviderManager
  {
    //Initialization related variables and logic
    private static bool isInitialized = false;
    private static Exception initializationException;

    private static object initializationLock = new object();

    //Public feature API
    private static DisplayManagerBase defaultProvider;
    private static DisplayCollection providerCollection;


    public static DisplayManagerBase Provider
    {
      get
      {
        if (!isInitialized) {
          Initialize();
        }
        return defaultProvider;
      }
    }

    public static DisplayCollection Providers
    {
      get
      {
        if (!isInitialized) {
          Initialize();
        }
        return providerCollection;
      }
    }

    static DisplayProviderManager()
    {
      Initialize();
    }

    private static void Initialize()
    {
      try {
        DisplayConfiguration dc = (DisplayConfiguration)ConfigurationManager.GetSection("DisplayProvider");

        if (dc.DefaultProvider == null || dc.Providers == null || dc.Providers.Count < 1) {
          throw new ProviderException("You must specify a valid default provider.");
        }

        //Instantiate the providers
        providerCollection = new DisplayCollection();
        ProvidersHelper.InstantiateProviders(dc.Providers, providerCollection, typeof(DisplayManagerBase));
        providerCollection.SetReadOnly();
        defaultProvider = providerCollection[dc.DefaultProvider];
        if (defaultProvider == null) {
          throw new ConfigurationErrorsException(
              "You must specify a default provider for the feature.",
              dc.ElementInformation.Properties["defaultProvider"].Source,
              dc.ElementInformation.Properties["defaultProvider"].LineNumber);
        }
      }
      catch (Exception ex) {
        initializationException = ex;
        isInitialized = true;
        throw ex;
      }
      isInitialized = true;
    }
  }

}
