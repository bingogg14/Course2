import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HotelsComponent } from './hotels/hotels.component';
import { HotelComponent } from './hotels/hotel/hotel.component';
import { HotelListComponent } from './hotels/hotel-list/hotel-list.component';
import { HotelRoomComponent } from './hotel-room/hotel-room.component';

@NgModule({
  declarations: [
    AppComponent,
    HotelsComponent,
    HotelComponent,
    HotelListComponent,
    HotelRoomComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
