import { TestBed } from '@angular/core/testing';

import { SilliconPowerService } from './sillicon-power.service';

describe('SilliconPowerService', () => {
  let service: SilliconPowerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SilliconPowerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
