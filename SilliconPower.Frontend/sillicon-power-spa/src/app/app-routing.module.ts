import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { 
    path: '', 
    children: [
      {
        path: 'component-interaction',
        loadChildren: () => import('./pages/component-interaction/component-interaction.module').then(m => m.ComponentInteractionModule)
      },
      {
        path: 'ngx-translate',
        loadChildren: () => import('./pages/ngx-translate/ngx-translate.module').then(m => m.NgxTranslateModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
