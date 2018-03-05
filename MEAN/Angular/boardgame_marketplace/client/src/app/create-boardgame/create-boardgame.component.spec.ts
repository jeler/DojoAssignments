import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBoardgameComponent } from './create-boardgame.component';

describe('CreateBoardgameComponent', () => {
  let component: CreateBoardgameComponent;
  let fixture: ComponentFixture<CreateBoardgameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateBoardgameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBoardgameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
