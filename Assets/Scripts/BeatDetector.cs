using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class BeatDetector : MonoBehaviour
{
    AudioSource audioSource;
    public float[] samples = new float[512];
    public float[] freqBand = new float [5];

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

        MakeFrequencyBands();
    }
    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 5; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 4)
            {
                sampleCount += 2;
            }
            for (int j = 0;j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;

            freqBand[i] = average * 10;
        }
    }
}
