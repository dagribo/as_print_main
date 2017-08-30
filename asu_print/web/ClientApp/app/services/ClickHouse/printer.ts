export class Printer{
    constructor(
        public ipAddress:string,
        public ip_address:number,
        public host_name:string,
        public login_name:string,
        public printer_name:string,
        public printer_sn:string,
        public printer_drivername:string,
        public printer_ip:string

    ){}
}

export class ExtPrinter extends Printer{
    constructor(public ipAddress:string,
        public ip_address:number,
        public host_name:string,
        public login_name:string,
        public printer_name:string,
        public printer_sn:string,
        public printer_drivername:string,
        public printer_ip:string,

        public job_count:number,
        public job_size:number,
        public job_pages:number
        
    )
    {super(ipAddress,ip_address,host_name,login_name,printer_name,printer_sn,printer_drivername,printer_ip);}
}

export class InfoDay{
    constructor(
               
        public print_job_owner:string,
        public document_name:string,
        public job_status:number,
        public job_size:number,
        public job_pages:number,
        public dt: string,

    ){}
}

