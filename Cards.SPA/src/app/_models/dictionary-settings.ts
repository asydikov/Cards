import { Category } from './category';
import { Mode } from './mode';
import { RepeatRate } from './repeat-rate';
import { EntityEnum } from './enums/entity-enum';

export class DictionarySettings {
    private category = {
        items: new Array<Category>(),
        selectedItem: new Category(),
        isDisabled: true
    };

    private mode = {
        items: new Array<Mode>(),
        selectedItem: new Mode(),
        isDisabled: true
    };

    private repeatRate = {
        items: new Array<RepeatRate>(),
        selectedItem: new RepeatRate(),
        isDisabled: true
    }

    setCategoryItems(items: Category[]) {
        this.category.items = items;
    }

    setModeItems(items: Mode[]) {
        this.mode.items = items;
    }

    setRepeatRateItems(items: RepeatRate[]) {
        this.repeatRate.items = items;
    }

    setCategoryItem = (id: string) => {
        let category = this.category.items.find(x => x.id === id);
        this.category.selectedItem = category ? category : this.category.items[0];
    }

    setModeItem = (id: string) => {
        let mode = this.mode.items.find(x => x.id === id);
        this.mode.selectedItem = mode ? mode : this.mode.items[0];
    }

    setRepeatRateItem = (id: string) => {
        let repeatRate = this.repeatRate.items.find(x => x.id === id);
        this.repeatRate.selectedItem = repeatRate ? repeatRate : this.repeatRate.items[0];
    }

    setAllDisableValue(isDisabled: boolean) {
        this.category.isDisabled = this.mode.isDisabled = this.repeatRate.isDisabled = isDisabled;
    }

    setCategoryDisableValue(isDisabled: boolean) {
        this.category.isDisabled = isDisabled;
    }

    setModeDisableValue(isDisabled: boolean) {
        this.mode.isDisabled = isDisabled;
    }

    setRepeatRateDisableValue(isDisabled: boolean) {
        this.repeatRate.isDisabled = isDisabled;
    }

    get categoryItems() {
        return this.category.items;
    }

    get modeItems() {
        return this.mode.items;
    }

    get repeatRateItems() {
        return this.repeatRate.items;
    }

    get categoryItem() {
        return this.category.selectedItem;
    }

    get modeItem() {
        return this.mode.selectedItem;
    }

    get repeatRateItem() {
        return this.repeatRate.selectedItem;
    }

    get categoryId() {
        return this.category.selectedItem.id;
    }

    get modeId() {
        return this.mode.selectedItem.id;
    }

    get repeatRateId() {
        return this.repeatRate.selectedItem.id;
    }

    get isCategoryDisabled() {
        return this.category.isDisabled;
    }

    get isModeDisabled() {
        return this.mode.isDisabled;
    }

    get isRepeatRateDisabled() {
        return this.repeatRate.isDisabled;
    }


}