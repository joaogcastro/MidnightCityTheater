import { TestBed } from '@angular/core/testing';

import { DocesService } from './doces.service';

describe('DocesService', () => {
  let service: DocesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DocesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
