import { Store } from '@ngrx/store';
import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { State as I18nState } from '../../state/i18n/i18n.state';
import { I18nComponent } from 'src/app/core/components/i18n/i18n.component';

@Component({
  selector: 'app-translate',
  templateUrl: './ngx-translate.component.html',
  styleUrls: ['./ngx-translate.component.scss']
})
export class NgxTranslateComponent extends I18nComponent implements OnInit {

  constructor(
    readonly i18nStore: Store<I18nState>,
    readonly translate : TranslateService
    ) {
      super(i18nStore, translate);
  }

  ngOnInit(): void {
  
  }

}


