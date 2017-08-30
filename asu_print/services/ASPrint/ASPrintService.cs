using System;
using System.Linq;
using System.Collections.Generic;
using printer.Database;
using services.ClickHouse;

namespace services.ASPrint{
    public class ASPrintService:IASPrint{
        private readonly PrinterContext _printer;

        public ASPrintService(printer.Database.PrinterContext printer){
            _printer=printer;
        }

        public IEnumerable<VPrint> GetExistPrintersByFirmId(int id)
        {
            return _printer.Printers.Where(p=>p.FirmId==id).Select(p=>
            new VPrint{
                Id=p.Id,
                Barcode=p.Barcode,
                SerialNumber=p.SerialNumber,
                Producer=p.Model.Producer.Name,
                Model=p.Model.Name,
            }
            ).AsEnumerable();
        }

        public Printer GetPrinterBySn(string id){
           return _printer.Printers.Select(p=>new Printer{
               SerialNumber=p.SerialNumber,
               Barcode=p.Barcode,
               Id=p.Id,
               FirmId=p.FirmId
           }).FirstOrDefault(p=>p.SerialNumber==id);
       }

        public void Save(Printer prn)
        {
            var dbprn=_printer.Printers.FirstOrDefault(p=>p.Id==prn.Id);
            if(dbprn==null){
                dbprn=new printer.Database.Printer();
                _printer.Printers.Add(dbprn);
            }
            dbprn.Barcode=prn.Barcode;
            dbprn.FirmId=prn.FirmId;
            dbprn.SerialNumber=prn.SerialNumber;
            dbprn.Model=_printer.Models.First(p=>p.Id==prn.ModelId);
            _printer.SaveChanges();
        }
    }

    public class Printer
    {
        public string SerialNumber { get;  set; }
        public string Barcode { get;  set; }
        public int Id { get;  set; }
        public int FirmId { get;  set; }
        public int ModelId{get;set;}
    }
}