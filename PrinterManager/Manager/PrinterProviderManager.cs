using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;

namespace PrinterManager.Providers
{
  public static class PrinterProviderManager
  {

    //Initialization related variables and logic
    private static bool isInitialized = false;
    private static Exception initializationException;

    private static object initializationLock = new object();

    //Public feature API
    private static PrinterProviderBase defaultProvider;
    private static PrinterCollection providerCollection;


    public static PrinterProviderBase Provider
    {
      get
      {
        if (!isInitialized) {
          Initialize();
        }
        return defaultProvider;
      }
    }

    public static PrinterCollection Providers
    {
      get
      {
        if (!isInitialized) {
          Initialize();
        }
        return providerCollection;
      }
    }

    static PrinterProviderManager()
    {
      Initialize();
    }

    private static void Initialize()
    {
      try {
        PrinterConfiguration dc = (PrinterConfiguration)ConfigurationManager.GetSection("PrinterProvider");

        if (dc.DefaultProvider == null || dc.Providers == null || dc.Providers.Count < 1) {
          throw new ProviderException("You must specify a valid default provider.");
        }

        //Instantiate the providers
        providerCollection = new PrinterCollection();
        ProvidersHelper.InstantiateProviders(dc.Providers, providerCollection, typeof(PrinterProviderBase));
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
