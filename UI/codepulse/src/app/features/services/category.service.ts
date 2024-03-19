import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../category/models/add-category-request-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../category/models/category-model';
import { environment} from 'src/environments/environment';
import { UpdateCategoryRequest } from '../category/models/update-category-request-model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient,private cookie:CookieService) { }

  apiUrl = environment.apiBaseUrl;
  addCategory(model: AddCategoryRequest): Observable<void>{
    return this.http.post<void>(this.apiUrl+'/api/categories'+'?addAuth=true',model,);
  }

  getAllCateogory(): Observable<Category[]>{
    return this.http.get<Category[]>(this.apiUrl+'/api/categories/getAllcategory');
  }

  getCategorybyId(id : string): Observable<Category>{
    return this.http.get<Category>(this.apiUrl+'/api/categories/'+id);
  }

  updateCategorybyId(id : string,updateCategory: UpdateCategoryRequest): Observable<Category>{
    return this.http.put<Category>(this.apiUrl+'/api/categories/'+id+'?addAuth=true',updateCategory);
  }
  
  deleteCategorybyId(id : string): Observable<Category>{
    return this.http.delete<Category>(this.apiUrl+'/api/categories/'+id+'?addAuth=true');
  }
}
