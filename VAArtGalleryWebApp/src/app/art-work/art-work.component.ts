import { Component, Input, OnInit } from '@angular/core';
import { ArtWorkService } from './art-work.service';
import { GalleryService } from '../gallery/gallery.service';
import { ActivatedRoute } from '@angular/router';
import { Gallery } from '../gallery/models';
import { ArtWorks } from './models';


@Component({
  selector: 'app-art-work',
  templateUrl: './art-work.component.html',
  styleUrl: './art-work.component.css'
})
export class ArtWorkComponent implements OnInit {
  galleryId: any;
  gallery: Gallery = {} as Gallery;
  artWorks: ArtWorks[] = [];
  displayedColumns: string[] = ['name', 'author', 'creationYear', 'askPrice', 'actions'];

  constructor(private route: ActivatedRoute, private artWorkService: ArtWorkService, private galleryService: GalleryService) { }
  
  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => this.galleryId = params.get('actualGalleryId'));
    this.galleryService.getGalleryById(this.galleryId).subscribe(g => this.gallery = g);
    this.artWorkService.getWorksOnDisplay(this.galleryId).subscribe(artWorks => {this.artWorks = artWorks;})
  }

  deleteArtWork(id: string): void{
    this.artWorkService.deleteArtWork(id)
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
