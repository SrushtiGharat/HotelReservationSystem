using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelSystem hotelSystem = new HotelSystem();
        [TestMethod]
        public void Given_NameAndRegularRates_Add_Hotel_To_List()
        {
            string hotelName = "Lakewood";
            int weekdayRatesForRegularCustomer = 110;
            int weekendRatesForRegularCustomer = 90;

            hotelSystem.AddHotel(new Hotel(hotelName, weekdayRatesForRegularCustomer, weekendRatesForRegularCustomer));

            Assert.AreEqual(1, hotelSystem.hotelList.Count);
        }

        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestHotel()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150));
            string[] dates = "13Nov2020,14Nov2020".Split(",");    //Friday,Saturday

            Hotel[] cheapestHotel = hotelSystem.GetCheapestHotel(dates).ToArray();

            Assert.AreEqual("Lakewood", cheapestHotel[0].name);
            Assert.AreEqual("Bridgewood", cheapestHotel[1].name);
            Assert.AreEqual(2, cheapestHotel.Length);
        }

        [TestMethod]
        public void Given_NullDates_Should_Return_HotelReservationException()
        {
            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150));
            string[] dates = null;

            var exception = Assert.ThrowsException<HotelReservationException>(() => hotelSystem.GetCheapestHotel(dates));

            Assert.AreEqual(HotelReservationException.ExceptionType.NULL_DATES, exception.type);
        }

        [TestMethod]
        [DataRow("112020,12Nov2020")]
        [DataRow("")]
        [DataRow(",12Nov2020")]
        public void Given_InvalidDateFormat_Should_Return_HotelReservationException(string date)
        {
            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150));
            string[] dates = date.Split(",");

            var exception = Assert.ThrowsException<HotelReservationException>(() => hotelSystem.GetCheapestHotel(dates));

            Assert.AreEqual(HotelReservationException.ExceptionType.INVALID_DATE_FORMAT, exception.type);
        }

        [TestMethod]
        [DataRow("11Nov2018,12Nov2018")]
        [DataRow("13Nov2020,11Nov2020")]
        public void Given_InvalidDate_Should_Return_HotelReservationException(string date)
        {
            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150));
            string[] dates = date.Split(",");

            var exception = Assert.ThrowsException<HotelReservationException>(() => hotelSystem.GetCheapestHotel(dates));

            Assert.AreEqual(HotelReservationException.ExceptionType.INVALID_DATE, exception.type);
        }
    }
}
