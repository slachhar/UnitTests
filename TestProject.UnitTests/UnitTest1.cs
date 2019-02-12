using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting.Fundamentals;

namespace TestProject.UnitTests
{
	[TestClass]
	public class ReservationTests
	{
		[TestMethod]
		public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
		{
			//Arrange
			var reservation = new Reservation();

			//Act
			var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void CanBeCancelledBy_UserIsCreatedBy_ReturnsTrue()
		{
			//Arrange
			var reservation = new Reservation();

			//Act
			reservation.MadeBy = new User { IsAdmin = false };
			var result = reservation.CanBeCancelledBy(reservation.MadeBy);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void CanBeCancelledBy_UserIsNotCreatedBy_ReturnsFalse()
		{
			//Arrange
			var reservation = new Reservation();

			//Act
			var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

			//Assert
			Assert.IsFalse(result);
		}
	}
}
