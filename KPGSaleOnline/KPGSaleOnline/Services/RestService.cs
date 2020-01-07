using KPGSaleOnline.IService;
using Newtonsoft.Json;
using sol.ServiceModel.Common;
using sol.ServiceModel.Sale;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace KPGSaleOnline.Services
{
    public class RestService : IRestService
    {
        private HttpClient _client;
        private string _solUrl;

        public RestService()
        {
            _client = new HttpClient();

#if DEBUG
            _solUrl = "http://172.22.25.166:55187/";
#else
#endif
        }

        public async Task<ReturnObject<SaleModel>> GetSaleData(DateTime date)
        {
            var ret = new ReturnObject<SaleModel>();
            try
            {
                var uri = new Uri($"{_solUrl}v1/sol/getsaledata?date={date.Year}-{date.Month}-{date.Day}");
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ret = JsonConvert.DeserializeObject<ReturnObject<SaleModel>>(content);
                }
            }catch (Exception ex)
            {
                Console.WriteLine( ex.Message);   
            }

            return ret;
        }
    }
}
