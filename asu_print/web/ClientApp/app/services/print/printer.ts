export class APrinter{
    constructor(public id:string|number,
        public fullName?:string,
        public fio?:string,
        public eMail?:string,
        public account?:string,
        public post?:string){}
}


export class VPrint{
    constructor(public id:string|number,
        public barcode:string,
        public serialNumber:string,
        public producer?:string,
        public model?:string){}
}