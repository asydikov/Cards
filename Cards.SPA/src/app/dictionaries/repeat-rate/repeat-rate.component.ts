import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { RepeatRate } from 'src/app/_models/repeat-rate';
import { EntityEnum } from 'src/app/_models/enums/entity-enum';

@Component({
  selector: 'app-repeat-rate',
  templateUrl: './repeat-rate.component.html',
})
export class RepeatRateComponent implements OnInit {

  @Input() _items: RepeatRate[];
  @Input() selectedItem: RepeatRate;
  @Input() isDisabled = true;
  @Output() itemChanged: EventEmitter<string>;

  @Input() set items(values: RepeatRate[]) {
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
