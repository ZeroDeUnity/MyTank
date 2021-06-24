using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    /// <summary>
    /// 玩家预制体
    /// </summary>
    public GameObject playerPrefab;

    /// <summary>
    /// 敌人预制体List
    /// </summary>
    public GameObject[] enemyPrefabList;

    /// <summary>
    /// 是否创建玩家
    /// </summary>
    public bool createPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 生成坦克
    /// </summary>
    private void BornTank() 
    {
        if (createPlayer)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);
        }
        
    }
}
