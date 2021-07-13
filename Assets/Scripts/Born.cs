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
            //获取敌人坦克数量
            int EnemyCount = EnemyMananger.instance.EnemyCount;
            //获取敌人坦克配置
            Hashtable EnemyConfig = EnemyMananger.instance.EnemyConfig;

            if (EnemyCount <= 0)
            {
                //剩余敌人数量为0
                return;
            }


            for (int i = 0; i < EnemyConfig.Count; i++)
            {
                int num = Random.Range(0, EnemyConfig.Count) + 1;
                string EnemyConfigKey = "Enemy00" + num + "";
                int EnemyCount_Now = EnemyConfig[EnemyConfigKey] != null ? int.Parse(EnemyConfig[EnemyConfigKey].ToString()) : 0;

                if (EnemyCount_Now <= 0)
                {
                    i = 0;
                    EnemyConfig.Remove(EnemyConfigKey);
                    if (EnemyConfig.Count <= 1)
                    {
                        if (EnemyCount>0)
                        {

                        }
                        break;
                    }
                    continue;
                }

                EnemyConfig[EnemyConfigKey] = EnemyCount_Now - 1;

                EnemyMananger.instance.EnemyConfig = EnemyConfig;

                EnemyMananger.instance.EnemyCount = EnemyCount - 1;

                Instantiate(enemyPrefabList[num - 1], transform.position, Quaternion.identity);

                break;
            }

            //int num = Random.Range(0, 2);
            //Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);
        }

    }
}
