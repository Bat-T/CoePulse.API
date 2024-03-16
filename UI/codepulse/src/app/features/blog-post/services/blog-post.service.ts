import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { AddBlogPost } from '../models/add-blog-post-model';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/blog-post-model';
import { UpdateBlogPost } from '../models/update-blog-post-model';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {

  apiUrl = environment.apiBaseUrl;
  constructor(private http: HttpClient) { }

  
  addCategory(model: AddBlogPost): Observable<BlogPost>{
    return this.http.post<BlogPost>(this.apiUrl+'/api/BlogPosts',model);
  }

  getAllCategory(): Observable<BlogPost[]>{
    return this.http.get<BlogPost[]>(this.apiUrl+'/api/BlogPosts');
  }
  getBlogpostDetailbyId(id : string): Observable<BlogPost>{
    return this.http.get<BlogPost>(this.apiUrl+'/api/BlogPosts/'+id);
  }
  
  updateBlogPostDetail(id:string, updateblogPostModel: UpdateBlogPost): Observable<BlogPost>{
    return this.http.put<BlogPost>(this.apiUrl+'/api/BlogPosts/'+id,updateblogPostModel);
  }

  deleteBlogPost(id:string):Observable<BlogPost>{
    return this.http.delete<BlogPost>(this.apiUrl+'/api/BlogPosts/'+id);
  }

  getBlogPostByUrlHandle(urlHandle: string): Observable<BlogPost>{
    return this.http.get<BlogPost>(this.apiUrl+'/api/BlogPosts/'+urlHandle);
  }
}
