using System.Collections;
using UnityEngine;

public class MirrorLightFlicker : MonoBehaviour
{
    [SerializeField] private Light mirroredLightComponent;
    [SerializeField] private float minTimer = 10;
    [SerializeField] private float maxTimer = 60;
    [SerializeField] private int minFlickerAmount = 1;
    [SerializeField] private int maxFlickerAmount = 5;

    private Light lightComponent;
    private float baseLightIntensity;

    [SerializeField] private float timer;
    [SerializeField] private bool flickering;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Random.Range(minTimer, maxTimer);

        lightComponent = GetComponent<Light>();
        baseLightIntensity = lightComponent.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0 && !flickering)
        {
            timer -= Time.deltaTime;
            return;
        }
        
        if(!flickering)
        {
            StartCoroutine(Flicker());
            flickering = true;
        }
    }

    IEnumerator Flicker()
    {
        int flickerAmount = Random.Range(minFlickerAmount, maxFlickerAmount);

        for (int i = 0; i < flickerAmount; i++)
        {
            lightComponent.intensity = 0;
            mirroredLightComponent.intensity = 0;
            yield return new WaitForSeconds(.5f);
            lightComponent.intensity = baseLightIntensity;
            mirroredLightComponent.intensity = baseLightIntensity;
            yield return new WaitForSeconds(1f);
        }

        flickering = false;
        timer = Random.Range(minTimer, maxTimer);
    }
}
