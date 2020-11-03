using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelSystem
    {
        public List<Hotel> hotelList;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HotelSystem()
        {
            hotelList = new List<Hotel>();
        }

        /// <summary>
        /// Add hotels to list
        /// </summary>
        /// <param name="hotel"></param>
        public void AddHotel(Hotel hotel)
        {
            hotelList.Add(hotel);
        }
    }
}
