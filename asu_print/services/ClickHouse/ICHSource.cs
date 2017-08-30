using System.Collections.Generic;

namespace services.ClickHouse{
    public interface ICHSource
    {
        IEnumerable<CHPrinter> GetPrintersForAccount(string account);
        IEnumerable<CHPrinter> GetPrintersForAccounts(IEnumerable<string> account);
        IEnumerable<CHRepPrinter> GetInfoForDay(string date);
        IEnumerable<CHExtPrinter> GetExtendedPrinterInfo(string sn);
    }
}