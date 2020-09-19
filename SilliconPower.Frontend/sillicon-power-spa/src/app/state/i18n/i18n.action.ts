import { createAction, props } from '@ngrx/store'

export const setDefaultLang = createAction('[i18n] Set default lang', props<{lang: string}>());
export const changeLang = createAction('[i18n] Change lang', props<{lang: string}>());