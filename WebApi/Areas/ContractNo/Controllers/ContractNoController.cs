using Common.Dto;
using Newtonsoft.Json;
using Service.Business.Contract;
using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Areas.ContractNo.Controllers
{
    public class ContractNoController : ApiController
    {
        ContractManager Contract = new ContractManager();
        JsonMsgRet JsonDto = new JsonMsgRet();
        /// <summary>
        /// 获取合同号的公司信息
        /// </summary>
        /// <returns></returns>
        public string GetCommnyInfo()
        {
            try
            {
                JsonDto.list = Contract.GetCompanyInfo();
                JsonManage.succes(JsonDto);
            }
            catch (Exception e)
            {
                JsonManage.erro(JsonDto, e.Message);
            }
            return JsonConvert.SerializeObject(JsonDto);
        }


        /// <summary>
        /// 获取合同号
        /// </summary>
        /// <param name="ContractNumber"></param>
        /// <returns></returns>
        public string InsertContractNumber(OA_Contract_Number ContractNumber)
        {
            try
            {
                bool flag = false;
                string msg = "";
                JsonDto.list = Contract.InsertContractNumber(ContractNumber, out flag, out msg);
                if (flag)
                {
                    JsonManage.succes(JsonDto);
                }
                else
                {
                    JsonManage.erro(JsonDto, msg);
                }
            }
            catch (Exception e)
            {
                JsonManage.erro(JsonDto, e.Message);
            }
            return JsonConvert.SerializeObject(JsonDto);
        }


        /// <summary>
        /// 通过年月来获取合同号信息集合
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public string GetContractNumberInfo(string Year, string Month)
        {

            try
            {
                JsonDto.list = Contract.GetContractNumberInfo(Year, Month);
                JsonManage.succes(JsonDto);
            }
            catch (Exception e)
            {
                JsonManage.erro(JsonDto, e.Message);
            }
            return JsonConvert.SerializeObject(JsonDto);
        }


        /// <summary>
        /// 获取合同号的公司信息
        /// </summary>
        /// <returns></returns>
        public string GetCompanyContract()
        {
            try
            {
                JsonDto.list = Contract.GetCompanyContractInfo();
                JsonManage.succes(JsonDto);
            }
            catch (Exception e)
            {
                JsonManage.erro(JsonDto, e.Message);
            }
            return JsonConvert.SerializeObject(JsonDto);
        }


        /// <summary>
        /// 更新或者是添加合同号公司信息
        /// </summary>
        /// <param name="CompanyContract"></param>
        /// <returns></returns>
        public string UpdateInCompanyContract(OA_Company_Contract_Info CompanyContract)
        {
            try
            {
                if (CompanyContract.ID > 0)
                {
                    JsonDto.list = Contract.UpdateCompanyContract(CompanyContract);
                }
                else
                {
                    JsonDto.list = Contract.InsertCompanyContract(CompanyContract);
                }
                JsonManage.succes(JsonDto);
            }
            catch (Exception e)
            {
                JsonManage.erro(JsonDto, e.Message);
            }
            return JsonConvert.SerializeObject(JsonDto);
        }

        /// <summary>
        /// 通过id删除公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string DelCompanyContract(int id)
        {
            try
            {
                JsonDto.list = Contract.DelCompanyContract(id);
                JsonManage.succes(JsonDto);
            }
            catch (Exception e)
            {
                JsonManage.erro(JsonDto, e.Message);
            }
            return JsonConvert.SerializeObject(JsonDto);
        }
    }
}
