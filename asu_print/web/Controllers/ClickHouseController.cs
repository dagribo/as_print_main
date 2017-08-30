using Microsoft.AspNetCore.Mvc;
using System.Linq;
using services.NSI;
using services.ASPrint;
using System.Collections.Generic;
using services.ClickHouse;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

[Route("api/[controller]/[action]/{id?}")]
public class ClickHouseController : Controller
{
    private readonly ICHSource _chService;
    private readonly INSI _nsi;
    

    public ClickHouseController (ICHSource chService,INSI nsi)
    {        
        _chService = chService;
        _nsi=nsi;
    
    }
    [HttpGet]
    public IEnumerable<CHPrinter> GetPrintersForPeople(int id){
        var p=_nsi.GetPeople(id);
        return _chService.GetPrintersForAccount(p.Account).ToArray();
    }

    [HttpGet]
    public IEnumerable<CHPrinter> GetPrintersForFirm(int id){
        var p=_nsi.GetPeopleFromFirm(id);
        return _chService.GetPrintersForAccounts(p.Select(a=>a.Account)).ToArray();
        
    }

    [HttpGet]
    public IEnumerable<CHExtPrinter> getExtPrinters(string id){
        return _chService.GetExtendedPrinterInfo(id).ToArray();
    }

    [HttpGet]
    public IEnumerable<CHRepPrinter> getInfoForDay(string id){
        return _chService.GetInfoForDay(id).ToArray();
    }


}