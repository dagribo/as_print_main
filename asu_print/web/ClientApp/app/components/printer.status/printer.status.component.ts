import { Component,Input,Output,EventEmitter} from '@angular/core';
import { ViewCell } from "ng2-smart-table";
import {PrintService,APrinter } from '../../services/print/print'
import {Printer} from '../../services/ClickHouse/click-house'
import {ChangeDetectorRef} from '@angular/core';


@Component({   
     selector:'ps',
    template: `
    
    <span [ngSwitch]="state">
    <span *ngSwitchCase="states.BadSN">
        Не верный серийный номер
    </span>
    <span *ngSwitchCase="states.NotInBase">
    
        Нет в базе
<button *ngIf="viewOnly==false" (click)="addToDB($event)">Добавить в базу</button>
    </span>
    <span *ngSwitchCase="states.NotInSc">
    Нет в базе СК
    </span>
    <span *ngSwitchCase="states.Good">
    OK
    </span>

    </span>
    
  `,
})
export class PrinterStatus implements ViewCell{
    states=States;
    state: States;
    val:Printer;
    @Output() addToDb = new EventEmitter<Printer>();
    public addToDB(ev:any){
        this.addToDb.emit(this.val)
    }

    @Input() viewOnly:boolean;

    constructor(private ps:PrintService,private ref:ChangeDetectorRef){}
    @Input() value: string | number;
    @Input() set rowData(val: Printer)
    {   
        this.val=val;     
        if(val==undefined)return;        
        var self=this;
        if(val.printer_sn=="-3"){
            self.state=States.BadSN;
        }
        else
            this.ps.getPrinterBySn(val.printer_sn).subscribe(p=>{
                
                if(p==null){
                    self.state=States.NotInBase;
                }
                else {
                    self.state=States.Good;
                }
                self.ref.detectChanges();
            });
        
    }
}
enum States{
    BadSN,
    NotInBase,
    NotInSc,
    Good
}