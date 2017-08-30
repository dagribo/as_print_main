import { Component,Input } from '@angular/core';
import { ClickHouseService,ExtPrinter } from '../../services/ClickHouse/click-house';

@Component({
    selector:"chfi",
    templateUrl:"./ch.fullinfo.component.html",
    styles:[".item:nth-child(odd){background: #f0f0f0; }",
".item .row {margin-left: 0px;margin-right: 0px;}",
".item .row:nth-child(2n) {background-color: aliceblue;}"
]
})
export class CHFullInfo{
    printers: ExtPrinter[];
    sn: string;
    
    constructor(private chs: ClickHouseService) {
        this.sn = 'L03010808130800540';
        this.chs.getExtPrinters(this.sn).subscribe((res)=>this.printers=res);
    }
    
    @Input() set serial(sn:string){
        this.sn=sn;
        this.chs.getExtPrinters(sn).subscribe((res)=>this.printers=res);
    }
}

