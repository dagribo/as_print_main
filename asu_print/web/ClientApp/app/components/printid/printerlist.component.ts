import { Component, Input, EventEmitter, Output } from '@angular/core';
import { ClickHouseService, Printer } from '../../services/ClickHouse/click-house';
import { Ng2SmartTableModule } from "ng2-smart-table";
import { Firm, People } from "../../services/nsi/nsi";
import { SCService, SCPrinter } from "../../services/sc/sc";
import { PrinterStatus } from "../printer.status/printer.status.component"
import { Subscription } from "rxjs";



@Component({
  selector: 'plist',
  templateUrl: './printerlist.component.html'
})
export class PrinterList {
  lastRequest: Subscription=new Subscription();
  _firm: Firm;
  _people: People;
  selectedPrinter: Printer;
  @Output() addToDb = new EventEmitter<Printer>();
  public onAddToDb(printer: Printer) {
    this.addToDb.emit(printer);
  }


  public chRowSelected(arg: any) {
    var self = this;
    self.selectedPrinter = arg.data;
  }

  public loading: string;
  printers: Printer[] = [];

  @Input()
  set people(pid: People) {
    if (pid == null) return;
    this.selectedPrinter = null;
    this.loading = `Загружаем данные о принтерах для '${pid.fullName}'`;
    this._people = pid;

    var self = this;
    this.lastRequest.unsubscribe(); self.printers = [];
    this.lastRequest = this.chService.getPrintersForPeople(this._people.id).subscribe((printers) => { self.printers = printers; self.loading = null; });
  }
  get people() { return this._people; }


  @Input()
  set firm(fid: Firm) {
    if (fid == null) return;
    this.selectedPrinter = null;
    this.loading = `Загружаем данные о принтерах для '${fid.name}'`;
    this._firm = fid;
    var self = this;
    this.lastRequest.unsubscribe(); self.printers = [];
    this.lastRequest = this.chService.getPrintersForFirm(this._firm.id).subscribe((printers) => { self.printers = printers; self.loading = null; });
  }
  get firm() { return this._firm; }

  constructor(private chService: ClickHouseService) {

  }
  settings = {
    actions: { add: false, edit: false, delete: false },
    columns: {
      ipAddress: { title: 'IP-адрес ПК' },
      host_name: { title: 'Имя ПК' },
      login_name: { title: 'Имя пользователя' },
      printer_drivername: { title: 'Драйвер принтера' },
      printer_ip: { title: 'IP-адрес принтера' },
      printer_name: { title: 'Имя принтера' },
      printer_sn: { title: 'Серийный номер принтера' },
      status: { title: 'Статус', type: 'custom', renderComponent: PrinterStatus }
    },
    noDataMessage: "Принтеры не найдены"
  };

}
