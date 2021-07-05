using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ExcelTool
    {

        /// <summary>
        /// 读取表数据，生成对应的数组
        /// </summary>
        /// <param name="GetType">获取数据类型(MapData,MapConfigData)</param>
        /// <param name="GateNumber">关卡数</param>
        /// <returns>Item数组</returns>
        public static DataTable CreateItemArrayWithExcel(String GetType,int GateNumber)
        {
            string FilePath = Application.dataPath + "/ExcelData/" + "MapData.xlsx";
            //获得表数据
            int columnNum = 0, rowNum = 0;
            DataRowCollection collect = ReadExcel(FilePath, ref columnNum, ref rowNum);

            DataTable GateDT = new DataTable();

            if (GetType == "MapData")
            {
                //根据excel的定义，第二行开始才是数据
/*                for (int i = 1; i < rowNum; i++)
                {
                    dt.Columns.Add("");
                    dt.Columns.Add("");
                    dt.Columns.Add("");
                    Item item = new Item();
                    //解析每列的数据
                    item.itemId = uint.Parse(collect[i][0].ToString());
                    item.itemName = collect[i][1].ToString();
                    item.itemPrice = uint.Parse(collect[i][2].ToString());
                    array[i - 1] = item;
                }*/
            }
            else if(GetType == "MapConfigData") {
                GateDT.Columns.Add("MapNumber");
                GateDT.Columns.Add("EnemyCount");
                GateDT.Columns.Add("EnemyType");
                DataRow row = GateDT.NewRow();
                GateDT.Rows.Add(GateNumber, collect[1][1].ToString(), collect[1][2].ToString());


                //根据excel的定义，第二行开始才是数据
                /*                for (int i = 1; i < rowNum; i++)
                                {
                                    dt.Columns.Add("");
                                    dt.Columns.Add("");
                                    dt.Columns.Add("");
                                    Item item = new Item();
                                    //解析每列的数据
                                    item.itemId = uint.Parse(collect[i][0].ToString());
                                    item.itemName = collect[i][1].ToString();
                                    item.itemPrice = uint.Parse(collect[i][2].ToString());
                                    array[i - 1] = item;
                                }*/
            }

            return GateDT;
        }

        /// <summary>
        /// 读取excel文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="columnNum">行数</param>
        /// <param name="rowNum">列数</param>
        /// <returns></returns>
        static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet result = excelReader.AsDataSet();
            //Tables[0] 下标0表示excel文件中第一张表的数据
            columnNum = result.Tables[0].Columns.Count;
            rowNum = result.Tables[0].Rows.Count;
            return result.Tables[0].Rows;
        }
    }

}
