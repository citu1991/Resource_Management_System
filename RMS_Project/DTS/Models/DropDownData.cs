using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTS.Models
{
     public class DropDownData
    {
        public List<SelectListItem> RenderDropDownList(DataTable DT)
        {
            var list = new List<SelectListItem>();
            if (DT != null && DT.Rows.Count > 0)
            {
                foreach (DataRow rows in DT.Rows)
                {
                    list.Add(
                        new SelectListItem()
                        {
                            Text = rows["Text"].ToString(),
                            Value = rows["Value"].ToString()
                        });
                }
            }
            return list;
        }

    }
}