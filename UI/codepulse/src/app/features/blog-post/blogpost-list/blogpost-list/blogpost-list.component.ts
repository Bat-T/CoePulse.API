import { Component, OnInit } from '@angular/core';
import { BlogPostService } from '../../services/blog-post.service';
import { BlogPost } from '../../models/blog-post-model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-blogpost-list',
  templateUrl: './blogpost-list.component.html',
  styleUrls: ['./blogpost-list.component.css']
})
export class BlogpostListComponent implements OnInit{

  $blogposts?: Observable<BlogPost[]>;
  constructor(private blogpostService: BlogPostService) { }
  ngOnInit(): void {
    this.$blogposts = this.blogpostService.getAllCategory();
  }

}
