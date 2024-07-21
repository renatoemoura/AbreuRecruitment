import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GalleryComponent } from './gallery/gallery.component';
import { ArtWorkComponent } from './art-work/art-work.component';
import { ModalGalleryComponent } from './modal-gallery/modal-gallery.component';

const routes: Routes = [
  { path: '', component: GalleryComponent },
  { path: 'art-galleries', component: GalleryComponent },
  { path: 'art-works', component: ArtWorkComponent },
  { path: 'art-gallery-modal', component: ModalGalleryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
