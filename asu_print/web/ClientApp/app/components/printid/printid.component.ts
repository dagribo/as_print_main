import { Component } from '@angular/core';
import { Firm } from '../../services/nsi/firm';
import { People } from '../../services/nsi/people';
import { Printer } from "../../services/ClickHouse/click-house";
import {EditStatus} from "../printer.editor/printer.editor"

@Component({
    selector: 'pid',    
    //template:'Идентификация устройства печати'
    templateUrl:'./printid.component.html'
})
export class PrintIdComponent {

    editMode:boolean=false;
    showPrinterEditor(): void {
        this.editMode=true;
    }
    hidePrinterEditor(): void {
        this.editMode=false;
    }

    editEnded(state:EditStatus){
        this.hidePrinterEditor();
    }

    printerToAdd: Printer;
    selected: Firm = null;
    pselected:People=null;

    public onAddToDb(prn:Printer){
        this.printerToAdd=prn;
        this.showPrinterEditor();
    }

    firmSelected(firm: Firm) {
        this.pselected=null;
        this.selected=firm;        
        
    }
    peopleSelected(people:People) {
        this.selected=null;
        this.pselected=people;        
    }
}
