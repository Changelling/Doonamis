import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { State } from 'src/app/state/i18n/i18n.state';
import { Store } from '@ngrx/store';
import { getCurrentLang } from '../../../state/i18n/i18n.selector';
import { LocalStorageService } from '../../services';

@Component({
  selector: 'app-i18n',
  templateUrl: './i18n.component.html'
})
export class I18nComponent implements OnInit, OnDestroy {
  private getCurrentLangSub: Subscription;
  protected customCurrentLangSub: Subscription;

  constructor(
    store: Store<State>, 
    translate: TranslateService) {
      
      translate.setDefaultLang(LocalStorageService.getCurrentLang());
      translate.use(LocalStorageService.getCurrentLang());

      this.getCurrentLangSub = store.select(getCurrentLang).subscribe((currentLang) => translate.use(currentLang));
  }

  ngOnDestroy(): void {
    this.getCurrentLangSub?.unsubscribe();
    this.customCurrentLangSub?.unsubscribe();
  }

  ngOnInit(): void {}
}
