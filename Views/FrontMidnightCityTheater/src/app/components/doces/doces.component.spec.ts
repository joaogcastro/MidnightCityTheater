import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocesComponent } from './doces.component';

describe('DocesComponent', () => {
  let component: DocesComponent;
  let fixture: ComponentFixture<DocesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DocesComponent]
    });
    fixture = TestBed.createComponent(DocesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
