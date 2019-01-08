import { OrderLineItem } from './orderLineItem';

export class Order {
    customerId: number;
    items: OrderLineItem[];

    constructor() {
        this.items = [];
    }
}
