import {Component,Output,EventEmitter ,Input ,OnInit} from "@angular/core";
import { Printer } from '../../services/ClickHouse/click-house';
import { SCPrinter } from '../../services/sc/sc';
import {NsiItem,NsiService,Firm} from '../../services/nsi/nsi';
import {PrintService,APrinter} from '../../services/print/print';



@Component({
    selector:"pe",
    templateUrl:"./printer.editor.component.html"
})
export class PrinterEditor implements OnInit{
    ngOnInit(): void {
        
        this.nsi.getProducers().subscribe((prods)=>this.producers=prods);
    }

    constructor(private nsi:NsiService,private ps:PrintService){

    }
    pmodel:number;
    pmodels:NsiItem[];
    producers:NsiItem[];
    @Input() set producer(prod:number){
        this.nsi.getModelsByProducer(prod).subscribe((mod)=>this.pmodels=mod);
    }
    source: Printer;
    firstSearch:boolean;
    scSelected:SCPrinter;
    printerSelected(prn:SCPrinter){
        this.firstSearch=false;
        this.scSelected=prn;
    }
    print:Printer;
    @Input() firm:Firm;
    @Output() editEnded = new EventEmitter<EditStatus>();
    @Input() set sourcePrinter(print:Printer){
        this.firstSearch=true;
        this.source=print;
        this.scSearch=print.printer_sn;
        this.print=print;
    }
    scSearch:string;
    cancel(ec:any)
    {
        this.editEnded.emit(EditStatus.Canceled);
    }
    savePrinter(ev:any){
        console.log(this.scSelected);
        console.log(this.scSelected.shk);
        this.ps.newPrinter({
            serialNumber:this.print.printer_sn,
            barcode:this.scSelected.shk,
            firmId:this.firm.id,
            modelId:this.pmodel,
            id:0

        }).subscribe((p)=>this.editEnded.emit(EditStatus.Added));
    }
    changeSK(ev:any){
        this.scSelected=null;
    }
}

export enum EditStatus{
    Added,
    Canceled
}