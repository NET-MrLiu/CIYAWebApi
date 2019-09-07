using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("RPT_Product_Setting_Template")]
    public partial class RPT_Product_Setting_Template
    {
           public RPT_Product_Setting_Template(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string temp_title {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string setting_combination {get;set;}

           /// <summary>
           /// Desc:
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public int? temp_status {get;set;}

    }
}
