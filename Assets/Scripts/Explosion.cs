using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //移除爆炸效果
        Destroy(gameObject, 0.67f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
