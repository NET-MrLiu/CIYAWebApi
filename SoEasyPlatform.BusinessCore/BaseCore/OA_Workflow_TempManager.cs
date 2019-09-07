﻿using Sugar.Enties;
using SqlSugar;
using System;
using System.Collections.Generic;
public class OA_Workflow_TempManager : DbContext<OA_Workflow_Temp>
{
 
    //当前类已经继承了 DbContext增、删、查、改的方法

    //这里面写的代码不会给覆盖,如果要重新生成请删除 OA_Workflow_TempManager.cs


    #region 教学方法
    /// <summary>
    /// 如果DbContext中的增删查改方法满足不了你，你可以看下具体用法
    /// </summary>
    public void Study()
    {
	     
	   /*********查询*********/

        var data1 = OA_Workflow_TempDb.GetById(1);//根据ID查询
        var data2 = OA_Workflow_TempDb.GetList();//查询所有
        var data3 = OA_Workflow_TempDb.GetList(it => 1 == 1);  //根据条件查询  
        //var data4 = OA_Workflow_TempDb.GetSingle(it => 1 == 1);//根据条件查询一条,如果超过一条会报错

        var p = new PageModel() { PageIndex = 1, PageSize = 2 };// 分页查询
        var data5 = OA_Workflow_TempDb.GetPageList(it => 1 == 1, p);
        Console.Write(p.PageCount);//返回总数

        var data6 = OA_Workflow_TempDb.GetPageList(it => 1 == 1, p, it => SqlFunc.GetRandom(), OrderByType.Asc);// 分页查询加排序
        Console.Write(p.PageCount);//返回总数
     
        List<IConditionalModel> conModels = new List<IConditionalModel>(); //组装条件查询作为条件实现 分页查询加排序
        conModels.Add(new ConditionalModel() { FieldName = typeof(OA_Workflow_Temp).GetProperties()[0].Name, ConditionalType = ConditionalType.Equal, FieldValue = "1" });//id=1
        var data7 = OA_Workflow_TempDb.GetPageList(conModels, p, it => SqlFunc.GetRandom(), OrderByType.Asc);

        OA_Workflow_TempDb.AsQueryable().Where(x => 1 == 1).ToList();//支持了转换成queryable,我们可以用queryable实现复杂功能

        //我要用事务
        var result = Db.Ado.UseTran(() =>
         {
            //写事务代码
        });
        if (result.IsSuccess)
        {
            //事务成功
        }

        //多表查询地址 http://www.codeisbug.com/Doc/8/1124



        /*********插入*********/
        var insertData = new OA_Workflow_Temp() { };//测试参数
        var insertArray = new OA_Workflow_Temp[] { insertData };
        OA_Workflow_TempDb.Insert(insertData);//插入
        OA_Workflow_TempDb.InsertRange(insertArray);//批量插入
        var id = OA_Workflow_TempDb.InsertReturnIdentity(insertData);//插入返回自增列
        OA_Workflow_TempDb.AsInsertable(insertData).ExecuteCommand();//我们可以转成 Insertable实现复杂插入



		/*********更新*********/
	    var updateData = new OA_Workflow_Temp() {  };//测试参数
        var updateArray = new OA_Workflow_Temp[] { updateData };//测试参数
        OA_Workflow_TempDb.Update(updateData);//根据实体更新
        OA_Workflow_TempDb.UpdateRange(updateArray);//批量更新
        //OA_Workflow_TempDb.Update(it => new OA_Workflow_Temp() { Name = "a", CreateTime = DateTime.Now }, it => it.id==1);// 只更新Name列和CreateTime列，其它列不更新，条件id=1
        OA_Workflow_TempDb.AsUpdateable(updateData).ExecuteCommand();



		/*********删除*********/
	    var deldata = new OA_Workflow_Temp() {  };//测试参数
        OA_Workflow_TempDb.Delete(deldata);//根据实体删除
        OA_Workflow_TempDb.DeleteById(1);//根据主键删除
        OA_Workflow_TempDb.DeleteById(new int[] { 1,2});//根据主键数组删除
        OA_Workflow_TempDb.Delete(it=>1==2);//根据条件删除
        OA_Workflow_TempDb.AsDeleteable().Where(it=>1==2).ExecuteCommand();//转成Deleteable实现复杂的操作
    } 
    #endregion

 
 
}