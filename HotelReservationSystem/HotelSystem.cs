using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelSystem
    {
        DateValidation dateValidation = new DateValidation();
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

        /// <summary>
        /// Get cheapest hotel
        /// </summary>
        /// <param name="dates"></param>
        /// <returns>Hotel</returns>
        public Hotel GetCheapestHotel(string[] dates)
        {
            DateTime[] validatedDates = dateValidation.ValidateAndReturnDates(dates);
            hotelList.Sort((e1, e2) => e1.weekdayRatesForRegularCustomer.CompareTo(e2.weekdayRatesForRegularCustomer));
            return hotelList.First();
        }
    }
}
