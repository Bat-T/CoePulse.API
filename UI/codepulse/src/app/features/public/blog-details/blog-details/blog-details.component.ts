import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { BlogPost } from 'src/app/features/blog-post/models/blog-post-model';
import { BlogPostService } from 'src/app/features/blog-post/services/blog-post.service';

@Component({
  selector: 'app-blog-details',
  templateUrl: './blog-details.component.html',
  styleUrls: ['./blog-details.component.css']
})
export class BlogDetailsComponent implements OnInit{

  private urlHandle: string = '';
  public blogPost$?:Observable<BlogPost>;
  constructor(private route: ActivatedRoute,private blogPostService:BlogPostService) { }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        this.urlHandle = params.get('urlHandle') || '';

      }
    })
    this.getBlogPostDetails();
  }

  //Fetch blog details by the urlHandle
  getBlogPostDetails(){
    this.blogPost$ = this.blogPostService.getBlogPostByUrlHandle(this.urlHandle);
  }

}
