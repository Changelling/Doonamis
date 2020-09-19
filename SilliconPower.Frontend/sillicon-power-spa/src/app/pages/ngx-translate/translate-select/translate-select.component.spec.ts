import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslateSelectComponent } from './translate-select.component';

describe('TranslateSelectComponent', () => {
  let component: TranslateSelectComponent;
  let fixture: ComponentFixture<TranslateSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TranslateSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TranslateSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
