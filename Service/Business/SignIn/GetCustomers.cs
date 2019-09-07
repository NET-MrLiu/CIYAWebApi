using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Business
{
    public class GetCustomers
    {
        CRM_Source_InfoManager _CRMSourceService = new CRM_Source_InfoManager();
        CRM_Customer_InfoManager _CRMCustomerService = new CRM_Customer_InfoManager();
        public List<CRM_Customer_Info> GetCustomerBusiness(string id)
        {
            string emp_no = id;
            List<CRM_Customer_Info> list = new List<CRM_Customer_Info>();
            DateTime time = DateTime.Now;
            var customerid = _CRMSourceService.GetList(x => x.src_emp_no == emp_no && x.src_end_date >= time).OrderBy(x => x.src_add_date).Select(x => x.src_cust_id).Distinct();
            int?[] customers = customerid.ToArray();
            if (customers != null)
            {
                list = _CRMCustomerService.GetList(x => customers.Contains(x.ID));
            }
            return list;
        }
    }
}
