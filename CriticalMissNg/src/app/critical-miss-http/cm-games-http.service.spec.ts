import { TestBed, inject } from '@angular/core/testing';

import { CmGamesHttpService } from './cm-games-http.service';

describe('CmGamesHttpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CmGamesHttpService]
    });
  });

  it('should be created', inject([CmGamesHttpService], (service: CmGamesHttpService) => {
    expect(service).toBeTruthy();
  }));
});
