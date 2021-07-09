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
            DataTable gateDT = new DataTable();

            string FilePath = Application.dataPath + "/ExcelData/" + "MapData.xlsx";
            //获得表数据
            int columnNum = 0, rowNum = 0;
            DataRowCollection collect = ReadExcel(FilePath, ref columnNum, ref rowNum);


            if (GetType == "MapData")
            {
                //根据excel的定义，第二行开始才是数据

                int counts = (GateNumber - 1) * 21 + 2;
                int rowCount = 20;
                int columnCount = 27;

                if (collect[counts][1] == null)
                {
                    //关卡信息不存在
                    //地图加载完,随机加载地图数据
                    CreateItemArrayWithExcel(GetType, (GateNumber- UnityEngine.Random.Range(1, GateNumber)));
                    //return null;
                }

                for (int i = 0; i < columnCount; i++)
                {
                    gateDT.Columns.Add(""+i+"");
                }

                for (int i = 0; i < rowCount; i++)
                {
                    int rowNum_Now = counts + i;

                    DataRow gateDR = gateDT.NewRow();

                    for (int j = 0; j < columnCount; j++)
                    {
                        gateDR[j] = collect[rowNum_Now][j];
                    }
                    
                    gateDT.Rows.Add(gateDR);
                }

            }
            else if(GetType == "MapConfigData") {
                //返回关卡配置信息
                //根据excel的定义，第二行开始才是数据

                int counts = (GateNumber - 1) * 21 + 1;

                if (collect[counts][1]==null)
                {
                    //关卡信息不存在
                    //地图加载完,随机加载关卡信息
                    CreateItemArrayWithExcel(GetType, (GateNumber - UnityEngine.Random.Range(1, GateNumber)));
                    //return null;
                }

                gateDT.Columns.Add("MapNumber");
                gateDT.Columns.Add("EnemyCount");
                gateDT.Columns.Add("EnemyType");
                DataRow row = gateDT.NewRow();
                gateDT.Rows.Add(GateNumber, collect[counts][1].ToString(), collect[counts][2].ToString());
            }

            return gateDT;
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
