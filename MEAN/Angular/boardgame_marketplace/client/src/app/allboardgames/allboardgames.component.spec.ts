import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllboardgamesComponent } from './allboardgames.component';

describe('AllboardgamesComponent', () => {
  let component: AllboardgamesComponent;
  let fixture: ComponentFixture<AllboardgamesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllboardgamesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllboardgamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
