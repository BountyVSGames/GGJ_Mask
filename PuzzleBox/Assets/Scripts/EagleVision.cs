using UnityEngine;
using System.Collections.Generic;


public class EagleVision : MonoBehaviour
{

    public Material HighlightMaterial;
    private bool EagleVisionActive;

    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
  /*      if(Input.GetKeyDown(KeyCode.Q))
        {
            EnableEagleVision();
            print("tKeyDown");

        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            DisableEagleVision();
            print("tKeyDown");
        }*/
    }

    void EnableEagleVision()
    {
        if (EagleVisionActive) return;

        GameObject[] targets = GameObject.FindGameObjectsWithTag("EagleVision");

        foreach (GameObject target in targets)
        { 
        
            Renderer rend = target.GetComponent<Renderer>();
            if (rend != null)
            {
                originalMaterials[rend] = rend.material;
                rend.material = HighlightMaterial;
            }
        }
        EagleVisionActive = true;
    }

    void DisableEagleVision()
    {
        foreach (var pair in originalMaterials)
        {
            if (pair.Key != null)
                pair.Key.material = pair.Value;
        }

        originalMaterials.Clear();
        EagleVisionActive = false;
    }
}
