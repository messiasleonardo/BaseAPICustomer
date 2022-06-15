using Shared.Models;
using System;
using System.Collections.Generic;
using Tests_BaseAPI.Helper;
using Xunit;

namespace Tests_BaseAPI
{
    public class TestsCustomer_WhitAPICLient
    {
        APIClient _client = new APIClient();
        private string _urlAPi = "https://localhost:7099/api";

        [Fact]
        public void Get()
        {
            //Arrage
            var expected = new List<Customer>();
            //Act
            var actual = _client.QueryAPI<List<Customer>>($"{_urlAPi}/Customer");
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        public void GetCustomerWithId(int id)
        {
            var request = new Customer { Id = id };
            //Arrage
            var expected = new Customer();

            //Act
            var actual = _client.QueryAPI<Customer, Customer>(request, $"{_urlAPi}/Customer/Id");

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
            var actual = _client.QueryAPI<Customer,Customer>(request, $"{_urlAPi}/Customer");

            //Assert
            Assert.True(Convert.ToBoolean(actual));
        }

        [Theory]
        [InlineData(1)]
        public void Delete(int id)
        {

            //Arrage

            //Act
            var actual = _client.QueryAPIDelete<Customer>($"{_urlAPi}/Customer/{id}");

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
            var actual = _client.QueryAPIPut<Customer, Customer>(request, $"{_urlAPi}/Customer");

            //Assert
            Assert.True(Convert.ToBoolean(actual));
        }

    }
}