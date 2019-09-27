using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    GameManage GM;

    void Start()
    {
        GM = FindObjectOfType<GameManage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8) 
        {
            Destroy(collision.gameObject);
            GM.life -= 1;
        }
        if(collision.gameObject.layer == 9)
        {
            Destroy(collision.gameObject);
            GM.life -= 1;
        }
    }
}
