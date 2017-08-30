import {Output, Component,Input,EventEmitter } from '@angular/core';
import { SCPrinter,SCService } from "../../services/sc/sc";



@Component({
    selector:'scpl',
    templateUrl:"./sc.printer.list.component.html"})
export class ScPrinterList{
constructor(private scService:SCService){

}
    @Input() autoSelectSingle:boolean;
    rowSelected(arg:any){
        this.printerSelected.emit(arg.data);        
}

    @Output() printerSelected=new EventEmitter<SCPrinter>();
    @Input() set serialNumber(num:string){
        var self=this;
        this.scService.getPrintersBySn(num).subscribe((prints)=>self.recived(self,prints));
    }
   
    @Input() set search(num:string){
        var self=this;
        this.scService.getPrintersBySnShk(num).subscribe((prints)=>self.recived(self,prints));
    }
    recived(self:ScPrinterList,prints:SCPrinter[]){
        self.scprinters=prints;
        if(self.autoSelectSingle==true && self.scprinters.length==1){
            self.rowSelected({data:self.scprinters[0]});
        }
    }
    

    sdsettings={actions:{add:false,edit:false,delete:false},
    columns: {
      ivc: {title: 'ИВЦ'},
      rivc: {title: 'РИВЦ'},
      manufacterer: {title: 'Производитель'},
      model: {title: 'Модель'},
      phone: {title: 'Телефон'},
      owner: {title: 'Владелец'},
      shk:{title:'Штрих-код'},
      seriaL_NUM: {title: 'Серийный номер принтера'},          
      workplace: {title: 'Рабочее место'},          
      city: {title: 'Город'},          
      street: {title: 'Улица'},          
      number: {title: '№ дома'},          

    },
    noDataMessage:"В базе сервисной компании принтеры не найдены"};
    scprinters:SCPrinter[]=[];
}