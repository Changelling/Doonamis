import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HeroViewModel } from './view-models';

@Component({
  selector: 'hero',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.scss']
})
export class HeroComponent implements OnInit {
  @Input() model: HeroViewModel;
  @Output() heroDeleted = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {  }

  heroActionClicked() {
    this.heroDeleted.emit(this.model.id);
  }
}
