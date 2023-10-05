import { Topping } from './Topping.model';

export interface Pizza {
  id?: number;
  name?: string;
  toppings?: Topping[];
}
