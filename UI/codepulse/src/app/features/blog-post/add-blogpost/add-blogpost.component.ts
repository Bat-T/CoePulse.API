import { Component, OnInit, inject } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post-model';
import { Router } from '@angular/router';
import { BlogPostService } from '../services/blog-post.service';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../category/models/category-model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnInit{

  model: AddBlogPost;
  public categories$?: Observable<Category[]>;

  constructor(private blogpostService: BlogPostService,private categoryService:CategoryService, private router: Router) {
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
  }

  OnSubmit() {
    console.log(this.model);
    this.blogpostService.addCategory(this.model).subscribe({
      next: (response) =>{
        console.log("It works");
        this.router.navigateByUrl('/admin/blogposts');
      }
    })
  }

}
