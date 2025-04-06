import { Iproduct } from "./Iproduct"

export interface Pagination {
    pageNumber: number
    pageSize: number
    totalCount: number
    data: Iproduct[]
  }

 