using BaseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Models;
using System.Web.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly APIConfig _config;
        private readonly string _path = $"C:\\Users\\Tecnologia7.ERITELTELECOM\\source\\repos\\BaseAPI\\BaseAPI\\FakeData";

        public CustomerController()
        {
            //_path = null;
            //_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filepath = Path.Combine(_path, "DataBase.json");
            _path = filepath;
        }

        //Get all customer inside the DataBase
        [HttpGet]
        public List<Customer>? Get()
        {
            string jsonFromFile;
            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var removeLastChar = jsonFromFile.Remove(jsonFromFile.Length - 1);
            var fixedJson = $"[{removeLastChar}]";
            var customerFromJson = JsonConvert.DeserializeObject<List<Customer>>(fixedJson);
            return customerFromJson;
        }

        [HttpGet("Id")]
        public Customer? Get(int id)
        {
            string jsonFromFile;
            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var removeLastChar = jsonFromFile.Remove(jsonFromFile.Length - 1);
            var fixedJson = $"[{removeLastChar}]";
            var customerFromJson = JsonConvert.DeserializeObject<List<Customer>>(fixedJson);
            var customer = customerFromJson?.FirstOrDefault(x => x.Id == id);

            return customer;
        }

        [HttpPost]
        public bool Post(Customer customer)
        {

            try
            {
                var jsonToWrite = JsonConvert.SerializeObject(customer);
                var result = FixJson(jsonToWrite);

                using (var write = new StreamWriter(_path, append: true))
                {
                    write.WriteLine();
                    write.Write(result);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private string FixJson(string jsonToWrite)
        {
            var part = jsonToWrite.Replace(']', ' ').Replace(']',' ').Split('{');
            var result = "";
            if (part.Length > 1)
            {

            var fullText = "{" + $"{part[1]}" + "{" + $"{part[2]}" + '}';
            var removeLastChar = fullText.Remove(fullText.Length - 1);

            result = $"{removeLastChar},";
            }

            return result;
        }

        [HttpDelete("Id")]
        public bool Delete(int id)
        {
            string jsonFromFile;
            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var removeLastChar = jsonFromFile.Remove(jsonFromFile.Length - 1);
            var fixedJson = $"[{removeLastChar}]";
            var customerFromJson = JsonConvert.DeserializeObject<List<Customer>>(fixedJson);
            var customerNeedRemove = new Customer();
            foreach (var item in customerFromJson)
            {
                if (item.Id == id)
                {
                    customerNeedRemove = item;
                }
            }

            customerFromJson.Remove(customerNeedRemove);

            var jsonToWrite = JsonConvert.SerializeObject(customerFromJson);
            var result = FixJson(jsonToWrite);

            using (var write = new StreamWriter(_path, append: false))
            {
                write.WriteLine();
                write.Write(result);
            }

            return true;
        }

        [HttpPut]
        public bool Update(Customer customer)
        {
            string jsonFromFile;
            using (var reader = new StreamReader(_path))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var removeLastChar = jsonFromFile.Remove(jsonFromFile.Length - 1);
            var fixedJson = $"[{removeLastChar}]";
            var customerFromJson = JsonConvert.DeserializeObject<List<Customer>>(fixedJson);

            var obj = customerFromJson?.FirstOrDefault(x=>x.Id == customer.Id);
            if (obj != null)
            {
                customerFromJson?.Remove(obj);
            }
            customerFromJson?.Add(customer);

            var jsonToWrite = JsonConvert.SerializeObject(customerFromJson);
            var result = FixJsonPut(jsonToWrite);
            //result = result.Remove(result.Length - 1);
            using (var write = new StreamWriter(_path, append: false))
            {
                write.WriteLine();
                write.Write(result);
            }
            return true;
        }

        private string FixJsonPut(string jsonToWrite)
        {
            string result = jsonToWrite.Replace('[',' ').Replace(']',' ');
            return result;
        }
    }
}
