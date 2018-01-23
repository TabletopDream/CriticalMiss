import { TestBed, inject } from '@angular/core/testing';

import { CmHttpUrlBuilderService } from './cm-http-url-builder.service';

describe('CmHttpUrlGeneratorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CmHttpUrlBuilderService]
    });
  });

  it('should be created', inject([CmHttpUrlBuilderService], (service: CmHttpUrlBuilderService) => {
    expect(service).toBeTruthy();
  }));
});
