import { TestBed } from '@angular/core/testing';

import { CopagoService } from './copago.service';

describe('CopagoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CopagoService = TestBed.get(CopagoService);
    expect(service).toBeTruthy();
  });
});
