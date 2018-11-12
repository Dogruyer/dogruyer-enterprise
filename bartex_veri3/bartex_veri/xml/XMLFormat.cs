using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace bartex_veri.xml
{
    public class XMLFormat
    {
        public string ConvertDataTableToXMLDataString(DataTable dataTbl)
        {
            StringBuilder XMLString = new StringBuilder();

            if (string.IsNullOrEmpty(dataTbl.TableName))
                dataTbl.TableName = "DataTable";
            XMLString.AppendFormat("<{0}>", dataTbl.TableName);

            DataColumnCollection tableColumns = dataTbl.Columns;
            foreach (DataRow row in dataTbl.Rows)
            {
                XMLString.AppendFormat("<RowData>");
                foreach (DataColumn column in tableColumns)
                {
                    XMLString.AppendFormat("<{1}>{0}</{1}>", row[column].ToString(), column.ColumnName);
                }
                XMLString.AppendFormat("</RowData>");
            }
            XMLString.AppendFormat("</{0}>", dataTbl.TableName);
            return XMLString.ToString();
        }

    }
}