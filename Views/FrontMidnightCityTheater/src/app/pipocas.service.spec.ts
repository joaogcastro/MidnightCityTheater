import { TestBed } from '@angular/core/testing';

import { PipocasService } from './pipocas.service';

describe('PipocasService', () => {
  let service: PipocasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PipocasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
