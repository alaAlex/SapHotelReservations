using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingApp;

namespace Tests
{
    [TestClass]
    public class HotelTests
    {
        [TestMethod]
        [DataRow(-4, 2, false)]
        [DataRow(200, 400, false)]
        public void TestCaseOne(int startDay, int endDay, bool expected)
        {
            Hotel hotel = new Hotel(3);
            bool actualResult = hotel.IsReservationAccepted(startDay, endDay);

            Assert.AreEqual(expected, actualResult); // some comment
        }

        [TestMethod]
        public void TestCaseTwo()
        {
            Hotel hotel = new Hotel(3);
            bool expected = true;
            bool actualResult = hotel.IsReservationAccepted(0, 5)
                           && hotel.IsReservationAccepted(7, 13)
                           && hotel.IsReservationAccepted(3, 9)
                           && hotel.IsReservationAccepted(5, 7)
                           && hotel.IsReservationAccepted(6, 6)
                           && hotel.IsReservationAccepted(0, 4);

            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod]
        public void TestCaseThree()
        {
            Hotel hotel = new Hotel(3);

            Assert.AreEqual(true, hotel.IsReservationAccepted(1, 3));
            Assert.AreEqual(true, hotel.IsReservationAccepted(2, 5));
            Assert.AreEqual(true, hotel.IsReservationAccepted(1, 9));
            Assert.AreEqual(false, hotel.IsReservationAccepted(0, 15));
        }

        [TestMethod]
        public void TestCaseFour()
        {
            Hotel hotel = new Hotel(3);

            Assert.AreEqual(true, hotel.IsReservationAccepted(1, 3));
            Assert.AreEqual(true, hotel.IsReservationAccepted(0, 15));
            Assert.AreEqual(true, hotel.IsReservationAccepted(1, 9));
            Assert.AreEqual(false, hotel.IsReservationAccepted(2, 5));
            Assert.AreEqual(true, hotel.IsReservationAccepted(4, 9));
        }

        [TestMethod]
        public void TestCaseFive()
        {
            Hotel hotel = new Hotel(2);

            Assert.AreEqual(true, hotel.IsReservationAccepted(1, 3));
            Assert.AreEqual(true, hotel.IsReservationAccepted(0, 4));
            Assert.AreEqual(false, hotel.IsReservationAccepted(2, 3));
            Assert.AreEqual(true, hotel.IsReservationAccepted(5, 5));
            Assert.AreEqual(true, hotel.IsReservationAccepted(4, 10));
            Assert.AreEqual(true, hotel.IsReservationAccepted(10, 10));
            Assert.AreEqual(true, hotel.IsReservationAccepted(6, 7));
            Assert.AreEqual(false, hotel.IsReservationAccepted(8, 10));
            Assert.AreEqual(true, hotel.IsReservationAccepted(8, 9));
        }
    }
}
