using UnityEngine;

public class WaterDropSound3dScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    [SerializeField] private float timerMax;


    private float timer = 1;


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
            audioSource.clip = clip;
            audioSource.Play();

            // start new timer
            StartTimer(clip);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    private void StartTimer(AudioClip clip)
    {
        float clipLength = clip.length;
        timer = clipLength + Random.Range(0.2f, timerMax);
    }
}
