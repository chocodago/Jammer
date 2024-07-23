using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogeScript : MonoBehaviour
{
    public int health = 10;
    public SpriteRenderer spriteRenderer;
    public Sprite dogeCrying;
    string defaultText = "ZZZZZ....";

    public Text sleepingText;
    public GameObject gameOverPanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Beats"))
        {
            health--;
            sleepingText.text = "huh??.";

            StartCoroutine(returnDefaultTest(1f));

            if(health < 0)
            {
                spriteRenderer.sprite = dogeCrying;
                sleepingText.text = "Why you wake me... huhu...";
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
            }

            Destroy(other.gameObject);
        }
    }
    IEnumerator returnDefaultTest(float secs)
    {
        yield return new WaitForSeconds(secs);

        sleepingText.text = defaultText;
    }
}
