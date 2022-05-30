import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SonComponentComponent } from './son-component.component';

describe('SonComponentComponent', () => {
  let component: SonComponentComponent;
  let fixture: ComponentFixture<SonComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SonComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SonComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
