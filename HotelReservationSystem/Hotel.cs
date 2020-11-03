using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string name;
        public int weekdayRatesForRegularCustomer;
        public int weekendRatesForRegularCustomer;
        public int rating;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Hotel()
        {
            name = "";
            weekdayRatesForRegularCustomer = 0;
            weekendRatesForRegularCustomer = 0;
            rating = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weekdayRatesForRegularCustomer"></param>
        /// <param name="weekendRatesForRegularCustomer"></param>
        /// <param name="rating"></param>
        public Hotel(string name, int weekdayRatesForRegularCustomer, int weekendRatesForRegularCustomer, int rating)
        {
            this.name = name;
            this.weekdayRatesForRegularCustomer = weekdayRatesForRegularCustomer;
            this.weekendRatesForRegularCustomer = weekendRatesForRegularCustomer;
            this.rating = rating;
        }
    }
}
