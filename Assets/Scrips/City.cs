using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    Animator myAnim;
    public int transition;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    if(transition <= 0)
    //    {
    //        transition = 0;
    //    }
    //}

    public void Mudar()
    {
        transition++;
         myAnim.SetInteger("Transition", transition);
    }

    //public void Diminuir()
    //{

    //    transition--;
    //    FindObjectOfType<GameManage>().combo -= 1;
    //    myAnim.SetInteger("Transition", transition);
    //}
}
