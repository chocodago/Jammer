using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject squarePrefab;
    public float[] beatsSize;
    public Transform[] spawnPos;
    public float secs = 1f;
    public float timer;
    BeatDetector beatDetector;

    public GameObject beatsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        beatDetector = GetComponent<BeatDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= secs)
        {
            timer = 0f;

            Array.Copy(beatDetector.freqBand, beatsSize, beatDetector.freqBand.Length);

            for (int i = 0; i < spawnPos.Length; i++)
            {
                if(beatsSize[i] > 1.0f)
                {
                    GameObject tapArea = Instantiate(beatsPrefab, spawnPos[i].position, Quaternion.identity);
                    tapArea.transform.localScale = new Vector3(1, beatsSize[i], 0);
                }
            }
            /*
            foreach(float size in beatsSize)
            {
                if(size > 1.0f)
                {
                    GameObject tapArea = Instantiate(beatsPrefab, spawnPos[, Quaternion.identity);
                    tapArea.transform.localScale = new Vector3(1, size, 0);
                }
            }*/
        }       
    }
    
}
