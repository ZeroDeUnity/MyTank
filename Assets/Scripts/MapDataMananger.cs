using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MapDataMananger : MonoBehaviour
{
    /// <summary>
    /// 关卡数
    /// </summary>
    public int GateNumber = 1;

    /// <summary>
    /// 地图数据DataTable
    /// </summary>
    public DataTable MapDataDT = new DataTable();

    /// <summary>
    /// 敌人数量
    /// </summary>
    public int EnemyCount = 0;

    /// <summary>
    /// 地图敌人配置数据DataTable
    /// </summary>
    public DataTable MapEnemyConfigDataDT = new DataTable();

    //单例
    public static MapDataMananger instance;

    public static MapDataMananger Instance {
        get => instance;
        set => instance = value;
    }


    private void Awake()
    {
        instance = this;
        MapDataDT = ExcelTool.CreateItemArrayWithExcel("MapData", GateNumber);
        MapEnemyConfigDataDT = ExcelTool.CreateItemArrayWithExcel("MapConfigData", GateNumber);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
