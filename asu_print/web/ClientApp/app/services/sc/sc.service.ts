import {Injectable,Inject} from '@angular/core';
import { Http,Response } from '@angular/http';
import {Observable} from 'rxjs/Observable';
import {SCPrinter } from './scprinter';


@Injectable()
export class SCService{  
    http: Http;
    originUrl: string;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string){
        this.originUrl=originUrl;
        this.http=http;
    }    
    getPrintersBySnShk(id:string): Observable<SCPrinter[]> {
        if(id==undefined)
         id='';
         return this.http.get(
             `${this.originUrl}/api/SC/getPrintersBySnShk/${id}`).map((data)=>data.json());
        
    }

    getPrinterByShk(id:string): Observable<SCPrinter> {
        if(id==undefined)
         id='';
         return this.http.get(
             `${this.originUrl}/api/SC/getPrinterByShk/${id}`).map((data)=>data.json());
        
    }

    getPrintersBySn(id:string): Observable<SCPrinter[]> {
       if(id==undefined)
        id='';
        return this.http.get(
            `${this.originUrl}/api/SC/GetPrintersBySn/${id}`).map((data)=>data.json());
       
   }
   
}

