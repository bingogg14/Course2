
import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavAppComponent } from './nav-app.component';

describe('NavAppComponent', () => {
  let component: NavAppComponent;
  let fixture: ComponentFixture<NavAppComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ NavAppComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
