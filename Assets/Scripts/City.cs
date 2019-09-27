using UnityEngine;

public class City : MonoBehaviour
{
    Animator myAnim;
    public int transition;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }    

    public void Mudar()
    {
        transition++;
         myAnim.SetInteger("Transition", transition);
    }   
}
