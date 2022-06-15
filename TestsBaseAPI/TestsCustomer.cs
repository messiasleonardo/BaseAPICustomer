using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBaseAPI.Helper;
using Xunit;

namespace TestsBaseAPI
{
    public class TestsCustomer
    {
        APIClient _client = new APIClient();

        [Fact]
        public void Get()
        {
            //Arrage
            var expected = new List<Customer>();
            //Act
            var actual = _client.QueryAPI<List<Customer>>("");
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
            var actual = _client.QueryAPI<Customer,Customer>(request, "");

            //Assert
            Assert.Equal(expected.Id, actual?.Id);
        }
    }
}
