using System.Collections;
using System.Collections.Generic;
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
        EnemyCount = 200;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCountText.text = EnemyCount.ToString();
    }
}
