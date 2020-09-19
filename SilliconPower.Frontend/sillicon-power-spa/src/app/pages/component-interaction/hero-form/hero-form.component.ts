import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { I18nComponent } from 'src/app/core/components/i18n/i18n.component';
import { TranslateService } from '@ngx-translate/core';
import { Store } from '@ngrx/store';
import { State as I18nState } from '../../../state/i18n/i18n.state';
import { EventBusService, EmitEvent, Events } from 'src/app/core/services/event-bus/event-bus.service';
import { PasswordValidators } from 'src/app/shared';

@Component({
  selector: 'hero-form',
  templateUrl: './hero-form.component.html',
  styleUrls: ['./hero-form.component.scss']
})
export class HeroFormComponent  extends I18nComponent implements OnInit {
  heroForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private eventBus: EventBusService,
    readonly i18nStore: Store<I18nState>,
    readonly translate : TranslateService
    ) {
      super(i18nStore, translate);
  }

  ngOnInit(): void {
    this.heroForm = this.fb.group({
      heroName: [
        null, 
        [
          Validators.required, 
          Validators.minLength(6), 
          PasswordValidators.containCharacterValidator('SPA-')
        ]
      ]
    });
  }
  
  submitForm(): void {
    for (const i in this.heroForm.controls) {
      this.heroForm.controls[i].markAsDirty();
      this.heroForm.controls[i].updateValueAndValidity();
    }
    this.eventBus.emit(new EmitEvent(Events.HeroAdded, this.heroForm.value['heroName']));
    this.heroForm.reset();
  }

}
