import { OkResponse } from "./ok-response";
import { Category } from '../category';
import { Mode } from '../mode';
import { RepeatRate } from '../repeat-rate';
import { Card } from '../card';

export class DictionaryOkResponse extends OkResponse<Card>{
    categories: Category[] = [];
    modes: Mode[] = [];
    repeatRates: RepeatRate[] = [];
}