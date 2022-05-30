import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexAdminPageComponent } from './index-admin-page.component';

describe('IndexAdminPageComponent', () => {
  let component: IndexAdminPageComponent;
  let fixture: ComponentFixture<IndexAdminPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndexAdminPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndexAdminPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
