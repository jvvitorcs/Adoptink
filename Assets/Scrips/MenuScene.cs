using UnityEngine;

    public class MenuScene : MonoBehaviour
    {
    public AudioClip musiquinha;
     void Start()
    {
        AudioManager.instance.PlayMusic(musiquinha, true);
    }


}

