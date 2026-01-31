using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakeDamage : MonoBehaviour
{
    PostProcessVolume postProcessVolume; 
    Vignette vignette;

    [HideInInspector] public bool effectOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings<Vignette>(out vignette);

        if (!vignette) 
        {
            Debug.LogWarning("Vignette empty");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (effectOn)
        {
            float currentIntensity = vignette.intensity.value;
            currentIntensity += Time.deltaTime * 0.4f;
            vignette.intensity.Override(currentIntensity);
        }

        if (!effectOn)
        {
            float currentIntensity = vignette.intensity.value;
            currentIntensity -= Time.deltaTime * 0.1f;
            vignette.intensity.Override(currentIntensity);
        }
    }
}
