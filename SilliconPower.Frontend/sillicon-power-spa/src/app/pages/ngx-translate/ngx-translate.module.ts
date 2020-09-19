import { NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NgxTranslateRoutingModule } from './ngx-translate-routing.module';
import { NgxTranslateNgZorroModule } from './ngx-translate-ng-zorro.module';
import { NgxTranslateComponent } from './ngx-translate.component';
import { TranslateOptionsComponent } from './translate-options/translate-options.component';
import { TranslateSelectComponent } from './translate-select/translate-select.component';

import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgxTranslateNgZorroModule,
    NgxTranslateRoutingModule,
    TranslateModule.forChild({
      loader: {
        provide: TranslateLoader,
        useFactory: translateHttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: true
    })
  ],
  declarations: [NgxTranslateComponent, TranslateOptionsComponent, TranslateSelectComponent],
  exports: [NgxTranslateComponent, TranslateOptionsComponent, TranslateSelectComponent]
})
export class NgxTranslateModule { }

export function translateHttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/ngx-translate/', '.json');
}
