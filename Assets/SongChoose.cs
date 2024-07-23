using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongChoose : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] clips;


    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0f;

    }
    public void SelectSong(int song)
    {
        audioSource.clip = clips[song];
        Time.timeScale = 1f;
        audioSource.Play();
        gameObject.SetActive(false);
    }
}
