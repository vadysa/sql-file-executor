using System;
using System.Data;
using System.IO;
using System.Linq;

namespace SqlFileExecutor.FileHandling
{
    static class DataTableExtention
    {
        public static void ToCSV(this DataTable dataTable, string strFilePath)
        {
            using(var sw = new StreamWriter(strFilePath, false))
            {
                for(int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sw.Write(dataTable.Columns[i]);
                    if(i < dataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);

                foreach(DataRow dr in dataTable.Rows)
                {
                    for(int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        if(!Convert.IsDBNull(dr[i]))
                        {
                            string value = dr[i].ToString();
                            if(value.Contains(','))
                            {
                                value = string.Format("\"{0}\"", value);
                                sw.Write(value);
                            }
                            else
                            {
                                sw.Write(dr[i].ToString());
                            }
                        }
                        if(i < dataTable.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }

                // Write header
                //sw.WriteLine(string.Join(",", dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

                //// Write rows
                //foreach(DataRow row in dataTable.Rows)
                //{
                //    var values = row.ItemArray.Select(value =>
                //    {
                //        if(!Convert.IsDBNull(value))
                //        {
                //            string stringValue = value.ToString();
                //            return stringValue.Contains(',') ? $"\"{stringValue}\"" : stringValue;
                //        }
                //        return string.Empty;
                //    });

                //    sw.WriteLine(string.Join(",", values));
                //}
            }
        }
    }
}

