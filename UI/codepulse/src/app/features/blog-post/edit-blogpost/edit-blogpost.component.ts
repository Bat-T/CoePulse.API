import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { BlogPostService } from '../services/blog-post.service';
import { AddBlogPost } from '../models/add-blog-post-model';
import { BlogPost } from '../models/blog-post-model';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../category/models/category-model';
import { UpdateBlogPost } from '../models/update-blog-post-model';
import { environment } from 'src/environments/environment';
import { ImageService } from 'src/app/shared/components/image.service';
import { BlogImage } from 'src/app/shared/components/model/blogImage';

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrls: ['./edit-blogpost.component.css']
})
export class EditBlogpostComponent implements OnInit, OnDestroy {



  id: string = "";
  public model?: BlogPost;
  routesubscriber?: Subscription;
  updateSubscriber?: Subscription;
  getblogPostSubscriber?: Subscription;
  imageSelectorSubscription?: Subscription;
  categories$?: Observable<Category[]>;
  updatedBlogpost$?: Observable<BlogPost>;
  selectedCategories?: string[];
  isImageSelectorVisible: boolean = false;
  constructor(private route: ActivatedRoute, private router: Router, private blogpostService: BlogPostService, private categoryService: CategoryService,private imageService: ImageService) { }

  ngOnInit(): void {

    this.categories$ = this.categoryService.getAllCateogory();

    this.routesubscriber = this.route.params.subscribe({
      next: (params) => {
        this.id = params['id'];
        if (this.id) {
          this.getblogPostSubscriber = this.blogpostService.getBlogpostDetailbyId(this.id).subscribe({
            next: (response) => {
              this.model = response;
              this.selectedCategories = this.model.categories.map(x => x.id);
            }
          })
        }

        this.imageSelectorSubscription = this.imageService.onSelectedImage().
        subscribe({
          next: (imageUrl:BlogImage) => {
            if(this.model) {
              this.model.featuredImageUrl = imageUrl.url;
              this.CloseImageSelector();
            }
          }
        })  

        
      }
    })
  }


  OnSubmit() {
    var updateBlogPost: UpdateBlogPost = {
      author: this.model ? this.model?.author : '',
      title: this.model ? this.model?.title : '',
      content: this.model ? this.model?.content : '',
      urlHandle: this.model ? this.model?.urlHandle : '',
      shortDescription: this.model ? this.model?.shortDescription : '',
      isVisible: this.model ? this.model?.isVisible : false,
      featuredImageUrl: this.model ? this.model?.featuredImageUrl : '',
      publishedDate: this.model ? this.model?.publishedDate : new Date(),
      categories: this.selectedCategories ?? []
    };

    if (this.model && this.id) {
      this.updateSubscriber = this.blogpostService.updateBlogPostDetail(this.id, updateBlogPost)
        .subscribe({
          next: () => {
            this.router.navigateByUrl('/admin/blogposts');
          },
          error: (error) => {
            // this.router.navigateByUrl('/admin/blogposts');
            // console.log(error);
          }
        })
    }

  }

  OnDelete() {
    if (this.id) {
      this.blogpostService.deleteBlogPost(this.id).subscribe({
        next: () => {
          this.router.navigateByUrl('/admin/blogposts');
        },
        error: (error) => {
          // this.router.navigateByUrl('/admin/blogposts');
          // console.log(error);
        }
      })
    }
  }


  OpenImageSelector() {
    this.isImageSelectorVisible = true;
  }

  CloseImageSelector() {
    this.isImageSelectorVisible = false;
  }
  ngOnDestroy(): void {
    this.routesubscriber?.unsubscribe();
    this.updateSubscriber?.unsubscribe();
    this.getblogPostSubscriber?.unsubscribe();
    this.imageSelectorSubscription?.unsubscribe();
  }

}
