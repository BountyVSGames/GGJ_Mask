using JetBrains.Annotations;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class AmbientSound2dScript : MonoBehaviour
{
    [SerializeField] private AudioSource droneSource;
    [SerializeField] private AudioSource oneShotSource;

    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float timerMax;


    private float timer = 1;
    

    private void Start()
    {
        // start playing source A
        droneSource.Play();

        timer = timerMax;
    }
    private void StartTimer(AudioClip clip)
    {
        float clipLength = clip.length;
        timer = clipLength + Random.Range(0.2f, timerMax);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            // get random clip from array
            int index = Random.Range(0, audioClips.Length);
            AudioClip clip = (AudioClip)audioClips.GetValue(index);

            Debug.Log("started with clip");
            Debug.Log(clip.name.ToString());

            // play the clip
            oneShotSource.clip = clip;
            oneShotSource.Play();

            // start new timer
            StartTimer(clip);
        } else
        {
            timer -= Time.deltaTime;
        }
    }

}
