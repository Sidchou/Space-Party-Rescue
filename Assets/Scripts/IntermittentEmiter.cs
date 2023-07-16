using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermitentEmiter : MonoBehaviour
{
    public float timeToEmmit;
    public float minTime;
    public float maxTime;
    public bool Emmit;
    public float timer;
    private float volumeInicial;
    public AudioSource soundS;
    public AudioClip[] Notes;
    // Start is called before the first frame update
    void Start()
    {
        timeToEmmit = Random.Range(minTime, maxTime);
        volumeInicial = soundS.volume;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToEmmit)
        {
            //Reset Timer
            timer = 0;
            //sound.volume = volumeInicial * Random.Range(0.7f, 1f);
            //soundS.pitch = Random.Range(0.8f, 1.3f);
            //Declare which variable
            int whichClip = 0;
            //Random Assign
            whichClip = Random.Range(1, 4);
            //Play a clip
            soundS.PlayOneShot(Notes[whichClip], 0.7f);
            //Reset emitt time
            timeToEmmit = Random.Range(minTime, maxTime);
        }

    }
}
