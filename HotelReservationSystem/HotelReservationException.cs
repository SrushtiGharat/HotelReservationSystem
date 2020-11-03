using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservationException:Exception
    {
        /// <summary>
        /// Type Of Exceptions
        /// </summary>
        public enum ExceptionType
        {
            INVALID_DATE,
            NULL_DATES,
            INVALID_DATE_FORMAT,
            INVALID_CUSTOMER_TYPE
        }
        public ExceptionType type;

        /// <summary>
        /// Parameterised constructor of class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public HotelReservationException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
