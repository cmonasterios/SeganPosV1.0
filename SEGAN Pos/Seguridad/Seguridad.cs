using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SEGAN_POS
{
  public class Seguridad
  {
    private string stringKey;
    private string stringIV;
    private CryptoProvider algorithm;

    /// <summary>
    /// Proveedores del Servicio de criptografía.
    /// </summary>
    public enum CryptoProvider
    {
      DES,
      TripleDES,
      RC2,
      Rijndael
    }

    /// <summary>
    /// Encripción / Desencripción.
    /// </summary>
    public enum CryptoAction
    {
      Encrypt,
      Desencrypt
    }
    /// <summary>
    /// Constructor por defecto.
    /// </summary>
    /// <param name="alg">Establece el algoritmo de Encripción a utilizar.</param>
    public Seguridad(CryptoProvider alg)
    {
      this.algorithm = alg;
      Key = "12345678password";
      IV = "password12345678";
    }

    /// <summary>
    /// Propiedad que obtiene o establece el valor de la llave de encripción
    /// </summary>
    public string Key
    {
      get
      {
        return stringKey;
      }
      set
      {
        stringKey = value;
      }
    }

    /// <summary>
    /// Propiedad que obtiene o establece el valor del vector de inicialización.
    /// </summary>
    public string IV
    {
      get
      {
        return stringIV;
      }
      set
      {
        stringIV = value;
      }
    }

    /// <summary>
    /// Convierte los valores de tipo string, de la llave de cifrado
    /// en sus correspondiente byte array.
    /// </summary>
    /// <returns>Devuelve el arreglo de bytes correspondiente a la llave de cifrado.</returns>
    private byte[] MakeKeyByteArray()
    {
      // dependiendo del algoritmo utilizado.
      switch (this.algorithm) {
        // para los algoritmos
        case CryptoProvider.DES:
        case CryptoProvider.RC2:
          // verificamos que la longitud no sea menor que 8 bytes,
          if (stringKey.Length < 8)
            // de ser así, completamos la cadena hasta un valor válido
            stringKey = stringKey.PadRight(8);
          else if (stringKey.Length > 8)// si la cadena supera los 8 bytes,
            // truncamos la cadena dejándola en 8 bytes.
            stringKey = stringKey.Substring(0, 8);
          break;
        // para los algoritmos
        case CryptoProvider.TripleDES:
        case CryptoProvider.Rijndael:
          // verificamos que la longitud no sea menor a 16 bytes
          if (stringKey.Length < 16)
            // de ser así, completamos la cadena hasta esos 16 bytes.
            stringKey = stringKey.PadRight(16);
          else if (stringKey.Length > 16)//longitud es mayor a 16 bytes,
            // truncamos la cadena dejándola en 16 bytes.
            stringKey = stringKey.Substring(0, 16);
          break;
      }

      // utilizando los métodos del namespace System.Text, 
      // convertimos la cadena de caracteres en un arreglo de bytes
      // mediante el método GetBytes() del sistema de codificación UTF.
      return Encoding.UTF8.GetBytes(stringKey);
    }

    /// <summary>
    /// Convierte los valores de tipo string, del vector de inicialización
    /// en sus correspondiente byte array.
    /// </summary>
    /// <returns>Devuelve el arreglo de bytes correspondiente al VI.</returns>
    private byte[] MakeIVByteArray()
    {
      // dependiendo del algoritmo utilizado.
      switch (this.algorithm) {
        // para los algoritmos 
        case CryptoProvider.DES:
        case CryptoProvider.RC2:
        case CryptoProvider.TripleDES:
          // verificamos que la longitud no sea menor que 8 bytes, 
          if (stringIV.Length < 8)
            // de ser así, completamos la cadena hasta un valor válido
            stringIV = stringIV.PadRight(8);
          else if (stringIV.Length > 8)//si la cadena supera los 8 bytes,
            // truncamos la cadena dejándola en 8 bytes.
            stringIV = stringIV.Substring(0, 8);
          break;
        case CryptoProvider.Rijndael:
          // verificamos que la longitud no sea menor que 16 bytes,
          if (stringIV.Length < 16)
            // de ser así, completamos la cadena hasta un valor válido
            stringIV = stringIV.PadRight(16);
          else if (stringIV.Length > 16)//si la cadena supera los 16 bytes,
            // truncamos la cadena dejándola en 16 bytes.
            stringIV = stringIV.Substring(0, 16);
          break;
      }

      // utilizando los métodos del namespace System.Text, 
      // convertimos la cadena de caracteres en un arreglo de bytes
      // mediante el método GetBytes() del sistema de codificación UTF.
      return Encoding.UTF8.GetBytes(stringIV);
    }

    /// <summary>
    /// Cifra la cadena usando el proveedor especificado.
    /// </summary>
    /// <param name="CadenaOriginal">Cadena que será cifrada.</param>
    /// <returns>Devuelve la cadena cifrada.</returns>
    public string CifrarCadena(string CadenaOriginal)
    {
      // creamos el flujo tomando la memoria como respaldo.
      MemoryStream memStream = null;
      try {
        // verificamos que la llave y el VI han sido proporcionados.
        if (stringKey != null && stringIV != null) {
          // obtenemos el arreglo de bytes correspondiente a la llave
          // y al vector de inicialización.
          byte[] key = MakeKeyByteArray();
          byte[] IV = MakeIVByteArray();
          // convertimos el mensaje original en sus correspondiente
          // arreglo de bytes.
          byte[] textoPlano = Encoding.UTF8.GetBytes(CadenaOriginal);
          // creamos el flujo 
          memStream = new MemoryStream(CadenaOriginal.Length * 2);
          // obtenemos nuestro objeto cifrador, usando la clase 
          // CryptoServiceProvider codificada anteriormente.

          Cifrado cryptoProvider = new Cifrado((Cifrado.CryptoProvider)this.algorithm,
          Cifrado.CryptoAction.Encrypt);
          ICryptoTransform transform = cryptoProvider.GetServiceProvider(key, IV);
          // creamos el flujo de cifrado, usando el objeto cifrador creado y almancenando
          // el resultado en el flujo MemoryStream.
          CryptoStream cs = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
          // ciframos el mensaje.
          cs.Write(textoPlano, 0, textoPlano.Length);
          // cerramos el flujo de cifrado.
          cs.Close();
        }
      }
      catch {
        throw;
      }
      // la conversión se ha realizado con éxito,
      // convertimos el arreglo de bytes en cadena de caracteres, 
      // usando la clase Convert. Debido al formato UTF8 utilizado nos valemos
      // del método ToBase64String para tal fin.
      return Convert.ToBase64String(memStream.ToArray());
    }

    /// <summary>
    /// Descifra la cadena usando al proveedor específicado.
    /// </summary>
    /// <param name="CadenaCifrada">Cadena con el mensaje cifrado.</param>
    /// <returns>Devuelve una cadena con el mensaje original.</returns>
    public string DescifrarCadena(string CadenaCifrada)
    {
      // creamos el flujo tomando la memoria como respaldo.
      MemoryStream memStream = null;
      try {
        // verificamos que la llave y el VI han sido proporcionados.
        if (stringKey != null && stringIV != null) {
          // obtenemos el arreglo de bytes correspondiente a la llave
          // y al vector de inicialización.
          byte[] key = MakeKeyByteArray();
          byte[] IV = MakeIVByteArray();
          // obtenemos el arreglo de bytes de la cadena cifrada.
          byte[] textoCifrado = Convert.FromBase64String(CadenaCifrada);

          // creamos el flujo
          memStream = new MemoryStream(CadenaCifrada.Length);
          // obtenemos nuestro objeto cifrador, usando la clase 
          // CryptoServiceProvider codificada anteriormente.

          Cifrado cryptoProvider = new Cifrado((Cifrado.CryptoProvider)this.algorithm,
          Cifrado.CryptoAction.Desencrypt);
          ICryptoTransform transform = cryptoProvider.GetServiceProvider(key, IV);
          // creamos el flujo de cifrado, usando el objeto cifrador creado y almancenando
          // el resultado en el flujo MemoryStream.
          CryptoStream cs = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
          cs.Write(textoCifrado, 0, textoCifrado.Length); // ciframos
          cs.Close(); // cerramos el flujo.
        }
      }
      catch {
        throw;
      }

      // utilizamos el mismo sistema de codificación (UTF8) para obtener 
      // la cadena a partir del byte array.
      return Encoding.UTF8.GetString(memStream.ToArray());
    }

  }
}
