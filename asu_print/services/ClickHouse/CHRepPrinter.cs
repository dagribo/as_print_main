using System;
using System.Data;
using System.Net;
using System.Reflection;

namespace services.ClickHouse
{
    public class CHRepPrinter
    {
        private static Type type=typeof(CHRepPrinter);
        public CHRepPrinter(){}
        public CHRepPrinter(IDataReader reader)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var p=type.GetProperty(reader.GetName(i));
                if(p!=null){
                    p.SetValue(this,reader.GetValue (i));
                }                
            }
        }

        
        public string print_job_owner{get;set;}
        public string document_name{get;set;}
        public int job_status{get;set;}
        public long job_pages{get;set;}
        public long job_size{get;set;}
        public System.DateTime dt{get;set;}
        
    }
}