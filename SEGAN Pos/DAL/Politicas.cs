using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{
  public class Politicas : DataAccess
  {

    #region Public Methods

    public List<EPK_Politica> Obtener(bool fiscal)
    {
      return context.EPK_Politica.Where(p => p.ImprimeMaquinaFiscal == fiscal).OrderBy(p => p.Nivel).ToList();
    }

    #endregion

  }
}
