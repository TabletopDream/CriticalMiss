import { TestBed, inject } from '@angular/core/testing';

import { CmBoardsHttpService } from './cm-boards-http.service';

describe('CmBoardsHttpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CmBoardsHttpService]
    });
  });

  it('should be created', inject([CmBoardsHttpService], (service: CmBoardsHttpService) => {
    expect(service).toBeTruthy();
  }));
});
