import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post-model';
import { Router } from '@angular/router';
import { BlogPostService } from '../services/blog-post.service';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../category/models/category-model';
import { Observable, Subscription } from 'rxjs';
import { ImageService } from 'src/app/shared/components/image.service';
import { BlogImage } from 'src/app/shared/components/model/blogImage';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnInit, OnDestroy {

  model: AddBlogPost;
  isImageSelectorVisible: boolean = false;
  imageSelectorSubscription?: Subscription;
  public categories$?: Observable<Category[]>;

  constructor(private blogpostService: BlogPostService, private categoryService: CategoryService, private router: Router, private imageService: ImageService) {
    this.model = {
      title: '',
      content: '',
      urlHandle: '',
      shortDescription: '',
      isVisible: true,
      author: '',
      featuredImageUrl: '',
      publishedDate: new Date(),
      categories: []
    }
  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCateogory();

    this.imageSelectorSubscription = this.imageService.onSelectedImage().
      subscribe({
        next: (imageUrl: BlogImage) => {
          if (this.model) {
            this.model.featuredImageUrl = imageUrl.url;
            this.CloseImageSelector();
          }
        }
      })
  }

  OnSubmit() {
    console.log(this.model);
    this.blogpostService.addCategory(this.model).subscribe({
      next: (response) => {
        console.log("It works");
        this.router.navigateByUrl('/admin/blogposts');
      }
    })
  }

  OpenImageSelector() {
    this.isImageSelectorVisible = true;
  }

  CloseImageSelector() {
    this.isImageSelectorVisible = false;
  }

  ngOnDestroy(): void {
    this.imageSelectorSubscription?.unsubscribe();
  }

}
