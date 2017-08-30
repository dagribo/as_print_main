using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using Npgsql;

namespace services.ServiceCompany
{
    public class SCPrinter
    {
        private static Type tp=typeof(SCPrinter);       

        public SCPrinter(IDataRecord reader)        
        {
            for(var i=0;i<reader.FieldCount;i++){
                var name=reader.GetName(i);
                var p=tp.GetProperty(name);
                if(p!=null){
                    if(reader.IsDBNull(i))
                        p.SetValue(this,null);
                    else
                        p.SetValue(this,reader.GetValue(i));
                }
            }            
        }


        public string IVC{get;set;}
        public string RIVC{get;set;}
        public string PERSON_NAME{get;set;}
        public string DEVICE{get;set;}
        public string MANUFACTERER{get;set;}
        public string MODEL{get;set;}
        public string FLOOR{get;set;}
        public string ROOM{get;set;}
        public string PHONE{get;set;}
        public string OWNER{get;set;}
        public string DEPT{get;set;}
        public string RZD_ENTERPRISE{get;set;}
        public string SHK{get;set;}
        public string SERIAL_NUM{get;set;}
        public string INVENTORY_NUM{get;set;}
        public string STATUS{get;set;}
        public DateTime? ACCEPTED{get;set;}
        public DateTime? REMOVE{get;set;}
        public int REPAIR_NEED{get;set;}
        public int PROPHYLAXIS_NEED{get;set;}
        public string AIS_TP_NUM{get;set;}
        public DateTime? ENTRY_DATE{get;set;}
        public DateTime? LAST_CHANGE_DATE{get;set;}
        public int PRINT_COUNTER{get;set;}
        public string WORKPLACE{get;set;}
        public string RESPONSIBL{get;set;}
        public string CITY{get;set;}
        public string STREET{get;set;}
        public string NUMBER{get;set;}
    }
}