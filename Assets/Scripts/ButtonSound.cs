using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip sound;
    private Button button;
    private AudioSource source;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        button = GetComponent<Button>();
        source = GetComponent<AudioSource>();
        source.clip = sound;
        button.onClick.AddListener(() => PlaySound());
    }

    public void PlaySound()
    {
        AudioManager.instance.PlaySFx(sound, false);
    }
}
