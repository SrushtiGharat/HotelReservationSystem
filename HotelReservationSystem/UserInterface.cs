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

                for (int i = 1; i <= cheapestHotels.Length; i++)
                {
                    Console.WriteLine(i + " " + cheapestHotels[i - 1].name);
                }
                Console.WriteLine("Rate :" + hotelSystem.CalculateTotalRate(cheapestHotels[0]));
            }
            catch (HotelReservationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
