using KPGSaleOnline.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KPGSaleOnline.IService
{
    public interface IRestService
    {
        Task<List<SaleData>> GetSaleData();
    }
}
