import { NgModule } from '@angular/core';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NZ_ICONS, NzIconModule } from 'ng-zorro-antd/icon';

import {
  MenuFoldOutline,
  MenuUnfoldOutline,
  FormOutline,
  DashboardOutline
} from '@ant-design/icons-angular/icons';

const icons = [MenuFoldOutline, MenuUnfoldOutline, DashboardOutline, FormOutline];



@NgModule({
  declarations: [],
  imports: [    
    NzLayoutModule,
    NzMenuModule,
    NzIconModule
  ],
  exports: [    
    NzLayoutModule,
    NzMenuModule,
    NzIconModule
  ],
  providers: [
    { provide: NZ_ICONS, useValue: icons }
  ]
})
export class AppNgZorroModule { }
