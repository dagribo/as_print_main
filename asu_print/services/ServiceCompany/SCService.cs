using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using data.nsi;
using NpgsqlTypes;

namespace services.ServiceCompany{

    public class SCService : ISCService,IDisposable
    {
        private readonly nsiContext _nsi;

        public SCService(data.nsi.nsiContext nsi){
            _nsi=nsi;
        }

        public void Dispose()
        {
            _nsi.Dispose();
        }
private readonly string select=@"""IVC"",
""RIVC"",
""PERSON_NAME"",
""DEVICE"",
""MANUFACTERER"",
""MODEL"",
""FLOOR"",
""ROOM"",
""PHONE"",
""OWNER"",
""DEPT"",
""RZD_ENTERPRISE"",
""SHK"",
""SERIAL_NUM"",
""INVENTORY_NUM"",
""STATUS"",
NULLIF(""ACCEPTED"",'0001-01-01 BC') as ""ACCEPTED"",
NULLIF(""REMOVED"",'0001-01-01 BC') as ""REMOVED"", 
""REPAIR_NEED"",
""PROPHYLAXIS_NEED"",
""AIS_TP_NUM"", 
NULLIF(""ENTRY_DATE"", '0001-01-01 BC') as ""ENTRY_DATE"",
NULLIF(""LAST_CHANGE_DATE"",'0001-01-01 BC') as ""LAST_CHANGE_DATE"", 
""PRINT_COUNTER"",
""WORKPLACE"",
""RESPONSIBLE"",
""CITY"",
""STREET"",
""NUMBER""";
        public IEnumerable<SCPrinter> GetPrintersBySn(string sn)
        {
            var con=_nsi.Database.GetDbConnection();
            con.Open();
            using(var rd=new Npgsql.NpgsqlCommand($@"SELECT 
{select}
FROM public.sd_printers where ""SERIAL_NUM"" like @sn limit 100;",(Npgsql.NpgsqlConnection) con)){
                rd.Parameters.AddWithValue("@sn",NpgsqlDbType.Varchar,200,$"%{sn}%");                
                using(var reader=rd.ExecuteReader()){
                    while(reader.Read()){
                        yield return new SCPrinter(reader);
                    }
                }
                
            }
        }

        public IEnumerable<SCPrinter> getPrintersBySnShk(string sn)
        {
            var con=_nsi.Database.GetDbConnection();
            con.Open();
            using(var rd=new Npgsql.NpgsqlCommand($@"SELECT 
{select}
FROM public.sd_printers where ""SERIAL_NUM"" like @sn or ""SHK"" like @sn limit 100;",(Npgsql.NpgsqlConnection) con)){
                rd.Parameters.AddWithValue("@sn",NpgsqlDbType.Varchar,200,$"%{sn}%");                
                using(var reader=rd.ExecuteReader()){
                    while(reader.Read()){
                        yield return new SCPrinter(reader);
                    }
                }
                
            }
        }

        public IEnumerable<SCPrinter> getPrintersByShk(string shk)
        {
            var con=_nsi.Database.GetDbConnection();
            con.Open();
            using(var rd=new Npgsql.NpgsqlCommand($@"SELECT 
{select}
FROM public.sd_printers where ""SHK"" = @sn limit 100;",(Npgsql.NpgsqlConnection) con)){
                rd.Parameters.AddWithValue("@sn",NpgsqlDbType.Varchar,200,$"{shk}");                
                using(var reader=rd.ExecuteReader()){
                    while(reader.Read()){
                        yield return new SCPrinter(reader);
                    }
                }
                
            }
        }
    }
}