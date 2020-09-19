import { createFeatureSelector, createSelector } from '@ngrx/store';
import { I18nState } from './i18n.state'

const getI18nFeatureState = createFeatureSelector<I18nState>('i18n');

export const getCurrentLang = createSelector(
    getI18nFeatureState,
    i18n => i18n.currentLang
);
