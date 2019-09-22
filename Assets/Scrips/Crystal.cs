using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{

    public Sprite[] lifeSprite;
    public Image lifeUI;
    private GameManage GM;


    void Start()
    {
        GM = FindObjectOfType<GameManage>();    
    }

    void Update()
    {
        lifeUI.sprite = lifeSprite[GM.life];
    }
}
