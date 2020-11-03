using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Reservation System");

            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel("Lakewood", 110,90));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150,50));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220,150));

            Console.WriteLine("Hotels Loaded......");

            UserInterface.UserInput(hotelSystem);
        }
    }
}
