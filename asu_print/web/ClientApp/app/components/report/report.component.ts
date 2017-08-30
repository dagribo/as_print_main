import { Component,Input, OnInit, Output, EventEmitter} from '@angular/core';
import { InfoDay } from '../../services/ClickHouse/printer';
import { MenuItem, OverlayPanel } from 'primeng/primeng';
import { SelectItem } from 'primeng/primeng';

@Component({
    selector:"report",
    templateUrl:"./report.component.html",
    styles:[".item:nth-child(odd){background: #f0f0f0; }",
".item .row {margin-left: 0px;margin-right: 0px;}",
".item .row:nth-child(2n) {background-color: aliceblue;}",
".exel_but {position:absolute;margin-left: 1300px;margin-top: -90px}"
    ]})

export class CHReport implements OnInit {

    @Output() dateChanged = new EventEmitter<Date[]>();

    @Input() trueDate1: Date;
    @Input() trueDate2: Date;

    printers: InfoDay[];
    public cellOpt: any = {
        textAlign: 'center',
        borderBottom: 'black', 
        borderRight: 'black'
    };

    today: Date = new Date();
    date1: Date;
    date2: Date;
    ru: any;
    items: MenuItem[];
    display: boolean = false;
    condition: number;
    header: string = "За месяц";
    subHeader: string = this.header;

    months: SelectItem[];
    selectedMonth: any;

    years: SelectItem[];
    selectedYear: any;

    quarters: SelectItem[];
    selectedQuarter: any;
    
    constructor() {
        const rusMonth = ['Январь', 'Февраль','Март','Апрель','Май','Июнь','Июль','Август','Сентябрь','Октябрь','Ноябрь','Декабрь'];
        let i = 0;
        this.months = [];
        rusMonth.forEach((month)=>{
                this.months.push({
                    label: month,
                    value: {id: i++, name: month, code: month.slice(0,3)}
                })
        });
   
        this.years = [];
        for(let i = new Date().getFullYear(); i > 2000; --i){
            this.years.push({
                label:i.toString(),
                value:{id: i, name: i, code: i}
            });
        }    
        
        this.quarters = [];
        for(let i = 1; i < 5; ++i){
            this.quarters.push({
                label:i.toString(),
                value:{id: i - 1, name: i, code: i}
            });
        }
    }

    ondateChanged(){
        let dates = [];
        dates.push(this.trueDate1);
        dates.push(this.trueDate2);
        this.dateChanged.emit(dates);   
    }

    formatDate(date: Date): string {
        const strDate = date.toLocaleDateString();
        return strDate.slice(0,2) + '.' + strDate.slice(3,5) +'.' + strDate.slice(-4);
    }

    copyDatesForward(){
        this.date1 = this.trueDate1;
        this.date2 = this.trueDate2;
    }

    copyDatesBack(){
        this.trueDate1 = this.date1;
        this.trueDate2 = this.date2;
    }

    clearDropDown(cond: boolean){
        if (cond)
            this.subHeader = this.header;
        this.selectedMonth = this.months[this.trueDate1.getMonth()].value;
        this.selectedYear = this.years[this.today.getFullYear() - this.trueDate1.getFullYear()].value;
        this.selectedMonth = this.quarters[Math.floor(this.trueDate1.getMonth() /3)].value;
    }

    choosedYearOrMonth(){
        this.date1 = new Date(this.selectedYear.id, this.selectedMonth.id, 1);
        if (this.selectedMonth.id === this.today.getMonth() && this.selectedYear.id === this.today.getFullYear())
            this.date2 = this.today;
        else
            this.date2 = new Date(this.selectedYear.id, this.selectedMonth.id + 1, 0);
    }

    choosedYearOrQuarter(){
        this.date1 = new Date(this.selectedYear.id, this.selectedQuarter.id*3, 1);
        if (this.selectedQuarter.id === Math.floor(this.today.getMonth() / 3) && this.selectedYear.id === this.today.getFullYear())
            this.date2 = this.today;
        else
            this.date2 = new Date(this.selectedYear.id, this.selectedQuarter.id*3 + 3, 0);
    }

    showDialog(header: string, cond: number) {
        this.header = header;
        this.condition = cond;
        this.display = true;
    }
    
    parseTime(date: Date): string {
        const strDate = date.toLocaleDateString();
        return strDate.slice(-4) + "-" + strDate.slice(3,5) + "-" + strDate.slice(0,2);
    }

    sinceTheBeginningOfTheYear(){
        this.date1 = new Date(this.today.getFullYear(),0,1);
        this.date2 = this.today;
    }

    dropCurrentOption(){
        this.items.find(res => res.label === this.header).command();
    }

    ngOnInit() {
      //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
      //Add 'implements OnInit' to the class.
        this.ru = {
            firstDayOfWeek: 1,
            dayNames: ["Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"],
            dayNamesShort: ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"],
            dayNamesMin: ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"],
            monthNames: [ "Январь","Февраль","Март","Апрель","Май","Июнь","Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь" ],
            monthNamesShort: [ "Янв", "Фев", "Март", "Апр", "Май", "Июн","Июл", "Авг", "Сен", "Окт", "Ноя", "Дек" ]
        }

        this.items = [
            {label: 'Сутки',command: () => {
                this.date1 = this.trueDate1;
                this.date2 = null;
                this.showDialog("Сутки", 2);
            }},
            {label: 'За период', command: () => {
                this.copyDatesForward();
                this.showDialog("За период", 2); 
            }},
            {label: 'С начала года', command: () => {
                this.copyDatesForward(); 
                this.sinceTheBeginningOfTheYear();
                this.showDialog("С начала года ", 1);
            }},
            {label: 'За месяц',  command: () => {
                this.selectedMonth = this.months[this.trueDate1.getMonth()].value;
                this.selectedYear = this.years[this.today.getFullYear() - this.trueDate1.getFullYear()].value;
                this.choosedYearOrMonth();
                this.showDialog("За месяц", 3);
            }},
            {label: 'За квартал', command: () => {
                this.selectedMonth = this.quarters[Math.floor(this.trueDate1.getMonth() /3)].value;
                this.selectedYear = this.years[this.today.getFullYear() - this.trueDate1.getFullYear()].value;
                this.choosedYearOrQuarter();
                this.showDialog("За квартал", 3);
            }},
        ];

        this.selectedMonth = this.months[this.today.getMonth()].value;
        this.selectedYear = this.years[0].value; 
        this.choosedYearOrMonth();    
        this.copyDatesBack();
        this.selectedQuarter = this.quarters[Math.floor(this.today.getMonth() /3)].value;
        this.ondateChanged();
  }

}

