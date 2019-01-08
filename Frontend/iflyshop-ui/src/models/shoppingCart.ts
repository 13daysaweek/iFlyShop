import { CartItem } from './cartItem';

export class ShoppingCart {
    items: CartItem[];

    getTotal(): number {
        const total = this.items.map(_ => _.quantity * _.unitPrice).reduce((p, n) => p + n);

        return total;
    }

    get total(): number {
        const total = this.items.map(_ => _.quantity * _.unitPrice).reduce((p, n) => p + n);

        return total;
    }

    constructor() {
        this.items = [];
    }
}
