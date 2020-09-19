import * as AppState from '../app.state';

export interface State extends AppState.State {
    i18n: I18nState;
}

export interface I18nState extends AppState.State {
    currentLang: string;
}
