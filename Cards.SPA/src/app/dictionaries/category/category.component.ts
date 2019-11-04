import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CategoryService } from 'src/app/_services/category.service';
import { Category } from 'src/app/_models/category';
import { EntityEnum } from 'src/app/_models/enums/entity-enum';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
})
export class CategoryComponent implements OnInit {

  @Input() _items: Category[];
  @Input() selectedItem: Category;
  @Input() isDisabled = true;
  @Output() itemChanged: EventEmitter<string>;

  @Input() set items(values: Category[]) {
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
