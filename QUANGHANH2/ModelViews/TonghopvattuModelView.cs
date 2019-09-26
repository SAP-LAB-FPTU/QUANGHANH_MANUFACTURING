using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.ModelViews
{
    public class TonghopvattuDetailModelView
    {
        public string Id { get; set; }
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string SupplyUnit { get; set; }
        public double SupplyAverage { get; set; }
        public int SupplyQuantity { get; set; }
    }

    public class TonghopvattuSummaryModelView
    {
        public string Id { get; set; }
        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
        public string SupplyUnit { get; set; }
        public int SupplyQuantity { get; set; }
        public double EstimatePrice { get; set; }
        public string Note { get; set; }
    }

    public class TonghopvattuDepartmentModelView
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string DepartmentType { get; set; }
    }

    public class TonghopVattuSearchModelView
    {
        public string MonthPicked { get; set; }
        public string DepartmentId { get; set; }

        public string SupplyId { get; set; }
        public string SupplyName { get; set; }
    }
}