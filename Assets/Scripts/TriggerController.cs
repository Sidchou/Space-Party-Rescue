using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class TriggerController : MonoBehaviour

{

    public bool isTriggerPressed;
    public float normalAngle = 1;
    public float micAngle = 0.3f;
    public float duckSend = -100.0f;
    public float ambientDuckNormal = 0.0f;
    public float ambientDuckMic = -37.0f;
    public float ambientVolumeNormal = -10.0f;
    public float ambientVolumeMic = 0.0f;
    public AudioMixer mixer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggerPressed)
        {
            mixer.SetFloat("VolumeAmbience", ambientVolumeMic);
            mixer.SetFloat("Treshold", ambientDuckMic); 

        }
        else
        {
            mixer.SetFloat("VolumeAmbience", ambientVolumeNormal);
            mixer.SetFloat("Treshold", ambientDuckNormal);

        }

    }


    public void TriggerPressed (bool Pressed){

       }

}
