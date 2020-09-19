import { createReducer, on } from '@ngrx/store';
import * as I18nActions from './i18n.action';
import { I18nState } from './i18n.state';
import { LocalStorageService } from '../../core';


const initialState: I18nState = {
    currentLang: LocalStorageService.getCurrentLang()
}

export const i18nReducer = createReducer<I18nState>(
    initialState,
    on(I18nActions.setDefaultLang, (state, action) => {
        LocalStorageService.setCurrentLang(action.lang);
        return {
            ...state,
            currentLang: action.lang
        };
    }),
    on(I18nActions.changeLang, (state, action)  => {
        LocalStorageService.setCurrentLang(action.lang);
        return {
            ...state,
            currentLang: action.lang
        };
    })
);
