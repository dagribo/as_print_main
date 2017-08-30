using System.Collections.Generic;

namespace services.ASPrint{
    public interface IASPrint
    {
        Printer GetPrinterBySn(string id);
        void Save(Printer prn);
        IEnumerable<VPrint> GetExistPrintersByFirmId(int id);
    }
}