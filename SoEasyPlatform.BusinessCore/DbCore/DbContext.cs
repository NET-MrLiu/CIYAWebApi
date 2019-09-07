using Sugar.Enties;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
public class DbContext<T> where T : class, new()
{
    public DbContext()
    {
        Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "server=115.28.136.7;uid=LY;pwd=abc123.;database=db_SyMis",
            DbType = DbType.SqlServer,
            InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
            IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

        });
        //调式代码 用来打印SQL 
        Db.Aop.OnLogExecuting = (sql, pars) =>
        {
            Console.WriteLine(sql + "\r\n" +
                Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            Console.WriteLine();
        };

    }
    //注意：不能写成静态的
    public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
	public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来操作当前表的数据

   public SimpleClient<CRM_Authentication_Info> CRM_Authentication_InfoDb { get { return new SimpleClient<CRM_Authentication_Info>(Db); } }//用来处理CRM_Authentication_Info表的常用操作
   public SimpleClient<CRM_Source_Info> CRM_Source_InfoDb { get { return new SimpleClient<CRM_Source_Info>(Db); } }//用来处理CRM_Source_Info表的常用操作
   public SimpleClient<RPT_WXB_Expend_Daily> RPT_WXB_Expend_DailyDb { get { return new SimpleClient<RPT_WXB_Expend_Daily>(Db); } }//用来处理RPT_WXB_Expend_Daily表的常用操作
   public SimpleClient<CRM_Record_Intention> CRM_Record_IntentionDb { get { return new SimpleClient<CRM_Record_Intention>(Db); } }//用来处理CRM_Record_Intention表的常用操作
   public SimpleClient<CRM_Linkman_Cust> CRM_Linkman_CustDb { get { return new SimpleClient<CRM_Linkman_Cust>(Db); } }//用来处理CRM_Linkman_Cust表的常用操作
   public SimpleClient<RPT_Goals_Group_Product> RPT_Goals_Group_ProductDb { get { return new SimpleClient<RPT_Goals_Group_Product>(Db); } }//用来处理RPT_Goals_Group_Product表的常用操作
   public SimpleClient<OA_Workflow_Temp> OA_Workflow_TempDb { get { return new SimpleClient<OA_Workflow_Temp>(Db); } }//用来处理OA_Workflow_Temp表的常用操作
   public SimpleClient<CRM_Record> CRM_RecordDb { get { return new SimpleClient<CRM_Record>(Db); } }//用来处理CRM_Record表的常用操作
   public SimpleClient<HR_Transfer_Record> HR_Transfer_RecordDb { get { return new SimpleClient<HR_Transfer_Record>(Db); } }//用来处理HR_Transfer_Record表的常用操作
   public SimpleClient<RPT_Brokerage_Grade> RPT_Brokerage_GradeDb { get { return new SimpleClient<RPT_Brokerage_Grade>(Db); } }//用来处理RPT_Brokerage_Grade表的常用操作
   public SimpleClient<CRM_Linkman_Char> CRM_Linkman_CharDb { get { return new SimpleClient<CRM_Linkman_Char>(Db); } }//用来处理CRM_Linkman_Char表的常用操作
   public SimpleClient<CRM_Market_Info> CRM_Market_InfoDb { get { return new SimpleClient<CRM_Market_Info>(Db); } }//用来处理CRM_Market_Info表的常用操作
   public SimpleClient<RPT_Product_Setting> RPT_Product_SettingDb { get { return new SimpleClient<RPT_Product_Setting>(Db); } }//用来处理RPT_Product_Setting表的常用操作
   public SimpleClient<CRM_Intention> CRM_IntentionDb { get { return new SimpleClient<CRM_Intention>(Db); } }//用来处理CRM_Intention表的常用操作
   public SimpleClient<OA_Task_Log> OA_Task_LogDb { get { return new SimpleClient<OA_Task_Log>(Db); } }//用来处理OA_Task_Log表的常用操作
   public SimpleClient<RPT_Grade_Line> RPT_Grade_LineDb { get { return new SimpleClient<RPT_Grade_Line>(Db); } }//用来处理RPT_Grade_Line表的常用操作
   public SimpleClient<OA_Project_Info> OA_Project_InfoDb { get { return new SimpleClient<OA_Project_Info>(Db); } }//用来处理OA_Project_Info表的常用操作
   public SimpleClient<CRM_AV_Record> CRM_AV_RecordDb { get { return new SimpleClient<CRM_AV_Record>(Db); } }//用来处理CRM_AV_Record表的常用操作
   public SimpleClient<OA_Feedback_Info> OA_Feedback_InfoDb { get { return new SimpleClient<OA_Feedback_Info>(Db); } }//用来处理OA_Feedback_Info表的常用操作
   public SimpleClient<OA_Project_Flow> OA_Project_FlowDb { get { return new SimpleClient<OA_Project_Flow>(Db); } }//用来处理OA_Project_Flow表的常用操作
   public SimpleClient<CRM_Action_Class> CRM_Action_ClassDb { get { return new SimpleClient<CRM_Action_Class>(Db); } }//用来处理CRM_Action_Class表的常用操作
   public SimpleClient<SYS_Type_Info> SYS_Type_InfoDb { get { return new SimpleClient<SYS_Type_Info>(Db); } }//用来处理SYS_Type_Info表的常用操作
   public SimpleClient<RPT_Monthly_Personal_Record> RPT_Monthly_Personal_RecordDb { get { return new SimpleClient<RPT_Monthly_Personal_Record>(Db); } }//用来处理RPT_Monthly_Personal_Record表的常用操作
   public SimpleClient<OA_Pre_Assign_Info> OA_Pre_Assign_InfoDb { get { return new SimpleClient<OA_Pre_Assign_Info>(Db); } }//用来处理OA_Pre_Assign_Info表的常用操作
   public SimpleClient<SYS_Role> SYS_RoleDb { get { return new SimpleClient<SYS_Role>(Db); } }//用来处理SYS_Role表的常用操作
   public SimpleClient<SYS_Product_Permission> SYS_Product_PermissionDb { get { return new SimpleClient<SYS_Product_Permission>(Db); } }//用来处理SYS_Product_Permission表的常用操作
   public SimpleClient<SYS_Product_Class> SYS_Product_ClassDb { get { return new SimpleClient<SYS_Product_Class>(Db); } }//用来处理SYS_Product_Class表的常用操作
   public SimpleClient<RPT_Quota_Setting> RPT_Quota_SettingDb { get { return new SimpleClient<RPT_Quota_Setting>(Db); } }//用来处理RPT_Quota_Setting表的常用操作
   public SimpleClient<SYS_Industry_Info_Custom> SYS_Industry_Info_CustomDb { get { return new SimpleClient<SYS_Industry_Info_Custom>(Db); } }//用来处理SYS_Industry_Info_Custom表的常用操作
   public SimpleClient<SYS_Permission> SYS_PermissionDb { get { return new SimpleClient<SYS_Permission>(Db); } }//用来处理SYS_Permission表的常用操作
   public SimpleClient<SYS_Login_Log> SYS_Login_LogDb { get { return new SimpleClient<SYS_Login_Log>(Db); } }//用来处理SYS_Login_Log表的常用操作
   public SimpleClient<SYS_Menu> SYS_MenuDb { get { return new SimpleClient<SYS_Menu>(Db); } }//用来处理SYS_Menu表的常用操作
   public SimpleClient<HR_Dimission_Info> HR_Dimission_InfoDb { get { return new SimpleClient<HR_Dimission_Info>(Db); } }//用来处理HR_Dimission_Info表的常用操作
   public SimpleClient<SYS_Message> SYS_MessageDb { get { return new SimpleClient<SYS_Message>(Db); } }//用来处理SYS_Message表的常用操作
   public SimpleClient<SYS_Industry_Temp> SYS_Industry_TempDb { get { return new SimpleClient<SYS_Industry_Temp>(Db); } }//用来处理SYS_Industry_Temp表的常用操作
   public SimpleClient<CRM_SignIn> CRM_SignInDb { get { return new SimpleClient<CRM_SignIn>(Db); } }//用来处理CRM_SignIn表的常用操作
   public SimpleClient<HR_Reinstate_Info> HR_Reinstate_InfoDb { get { return new SimpleClient<HR_Reinstate_Info>(Db); } }//用来处理HR_Reinstate_Info表的常用操作
   public SimpleClient<SYS_Action_Log> SYS_Action_LogDb { get { return new SimpleClient<SYS_Action_Log>(Db); } }//用来处理SYS_Action_Log表的常用操作
   public SimpleClient<HR_Handover_Info> HR_Handover_InfoDb { get { return new SimpleClient<HR_Handover_Info>(Db); } }//用来处理HR_Handover_Info表的常用操作
   public SimpleClient<SYS_Config> SYS_ConfigDb { get { return new SimpleClient<SYS_Config>(Db); } }//用来处理SYS_Config表的常用操作
   public SimpleClient<OA_Workflow> OA_WorkflowDb { get { return new SimpleClient<OA_Workflow>(Db); } }//用来处理OA_Workflow表的常用操作
   public SimpleClient<SYS_City_Info> SYS_City_InfoDb { get { return new SimpleClient<SYS_City_Info>(Db); } }//用来处理SYS_City_Info表的常用操作
   public SimpleClient<HR_Department_Info> HR_Department_InfoDb { get { return new SimpleClient<HR_Department_Info>(Db); } }//用来处理HR_Department_Info表的常用操作
   public SimpleClient<SYS_Hosts_Info> SYS_Hosts_InfoDb { get { return new SimpleClient<SYS_Hosts_Info>(Db); } }//用来处理SYS_Hosts_Info表的常用操作
   public SimpleClient<RPT_Performance_Record> RPT_Performance_RecordDb { get { return new SimpleClient<RPT_Performance_Record>(Db); } }//用来处理RPT_Performance_Record表的常用操作
   public SimpleClient<SYS_Product_Package> SYS_Product_PackageDb { get { return new SimpleClient<SYS_Product_Package>(Db); } }//用来处理SYS_Product_Package表的常用操作
   public SimpleClient<RPT_WXB_Project> RPT_WXB_ProjectDb { get { return new SimpleClient<RPT_WXB_Project>(Db); } }//用来处理RPT_WXB_Project表的常用操作
   public SimpleClient<RPT_Goals_Info> RPT_Goals_InfoDb { get { return new SimpleClient<RPT_Goals_Info>(Db); } }//用来处理RPT_Goals_Info表的常用操作
   public SimpleClient<CRM_Order_Info> CRM_Order_InfoDb { get { return new SimpleClient<CRM_Order_Info>(Db); } }//用来处理CRM_Order_Info表的常用操作
   public SimpleClient<OA_Task_Info> OA_Task_InfoDb { get { return new SimpleClient<OA_Task_Info>(Db); } }//用来处理OA_Task_Info表的常用操作
   public SimpleClient<HR_Employee_Info> HR_Employee_InfoDb { get { return new SimpleClient<HR_Employee_Info>(Db); } }//用来处理HR_Employee_Info表的常用操作
   public SimpleClient<RPT_Product_Setting_Template> RPT_Product_Setting_TemplateDb { get { return new SimpleClient<RPT_Product_Setting_Template>(Db); } }//用来处理RPT_Product_Setting_Template表的常用操作
   public SimpleClient<OA_Order_Project> OA_Order_ProjectDb { get { return new SimpleClient<OA_Order_Project>(Db); } }//用来处理OA_Order_Project表的常用操作
   public SimpleClient<CRM_Cust_Relationship> CRM_Cust_RelationshipDb { get { return new SimpleClient<CRM_Cust_Relationship>(Db); } }//用来处理CRM_Cust_Relationship表的常用操作
   public SimpleClient<CRM_Cust_Info_Expand> CRM_Cust_Info_ExpandDb { get { return new SimpleClient<CRM_Cust_Info_Expand>(Db); } }//用来处理CRM_Cust_Info_Expand表的常用操作
   public SimpleClient<RPT_Brokerage_Project> RPT_Brokerage_ProjectDb { get { return new SimpleClient<RPT_Brokerage_Project>(Db); } }//用来处理RPT_Brokerage_Project表的常用操作
   public SimpleClient<CRM_Order_Combination> CRM_Order_CombinationDb { get { return new SimpleClient<CRM_Order_Combination>(Db); } }//用来处理CRM_Order_Combination表的常用操作
   public SimpleClient<RPT_Brokerage_Accounts_Date> RPT_Brokerage_Accounts_DateDb { get { return new SimpleClient<RPT_Brokerage_Accounts_Date>(Db); } }//用来处理RPT_Brokerage_Accounts_Date表的常用操作
   public SimpleClient<RPT_Group_Setting_Template> RPT_Group_Setting_TemplateDb { get { return new SimpleClient<RPT_Group_Setting_Template>(Db); } }//用来处理RPT_Group_Setting_Template表的常用操作
   public SimpleClient<OA_Service_Record> OA_Service_RecordDb { get { return new SimpleClient<OA_Service_Record>(Db); } }//用来处理OA_Service_Record表的常用操作
   public SimpleClient<CRM_Customer_Info> CRM_Customer_InfoDb { get { return new SimpleClient<CRM_Customer_Info>(Db); } }//用来处理CRM_Customer_Info表的常用操作
   public SimpleClient<SYS_Product_Info> SYS_Product_InfoDb { get { return new SimpleClient<SYS_Product_Info>(Db); } }//用来处理SYS_Product_Info表的常用操作
   public SimpleClient<OA_Service_Info> OA_Service_InfoDb { get { return new SimpleClient<OA_Service_Info>(Db); } }//用来处理OA_Service_Info表的常用操作
   public SimpleClient<RPT_Brokerage_Series> RPT_Brokerage_SeriesDb { get { return new SimpleClient<RPT_Brokerage_Series>(Db); } }//用来处理RPT_Brokerage_Series表的常用操作
   public SimpleClient<CRM_Transfer_Record> CRM_Transfer_RecordDb { get { return new SimpleClient<CRM_Transfer_Record>(Db); } }//用来处理CRM_Transfer_Record表的常用操作
   public SimpleClient<HR_Area_Info> HR_Area_InfoDb { get { return new SimpleClient<HR_Area_Info>(Db); } }//用来处理HR_Area_Info表的常用操作
   public SimpleClient<RPT_Quota_Template> RPT_Quota_TemplateDb { get { return new SimpleClient<RPT_Quota_Template>(Db); } }//用来处理RPT_Quota_Template表的常用操作
   public SimpleClient<RPT_Brokerage_Proj_Series> RPT_Brokerage_Proj_SeriesDb { get { return new SimpleClient<RPT_Brokerage_Proj_Series>(Db); } }//用来处理RPT_Brokerage_Proj_Series表的常用操作
   public SimpleClient<RPT_WXB_Expend> RPT_WXB_ExpendDb { get { return new SimpleClient<RPT_WXB_Expend>(Db); } }//用来处理RPT_WXB_Expend表的常用操作
   public SimpleClient<CRM_Linkman_Info> CRM_Linkman_InfoDb { get { return new SimpleClient<CRM_Linkman_Info>(Db); } }//用来处理CRM_Linkman_Info表的常用操作
   public SimpleClient<RPT_Group_Setting> RPT_Group_SettingDb { get { return new SimpleClient<RPT_Group_Setting>(Db); } }//用来处理RPT_Group_Setting表的常用操作


   /// <summary>
    /// 获取所有
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList()
    {
        return CurrentDb.GetList();
    }

    /// <summary>
    /// 根据表达式查询
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList(Expression<Func<T, bool>> whereExpression)
    {
        return CurrentDb.GetList(whereExpression);
    }


    /// <summary>
    /// 根据表达式查询分页
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel)
    {
        return CurrentDb.GetPageList(whereExpression, pageModel);
    }

    /// <summary>
    /// 根据表达式查询分页并排序
    /// </summary>
    /// <param name="whereExpression">it</param>
    /// <param name="pageModel"></param>
    /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
    /// <param name="orderByType">OrderByType.Desc</param>
    /// <returns></returns>
    public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
    {
        return CurrentDb.GetPageList(whereExpression, pageModel,orderByExpression,orderByType);
    }


    /// <summary>
    /// 根据主键查询
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetById(dynamic id)
    {
        return CurrentDb.GetById(id);
    }

    /// <summary>
    /// 根据主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(dynamic id)
    {
        return CurrentDb.Delete(id);
    }


    /// <summary>
    /// 根据实体删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(T data)
    {
        return CurrentDb.Delete(data);
    }

    /// <summary>
    /// 根据主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(dynamic[] ids)
    {
        return CurrentDb.AsDeleteable().In(ids).ExecuteCommand()>0;
    }

    /// <summary>
    /// 根据表达式删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(Expression<Func<T, bool>> whereExpression)
    {
        return CurrentDb.Delete(whereExpression);
    }


    /// <summary>
    /// 根据实体更新，实体需要有主键
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Update(T obj)
    {
        return CurrentDb.Update(obj);
    }

    /// <summary>
    ///批量更新
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Update(List<T> objs)
    {
        return CurrentDb.UpdateRange(objs);
    }

    /// <summary>
    /// 插入
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Insert(T obj)
    {
        return CurrentDb.Insert(obj);
    }


    /// <summary>
    /// 批量
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Insert(List<T> objs)
    {
        return CurrentDb.InsertRange(objs);
    }


    //自已扩展更多方法 
}


