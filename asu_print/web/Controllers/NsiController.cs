using Microsoft.AspNetCore.Mvc;
using services.NSI;
using System.Collections.Generic;

[Route("api/[controller]/[action]/{id?}")]
public class NsiController : Controller
{
    private readonly INSI _nsiService;

    public NsiController(services.NSI.INSI nsiService)
    {
        _nsiService = nsiService;
    }
    [HttpGet]
    public IEnumerable<Firm> GetChildFirm(int? id)
    {
        return _nsiService.GetChildrenFirms(id);
    }

    [HttpGet]
    public IEnumerable<People> GetPeople(int id)
    {
        return _nsiService.GetPeopleFromFirm(id);
    }

    [HttpGet]
    public IEnumerable<NsiItem> GetProducers()
    {
        return _nsiService.GetProducers();
    }
    [HttpGet]
    public IEnumerable<NsiItem> GetModelsByProducer(int id)
    {
        return _nsiService.GetModelsByProducer(id);
    }

}