import { Category } from "../../category/models/category-model";

export interface BlogPost{
    id: string,
    title: string,
    content: string,
    urlHandle: string,
    shortDescription: string,
    isVisible: boolean,
    author: string,
    featuredImageUrl:string,
    publishedDate: Date,
    categories: Category[]
}