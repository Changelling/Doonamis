import { AbstractControl, ValidatorFn } from '@angular/forms';


export class PasswordValidators {
    
    public static containCharacterValidator (character: string): ValidatorFn {
        return (c: AbstractControl): { [key: string] : boolean} | null => {
            if(c.value != null && !PasswordValidators.containCharacter(c.value, character)){
                return {'containCharacter': true};
            }
            return null;
        }
    }
    
    static containCharacter(password: string, character: string): boolean{
        return password.indexOf(character) != -1;
    }
}
