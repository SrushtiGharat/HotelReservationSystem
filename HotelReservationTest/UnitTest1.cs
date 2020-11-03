using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelSystem hotelSystem = new HotelSystem(CustomerType.REGULAR);

        [TestMethod]
        public void Given_NameAndRegularRates_Add_Hotel_To_List()
        {
            string hotelName = "Lakewood";
            int weekdayRatesForRegularCustomer = 110;
            int weekendRatesForRegularCustomer = 90;
            int weekdayRatesForRewardCustomer = 80;
            int weekendRatesForRewardCustomer = 80;

            int rating = 3;

            hotelSystem.AddHotel(new Hotel(hotelName, weekdayRatesForRegularCustomer, weekendRatesForRegularCustomer, weekdayRatesForRewardCustomer, weekendRatesForRewardCustomer, rating));

            Assert.AreEqual(1, hotelSystem.hotelList.Count);
        }

        [TestMethod]
        public void Given_NullDates_Should_Return_HotelReservationException()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

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
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

            string[] dates = date.Split(",");

            var exception = Assert.ThrowsException<HotelReservationException>(() => hotelSystem.GetCheapestHotel(dates));

            Assert.AreEqual(HotelReservationException.ExceptionType.INVALID_DATE_FORMAT, exception.type);
        }

        [TestMethod]
        [DataRow("11Nov2018,12Nov2018")]
        [DataRow("13Nov2020,11Nov2020")]
        public void Given_InvalidDate_Should_Return_HotelReservationException(string date)
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            string[] dates = date.Split(",");

            var exception = Assert.ThrowsException<HotelReservationException>(() => hotelSystem.GetCheapestHotel(dates));

            Assert.AreEqual(HotelReservationException.ExceptionType.INVALID_DATE, exception.type);
        }

        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestHotel_ForRegularCustomer()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

            string[] dates = "13Nov2020,14Nov2020".Split(",");    //Friday,Saturday

            Hotel[] cheapestHotel = hotelSystem.GetCheapestHotel(dates).ToArray();

            Assert.AreEqual("Lakewood", cheapestHotel[0].name);
            Assert.AreEqual("Bridgewood", cheapestHotel[1].name);
            Assert.AreEqual(2, cheapestHotel.Length);
        }

        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestBestRatedHotel_ForRegularCustomer()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

            string[] dates = "13Nov2020,14Nov2020".Split(",");    //Friday,Saturday

            Hotel[] cheapestHotel = hotelSystem.GetCheapestBestRatedHotel(dates).ToArray();

            Assert.AreEqual(1, cheapestHotel.Length);
            Assert.AreEqual("Bridgewood", cheapestHotel[0].name);
        }

        [TestMethod]
        public void Given_ValidDate_Should_Return_BestRatedHotel_ForRegularCustomer()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

            string[] dates = "13Nov2020,14Nov2020".Split(",");    //Friday,Saturday

            Hotel[] bestRatedHotel = hotelSystem.GetBestRatedHotel(dates).ToArray();

            Assert.AreEqual(1, bestRatedHotel.Length);
            Assert.AreEqual("Ridgewood", bestRatedHotel[0].name);
        }

        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestBestRatedHotel_ForRewardCustomer()
        {
            hotelSystem.ctype = CustomerType.REWARD;
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

            string[] dates = "13Nov2020,14Nov2020".Split(",");    //Friday,Saturday

            Hotel[] cheapestHotel = hotelSystem.GetCheapestBestRatedHotel(dates).ToArray();

            Assert.AreEqual(1, cheapestHotel.Length);
            Assert.AreEqual("Ridgewood", cheapestHotel[0].name);
        }
    }
}

