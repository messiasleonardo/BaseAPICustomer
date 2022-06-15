using BaseAPI.Controllers;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests_BaseAPI
{
    public class TestsCustomer
    {
        CustomerBasicController _controller = new CustomerBasicController();
        [Fact]
        public void Get()
        {
            //Arrage
            var expected = 1;
            //Act
            var actual = _controller.Get();
            //Assert
            Assert.True(actual?.Count > expected);
        }

        [Theory]
        [InlineData(10)]
        public void GetCustomerWithId(int id)
        {

            //Arrage
            var expected = new Customer { Id = 10};

            //Act
            var actual = _controller.Get(id);

            //Assert
            Assert.Equal(expected.Id, actual?.Id);
        }

        [Fact]
        public void Post()
        {
            Customer request = new Customer
            {
                FirstName = "Leonardo",
                LastName = "Alves",
                Email = "leonardo.mess@terra.com.br",
                Number = "123456789",
                Address = new Address
                {
                    Country = "Brazil",
                    City = "São Paulo",
                    PostCode = "123456",
                    Street = "Teste"
                }
            };
            //Arrage

            //Act
            var actual = _controller.Post(request);

            //Assert
            Assert.True(Convert.ToBoolean(actual));
        }

        [Theory]
        [InlineData(1)]
        public void Delete(int id)
        {

            //Arrage

            //Act
            var actual = _controller.Delete(id);

            //Assert
            Assert.True(Convert.ToBoolean(actual));
        }

        [Fact]
        public void Update()
        {
            Customer request = new Customer
            {
                Id = 1,
                FirstName = "Leonardo",
                LastName = "Alves",
                Email = "leonardo.mess@terra.com.br",
                Number = "123456789",
                Address = new Address
                {
                    Country = "Brazil",
                    City = "São Paulo",
                    PostCode = "123456",
                    Street = "Teste"
                }
            };
            //Arrage

            //Act
            var actual = _controller.Update(request);

            //Assert
            Assert.True(Convert.ToBoolean(actual));
        }
    }
}
