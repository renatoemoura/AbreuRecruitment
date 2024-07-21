import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Gallery } from './models';
import { GalleryService } from './gallery.service';
import { Router } from '@angular/router';
import { ModalGalleryComponent } from '../modal-gallery/modal-gallery.component';
import { MatDialog } from '@angular/material/dialog';



@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrl: './gallery.component.css'
})

export class GalleryComponent implements OnInit {
  actualGallery: Gallery = {} as Gallery;
  galleries: Gallery[] = [];
  displayedColumns: string[] = ['name', 'city', 'manager', 'nbrWorks', 'actions'];

  constructor(private router: Router, private galleryService: GalleryService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.galleryService.getGalleries().subscribe(galleries => {this.galleries = galleries;});
  }
  ngOnChanges(): void {
    this.galleryService.getGalleries().subscribe(galleries => {this.galleries = galleries;});
  }

  editGalleryClick(galleryId: string) {
    this.galleryService.getGalleryById(galleryId).subscribe(g => {this.actualGallery = g;});
    const dialogRef = this.dialog.open(ModalGalleryComponent, {
      width: '450px',
      data: {
        id: this.actualGallery.id,
        name: this.actualGallery.name,
        city: this.actualGallery.city,
        manager: this.actualGallery.manager
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.galleryService.getGalleries().subscribe(galleries => {this.galleries = galleries;});
    });

    console.log(galleryId);
  }

  openArtWorksList(galleryId: string) {
    console.log(galleryId);
    this.router.navigate(['/art-works'], { queryParams: { actualGalleryId: galleryId }});
  }

  newGallery(): void {
    const dialogRef = this.dialog.open(ModalGalleryComponent, {
      width: '450px',
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.galleryService.getGalleries().subscribe(galleries => {this.galleries = galleries;});
    });
  }
  
  deleteGallery(id: string): void{
    this.galleryService.removeGallery(id)
    .subscribe(
      (data: any) => {
        window.location.reload();
      },
      error => {
        console.log(error);
      }
    );
  }
}
