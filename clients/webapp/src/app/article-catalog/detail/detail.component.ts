import { Component, OnInit } from '@angular/core';
import { ArticleCatalogService } from 'src/app/services/article-catalog.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticleCatalogDto } from 'src/app/share/models/article-catalog-dto.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  id!: string;
  isLoading = true;
  data = {} as ArticleCatalogDto;
  constructor(
    private service: ArticleCatalogService,
    private snb: MatSnackBar,
    private route: ActivatedRoute,
    public location: Location,
    private router: Router
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空

    }
  }
  ngOnInit(): void {
    this.getDetail();
  }
  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.data = res as ArticleCatalogDto;
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }
  back(): void {
    this.location.back();
  }

  edit(): void {
    this.router.navigateByUrl('/ArticleCatalog/edit/' + this.id);
  }
}
