using System.Collections.Generic;
namespace services.ServiceCompany{
 public interface    ISCService{
     IEnumerable<SCPrinter> GetPrintersBySn(string sn);
     IEnumerable<SCPrinter> getPrintersBySnShk(string sn);
     IEnumerable<SCPrinter> getPrintersByShk(string shk);
     
     
 }
}