using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    GameManage GM;
    public string humano;
    [SerializeField] AnimalScript animalScript;
    

    void Start()
    {
        GM = FindObjectOfType<GameManage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == humano)
        {
            Destroy(gameObject);
            ChangeSprite spritechange = collision.gameObject.GetComponent<ChangeSprite>();
            spritechange.Change();
            GM.AddPoints();
            TriggerSparklesVFX();
        }
        else if (collision.gameObject.tag == "Deadline")
        {
            return;
        }
        else
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GM.PlayError();
            GM.life -= 1;
        }
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(animalScript.GetSparklesVFX(), new Vector3(transform.position.x + 1f, transform.position.y + 2.5f, (transform.position.z - 0.1f)), Quaternion.identity);
        Destroy(sparkles, 1f);
    }
}
