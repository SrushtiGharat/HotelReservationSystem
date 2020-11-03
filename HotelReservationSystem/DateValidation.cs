using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class DateValidation
    {
        /// <summary>
        /// Validate the input dates
        /// </summary>
        /// <param name="enteredDates"></param>
        /// <returns></returns>
        public DateTime[] ValidateAndReturnDates(string[] enteredDates)
        {
            if (enteredDates == null)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.NULL_DATES, "Dates are null");
            }
            DateTime[] datesValidated = new DateTime[enteredDates.Length];
            for (int i = 0; i < enteredDates.Length; i++)
            {
                DateTime date = ConvertToDate(enteredDates[i]);
                if (date < DateTime.Today)
                {
                    throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE, "Dates are invalid");
                }
                if (i > 0 && date < datesValidated[i - 1])
                {
                    throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE, "Dates are invalid");
                }
                datesValidated[i] = date;
            }
            return datesValidated;
        }

        /// <summary>
        /// Convert entered string to DateTime type
        /// </summary>
        /// <param name="enteredDate"></param>
        /// <returns></returns>
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
