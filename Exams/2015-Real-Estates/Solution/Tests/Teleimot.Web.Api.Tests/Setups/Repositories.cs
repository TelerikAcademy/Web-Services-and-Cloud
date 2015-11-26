namespace Teleimot.Web.Api.Tests.Setups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Data.Repositories;
    using Moq;

    public static class Repositories
    {
        public static IRepository<Comment> CommentsRepository
        {
            get
            {
                var commentRepositoryMock = new Mock<IRepository<Comment>>();

                commentRepositoryMock.Setup(c => c.All())
                    .Returns(new List<Comment>
                    {
                        new Comment { Content = "Test 1",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 2",  CreatedOn = new DateTime(2015, 10, 5), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 3",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 4",  CreatedOn = new DateTime(2015, 10, 25), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 5",  CreatedOn = new DateTime(2015, 10, 9), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 6",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "AnotherUser" }},
                        new Comment { Content = "Test 7",  CreatedOn = new DateTime(2015, 10, 8), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 8",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 9",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "AnotherUser" }},
                        new Comment { Content = "Test 10",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 11",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "AnotherUser" }},
                        new Comment { Content = "Test 12",  CreatedOn = new DateTime(2015, 10, 11), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 13",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 14",  CreatedOn = new DateTime(2015, 10, 17), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 15",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "TestUser" }},
                        new Comment { Content = "Test 16",  CreatedOn = new DateTime(2015, 10, 1), User = new User { UserName = "TestUser" }},
                    }.AsQueryable());

                return commentRepositoryMock.Object;
            }
        } 
    }
}
