using System;
using System.Data;
using System.Net;
using System.Reflection;

namespace services.ClickHouse
{
    
    public class CHPrinter
    {
        private static Type type=typeof(CHPrinter);
        public CHPrinter(){}
        public CHPrinter(IDataReader reader)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var p=type.GetProperty(reader.GetName(i));
                if(p!=null){
                    p.SetValue(this,reader.GetValue (i));
                }                
            }
            
        }
        public string IpAddress{get;set;}        
        public uint ip_address{get;set;}
        public string host_name{get;set;}
        public string login_name{get;set;}
        public string printer_name{get;set;}
        public string printer_sn{get;set;}
        public string printer_drivername{get;set;}
        public string printer_ip{get;set;}
    }
}