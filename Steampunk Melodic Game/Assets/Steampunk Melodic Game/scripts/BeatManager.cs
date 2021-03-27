using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[RequireComponent(typeof(AudioSource))]


public class BeatManager : MyGenericSingleton<BeatManager>

{
    private AudioSource audioSource;

    //Controlled Frequencies samples    
    [SerializeField]
    private float[] equalizer;

    //Complete Frequencies samples
    private float[] samples = new float[512];

    public Action<float> OnBassBeat;
    public Action<float> OnMiddleBeat;
    public Action<float> OnHighBeat;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }//closes Awake method

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        equalizer = TurnSamplesToBands(samples, equalizer);
    }//closes Update method

    private void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    } //closes UpdateEqualizator method

    private float[] TurnSamplesToBands(float[] _samples, float[] _bands)
    {
        int count = 0;
        _bands = _bands.ToArray();

        for (int i = 0; i < _bands.Length; i++)
        {

            float average = 0;

            //Esto permite que samplecount sea un valor potencia de 2, sin embargo es corregido para el caso en que i==0 empieze siendo 2, y no 1.
            int sampleCount = (int)Mathf.Pow(2, i) * 2;


            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }//closes for (j)

            average /= count;
            _bands[i] = average * 10;

            switch (i)
            {
                case 0:
                    if (_bands[i] > 1) OnBassBeat?.Invoke(_bands[i]);
                    break;
                case 1:
                    if (_bands[i] > 1) OnMiddleBeat?.Invoke(_bands[i]);
                    break;
                case 2:
                    if (_bands[i] > 1) OnHighBeat?.Invoke(_bands[i]);
                    break;

            }
        }//closes for (i)

        return _bands;
    }//closes UpdateEqualizator method



}//closes AudioProcessor class
