import { Component, OnInit } from '@angular/core';
import { LanguageViewModel } from './view-models';
import * as I18nActions from '../../../state/i18n/i18n.action';
import { Store } from '@ngrx/store';
import { State } from '../../../state/i18n/i18n.state';
import { I18nComponent } from 'src/app/core/components/i18n/i18n.component';
import { getCurrentLang } from '../../../state/i18n/i18n.selector';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'translate-select',
  templateUrl: './translate-select.component.html',
  styleUrls: ['./translate-select.component.scss']
})
export class TranslateSelectComponent extends I18nComponent implements OnInit {
  public optionList : LanguageViewModel[] = [
    { lang: 'es-ES' },
    { lang: 'en-EN' }
  ];
  public selectedLanguage: LanguageViewModel = { lang: 'es-ES' };

  constructor(
    readonly i18nStore: Store<State>, 
    readonly translate : TranslateService) { 
    super(i18nStore, translate);
    this.customCurrentLangSub = i18nStore.select(getCurrentLang).subscribe(
      currentLang => this.selectedLanguage = { lang: currentLang }
    ); 
  }

  changeLang(value: LanguageViewModel){
    this.i18nStore.dispatch(I18nActions.changeLang({lang: value.lang}));
  }

  compareFn = (o1: LanguageViewModel, o2: LanguageViewModel) => (o1 && o2 ? o1.lang === o2.lang : o1 === o2);
}
