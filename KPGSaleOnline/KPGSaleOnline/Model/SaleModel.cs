using System;
using System.Collections.Generic;
using System.Text;

namespace KPGSaleOnline.Model
{
    public class SaleData
    {
        public string CompCode { get; set; }
        public string CompName { get; set; }
        public string LocCode { get; set; }
        public string CateCode { get; set; }
        public string CateName { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public string ShortName { get; set; }
        public int SortOrder { get; set; }
        public double Net { get; set; }
    }
}
