import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Printer,ExtPrinter,InfoDay} from './printer';

@Injectable()
export class ClickHouseService {
    http: Http;
    originUrl: string;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.originUrl = originUrl;
        this.http = http;
    }

    getPrintersForPeople(id: number | string): Observable<Printer[]> {
        return this.http.get(
            `${this.originUrl}/api/ClickHouse/GetPrintersForPeople/${id}`).map((data) => data.json());
    }

    getPrintersForFirm(id: number | string): Observable<Printer[]> {
        return this.http.get(
            `${this.originUrl}/api/ClickHouse/GetPrintersForFirm/${id}`).map((data) => data.json());
    }

    getExtPrinters(sn: number | string): Observable<ExtPrinter[]> {
        return this.http.get(
            `${this.originUrl}/api/ClickHouse/getExtPrinters/${sn}`).map((data) => data.json());
    }

    getInfoForDay(sn:number | string): Observable<InfoDay[]> {
        return this.http.get(
            `${this.originUrl}/api/ClickHouse/getInfoForDay/${sn}`).map((data) => data.json());
    }
}