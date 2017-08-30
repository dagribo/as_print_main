import { Component, Input, EventEmitter, Output } from '@angular/core';
import { PrinterModel } from './printermodel';

@Component({
    selector: 'printermodel',
    templateUrl: './printermodel.component.html',
    styles : ['./printermodel.component.css']
})
export class PrinterModelComponent {

    @Input() printermodel : PrinterModel;
    @Output() printer_infoChange = new EventEmitter<PrinterModel>();
   
    onPrinterInfoChange(model : PrinterModel){
        alert("Opps");
        this.printermodel = model;
        this.printer_infoChange.emit(model);
    }
}