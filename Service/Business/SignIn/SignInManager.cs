using SqlSugar;
using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service.Business
{
    public class SignInManager
    {
        CRM_Source_InfoManager _CRMSourceService = new CRM_Source_InfoManager();
        CRM_Customer_InfoManager _CRMCustomerService = new CRM_Customer_InfoManager();
        CRM_SignInManager _SignIn = new CRM_SignInManager();

        /// <summary>
        /// 获取销售用户客户集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 插入签到数据
        /// </summary>
        /// <param name="signin"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int AddSigin(CRM_SignIn signin, string userid)
        {
            int count = 0;
            var CommonCline = _CRMSourceService.Db;
            var emp = CommonCline.Queryable<HR_Employee_Info, HR_Department_Info>((st, sc) => new object[] { JoinType.Left, st.dept_id == sc.ID }).Where((st, sc) => st.emp_no == userid).Select((st, sc) => new
            {
                st.emp_no,
                st.emp_full_name,
                st.dept_id,
                st.emp_position,
                sc.dept_name,
                sc.dept_full_name
            }).ToList();

            if (emp != null && emp.Count > 0)
            {
                string strHostName = System.Net.Dns.GetHostName();

                signin.emp_no = emp[0].emp_no;
                signin.emp_name = emp[0].emp_full_name;
                signin.emp_dep = emp[0].dept_name;
                signin.emp_fulldep = emp[0].dept_full_name;
                signin.sign_time = DateTime.Now;
                signin.emp_position = emp[0].emp_position;
                signin.ip = HttpContext.Current.Request.UserHostAddress;
                count = CommonCline.Insertable(signin).ExecuteCommand();
            }
            else
            {
                return count;
            }
            return count;
        }


        /// <summary>
        /// 获取当前用户的签到数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<CRM_SignIn> SignInInfo(string userid)
        {
            return _SignIn.GetList(x => x.emp_no == userid);
        }

        /// <summary>
        /// 通过ID查询签到详细信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public CRM_SignIn SignInItemByCode(int code)
        {
            return _SignIn.GetById(code).FirstOrDefault();
        }

        public bool SignInItemEdit(string record, string image_path, int id)
        {
            var obj = _SignIn.GetById(id).FirstOrDefault();
            if (obj != null)
            {
                if (!string.IsNullOrEmpty(record) && record != "0")
                {
                    obj.record = record;
                }
                if (!string.IsNullOrEmpty(image_path) && image_path != "0")
                {
                    obj.image_path = image_path;
                }
                return _SignIn.Update(obj);
            }
            else
            {
                return false;
            }
        }
    }
}
