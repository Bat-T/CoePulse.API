import { Component, OnInit, ViewChild } from '@angular/core';
import { ImageService } from '../image.service';
import { BlogImage } from '../model/blogImage';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-image-selector',
  templateUrl: './image-selector.component.html',
  styleUrls: ['./image-selector.component.css']
})
export class ImageSelectorComponent implements OnInit {


  private file?: File;
  fileName?: string;
  title?: string;
  allimages$: Observable<BlogImage[]> | undefined;
  constructor(private imageService: ImageService) { }

  @ViewChild('form', { static: false }) imageUploadForm?: NgForm;

  onFileUploadChange(event: Event): void {
    const elemnt = event?.currentTarget as HTMLInputElement;
    this.file = elemnt.files?.[0];
  }

  onSubmit(): void {
    if (this.file && this.fileName !== '' && this.title !== '') {
      //image service to upload the file
      this.imageService.uploadimage(this.file, this.fileName ?? '', this.title ?? '').subscribe({
        next: (response) => {
          console.log(response);
          this.allimages$ = this.getAllImages();
          this.imageUploadForm?.reset();
        },
        error: (error) => {
          console.log(error);
        }
      });
    }

  }

  ngOnInit(): void {
    this.allimages$ = this.getAllImages();
  }
  private getAllImages(): Observable<BlogImage[]> {
    return this.imageService.getAllImages();
  }
  selectImage(image: BlogImage) {
    this.imageService.selectImage(image);
  }

}
