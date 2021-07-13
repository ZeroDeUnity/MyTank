using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMananger : MonoBehaviour
{
    //属性值
    /// <summary>
    /// 敌人数量
    /// </summary>
    public int EnemyCount = 20;
    /// <summary>
    /// 敌人配置组合
    /// </summary>
    public Hashtable EnemyConfig;

    //引用
    /// <summary>
    /// 敌人数量控件
    /// </summary>
    public Text enemyCountText;
    /// <summary>
    /// 敌人预制体List
    /// </summary>
    public GameObject[] enemyPrefabList;
    /// <summary>
    /// 出生点
    /// </summary>
    public GameObject born;

    //单例
    public static EnemyMananger instance;

    public static EnemyMananger Instance
    {
        get => instance;
        set => instance = value;
    }

    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        //获取地图敌人配置数据DT
        DataTable MapEnemyConfigDataDT = MapDataMananger.instance.MapEnemyConfigDataDT;
        //获取敌人数量
        EnemyCount = int.Parse(MapEnemyConfigDataDT.Rows[0]["EnemyCount"].ToString());
        //获取敌人配置组合
        EnemyConfig = GetEnemyConfig(MapEnemyConfigDataDT);
    }

    // Update is called once per frame
    void Update()
    {
        //更新敌人数量文本控件数值
        enemyCountText.text = EnemyCount.ToString();
    }

    /// <summary>
    /// 获取敌人配置数据
    /// </summary>
    /// <param name="MapEnemyConfigDataDT">敌人配置数据</param>
    /// <returns>敌人配置数据Hashtable</returns>
    public Hashtable GetEnemyConfig(DataTable MapEnemyConfigDataDT)
    {
        Hashtable EnemyConfig_HasTb = new Hashtable();

        try
        {
            string EnemyTypeStr = MapEnemyConfigDataDT.Rows[0]["EnemyType"].ToString();

            string[] EnemyTypeStrs = EnemyTypeStr.Split(',');

            for (int i = 0; i < EnemyTypeStrs.Length; i++)
            {
                string[] EnemyTypeInfoStr = EnemyTypeStrs[i].Split('+');

                EnemyConfig_HasTb.Add(EnemyTypeInfoStr[0], EnemyTypeInfoStr[1]);
            }
        }
        catch (System.Exception e)
        {
            EnemyConfig_HasTb.Add("Enemy001", EnemyCount);
            print(e.ToString());
        }

        return EnemyConfig_HasTb;
    }
}
