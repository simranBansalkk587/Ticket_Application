import { TestBed } from '@angular/core/testing';

import { RoleguradService } from './rolegurad.service';

describe('RoleguradService', () => {
  let service: RoleguradService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoleguradService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
