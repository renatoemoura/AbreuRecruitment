import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';
import { GalleryService } from '../gallery/gallery.service';
import { ModalData } from './models';
import { MAT_DIALOG_DATA, MatDialog , MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-modal-gallery',
  templateUrl: './modal-gallery.component.html',
  styleUrl: './modal-gallery.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class ModalGalleryComponent {
  id: string = this.data.id;
  name: string = this.data.name;
  city: string = this.data.city;
  manager: string = this.data.manager;

  constructor(
    public dialogRef: MatDialogRef<ModalGalleryComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ModalData,
    private galleryService: GalleryService) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
  
  ngOnInit(): void {
    this.id = this.data.id;
    this.name = this.data.name;
    this.city = this.data.city;
    this.manager = this.data.manager;
  }

  addGallery(id: string, name: string, city: string, manager: string): void {
    if (id !== ""){
      this.galleryService.editGallery(id, name, city, manager)
      .subscribe(
      (data: any) => {
        console.log(data);
        window.location.reload();
      },
      error => {
        console.log(error);
      });
    } else {
      this.galleryService.addGallery(name, city, manager)
      .subscribe(
      (data: any) => {
        window.location.reload();
      },
      error => {
        console.log(error);
      });
    }
    this.dialogRef.close();
  }

  editGallery(id: string, name: string, city: string, manager: string){
    this.galleryService.editGallery(id, name, city, manager)
    .subscribe(
      (data: any) => {
        console.log(data);
        window.location.reload();
      },
      error => {
        console.log(error);
      });
    this.dialogRef.close();
  }
}
