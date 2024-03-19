import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { AddBlogPost } from '../models/add-blog-post-model';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/blog-post-model';
import { UpdateBlogPost } from '../models/update-blog-post-model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {

  apiUrl = environment.apiBaseUrl;
  constructor(private http: HttpClient,private cookie:CookieService) { }

  
  addCategory(model: AddBlogPost): Observable<BlogPost>{
    return this.http.post<BlogPost>(this.apiUrl+'/api/BlogPosts'+'?addAuth=true',model);
  }

  getAllCategory(): Observable<BlogPost[]>{
    return this.http.get<BlogPost[]>(this.apiUrl+'/api/BlogPosts');
  }
  getBlogpostDetailbyId(id : string): Observable<BlogPost>{
    return this.http.get<BlogPost>(this.apiUrl+'/api/BlogPosts/'+id);
  }
  
  updateBlogPostDetail(id:string, updateblogPostModel: UpdateBlogPost): Observable<BlogPost>{
    return this.http.put<BlogPost>(this.apiUrl+'/api/BlogPosts/'+id+'?addAuth=true',updateblogPostModel);
  }

  deleteBlogPost(id:string):Observable<BlogPost>{
    return this.http.delete<BlogPost>(this.apiUrl+'/api/BlogPosts/'+id+'?addAuth=true');
  }

  getBlogPostByUrlHandle(urlHandle: string): Observable<BlogPost>{
    return this.http.get<BlogPost>(this.apiUrl+'/api/BlogPosts/'+urlHandle);
  }
}
