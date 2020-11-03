using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class UserInterface
    {
        public static void UserInput(HotelSystem hotelSystem)
        {
            try
            {
                Console.WriteLine("Enter dates in dd-mm--yyyy format");
                string[] dates = Console.ReadLine().Split(",");

                Hotel[] cheapestHotels = hotelSystem.GetCheapestHotel(dates).ToArray();
                Console.WriteLine("Cheapest Hotel :");

                hotelSystem.DisplayHotels(cheapestHotels);
            }
            catch (HotelReservationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
