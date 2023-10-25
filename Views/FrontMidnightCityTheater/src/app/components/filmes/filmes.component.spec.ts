import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmesComponent } from './filmes.component';

describe('FilmesComponent', () => {
  let component: FilmesComponent;
  let fixture: ComponentFixture<FilmesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FilmesComponent]
    });
    fixture = TestBed.createComponent(FilmesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
