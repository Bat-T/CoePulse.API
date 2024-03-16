import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { BlogImage } from './model/blogImage';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  apiUrl = environment.apiBaseUrl;
  selectedImage: BehaviorSubject<BlogImage> = new BehaviorSubject<BlogImage>({
    id: '',
    title: '',
    fileExtension: '',
    fileName: '',
    dateCreated: '',
    url: '',
  });
  constructor(private http:HttpClient) { }

  uploadimage(file:File,filename:string,title:string):Observable<BlogImage>{
    //image service to upload the file
    const formdata = new FormData();
    formdata.append('file',file);
    formdata.append('filename',filename);
    formdata.append('title',title);
    return this.http.post<BlogImage>(this.apiUrl+'/api/Images',formdata);
  }

  getAllImages():Observable<BlogImage[]>{
    return this.http.get<BlogImage[]>(this.apiUrl+'/api/Images');
  }

  selectImage(image:BlogImage):void {
    this.selectedImage.next(image);
  }

  onSelectedImage():Observable<BlogImage>{
    return this.selectedImage.asObservable();
  }
}
