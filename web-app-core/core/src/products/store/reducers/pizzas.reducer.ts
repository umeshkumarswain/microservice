import { Pizza } from '../../models/pizza.model';
import * as fromPizzas from '../actions/pizza.actions';

export interface PizzaState {
  data: Pizza[];
  loaded: boolean;
  loading: boolean;
}

export const initialState: PizzaState = {
  data: [
    {
      name: 'seaside surfin',
      toppings: [
        {
          id: 6,
          name: 'mushroom',
        },
        {
          id: 7,
          name: 'olive',
        },
      ],
    },
  ],
  loaded: false,
  loading: false,
};

export function reducer(state = initialState, action: any): PizzaState {
  switch (action.type) {
    case fromPizzas.LOAD_PIZZA: {
      return {
        ...state,
        loading: true,
      };
    }

    case fromPizzas.LOAD_PIZZA_SUCCESS: {
      return {
        ...state,
        loading: false,
        loaded: true,
      };
    }

    case fromPizzas.LOAD_PIZZA_FAIL: {
      return {
        ...state,
        loading: false,
        loaded: false,
      };
    }
  }

  return state;
}
