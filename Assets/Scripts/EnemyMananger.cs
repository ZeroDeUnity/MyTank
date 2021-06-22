using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMananger : MonoBehaviour
{
    //属性值
    public int EnemyCount = 20;


    //引用
    public Text enemyCountText;


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
