import { Component } from '@angular/core';


import { Firm } from "../../services/nsi/nsi";
import {Printer} from '../../services/ClickHouse/click-house'


@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    date1: Date;
    date2: Date;
    parse(dates: Date[]){
        this.date1 = dates[0];
        this.date2 = dates[1];
    }
    //000000000Q846CXXPR1a
    
    //    printer:Printer=new Printer("10.81.20.159",1,"S81020159","hq-ivcdt","HP LaserJet Professional P1102","000000000Q846CXXPR1a","HP LaserJet Professional P1102","0")   ;
    //    firm:Firm={id:1816700,name:"Her"};
    constructor(){

    }
}
