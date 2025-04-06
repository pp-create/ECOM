import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-pagnation',
  standalone: false,
  templateUrl: './pagnation.component.html',
  styleUrl: './pagnation.component.scss'
})
export class PagnationComponent {
@Input() totalcount:number
@Input() pagesize:number
@Output() pageChanged = new EventEmitter();

onchangepage(ev: any) {
  this.pageChanged.emit(ev);
}

}


