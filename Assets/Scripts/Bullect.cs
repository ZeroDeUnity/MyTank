using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullect : MonoBehaviour
{
    public float MoveSpeed = 10;


    public bool isPlayerBullect = false;

    private bool markbool = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up*MoveSpeed*Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullect && markbool)
                {
                    markbool = false;
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullect&& markbool)
                {
                    markbool = false;
                    Destroy(gameObject);
                    collision.SendMessage("Die");
                    
                }
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
                //障碍
                Destroy(gameObject);
                break;
            case "AirBarrier":
                //空气墙
                Destroy(gameObject);
                break;
            case "Bullect":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
