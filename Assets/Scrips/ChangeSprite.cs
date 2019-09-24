using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public Sprite rightSprite;
    //SpriteRenderer myspriteRenderer;
    Movement movement;
    BoxCollider2D boxbox;
    Animator myanimator;

    //float speed = 3f;
    //Color color;


    private void Start()
    {
        boxbox = GetComponent<BoxCollider2D>();
        myanimator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        //color = GetComponent<SpriteRenderer>().color;
        //myspriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Change()
    {
        Destroy(boxbox);
        Destroy(myanimator);
        movement.speed = 0;
        Destroy(gameObject);
        //myspriteRenderer.sprite = rightSprite;

        //StartCoroutine(FadeOut(GetComponent<SpriteRenderer>()));

    }

    /*IEnumerator FadeOut(SpriteRenderer mySprite)
    {
        Color cor = mySprite.color;

        while (cor.a > 0f)
        {
            cor.a -= Time.deltaTime / speed;
            mySprite.color = cor;

            if(cor.a <= 0f)
            
                cor.a = 0.0f;
            yield return null;
        }
        Destroy(gameObject);
        mySprite.color = cor;

    }*/
}
