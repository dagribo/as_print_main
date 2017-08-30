import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Firm } from './firm';
import { People } from "./people";
import { NsiItem } from './nsi.item';

@Injectable()
export class NsiService {
    http: Http;
    originUrl: string;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.originUrl = originUrl;
        this.http = http;
    }
    getChildFirms(id: number | string): Observable<Firm[]> {

        return this.http.get(
            `${this.originUrl}/api/Nsi/GetChildFirm/${id}`).map((data) => data.json());

    }

    getPeople(id: number | string): Observable<People[]> {
        return this.http.get(
            `${this.originUrl}/api/Nsi/GetPeople/${id}`).map((data) => data.json());
    }

    getProducers(): Observable<NsiItem[]> {
        return this.http.get(
            `${this.originUrl}/api/Nsi/GetProducers/`).map((data) => data.json());
    }

    getModelsByProducer(id: number | string): Observable<NsiItem[]> {
        return this.http.get(
            `${this.originUrl}/api/Nsi/GetModelsByProducer/${id}`).map((data) => data.json());
    }
}

