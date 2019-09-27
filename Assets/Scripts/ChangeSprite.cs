using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    //public Sprite rightSprite;
    //SpriteRenderer myspriteRenderer;
    Movement movement;
    BoxCollider2D BCollider2D;
    Animator myAnimator;

    //float speed = 3f;
    //Color color;


    private void Start()
    {
        BCollider2D = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        //color = GetComponent<SpriteRenderer>().color;
        //myspriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Change()
    {
        Destroy(BCollider2D);
        Destroy(myAnimator);
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
