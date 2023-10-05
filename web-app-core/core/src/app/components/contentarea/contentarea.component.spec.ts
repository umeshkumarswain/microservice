import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentareaComponent } from './contentarea.component';

describe('ContentareaComponent', () => {
  let component: ContentareaComponent;
  let fixture: ComponentFixture<ContentareaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContentareaComponent]
    });
    fixture = TestBed.createComponent(ContentareaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
