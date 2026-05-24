import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dashboardpad } from './dashboardpad.component';

describe('Dashboardpad', () => {
  let component: Dashboardpad;
  let fixture: ComponentFixture<Dashboardpad>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Dashboardpad]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Dashboardpad);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
