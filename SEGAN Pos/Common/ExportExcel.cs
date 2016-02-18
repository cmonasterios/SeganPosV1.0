using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace SEGAN_POS
{
  public class ExportExcel
  {

    #region Public Methods

    public bool DumpExcel<T>(List<T> list, string filename)
    {
      try {
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);

        if (fileInfo.Exists)
          fileInfo.Delete();

        using (ExcelPackage pck = new ExcelPackage(fileInfo)) {
          ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Export");
          ws.Cells["A1"].LoadFromCollection(list, true);
          pck.Save();
        }
        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    #endregion

  }
}