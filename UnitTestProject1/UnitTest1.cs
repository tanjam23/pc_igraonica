using System;
using System.Collections.Generic;
using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestMethod
    {
        [TestMethod]
        public void Test_insertUser()
        {
            User testInfo = new User();
            UserRepository userRepository = new UserRepository();

            int userlistcount = userRepository.GetAllUsers().Count;
            int newusercount;
            testInfo.username = "Username";
            testInfo.name = "Name";
            testInfo.surname = "Surname";
            testInfo.address = "Address";
            testInfo.phone_number = 123456789;
            testInfo.gender = "Gender";

            userRepository.InsertUser(testInfo);
            newusercount = userRepository.GetAllUsers().Count;

            Assert.AreNotEqual(userlistcount, newusercount);
        }

        [TestMethod]
        public void Test_insertReservation()
        {
            Reservation testInfo = new Reservation();
            ReservationRepository reservationRepository = new ReservationRepository();

            int reslistcount = reservationRepository.GetAllReservations().Count;
            int newrescount;
            testInfo.code = 1;
            testInfo.date = "13.12.2020";
            testInfo.time = "8:00";
            testInfo.username = "Username";


            reservationRepository.InsertReservation(testInfo);
            newrescount = reservationRepository.GetAllReservations().Count;

            Assert.AreNotEqual(reslistcount, newrescount);
        }
        [TestMethod]

        public void Test_deleteUser()
        {
            List<User> resultUser = new List<User>();

            User testI = new User();
            UserRepository userRepository = new UserRepository();

            User testInfo = new User();
            testInfo.username = "Username";
            testInfo.name = "Name";
            testInfo.surname = "Surname";
            testInfo.address = "Address";
            testInfo.phone_number = 123456789;
            testInfo.gender = "Gender";

            userRepository.DeleteUser(testInfo);

            resultUser = userRepository.GetAllUsers();

            Assert.IsFalse(resultUser.Contains(testInfo));

        }
        [TestMethod]

        public void Test_deleteReservation()
        {
            List<Reservation> resultRes = new List<Reservation>();

            Reservation testI = new Reservation();
            ReservationRepository reservationRepository = new ReservationRepository();

            Reservation testInfo = new Reservation();
            testInfo.code = 1;
            testInfo.date = "13.12.2020";
            testInfo.time = "8:00";
            testInfo.username = "Username";

            reservationRepository.DeleteReservation(testInfo);

            resultRes = reservationRepository.GetAllReservations();

            Assert.IsFalse(resultRes.Contains(testInfo));

        }
    }

}
