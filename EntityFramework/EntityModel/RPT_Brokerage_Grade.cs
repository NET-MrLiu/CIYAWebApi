﻿using System;
using System.Linq;
using System.Text;

namespace EntityFramework
{
    ///<summary>
    ///
    ///</summary>
    public partial class RPT_Brokerage_Grade
    {
           public RPT_Brokerage_Grade(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? bkge_series_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bkge_grade_title {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public decimal? bkge_scale {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string bkge_describe {get;set;}

    }
}