using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    /// <summary>
    /// 自身SpriteRenderer
    /// </summary>
    private SpriteRenderer sr;
    /// <summary>
    /// 爆炸效果预制体
    /// </summary>
    public GameObject explosionPrefab;

    /// <summary>
    /// 老家被毁后的Sprite
    /// </summary>
    public Sprite BrokenSprite;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 老家被毁方法
    /// </summary>
    public void Die() 
    {
        sr.sprite = BrokenSprite;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //设置游戏状态为失败
        PlayerMananger.Instance.IsDefeat = true;
    }


}
