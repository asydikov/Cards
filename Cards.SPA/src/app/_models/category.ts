import { ModelBase } from './model-base';
import { Card } from './card';

export class Category extends ModelBase {
    name: string = '';
    sort: number = 0;
    cards: Card[] = [];
}