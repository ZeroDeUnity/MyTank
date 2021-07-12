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


    //引用
    /// <summary>
    /// 敌人数量控件
    /// </summary>
    public Text enemyCountText;
    /// <summary>
    /// 敌人预制体List
    /// </summary>
    public GameObject[] enemyPrefabList;


    // Start is called before the first frame update
    void Start()
    {
        //获取地图敌人配置数据DT
        DataTable MapDataDT = MapDataMananger.instance.MapEnemyConfigDataDT;
        //获取敌人数量
        EnemyCount = int.Parse(MapDataDT.Rows[0]["EnemyCount"].ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //更新敌人数量文本控件数值
        enemyCountText.text = EnemyCount.ToString();
    }
}
