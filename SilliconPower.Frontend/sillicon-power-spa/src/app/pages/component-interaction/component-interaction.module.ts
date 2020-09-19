import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentInteractionComponent } from './component-interaction.component';
import { ComponentInteractionRoutingModule } from './component-interaction-routing.module';
import { ComponentInteractionNgZorroModule } from './component-interaction-ng-zorro.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HeroComponent } from './hero/hero.component';
import { HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HeroFormComponent } from './hero-form/hero-form.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ComponentInteractionRoutingModule,
    ComponentInteractionNgZorroModule,
    TranslateModule.forChild({
      loader: {
        provide: TranslateLoader,
        useFactory: translateHttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: true
    })
  ],
  declarations: [ComponentInteractionComponent, HeroComponent, HeroFormComponent],
  exports: [ComponentInteractionComponent]
})
export class ComponentInteractionModule { }

export function translateHttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/component-interaction/', '.json');
}