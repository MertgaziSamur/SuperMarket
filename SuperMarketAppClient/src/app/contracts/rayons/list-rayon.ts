import { List_Product } from "../products/list_product";

export class List_Rayon {
  id: number;
  marketId: number;
  rayonType: string;
  products: List_Product[];
  createdDate: Date;
  updatedDate: Date;
}
