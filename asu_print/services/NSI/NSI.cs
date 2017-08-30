using System;
using System.Linq;
using System.Collections.Generic;
using data.nsi;
using printer.Database;

namespace services.NSI
{
    public class NSI : INSI
    {
        private readonly nsiContext _cntx;
        private readonly PrinterContext _pct;

        public NSI (data.nsi.nsiContext cntx,printer.Database.PrinterContext pct)
        {
            _cntx = cntx;
            _pct=pct;
        }

        public IEnumerable<Firm> GetChildrenFirms (int? parent)
        {
            var res=_cntx.TreeNode.Where(p=>p.TreeId==100 && p.FirmId.HasValue);
            /*if(parent==null)
                res=res.Where(p=>!p.ParentId.HasValue);
            else//*/
                res=res.Where(p=>p.ParentId==parent);

            return res
            .Select(p=>new Firm{Id=p.Id,Name=p.Firm.ShortName,HasChildren=true/*p.InverseParent.Any()*/}).OrderBy(p=>p.Name).AsEnumerable();   
        }

        public IEnumerable<NsiItem> GetProducers(){
            return _pct.Producers.Select(p=>new NsiItem{Id=p.Id,Name=p.Name}).AsEnumerable();
        }
        public IEnumerable<NsiItem> GetModelsByProducer(int pid){
            return _pct.Models.Where(p=>p.Producer.Id==pid).Select(p=>new NsiItem{Id=p.Id,Name=p.Name}).AsEnumerable();
        }

        public People GetPeople(int id)
        {
            return _cntx.Employee.Where(p=>p.Id==id).Select(p=>new People(){Id=p.Id,
            Fio=p.Fio,
            EMail=p.Email,
            Account=p.Account,
            Post=p.Post.PostName
            }).FirstOrDefault();
        }

        public IEnumerable<People> GetPeopleFromFirm(int firmId){
            
            var res=_cntx.TreeNode.Where(p=>p.Id==firmId).SelectMany(p=>p.Firm.Employee).Where(p=>!p.IsLocked)            
            .Select(p=>new People(){Id=p.Id,
            Fio=p.Fio,
            EMail=p.Email,
            Account=p.Account,
            Post=p.Post.PostName
            }).OrderBy(p=>p.Fio);

            return res.AsEnumerable();
        }
    }
}