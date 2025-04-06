export interface Iproduct {
    name: string
    description: string
    categoryName: string
    photo: IPhoto[]
    oldprice: number
    id: number
    newprice: number
  }
  
  export interface IPhoto {
    imageName: string
    productid: number
  }
  