import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PipocasComponent } from './pipocas.component';

describe('PipocasComponent', () => {
  let component: PipocasComponent;
  let fixture: ComponentFixture<PipocasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PipocasComponent]
    });
    fixture = TestBed.createComponent(PipocasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
