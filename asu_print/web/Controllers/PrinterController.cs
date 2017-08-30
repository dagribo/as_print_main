using Microsoft.AspNetCore.Mvc;
using System.Linq;
using services.NSI;
using services.ASPrint;
using System.Collections.Generic;
using services.ClickHouse;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


[Route("api/[controller]/[action]/{id?}")]
public class PrinterController : Controller
{
    private readonly IASPrint _print;

    public PrinterController (IASPrint print)
    {        
        _print=print;    
    }
    [HttpGet]
    public Printer GetPrinterBySn(string id){
        return _print.GetPrinterBySn(id);
    }
    [HttpPost]
    public Printer Create([FromBody]Printer prn){
        _print.Save(prn);
        return prn;
    }
    [HttpGet]
    public IEnumerable<VPrint> GetExistPrintersByFirmId(int id){
        return _print.GetExistPrintersByFirmId( id);
    }
}

