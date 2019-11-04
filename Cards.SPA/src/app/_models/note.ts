import { ModelBase } from "./model-base";
import { EntityEnum } from "./enums/entity-enum";

export class Note extends ModelBase {
    name: string = '';
    text: string = '';
    userId: string = EntityEnum.EmptyId;
    createdAt: string
}