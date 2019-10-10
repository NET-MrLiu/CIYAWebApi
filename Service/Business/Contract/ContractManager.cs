using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.Contract
{

    public class ContractManager
    {
        OA_Contract_NumberManager _Contract_Number = new OA_Contract_NumberManager();
        OA_Company_Contract_InfoManager _CompanyInfo = new OA_Company_Contract_InfoManager();
        public static object lockData = new object();

        public List<OA_Company_Contract_Info> GetCompanyInfo()
        {
            return _CompanyInfo.GetList();
        }


        public string InsertContractNumber(OA_Contract_Number ContractNumber, out bool status, out string msg)
        {
            try
            {
                lock (lockData)
                {
                    if (CheckContractNumberToTitle(ContractNumber))
                    {
                        status = false;
                        msg = "文件名称重复,切勿重复提交!";
                    }
                    else
                    {

                        DateTime dttime = DateTime.Now;
                        string Year = dttime.Year.ToString();
                        string Month = (dttime.Month).ToString();
                        //完整号码需要
                        string YearD = dttime.ToString("yy");
                        //加锁防止并发编号重复

                        string num = "";
                        //通过 年份 月份 和公司编号  去查询最后一个合同号编号  如果没有 则合同编号从1开始
                        var ContractNumberList = _Contract_Number.GetList(x => x.Month == Month && x.Year == Year && x.CompanyId == ContractNumber.CompanyId);

                        var code = 1;
                        if (ContractNumberList.Count > 0)
                        {
                            code = (int)ContractNumberList.Max(x => x.Number) + 1;
                        }
                        ContractNumber.Number = code;
                        num = code.ToString("00");
                        //获取公司代码
                        int gsid = (int)ContractNumber.CompanyId;
                        var Company = _CompanyInfo.GetList(x => x.ID == gsid).FirstOrDefault();
                        string titlecode = Company.CompanyCode;
                        ContractNumber.Year = Year;
                        ContractNumber.Month = Month;
                        ContractNumber.AllNumber = $"{titlecode}-{YearD}{ContractNumber.Month}{num}";
                        ContractNumber.Time = dttime;
                        _Contract_Number.Insert(ContractNumber);
                        status = true;
                        msg = "";
                    }
                }
            }
            catch (Exception e)
            {
                status = false;
                msg = e.Message;
                ContractNumber.AllNumber = e.Message + "请联系管理员";
            }
            return ContractNumber.AllNumber;
        }



        /// <summary>
        /// 检查文件标题在当前月是否存在
        /// </summary>
        /// <param name="ContractNumber"></param>
        /// <returns></returns>
        public bool CheckContractNumberToTitle(OA_Contract_Number ContractNumber)
        {
            DateTime dttime = DateTime.Now;
            string Year = dttime.Year.ToString();
            string Month = (dttime.Month).ToString();

            var obj = _Contract_Number.GetList(x => x.Year == Year && x.Month == Month && x.FileName == ContractNumber.FileName).FirstOrDefault();
            if (obj == null)
            {
                return false;
            }
            return true;
        }
        public List<OA_Contract_Number> GetContractNumberInfo(string Year, string Month)
        {
            return _Contract_Number.GetList(x => x.Month == Month && x.Year == Year).OrderByDescending(x => x.Time).ToList();
        }

        public List<OA_Company_Contract_Info> GetCompanyContractInfo()
        {
            return _CompanyInfo.GetList();
        }
        public bool UpdateCompanyContract(OA_Company_Contract_Info CompanyContract)
        {
            return _CompanyInfo.Update(CompanyContract);
        }

        public bool InsertCompanyContract(OA_Company_Contract_Info CompanyContract)
        {
            return _CompanyInfo.Insert(CompanyContract);
        }


        public bool DelCompanyContract(int id)
        {

            return _CompanyInfo.CurrentDb.DeleteById(id);
        }
    }
}
