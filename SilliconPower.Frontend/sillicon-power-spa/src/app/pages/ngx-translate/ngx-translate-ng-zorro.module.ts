import { NgModule } from '@angular/core';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzSelectModule } from 'ng-zorro-antd/select';

@NgModule({
  declarations: [],
  imports: [    
    NzListModule,
    NzSelectModule
  ],
  exports: [    
    NzListModule,
    NzSelectModule
  ]
})
export class NgxTranslateNgZorroModule { }
