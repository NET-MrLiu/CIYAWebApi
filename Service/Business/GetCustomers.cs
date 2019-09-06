using Service.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;

namespace Service.Business
{
    public class GetCustomers
    {
        CRM_Source_InfoService CRMSourceService = new CRM_Source_InfoService();
        CRM_Customer_InfoService CRMCustomerService = new CRM_Customer_InfoService();
        public List<CRM_Customer_Info> GetCustomerBusiness(string id)
        {
            string emp_no = id;
            List<CRM_Customer_Info> list = new List<CRM_Customer_Info>();
            DateTime time = DateTime.Now;
            var customerid = CRMSourceService.GetList(x => x.src_emp_no == emp_no && x.src_end_date >= time).OrderBy(x => x.src_add_date).Select(x => x.src_cust_id).Distinct();
            int?[] customers = customerid.ToArray();
            if (customers != null)
            {
                list = CRMCustomerService.GetList(x => customers.Contains(x.ID));
            }
            return list;
        }
    }
}
