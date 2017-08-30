import {Component} from "@angular/core";
import { Firm } from '../../services/nsi/firm';
import { People } from '../../services/nsi/people';
import { VPrint,PrintService } from '../../services/print/print';
@Component({
    selector:"existprinter",
    templateUrl:"./ep.list.component.html"
})
export class ExistPrinter{
    selected: Firm;//={id: 1816700, name: "Отдел разработки и внедрения ПО", hasChildren: true};
    pselected: People;
    constructor(private ps:PrintService){
        //this.firmSelected(this.selected);
    }
    firmSelected(firm: Firm) {
        this.pselected=null;
        this.selected=firm;       
        this.printer=null;
        if(this.selected==null)
            this.printers=[];
        else
            this.ps.getExistPrintersByFirmId(this.selected.id).subscribe((p)=>this.printers=p);
    }

    rowSelected(ev:any){
        this.printer=ev.data;
    }
    loading=null;
    printers:VPrint[];
    printer:VPrint;
    settings={
        actions:{add:false,edit:false,delete:false},
        columns: {
            producer: {title: 'Производитель'},
            model: {title: 'Модель'},
            serialNumber: {title: 'Серийный номер'},
            barcode: {title: 'Штрих-код СК'},
          
          
        },
        noDataMessage:"Принтеры не найдены"
    };
    peopleSelected(people:People) {
        this.selected=null;
        this.pselected=people;        
    }
}