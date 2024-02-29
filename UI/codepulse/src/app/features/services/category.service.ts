import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../category/models/add-category-request-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../category/models/category-model';
import { environment} from 'src/environments/environment';
import { UpdateCategoryRequest } from '../category/models/update-category-request-model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  apiUrl = environment.apiBaseUrl;
  addCategory(model: AddCategoryRequest): Observable<void>{
    return this.http.post<void>(this.apiUrl+'/api/categories',model);
  }

  getAllCateogory(): Observable<Category[]>{
    return this.http.get<Category[]>(this.apiUrl+'/api/categories/getAllcategory');
  }

  getCategorybyId(id : string): Observable<Category>{
    return this.http.get<Category>(this.apiUrl+'/api/categories/'+id);
  }

  updateCategorybyId(id : string,updateCategory: UpdateCategoryRequest): Observable<Category>{
    return this.http.put<Category>(this.apiUrl+'/api/categories/'+id,updateCategory);
  }
  
  deleteCategorybyId(id : string): Observable<Category>{
    return this.http.delete<Category>(this.apiUrl+'/api/categories/'+id);
  }
}
