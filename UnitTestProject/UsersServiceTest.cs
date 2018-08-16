using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using DAL.Interface;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    public class UsersServiceTest
    {
        //UsersService usersService;
        //Mock<IUnitOfWork> uowMock;
        //Mock<IRepository<User>> userRepositoryMock;
        //Mock<IRepository<Contact>> contactRepositoryMock;
        //Mock<IRepository<ListContacts>> listContactsRepositoryMock;

        //[SetUp]
        //public void TestInitialize()
        //{
        //    uowMock = new Mock<IUnitOfWork>();
        //    userRepositoryMock = new Mock<IRepository<User>>();
        //    contactRepositoryMock = new Mock<IRepository<Contact>>();
        //    listContactsRepositoryMock = new Mock<IRepository<ListContacts>>();

        //    userRepositoryMock.Setup(r => r.GetAll()).Returns(new List<User> {
        //        new User
        //        {
        //            UserId=1,
        //            FirstName = "Ivan",
        //            LastName = "Ivanov",
        //            Age = 15,
        //            City = "Kyiv"
        //        },
        //        new User
        //        {
        //            UserId = 2,
        //            FirstName = "Kate",
        //            LastName = "Petrova",
        //            Age = 3,
        //            City = "Kyiv"
        //        }});
        //    userRepositoryMock.Setup(u => u.Get(1)).Returns(new User
        //    {
        //        UserId = 1,
        //        FirstName = "Ivan",
        //        LastName = "Ivanov",
        //        Age = 15,
        //        City = "Kyiv"

        //    });
        //    userRepositoryMock.Setup(u => u.Update(It.IsAny<User>()));

        //    listContactsRepositoryMock.Setup(r => r.Create(It.IsAny<ListContacts>()));
        //    listContactsRepositoryMock.Setup(u => u.Update(It.IsAny<ListContacts>()));

        //    contactRepositoryMock.Setup(c => c.Create(It.IsAny<Contact>()));

        //    uowMock.Setup(f => f.Users).Returns(userRepositoryMock.Object);
        //    uowMock.Setup(f => f.Contacts).Returns(contactRepositoryMock.Object);
        //    uowMock.Setup(f => f.ListsContacts).Returns(listContactsRepositoryMock.Object);
        //    uowMock.Setup(f => f.Save());

        //    usersService = new UsersService(uowMock.Object);

        //}

        //[Test]
        //public void AddFriend()
        //{
        //    //arrange
        //    ContactDTO contact = new ContactDTO
        //    {
        //        UserId = 2,
        //        FirstName = "Vasya",
        //        LastName = "Pupkin"
        //    };
        //    int userId = 1;

        //    //act
        //    usersService.AddFriend(userId, contact);

        //    //assert
        //    Assert.AreEqual(1, usersService.GetUserById(1).ListContactsId);
        //}


    }
}
