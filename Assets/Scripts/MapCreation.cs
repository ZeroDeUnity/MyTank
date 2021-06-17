using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    /// <summary>
    /// 原来装饰初始化地图所需物体的数组
    /// 0.老家 1.墙 2.钢板 3.出生效果 4.河流 5.草
    /// 6.敌人出生点1 7.敌人出生点2 8.敌人出生点3
    /// 9.空气墙1 10.空气墙2 11.空气墙3 12.空气墙4
    /// </summary>
    public GameObject[] item;


    //关卡1
    public int[,] array001 = new int[20, 27] {
        {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0},
        {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,1},
        {0,1,0,0,0,0,4,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,0},
        {0,1,0,0,0,0,4,0,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,0,1,0,0},
        {0,0,0,0,0,0,4,0,0,0,0,0,1,0,1,0,1,1,1,1,1,0,0,1,0,0,1},
        {0,0,0,0,4,4,4,4,4,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,1,0},
        {0,0,0,0,0,0,4,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,1,0,0},
        {0,0,0,0,0,0,4,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,0},
        {0,0,4,4,4,4,4,4,4,4,4,0,0,0,1,0,0,0,1,0,0,0,1,1,1,1,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,1,0,0,0,0,0,0,2,2,2,0,0,0,0,0,0,5,0,0,0,0,0},
        {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0},
        {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0},
        {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0},
        {2,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2},
        {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,1,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}

    };


    public void Awake()
    {
        //实例化老家
        CreateItem(item[0], new Vector3(-5.25f, -9.5f, 0), Quaternion.identity);

        //实例化空气墙
        CreateItem(item[9], new Vector3(-0.75f, 10.5f, 0), Quaternion.identity);
        CreateItem(item[10], new Vector3(-18.25f, 0, 0), Quaternion.identity);
        CreateItem(item[11], new Vector3(9.75f, 0, 0), Quaternion.identity);
        CreateItem(item[12], new Vector3(-0.75f, -10.5f, 0), Quaternion.identity);

        //实例化我方出生点
        CreateItem(item[3], new Vector3(-7.25f, -9.5f, 0), Quaternion.identity);

        //实例化敌方出生点
        CreateItem(item[6], new Vector3(-17.25f, 9.5f, 0), Quaternion.identity);
        CreateItem(item[7], new Vector3(-5.25f, 9.5f, 0), Quaternion.identity);
        CreateItem(item[8], new Vector3(8.75f, 9.5f, 0), Quaternion.identity);

        //实例化老家围墙
        CreateItem(item[1], new Vector3(-4.25f, -9.5f, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-6.25f, -9.5f, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-5.25f, -8.5f, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-4.25f, -8.5f, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-6.25f, -8.5f, 0), Quaternion.identity);

        CreateGamelevels(array001);

        //print(asdsa);
    }

    private void CreateItem(GameObject CreateGameObject, Vector3 CreatePosion, Quaternion CreateRotaion)
    {

        GameObject Theitem = Instantiate(CreateGameObject, CreatePosion, CreateRotaion);
        Theitem.transform.SetParent(gameObject.transform);

    }

    private void CreateGamelevels(int[,] Gamelevels) {

        for (int i = 0; i < (Gamelevels.GetLength(0)); i++){

            for (int j = 0; j < Gamelevels.GetLength(1); j++)
            {
                int sum = Gamelevels[i, j];
                float x = (j * 1 + (-17.25f));
                float y = ((9.5f) - (i * 1));
                float z = 0;

                switch (sum)
                {
                    case 1:
                        //生成墙
                        CreateItem(item[1], new Vector3(x, y, z), Quaternion.identity);
                        break;
                    case 2:
                        //生成障碍
                        CreateItem(item[2], new Vector3(x, y, z), Quaternion.identity);
                        break;
                    case 4:
                        //生成河流
                        CreateItem(item[4], new Vector3(x, y, z), Quaternion.identity);
                            break;
                    case 5:
                        //生成草地
                        CreateItem(item[5], new Vector3(x, y, z), Quaternion.identity);
                        break;
                    default:
                        break;
                }

            }
        }
    }

}
