export interface SpaLocalStorage{
    currentLang: string;
    isAuthenticated: boolean;
    userName: string;
}

export interface SpaContainerLocalStorage {
  currentUserName: string;
  spaLocalStorages: SpaLocalStorage[];
}
