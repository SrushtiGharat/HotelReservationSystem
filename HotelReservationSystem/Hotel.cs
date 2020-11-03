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

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Hotel()
        {
            name = "";
            weekdayRatesForRegularCustomer = 0;
            weekendRatesForRegularCustomer = 0;

        }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weekdayRatesForRegularCustomer"></param>
        /// <param name="weekendRatesForRegularCustomer"></param>
        public Hotel(string name, int weekdayRatesForRegularCustomer, int weekendRatesForRegularCustomer)
        {
            this.name = name;
            this.weekdayRatesForRegularCustomer = weekdayRatesForRegularCustomer;
            this.weekendRatesForRegularCustomer = weekendRatesForRegularCustomer;
        }
    }
}
