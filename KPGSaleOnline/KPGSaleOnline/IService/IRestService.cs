using sol.ServiceModel.Common;
using sol.ServiceModel.Sale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KPGSaleOnline.IService
{
    public interface IRestService
    {
        Task<ReturnObject<SaleModel>> GetSaleData(DateTime date);
    }
}
