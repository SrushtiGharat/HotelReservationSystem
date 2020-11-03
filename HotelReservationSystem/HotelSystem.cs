﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelSystem
    {
        int weekday;
        int weekend;
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
        /// <returns>List of Hotels</returns>
        public List<Hotel> GetCheapestHotel(string[] dates)
        {
            int i = 0;
            int rate = 0;
            List<Hotel> cheapestHotels = new List<Hotel>();

            DateTime[] validatedDates = dateValidation.ValidateAndReturnDates(dates);
            SetWeekendsAndWeekdays(validatedDates);

            foreach (Hotel hotel in hotelList)
            {
                int totalRate = CalculateTotalRate(hotel);
                i++;
                if (i == 1)
                    rate = totalRate;
                if (totalRate == rate)
                    cheapestHotels.Add(hotel);
                if (totalRate < rate)
                {
                    rate = totalRate;
                    cheapestHotels.Clear();
                    cheapestHotels.Add(hotel);
                }
            }
            return cheapestHotels;
        }

        /// <summary>
        /// Calculate total rate of each hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>total rate</returns>
        public int CalculateTotalRate(Hotel hotel)
        {
            return (weekday * hotel.weekdayRatesForRegularCustomer) + (weekend * hotel.weekendRatesForRegularCustomer);
        }

        /// <summary>
        /// Set weekends and weekdays for given range of dates
        /// </summary>
        /// <param name="dates"></param>
        public void SetWeekendsAndWeekdays(DateTime[] dates)
        {
            weekday = 0;
            weekend = 0;

            foreach (DateTime date in dates)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Saturday)
                    weekend++;
                else
                    weekday++;
            }
        }

    }
}
