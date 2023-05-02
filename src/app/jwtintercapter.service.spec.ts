import { TestBed } from '@angular/core/testing';

import { JwtintercapterService } from './jwtintercapter.service';

describe('JwtintercapterService', () => {
  let service: JwtintercapterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtintercapterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
