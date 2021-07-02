﻿using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 玩家1的动画控制器
    /// </summary>
    public Animator Player_1_Animator;
    /// <summary>
    /// 坦克移动速度
    /// </summary>
    public float MoveSpeed = 20;
    /// <summary>
    /// 子弹角度
    /// </summary>
    private Vector3 bullectAulerAngles;
    /// <summary>
    /// 攻击cd
    /// </summary>
    private float timeVal;
    /// <summary>
    /// 无敌时间
    /// </summary>
    private float defendTimeVal=3;
    /// <summary>
    /// 是否处于无敌状态
    /// </summary>
    private bool isDefended=true;

    /// <summary>
    /// 自身SpriteRenderer(通过改变材质精灵来实现改变坦克朝向,已废弃,采用动画的方式进行转向处理)
    /// </summary>
    private SpriteRenderer sr;
    /// <summary>
    /// SpriteList,存放不同方向下的坦克Sprite
    /// </summary>
    public Sprite[] TankSprite;//上 右 下 左
    /// <summary>
    /// 子弹预制体
    /// </summary>
    public GameObject bullectPrefab;
    /// <summary>
    /// 爆炸效果预制体
    /// </summary>
    public GameObject explosionPrefab;
    /// <summary>
    /// 无敌效果预制体
    /// </summary>
    public GameObject defendEffectPrefab;
    /// <summary>
    /// 坦克最终前进方向标识
    /// </summary>
    private string fx1 = "";
    /// <summary>
    /// 动画控制属性:是否待机
    /// </summary>
    private bool IsIdle = true;
    /// <summary>
    /// 动画控制属性:纵向速度(大于0向上运动,小于0向下运动)
    /// </summary>
    private float VerticalSpeed = 0;
    /// <summary>
    /// 动画控制属性:横向速度(大于0向右运动,小于0向左运动)
    /// </summary>
    private float HonzontalSpeed = 0;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        Player_1_Animator.SetBool("IsIdle", IsIdle);
        Player_1_Animator.SetFloat("VerticalSpeed", VerticalSpeed);
        Player_1_Animator.SetFloat("HonzontalSpeed", HonzontalSpeed);

        //是否处于无敌状态
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal<=0)
            {
                defendEffectPrefab.SetActive(false);
                isDefended = false;
            }
        }

        if (PlayerMananger.Instance.IsDefeat)
        {
            return;
        }

        //攻击的cd
        if (timeVal>=0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }


    }

    public void FixedUpdate()
    {
        if (PlayerMananger.Instance.IsDefeat)
        {
            return;
        }
        
        Move();


    }

    /// <summary>
    /// 坦克的攻击方法
    /// </summary>
    private void Attack() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //子弹产生的角度:当前坦克的角度+子弹应该旋转的角度
            Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles+bullectAulerAngles));
            timeVal = 0;
        }
    }

    /// <summary>
    /// 坦克的移动方法
    /// </summary>
    private void Move() 
    {
        float v = Input.GetAxisRaw("Vertical");

        float h = Input.GetAxisRaw("Horizontal");



        if (v>0)
        {
            v = 1;
        }
        else if (v<0)
        {
            v = -1;
        }

        if (h > 0)
        {
            h = 1;
        }
        else if (h < 0)
        {
            h = -1;
        }

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
            //IsIdle = true;
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
                        IsIdle = false;
                        HonzontalSpeed = -1;
                        VerticalSpeed = 0;
                        //sr.sprite = TankSprite[3];
                        bullectAulerAngles = new Vector3(0, 0, 90);
                    }
                    else if (h > 0)
                    {
                        IsIdle = false;
                        HonzontalSpeed = 1;
                        VerticalSpeed = 0;
                        //sr.sprite = TankSprite[1];
                        bullectAulerAngles = new Vector3(0, 0, -90);
                    }
                    break;
                case "h":
                    transform.Translate(Vector3.up * v * MoveSpeed * Time.fixedDeltaTime, Space.World);
                    if (v < 0)
                    {
                        IsIdle = false;
                        VerticalSpeed = -1;
                        HonzontalSpeed = 0;
                        //sr.sprite = TankSprite[2];
                        bullectAulerAngles = new Vector3(0, 0, -180);
                    }
                    else if (v > 0)
                    {
                        IsIdle = false;
                        VerticalSpeed = 1;
                        HonzontalSpeed = 0;
                        //sr.sprite = TankSprite[0];
                        bullectAulerAngles = new Vector3(0, 0,0);
                    }
                    break;
            }
        }
        else if (v != 0)
        {
            transform.Translate(Vector3.up * v * MoveSpeed * Time.fixedDeltaTime, Space.World);
            if (v < 0)
            {
                IsIdle = false;
                VerticalSpeed = -1;
                HonzontalSpeed = 0;
                //sr.sprite = TankSprite[2];
                bullectAulerAngles = new Vector3(0, 0, -180);
            }
            else if (v > 0)
            {
                IsIdle = false;
                VerticalSpeed = 1;
                HonzontalSpeed = 0;
                //sr.sprite = TankSprite[0];
                bullectAulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (h != 0)
        {
            transform.Translate(Vector3.right * h * MoveSpeed * Time.fixedDeltaTime, Space.World);
            if (h < 0)
            {
                IsIdle = false;
                HonzontalSpeed = -1;
                VerticalSpeed = 0;
                //sr.sprite = TankSprite[3];
                bullectAulerAngles = new Vector3(0, 0, 90);
            }
            else if (h > 0)
            {
                IsIdle = false;
                HonzontalSpeed = 1;
                VerticalSpeed = 0;
                //sr.sprite = TankSprite[1];
                bullectAulerAngles = new Vector3(0, 0, -90);
            }

        }
    }

    /// <summary>
    /// 坦克的死亡方法
    /// </summary>
    public void Die() 
    {
        if (isDefended)
        {
            return;
        }
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject,0.1f);
        PlayerMananger.Instance.IsDead = true;
    }
}
