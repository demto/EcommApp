import { IBasketItem } from './item';
import { v4 as uuidv4 } from 'uuid';

export interface IBasket {
    id: number;
    items: IBasketItem[];
}

export class Basket implements IBasket {
    id = uuidv4();
    items: IBasketItem[] = [];
}