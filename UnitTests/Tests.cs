using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Tests
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Sprawdza czy otrzymamy prawidłowy pociąg kiedy podany ID
        [TestMethod]
        public void Test1()
        {
            var firstTrain = new Train()
            {
                Id = 1, From = 1, To = 3, Name = "Nr1",
                StartDate = new DateTime(2016, 01, 01, 00, 00, 00),
                EndDate = new DateTime(2016, 01, 01, 00, 00, 00),
                StartTime = new TimeSpan(10, 00, 00),
                EndTime = new TimeSpan(15, 23, 00)
            };

            var secondTrain = db.Trains.Find(2);

            bool expected = false;
            bool actual = firstTrain.Equals(secondTrain);

            Assert.AreEqual(expected, actual);
        }

        //Sprawdza czy obiekty się różnią między sobą
        [TestMethod]
        public void Test2()
        {
            var newConnection = new Train
            {
                Id = 7,From = 1,To = 3,Name = "Nr2",
                StartDate = new DateTime(2016, 01, 01, 11, 00, 00),
                EndDate = new DateTime(2016, 01, 01, 13, 43, 00),
                StartTime = new TimeSpan(02, 43, 0)
            };

            var firstTrain = new Train()
            {
                Id = 1,From = 1,To = 3,Name = "Nr1",
                StartDate = new DateTime(2016, 01, 01, 00, 00, 00),
                EndDate = new DateTime(2016, 01, 01, 00, 00, 00),
                StartTime = new TimeSpan(10, 00, 00),
                EndTime = new TimeSpan(15, 23, 00)
            };

            bool expected = false;
            bool actual = newConnection.Equals(firstTrain);

            Assert.AreEqual(expected, actual);
        }
    }
}