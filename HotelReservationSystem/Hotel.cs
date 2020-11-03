using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string name;
        public int ratesForRegularCustomer;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Hotel()
        {
            name = "";
            ratesForRegularCustomer = 0;
        }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ratesForRegularCustomer"></param>
        public Hotel(string name, int ratesForRegularCustomer)
        {
            this.name = name;
            this.ratesForRegularCustomer = ratesForRegularCustomer;
        }
    }
}
