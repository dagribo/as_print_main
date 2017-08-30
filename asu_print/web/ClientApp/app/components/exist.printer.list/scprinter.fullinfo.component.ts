import { Component,Input } from '@angular/core';
import { SCPrinter,SCService } from "../../services/sc/sc";


@Component({selector:"scpfi",templateUrl:"./scprinter.fullinfo.component.html",
styles:[".item:nth-child(odd){background: #f0f0f0; }",
".item .row {margin-left: 0px;margin-right: 0px;}",
".item .row:nth-child(2n) {background-color: aliceblue;}"
]
})
export class SCPrinterFullInfo{
    constructor(private scService:SCService){}
    printer:SCPrinter;
    _shk:string;
    @Input() set shk(shk:string){
        var self=this;
        self._shk=shk;
        this.scService.getPrinterByShk(shk).subscribe((printer)=>self.printer=printer);
    }
}