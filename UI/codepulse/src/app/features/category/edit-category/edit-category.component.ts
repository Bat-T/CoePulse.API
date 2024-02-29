import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from '../../services/category.service';
import { Category } from '../models/category-model';
import { CommonModule } from '@angular/common';
import { UpdateCategoryRequest } from '../models/update-category-request-model';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit,OnDestroy {





  public id: string | null = null;
  public category: Category | null = null;
  paramsubscription?: Subscription;
  categubscription?: Subscription;
  deleteubscription?: Subscription;
  updateSubscription?: Subscription;
  constructor(private route: ActivatedRoute,private categoryService: CategoryService,private router: Router){
    this.category = {id:'',name:'', urlHandle:''};
  }
  
  ngOnInit(): void {
    this.paramsubscription = this.route.paramMap.subscribe({
      next: (params)=>{
        this.id = params.get('id');
        if(this.id)
        {
          this.categubscription = this.categoryService.getCategorybyId(this.id).subscribe(
            {
              next: (response)=>{
                this.category=response;
              }
            }
          )
        }
      }
    });
  }

  updateCategory($event: any) {
    if (!this.category) {
      this.category = $event;
  } else {
      // Handle the case where category is null, e.g., log a warning or set a placeholder value
  }
  }
  
  OnSubmit() {
    const updatecategoryRequest: UpdateCategoryRequest = {
      name: this.category?.name ?? '',
      urlHandle: this.category?.urlHandle ?? '',
    };

    if(this.category?.id)
    {
       this.categubscription= this.categoryService.updateCategorybyId(this.category?.id,updatecategoryRequest).subscribe(
        {
          next:(response)=>{
            this.router.navigateByUrl('/admin/categories')
          }
        }
       )
    }
  }

  updateCategoryUrl(url: string) {
    if (this.category) {
      this.category.urlHandle = url;
    } else {
       // Handle the case where category is null, e.g., log a warning or set a placeholder value
    }
  }

  updateCategoryname(name: any) {
    if (this.category) {
      this.category.name  = name;
    } else {
     // Handle the case where category is null, e.g., log a warning or set a placeholder value
    }
  }

  onDelete() {
  
    if(this.category?.id)
    {
       this.deleteubscription= this.categoryService.deleteCategorybyId(this.category?.id).subscribe(
        {
          next:(response)=>{
            this.router.navigateByUrl('/admin/categories')
          }
        }
       )
    }
  }

      
  ngOnDestroy(): void {
    this.paramsubscription?.unsubscribe();
    this.categubscription?.unsubscribe();
    this.categubscription?.unsubscribe();
    this.deleteubscription?.unsubscribe();
  }

}
