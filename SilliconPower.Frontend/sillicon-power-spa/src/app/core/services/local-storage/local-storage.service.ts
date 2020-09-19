import { SpaContainerLocalStorage, SpaLocalStorage } from './local-storage.model';
import { LocalStorageInitializeService } from './local-storage-initialize.service';

export class LocalStorageService {
  static customLocalStorageKey = 'dbs-spa-template-local-storage'; 

  constructor() { }
  
  private static getCurrentContainerLocalStorage() : SpaContainerLocalStorage{
    return JSON.parse(localStorage.getItem(LocalStorageService.customLocalStorageKey)) as SpaContainerLocalStorage;
  }

  private static changeLocalStorage(storageChanged: SpaLocalStorage): void {
    let containerLocalStorage = LocalStorageService.getCurrentContainerLocalStorage();
    containerLocalStorage.spaLocalStorages = containerLocalStorage.spaLocalStorages.map( currentStorage => {     
      return currentStorage.userName == storageChanged.userName ? storageChanged : currentStorage;
    });
    LocalStorageService.changeContainerLocalStorage(containerLocalStorage );
  }

  private static changeContainerLocalStorage(containerLocalStorage: SpaContainerLocalStorage): void {
    localStorage.setItem( LocalStorageService.customLocalStorageKey, JSON.stringify(containerLocalStorage) );
  }

  private static getCurrentLocalStorage() : SpaLocalStorage{
    let containerLocalStorage = LocalStorageService.getCurrentContainerLocalStorage();
    return containerLocalStorage?.spaLocalStorages?.find(storage => storage.userName == containerLocalStorage.currentUserName);
  }

  private static initializeContainerLocalStorage(userName: string){
    let containerLocalStorage = LocalStorageService.getCurrentContainerLocalStorage();
    if(!containerLocalStorage){
      containerLocalStorage = LocalStorageInitializeService.getContainerLocalStorageInitial(userName);
    } else {
      LocalStorageService.initializeLocalStorage(containerLocalStorage, userName);
    } 
    containerLocalStorage.currentUserName = userName;
    LocalStorageService.changeContainerLocalStorage(containerLocalStorage);
  }

  private static initializeLocalStorage(containerStoreage: SpaContainerLocalStorage, userName: string) {
    if(!containerStoreage.spaLocalStorages.some(storage => storage.userName == userName)){
      containerStoreage.spaLocalStorages.push(LocalStorageInitializeService.getLocalStorageInitial(userName));
    }  
  }

  //#region currentLang
  public static getCurrentLang(): string{
    let storage = LocalStorageService.getCurrentLocalStorage();
    return storage?.currentLang ?? 'es-ES';
  }

  public static setCurrentLang(lang: string){
    let storage = LocalStorageService.getCurrentLocalStorage();
    storage.currentLang = lang;
    LocalStorageService.changeLocalStorage(storage);
  }
  //#endregion
  
  //#region isAuthenticated  
  public static getIsAuthenticated(): boolean{
    let storage = LocalStorageService.getCurrentLocalStorage();
    return storage?.isAuthenticated ?? false;
  }

  public static setIsAuthenticated(isAuthenticated: boolean){
    let storage = LocalStorageService.getCurrentLocalStorage();
    storage.isAuthenticated = isAuthenticated;
    LocalStorageService.changeLocalStorage(storage);
  }
  //#endregion

  //#region userName  
  public static getUserName(): string{
    let storage = LocalStorageService.getCurrentLocalStorage();
    return storage?.userName ?? '';
  }

  public static logIn(userName: string){
    LocalStorageService.initializeContainerLocalStorage(userName);
    LocalStorageService.setIsAuthenticated(true);
  }

  public static logOut(){
    LocalStorageService.setIsAuthenticated(false);
    let containerLocalStorage = LocalStorageService.getCurrentContainerLocalStorage();
    containerLocalStorage.currentUserName = '';
    LocalStorageService.changeContainerLocalStorage(containerLocalStorage);
  }
  //#endregion

}
