using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Reservation System");

            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel("Lakewood", 110));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220));

            Console.WriteLine("Hotels Loaded......");

            try
            {
                Console.WriteLine("Enter dates in dd-mm--yyyy format");
                string[] dates = Console.ReadLine().Split(",");
                
                Hotel cheapestHotel = hotelSystem.GetCheapestHotel(dates);
                Console.WriteLine("Cheapest Hotel :");
                Console.WriteLine(cheapestHotel.name + " ,Rates : " + dates.Length * cheapestHotel.ratesForRegularCustomer);
            }
            catch(HotelReservationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
