import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {CalendarModule,DataTableModule,SharedModule,SplitButtonModule,OverlayPanelModule,
    DialogModule,ConfirmationService,ConfirmDialogModule,DropdownModule} from 'primeng/primeng';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TreeModule } from 'ng2-tree';
import { FtreeComponent } from './components/ftree/ftree.component';
import { NsiService } from "./services/nsi/nsi";
import { ClickHouseService } from "./services/ClickHouse/click-house";
import { SCService } from "./services/sc/sc";
import { PrintService } from "./services/print/print";
import { PrintIdComponent } from './components/printid/printid.component';
import { PrinterList } from "./components/printid/printerlist.component";
import { PrinterStatus } from "./components/printer.status/printer.status.component"
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { PrinterEditor } from './components/printer.editor/printer.editor';
import { ScPrinterList } from './components/printid/sc.printer.list.component'
import { FormsModule } from '@angular/forms';
import { ExistPrinter,SCPrinterFullInfo,CHFullInfo } from "./components/exist.printer.list/epl";
import { CHReport } from './components/report/report.component';
import { ExcelExportModule } from '@progress/kendo-angular-excel-export';


export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        FtreeComponent,
        PrintIdComponent,
        PrinterList,
        PrinterStatus,
        PrinterEditor,
        ScPrinterList,
        ExistPrinter,
        SCPrinterFullInfo,
        CHFullInfo,
        CHReport
    ],
    entryComponents: [PrinterStatus],
    providers: [NsiService, ClickHouseService, SCService, PrintService, ConfirmationService],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'printid', component: PrintIdComponent },
            { path: 'ep', component: ExistPrinter },
            { path: 'counter', component: CounterComponent },
            { path: 'chfi', component: CHFullInfo },
            { path: 'report', component: CHReport },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ]), TreeModule, Ng2SmartTableModule, FormsModule, BrowserModule, BrowserAnimationsModule,
        CalendarModule,DataTableModule,SharedModule,SplitButtonModule,OverlayPanelModule,
        ConfirmDialogModule,DialogModule,DropdownModule, ExcelExportModule
    ]
};
