using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGamePlayer : MonoBehaviour
{
    /// <summary>
    /// 选择的游玩模式
    /// </summary>
    public int SelectPlayerValue;

    /// <summary>
    /// P1选择器
    /// </summary>
    public GameObject select_Player;
    /// <summary>
    /// P2选择器
    /// </summary>
    public GameObject select_Players;

    //单例
    private static SelectGamePlayer instance;

    public static SelectGamePlayer Instance
    {
        get => instance;
        set => instance = value;
    }

    public void Awake()
    {
        instance = this;
    }


    void Start()
    {
        SelectPlayerValue = 1;
        select_Player.SetActive(true);
        select_Players.SetActive(false);
    }


    void Update()
    {
        SelectPlayer();

        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
        {
            if (SelectPlayerValue == 1)
            {
                Invoke("GameStart", 2);
            }
            else if (SelectPlayerValue == 2)
            {

            }

        }
    }

    /// <summary>
    /// 选择游戏模式
    /// </summary>
    public void SelectPlayer()
    {
        float v = Input.GetAxisRaw("Vertical");

        //float h = Input.GetAxisRaw("Horizontal");

        if (v > 0)
        {
            SelectPlayerValue = 1;
            select_Player.SetActive(true);
            select_Players.SetActive(false);

        }
        else if (v < 0)
        {
            SelectPlayerValue = 2;
            select_Player.SetActive(false);
            select_Players.SetActive(true);
        }
    }

    /// <summary>
    /// 游戏开始
    /// </summary>
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }


}
