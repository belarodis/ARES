import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalNotebook } from './modal-notebook';

describe('ModalNotebook', () => {
  let component: ModalNotebook;
  let fixture: ComponentFixture<ModalNotebook>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalNotebook]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalNotebook);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
