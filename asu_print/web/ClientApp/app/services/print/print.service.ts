import {Injectable,Inject} from '@angular/core';
import { Http,Response,Headers } from '@angular/http';
import {Observable} from 'rxjs/Observable';
import {APrinter ,VPrint} from './printer';


@Injectable()
export class PrintService{  
    headers: Headers;
    http: Http;
    originUrl: string;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string){
        this.originUrl=originUrl;
        this.http=http;
        this.headers=new Headers();
        this.headers.append("Content-Type","application/json; charset=UTF-8");
    }    
    getPrinterBySn(id:number|string): Observable<APrinter> {       
        return this.http.get(
            `${this.originUrl}/api/Printer/GetPrinterBySn/${id}`).map((data)=>data.json());       
   }
   getExistPrintersByFirmId(id:number|string): Observable<VPrint[]>{
    return this.http.get(
        `${this.originUrl}/api/Printer/GetExistPrintersByFirmId/${id}`).map((data)=>data.json());       
   }

   newPrinter(data:any ):Observable<Response>{
       return this.http.post(
        `${this.originUrl}/api/Printer/Create`,
        JSON.stringify(data),{headers:this.headers}
       );
   }
  
}

