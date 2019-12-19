using KPGSaleOnline.IService;
using KPGSaleOnline.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace KPGSaleOnline.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;


        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<SaleData>> GetSaleData()
        {
            var ret = new List<SaleData>();
            try
            {
                var uri = new Uri("http://sol.kingpower.com/?method=getsale&datadate=20191212");
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ret = JsonConvert.DeserializeObject<List<SaleData>>(content);
                }
            }catch (Exception ex)
            {
                Console.WriteLine( ex.Message);   
            }

            return ret;
        }
    }
}
