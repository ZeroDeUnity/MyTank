using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMananger : MonoBehaviour
{
    //属性值
    public int LifeValue = 3;
    public int PlayerScore = 0;
    public bool IsDead = false;
    public bool IsDefeat = false;


    public GameObject born;

    //单例
    private static PlayerMananger instance;

    public static PlayerMananger Instance { 
        get => instance; 
        set => instance = value; 
    }

    public void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            Recover();
        }
    }

    private void Recover() 
    {
        if (LifeValue<=0)
        {
            //游戏失败,返回主界面
        }
        else
        {
            LifeValue--;
            GameObject go = Instantiate(born, new Vector3(-6.5f, -9.5f, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            IsDead = false;
        }
    }
}
