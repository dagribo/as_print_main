using System;
using System.Collections.Generic;
using System.Linq;
using ClickHouse.Ado;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace services.ClickHouse
{
    public class CHSource : ICHSource
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;

        public CHSource (IConfigurationRoot config, ILogger<CHSource> logger)
        {
            _logger = logger;
            _connectionString = config.GetConnectionString ("ClickHouse");
            /* 
                        using (var cnn = new ClickHouseConnection(config.GetConnectionString("ClickHouse"))){
                            cnn.Open();                
                            using (var cmd = cnn.CreateCommand("SELECT * FROM asu_print2.print_jobs LIMIT 5;"))
                            using (var reader = cmd.ExecuteReader())
                            {
                                do
                                {
                                    while (reader.Read())
                                    {                            
                                        for (var i = 0; i < reader.FieldCount; i++)
                                        {
                                            System.Console.Write(reader.GetValue(i));                                
                                            System.Console.Write("\t");
                                        }                            
                                        System.Console.WriteLine();
                                    }                        
                                } while (reader.NextResult());
                            }                
                        
                        }
                        //*/
        }

        public IEnumerable<CHExtPrinter> GetExtendedPrinterInfo(string sn)
        {
            if (!string.IsNullOrEmpty (sn))
            {                
                {                    
                    var query = $@"select 
IPv4NumToString(ip_address) as IpAddress,ip_address,host_name,login_name,printer_name,printer_sn,printer_drivername,printer_ip
print_job_owner,count(row_id) as jobs_count,sum(job_pages)as jobs_pages,sum(job_size) as job_size,toDate(min(long_date)) as firstTime,toDate(max(long_date)) as lastTime from print_jobs

where printer_sn='{sn}'
group by IpAddress,printer_sn,print_job_owner,ip_address,host_name,login_name,printer_name,printer_sn,printer_drivername,printer_ip";
                    using (var con = new ClickHouseConnection (_connectionString))
                    {
                        con.Open ();
                        using (var cmd = con.CreateCommand (query))
                        using (var reader = cmd.ExecuteReader ())
                        {
                            do {
                                while (reader.Read ())
                                {
                                    yield return new CHExtPrinter (reader);
                                }
                            } while (reader.NextResult ());
                        }
                        yield break;
                    }
                }
            }
        }

        public IEnumerable<CHPrinter> GetPrintersForAccount (string account)
        {
            if (!string.IsNullOrEmpty (account))
            {
                var parts = account.Split (new [] { '@' }, 2);
                if (parts.Length == 2)
                {
                    var dom = parts[1].Split (new [] { '.' }, 2)[0].ToUpper ();
                    if (dom == "SERW") { dom = "SERWRZD"; }
                    var query = $"SELECT distinct IPv4NumToString(ip_address) as IpAddress,ip_address,host_name,login_name,printer_name,printer_sn,printer_drivername,printer_ip from asu_print2.print_jobs where domain='{dom}' and print_job_owner='{parts[0].ToLower()}'";
                    using (var con = new ClickHouseConnection (_connectionString))
                    {
                        con.Open ();
                        using (var cmd = con.CreateCommand (query))
                        using (var reader = cmd.ExecuteReader ())
                        {
                            do {
                                while (reader.Read ())
                                {
                                    yield return new CHPrinter (reader);
                                }
                            } while (reader.NextResult ());
                        }
                        yield break;
                    }
                }
            }
        }

        public IEnumerable<CHPrinter> GetPrintersForAccounts (IEnumerable<string> accounts)
        {
            var query = new System.Text.StringBuilder ("SELECT distinct IPv4NumToString(ip_address) as IpAddress,ip_address,host_name,login_name,printer_name,printer_sn,printer_drivername,printer_ip from asu_print2.print_jobs where ");

            var where =
                string.Join (" OR ",
                    accounts.Where (account => !string.IsNullOrEmpty (account))
                    .Select (account => account.Split (new [] { '@' }, 2))
                    .Where (p => p.Length == 2)
                    .Select (p => new { dom = p[1].Split (new [] { '.' }, 2)[0].ToUpper (), name = p[0].ToLower () })
                    .Select (p => new { dom = p.dom == "SERW" ? "SERWRZD" : p.dom, p.name })
                    .Select (p => $"(domain='{p.dom}' and print_job_owner='{p.name}')"));
            if (where.Length == 0) yield break;
            query.Append (where);
            //_logger.LogDebug ($"ClickHouse query: {query}");
            using (var con = new ClickHouseConnection (_connectionString))
            {
                con.Open ();
                using (var cmd = con.CreateCommand (query.ToString ()))
                using (var reader = cmd.ExecuteReader ())
                {
                    do {
                        while (reader.Read ())
                        {
                            yield return new CHPrinter (reader);
                        }
                    } while (reader.NextResult ());
                }
                yield break;
            }
        }


        public IEnumerable<CHRepPrinter> GetInfoForDay(string date)
        {
            if (!string.IsNullOrEmpty (date))
            {                
                {      
            
                    var query = $@"select job_pages, job_size, job_status, document_name, print_job_owner, dt from print_jobs limit 100 ";
                    using (var con = new ClickHouseConnection (_connectionString))
                    {
                        con.Open ();
                        using (var cmd = con.CreateCommand (query))
                        using (var reader = cmd.ExecuteReader ())
                        {
                            do {
                                while (reader.Read ())
                                {
                                    yield return new CHRepPrinter (reader);
                                }
                            } while (reader.NextResult ());
                        }
                        yield break;
                    }
                }
            }
        }


    }
}