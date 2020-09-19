import { Component, OnInit, OnDestroy } from '@angular/core';
import { HeroViewModel } from './hero/view-models';
import { TranslateService } from '@ngx-translate/core';
import { Store } from '@ngrx/store';
import { State as I18nState } from '../../state/i18n/i18n.state';
import { I18nComponent } from 'src/app/core/components/i18n/i18n.component';
import { EventBusService, Events } from '../../core/services';
import { Subscription } from 'rxjs';

@Component({
  selector: 'component-interaction',
  templateUrl: './component-interaction.component.html',
  styleUrls: ['./component-interaction.component.scss']
})
export class ComponentInteractionComponent extends I18nComponent implements OnInit, OnDestroy {
  heroes: HeroViewModel[] = [];
  heroAddesSub: Subscription;

  constructor(
    private eventBus: EventBusService,
    readonly i18nStore: Store<I18nState>,
    readonly translate : TranslateService
    ) {
      super(i18nStore, translate);
  }

  ngOnInit(): void {
    this.heroes = [
      {
        id: 1,
        name: "SPA- Perico"
      }
    ];

    this.heroAddesSub = this.eventBus.on(
      Events.HeroAdded,
      (heroName: string) => this.heroes.push({id: this.heroes.length + 1, name: heroName})
    );
  }

  ngOnDestroy(): void {
    this.heroAddesSub.unsubscribe();
  }

  onHeroActionClicked(heroId: number){
    if(heroId){
      this.heroes = this.heroes.filter(hero => hero.id !== heroId);
    }
  }
 
}
