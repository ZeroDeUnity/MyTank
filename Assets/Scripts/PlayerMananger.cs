using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMananger : MonoBehaviour
{
    //属性值
    /// <summary>
    /// 关卡数
    /// </summary>
    public int GateNumber = 1;
    /// <summary>
    /// 玩家命数
    /// </summary>
    public int LifeValue = 3;
    /// <summary>
    /// 玩家得分
    /// </summary>
    public int PlayerScore = 0;
    /// <summary>
    /// 是否死亡
    /// </summary>
    public bool IsDead = false;
    /// <summary>
    /// 是否失败
    /// </summary>
    public bool IsDefeat = false;

    //引用
    /// <summary>
    /// 出生点
    /// </summary>
    public GameObject born;
    /// <summary>
    /// 游戏分数文本对象
    /// </summary>
    public Text playerScoreText;
    /// <summary>
    /// 玩家命数文本对象
    /// </summary>
    public Text playerLifeCountText;
    /// <summary>
    /// 黑背景UI
    /// </summary>
    public GameObject backGroundUI;
    /// <summary>
    /// 是否失败UI
    /// </summary>
    public GameObject isDefeatUI;

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
        isDefeatUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            Recover();
        }
        if (IsDefeat)
        {
            Recover();
        }

        playerScoreText.text = PlayerScore.ToString();
        playerLifeCountText.text = LifeValue.ToString();
    }

    /// <summary>
    /// 坦克被毁判定
    /// </summary>
    private void Recover() 
    {
        if (LifeValue<=0||IsDefeat==true)
        {
            //游戏失败,GameOver
            Invoke("ActiveDefeatUI",1.5f);
            //游戏失败,返回主界面
            Invoke("ReturnToMainMenu", 3);
        }
        else
        {
            LifeValue--;
            GameObject go = Instantiate(born, new Vector3(-7.25f, -9.5f, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            IsDead = false;
        }
    }

    /// <summary>
    /// 激活隐藏UI(GameOver)
    /// </summary>
    private void ActiveDefeatUI() 
    {

        isDefeatUI.SetActive(true);

    }

    private void ReturnToMainMenu() 
    {

        SceneManager.LoadScene("GameState");
    }
}
