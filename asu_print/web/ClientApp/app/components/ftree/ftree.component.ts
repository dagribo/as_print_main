import { Component,Output,EventEmitter,Input } from '@angular/core';
import { TreeModel,Ng2TreeSettings,NodeEvent } from 'ng2-tree';
import {NsiService,Firm,People  } from "../../services/nsi/nsi";


@Component({
    selector: 'ftree',
    template:'<tree [tree]="tree" [settings]="settings" (nodeSelected)="onNodeSelected($event)"></tree>' 
})
export class FtreeComponent {
    @Output() firmSelected = new EventEmitter<Firm>();
    @Output() peopleSelected = new EventEmitter<People>();
    @Output() itemSelected = new EventEmitter<People|Firm>();
    
    public onNodeSelected(e: NodeEvent): void {        
        if(e.node.isLeaf()){
            var p:People=new People( e.node.node.id,e.node.value.toString());
            this.peopleSelected.emit(p);
            this.itemSelected.emit(p);
            return;
        }
        if(!e.node.isLeaf()){
            var f=new Firm(e.node.node.id,e.node.value.toString());
            this.firmSelected.emit(f);
            this.itemSelected.emit(f);
            return;
        }
        throw "Unknown type";
        /*
        var res:People;
        res=<People>e.node.node;
        console.log(res);
        var hasChild=e.node.node.loadChildren!=null;
        var f:Firm={
            hasChildren:hasChild,
            id:Number(e.node.node.id),
            name: e.node.node.value.toString()
        };
        
        this.tree
        this.firmSelected.emit(f);//*/
      }

    LoadSub(firm: Firm, callback: (children: TreeModel[]) => void,self:FtreeComponent): void {
        self.nsiService.getChildFirms(firm.id).subscribe(
            (items)=>{                
                if(self.showPeople)
                    self.nsiService.getPeople(firm.id).subscribe(
                        (people)=>{
                            callback(
                            items.map((f)=>self.createNode(f,self)).concat(
                                people.map((p)=>self.createNodeFromPeople(p,self))
                            ));
                        }
                    )
                else
                    callback(items.map((f)=>self.createNode(f,self)));                
                
            }
        );
    }
    createNode(firm: Firm, self: FtreeComponent): TreeModel {
        var res:TreeModel={
            id:firm.id,
            value:firm.name,
            
        }
        if(firm.hasChildren)
            res.loadChildren=(callback)=>{self.LoadSub(firm,callback,self);}                
        return res;
    }

    createNodeFromPeople(people: People, self: FtreeComponent): TreeModel {
        var res:TreeModel={
            id:people.id,
            value:`${people.fio} - ${people.post}`
            
        }        
        return res;
    }

    

    rootFirmsLoaded(firms: Firm[], self: FtreeComponent): void { 
        var tmp:TreeModel={value:"1",settings:{static:true,    cssClasses:{
            expanded:"glyphicon glyphicon-folder-open",
            collapsed:"glyphicon glyphicon-folder-close",                    
            leaf:"glyphicon glyphicon-user"
        }}};
        tmp.children=[];
        firms.forEach((f)=>{
            
            tmp.children.push(self.createNode(f,self));
               
        });
        
        self.tree=tmp;
    }//*/
    @Input() showPeople:boolean=false;
    public constructor(private nsiService: NsiService) {
        var self=this;
        nsiService.getChildFirms(null).subscribe((items)=>this.rootFirmsLoaded(items,self));        
    }
    public settings: Ng2TreeSettings = {
        rootIsVisible: false
      };
    public tree: TreeModel=null;
}
