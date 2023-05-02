import { TestBed } from '@angular/core/testing';

import { JwtactivateguradService } from './jwtactivategurad.service';

describe('JwtactivateguradService', () => {
  let service: JwtactivateguradService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtactivateguradService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
