using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.Common
{
  public static class Extensions
  {

    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
      return source.IndexOf(toCheck, comp) >= 0;
    }

    public static T ValueOrNull<T>(this T obj) where T : class, new()
    {
      return obj ?? new T();
    }

  }
}
