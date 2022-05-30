import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexAngularDocComponent } from './index-angular-doc.component';

describe('IndexAngularDocComponent', () => {
  let component: IndexAngularDocComponent;
  let fixture: ComponentFixture<IndexAngularDocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndexAngularDocComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndexAngularDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
