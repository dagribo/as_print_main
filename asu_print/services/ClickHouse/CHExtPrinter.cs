using System;
using System.Data;
using System.Reflection;

namespace services.ClickHouse
{
    public class CHExtPrinter:CHPrinter
    {
        private static Type type=typeof(CHExtPrinter);
        public CHExtPrinter(IDataReader reader):base(reader)
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
        public ulong job_count{get;set;}
        public long job_pages{get;set;}
        public long job_size{get;set;}
        public DateTime firstTime{get;set;}
        public DateTime lastTime{get;set;}
        


    }
}