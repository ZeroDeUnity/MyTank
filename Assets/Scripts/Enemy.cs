using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //属性值
    /// <summary>
    /// 坦克移动速度
    /// </summary>
    public float MoveSpeed = 3;
    /// <summary>
    /// 子弹角度
    /// </summary>
    private Vector3 bullectAulerAngles;
    /// <summary>
    /// 设定坦克初始上下方向
    /// </summary>
    private float v = -1;
    /// <summary>
    /// 设定坦克初始左右方向
    /// </summary>
    private float h;

    //引用
    /// <summary>
    /// 自身SpriteRenderer
    /// </summary>
    private SpriteRenderer sr;
    /// <summary>
    /// SpriteList,存放不同方向下的坦克Sprite
    /// </summary>
    public Sprite[] TankSprite;//上 右 下 左
    /// <summary>
    /// 敌人动画预制体
    /// </summary>
    public GameObject EnemyAnimationPrefab;
    /// <summary>
    /// 子弹预制体
    /// </summary>
    public GameObject bullectPrefab;
    /// <summary>
    /// 爆炸效果预制体
    /// </summary>
    public GameObject explosionPrefab;

    //计时器
    /// <summary>
    /// 坦克攻击计时器
    /// </summary>
    private float timeVal = 0;
    /// <summary>
    /// 坦克移动计时器
    /// </summary>
    private float timeValChangeDirection = 3;

    /// <summary>
    /// 坦克最终前进方向标识
    /// </summary>
    public string fx1 = "";


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        //ttack();
        //攻击的时间间隔
        if (timeVal >= 3)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime* Random.Range(0, 4);
        }


    }

    public void FixedUpdate()
    {
        //坦克移动
        Move();
    }

    //坦克的攻击方法
    private void Attack()
    {

        //子弹产生的角度:当前坦克的角度+子弹应该旋转的角度
        Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectAulerAngles));
        timeVal = 0;

    }

    //坦克的移动方法
    private void Move()
    {
        if (timeValChangeDirection >= 4)
        {
            int num = Random.Range(0, 7);
            if (num >= 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                v = 0;
                h = -1;
            }
            else if (num > 2 && num < 5)
            {
                v = 0;
                h = 1;
            }

            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }
        //v = Input.GetAxisRaw("Vertical");

        //h = Input.GetAxisRaw("Horizontal");

        if ((v == 0 || h == 0) && v != 0)
        {
            fx1 = "v";
        }
        if ((v == 0 || h == 0) && h != 0)
        {
            fx1 = "h";
        }



        if (v == 0 && h == 0)
        {
            EnemyAnimationPrefab.SetActive(false);
            fx1 = "";
        }

        if (v != 0 && h != 0)
        {
            switch (fx1)
            {
                case "v":
                    transform.Translate(Vector3.right * h * MoveSpeed * Time.fixedDeltaTime, Space.World);
                    if (h < 0)
                    {
                        sr.sprite = TankSprite[3];
                        bullectAulerAngles = new Vector3(0, 0, 90);
                    }
                    else if (h > 0)
                    {
                        sr.sprite = TankSprite[1];
                        bullectAulerAngles = new Vector3(0, 0, -90);
                    }
                    break;
                case "h":
                    transform.Translate(Vector3.up * v * MoveSpeed * Time.fixedDeltaTime, Space.World);
                    if (v < 0)
                    {
                        sr.sprite = TankSprite[2];
                        bullectAulerAngles = new Vector3(0, 0, -180);
                    }
                    else if (v > 0)
                    {
                        sr.sprite = TankSprite[0];
                        bullectAulerAngles = new Vector3(0, 0, 0);
                    }
                    break;
            }
        }
        else if (v != 0)
        {
            transform.Translate(Vector3.up * v * MoveSpeed * Time.fixedDeltaTime, Space.World);
            if (v < 0)
            {
                sr.sprite = TankSprite[2];
                bullectAulerAngles = new Vector3(0, 0, -180);
            }
            else if (v > 0)
            {
                EnemyAnimationPrefab.SetActive(true);
                sr.sprite = TankSprite[0];
                bullectAulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (h != 0)
        {
            transform.Translate(Vector3.right * h * MoveSpeed * Time.fixedDeltaTime, Space.World);
            if (h < 0)
            {   
                sr.sprite = TankSprite[3];
                bullectAulerAngles = new Vector3(0, 0, 90);
            }
            else if (h > 0)
            {
                sr.sprite = TankSprite[1];
                bullectAulerAngles = new Vector3(0, 0, -90);
            }

        }
    }


    /// <summary>
    /// 坦克的死亡方法
    /// </summary>
    public void Die()
    {
        
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject, 0.1f);
        //得分增加
        print("得分+1");
        PlayerMananger.Instance.PlayerScore++;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Tank":

                break;
            case "Heart":

                break;
            case "Enemy":
                //敌人坦克
                timeValChangeDirection = Random.Range(0, 2);
                break;
            case "Wall":
                //墙壁
                timeValChangeDirection = Random.Range(2, 4);
                break;
            case "Barrier":
                //障碍
                timeValChangeDirection = Random.Range(2, 4);
                break;
            case "AirBarrier":
                //空气墙
                timeValChangeDirection = Random.Range(2, 4);
                break;
            case "River":
                //河流
                timeValChangeDirection = Random.Range(2, 4);
                break;
                
            default:
                break;
        }
    }

}
