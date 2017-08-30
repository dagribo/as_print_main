using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using services.ServiceCompany;

[Route("api/[controller]/[action]/{id?}")]
public class SCController : Controller
{
    private readonly ISCService _sc;

    public SCController (ISCService sc)
    {
        _sc = sc;
    }
    [HttpGet]
    public IEnumerable<SCPrinter> GetPrintersBySn(string id){
        return _sc.GetPrintersBySn(id).ToArray();;
    }
    [HttpGet]
    public IEnumerable<SCPrinter> GetPrintersBySnShk(string id){
        return _sc.getPrintersBySnShk(id).ToArray();
    }

    [HttpGet]
    public SCPrinter GetPrinterByShk(string id){
        return _sc.getPrintersByShk(id).FirstOrDefault();

    }
    
}