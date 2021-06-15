using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //属性值
    public float MoveSpeed = 3;
    private Vector3 bullectAulerAngles;
    private float v = -1;
    private float h;

    //引用
    private SpriteRenderer sr;
    public Sprite[] TankSprite;//上 右 下 左
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;

    //计时器
    private float timeVal = 0;
    private float timeValChangeDirection = 3;

    public string fx1 = "";

    private List<string> fxlist = new List<string>();

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

    //坦克的死亡方法
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
                timeValChangeDirection = 4;
                break;
            case "Wall":
                //墙壁
                timeValChangeDirection = Random.Range(3, 4);
                break;
            case "Barrier":
                //障碍
                timeValChangeDirection = Random.Range(3, 4);
                break;
            case "AirBarrier":
                //空气墙
                timeValChangeDirection = Random.Range(3, 4);
                break;
            case "River":
                //河流
                timeValChangeDirection = Random.Range(3, 4);
                break;
                
            default:
                break;
        }
    }

}
