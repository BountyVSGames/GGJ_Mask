using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakeDamage : MonoBehaviour
{

    [Range(0, 1)] public float maxVignetteIntensity;
    public float vignetteFadeDuration;

    private float currentVignetteIntensity;

    PostProcessVolume postProcessVolume; 
    Vignette vignette;

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

        vignette.enabled.Override(false);

        currentVignetteIntensity = vignette.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            StopAllCoroutines();
            StartCoroutine(IncreaseIntensityOverTime());
        }

        if (Input.GetKey(KeyCode.L))
        {
            StopAllCoroutines();
            StartCoroutine(DecreaseIntensityOverTime());
        }
    }

    private IEnumerator IncreaseIntensityOverTime()
    {
        float startValue = currentVignetteIntensity;
        float elapsed = 0.0f;

        while (elapsed < vignetteFadeDuration) 
        { 
            elapsed += Time.deltaTime;

            currentVignetteIntensity = Mathf.Lerp(startValue, maxVignetteIntensity, elapsed / vignetteFadeDuration);

            vignette.enabled.Override(true);
            vignette.intensity.Override(currentVignetteIntensity);
            yield return null;
        }
    }

    private IEnumerator DecreaseIntensityOverTime()
    {
        float startValue = currentVignetteIntensity;
        float elapsed = 0.0f;

        while (elapsed < vignetteFadeDuration) 
        { 
            elapsed += Time.deltaTime;

            currentVignetteIntensity = Mathf.Lerp(startValue, -maxVignetteIntensity, elapsed / vignetteFadeDuration);

            vignette.enabled.Override(true);
            vignette.intensity.Override(currentVignetteIntensity);
            yield return null;
        }
    }
}
