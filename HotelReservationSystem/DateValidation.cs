using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace HotelReservationSystem
{
    public class DateValidation
    {
        /// <summary>
        /// Validate the input dates
        /// </summary>
        /// <param name="enteredDates"></param>
        /// <returns>List Of Validated Dates</returns>
        public DateTime[] ValidateAndReturnDates(string[] enteredDates)
        {           
            if (enteredDates == null)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.NULL_DATES, "Dates are null");
            }
            DateTime startDate = ConvertToDate(enteredDates[0]);
            DateTime endDate = ConvertToDate(enteredDates[1]);
            if(startDate > endDate || startDate < DateTime.Today)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE, "Dates are invalid");
            }
            
            TimeSpan t = endDate.Date - startDate.Date;
            int noOfDays = t.Days+1;
            DateTime[] datesValidated = new DateTime[noOfDays];

            for(int i = 0;i < noOfDays; i++)
            {
                datesValidated[i] = startDate.AddDays(i);
            }

            return datesValidated;
        }

        /// <summary>
        /// Convert entered string to DateTime type
        /// </summary>
        /// <param name="enteredDate"></param>
        /// <returns>string in DateTime Format</returns>
        public DateTime ConvertToDate(string enteredDate)
        {
            try
            {
                DateTime date = DateTime.Parse(enteredDate);
                return date;
            }
            catch (FormatException)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE_FORMAT, "Date Format is Invalid");
            }
        }
    }
}
