﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelSystem
    {
        public CustomerType ctype;
        int weekday;
        int weekend;
        DateValidation dateValidation = new DateValidation();
        public List<Hotel> hotelList;

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="ctype"></param>
        public HotelSystem(CustomerType ctype)
        {
            this.ctype = ctype;
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
        /// Get cheapest best rated hotels
        /// </summary>
        /// <param name="dates"></param>
        /// <returns>List Of Hotels</returns>
        public List<Hotel> GetCheapestBestRatedHotel(string[] dates)
        {
            List<Hotel> cheapestHotels = GetCheapestHotel(dates);
            cheapestHotels.Sort((e1, e2) => e1.rating.CompareTo(e2.rating));
            int highestRating = cheapestHotels.Last().rating;
            return cheapestHotels.FindAll(e => e.rating == highestRating);
        }

        /// <summary>
        /// Get best rated hotels
        /// </summary>
        /// <param name="dates"></param>
        /// <returns>List Of Hotels</returns>
        public List<Hotel> GetBestRatedHotel(string[] dates)
        {
            DateTime[] validatedDates = dateValidation.ValidateAndReturnDates(dates);
            SetWeekendsAndWeekdays(validatedDates);

            hotelList.Sort((e1, e2) => e1.rating.CompareTo(e2.rating));
            int highestRating = hotelList.Last().rating;
            return hotelList.FindAll(e => e.rating == highestRating);
        }

        /// <summary>
        /// Calculate total rate of each hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>total rate</returns>
        public int CalculateTotalRate(Hotel hotel)
        {
            if (ctype == CustomerType.REGULAR)
                return (weekday * hotel.weekdayRatesForRegularCustomer) + (weekend * hotel.weekendRatesForRegularCustomer);
            else
                return (weekday * hotel.weekdayRatesForRewardCustomer) + (weekend * hotel.weekendRatesForRewardCustomer);
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
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    weekend++;
                else
                    weekday++;
            }
        }

        /// <summary>
        /// Display Hotel info
        /// </summary>
        /// <param name="hotels"></param>
        public void DisplayHotels(List<Hotel> hotels)
        {
            int i = 1;
            Console.WriteLine("Hotels");
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(i + ". " + hotel.name + "\tRating :" + hotel.rating + "\tTotal Rate :" + CalculateTotalRate(hotel));
                i++;
            }
        }

    }
}
