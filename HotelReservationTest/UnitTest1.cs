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
            int ratesForRegularCustomer = 110;

            hotelSystem.AddHotel(new Hotel(hotelName, ratesForRegularCustomer));

            Assert.AreEqual(1, hotelSystem.hotelList.Count);
        }
    }
}
