using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGamePlayer : MonoBehaviour
{
    public int SelectPlayerValue;


    public GameObject select_Player;
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

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }


}
