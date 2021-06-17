using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMananger : MonoBehaviour
{
    //属性值
    public int EnemyCount = 20;
    public int LifeValue = 3;
    public int PlayerScore = 0;
    public bool IsDead = false;
    public bool IsDefeat = false;

    //引用
    public GameObject born;
    public Text enemyCountText;
    public Text playerScoreText;
    public Text playerLifeCountText;
    public GameObject backGroundUI;
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
        enemyCountText.text = EnemyCount.ToString();
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
    private void ActiveDefeatUI() {

        isDefeatUI.SetActive(true);

    }
}
