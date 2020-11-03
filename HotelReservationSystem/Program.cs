using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Reservation System");

            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

            Console.WriteLine("Hotels Loaded......");

            UserInterface.UserInput(hotelSystem);
        }
    }
}
