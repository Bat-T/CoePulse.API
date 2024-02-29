export interface UpdateBlogPost{
    title: string,
    content: string,
    urlHandle: string,
    shortDescription: string,
    isVisible: boolean,
    author: string,
    featuredImageUrl:string,
    publishedDate: Date,
    categories: string[]
}