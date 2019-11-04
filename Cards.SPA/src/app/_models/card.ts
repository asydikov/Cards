import { ModelBase } from './model-base';
import { EntityEnum } from './enums/entity-enum';

export class Card extends ModelBase {
    userId: string = EntityEnum.EmptyId;;
    word: string = '';
    meaning: string = '';
    note: string = '';
    modeId: string = EntityEnum.EmptyId;
    isSaved: boolean = false;
    categoryId: string = EntityEnum.EmptyId;
    repeatRateId: string = EntityEnum.EmptyId;
    createdAt: string = '';
    updatedAt: string = '';
}
