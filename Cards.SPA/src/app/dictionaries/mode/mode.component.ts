import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Mode } from 'src/app/_models/mode';
import { EntityEnum } from 'src/app/_models/enums/entity-enum';

@Component({
  selector: 'app-mode',
  templateUrl: './mode.component.html',
})
export class ModeComponent implements OnInit {

  @Input() _items: Mode[];
  @Input() selectedItem: Mode;
  @Input() isDisabled = true;
  @Output() itemChanged: EventEmitter<string>;

  @Input() set items(values: Mode[]) {
    this._items = values;
    if (this._items && !this.selectedItem && this.selectedItem.id !== EntityEnum.EmptyId) {
      this.selectedItem = this._items[0];
    }
  };

  constructor() {
    this.itemChanged = new EventEmitter();
  }

  ngOnInit() { }

  selected() {
    this.itemChanged.emit(this.selectedItem.id);
  }

}
