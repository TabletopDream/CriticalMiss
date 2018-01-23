import { TestBed, inject } from '@angular/core/testing';

import { CmItemsHttpService } from './cm-items-http.service';

describe('CmItemsHttpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CmItemsHttpService]
    });
  });

  it('should be created', inject([CmItemsHttpService], (service: CmItemsHttpService) => {
    expect(service).toBeTruthy();
  }));
});
