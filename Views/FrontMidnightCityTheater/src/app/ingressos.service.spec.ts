import { TestBed } from '@angular/core/testing';

import { IngressosService } from './ingressos.service';

describe('IngressosService', () => {
  let service: IngressosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IngressosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
