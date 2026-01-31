using NUnit.Framework.Internal;
using UnityEngine;

public class IconRotation : MonoBehaviour
{

    public Material[] materials;
    public Material[] answer;
    public GameObject[] icons;
    private Camera m_Camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
        WinIcons();
    }

    private void RayCast()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                foreach (GameObject icon in icons)
                {
                    if (hit.collider.gameObject == icon)
                    { 
                        Material maerialInUse = icon.GetComponent<Renderer>().material;
                        Debug.Log(maerialInUse.name.ToString());
                        switch (maerialInUse.name.ToString())
                        {
                            case "Angry (Instance)":
                                icon.GetComponent<Renderer>().material = materials[1];
                                break;
                            case "Sad (Instance)":
                                icon.GetComponent<Renderer>().material = materials[2];
                                break;
                            case "Smile (Instance)":
                                icon.GetComponent<Renderer>().material = materials[3];
                                break;
                            case "Suprise (Instance)":
                                icon.GetComponent<Renderer>().material = materials[0];
                                break;
                            default:
                                icon.GetComponent<Renderer>().material = materials[0];
                                break;
                        }
                    }
                }
            }
        }
    }

    void WinIcons()
    {
        bool broken = false;
        for (int i = 0; i < 3; i++)
        {
            string matName = icons[i].GetComponent<Renderer>().material.name;
            int splitIndex = matName.IndexOf('(');
            string test = matName.Substring(0, splitIndex - 1);

            string matNameAns = answer[i].name;
           // int splitIndexAns = matNameAns.IndexOf('(');
           // string testAns = matNameAns.Substring(0, splitIndexAns - 1);

            if (matNameAns != test) {
                broken = true;
                break;
            }
            

        }
        if (broken) 
        {
            return;
        }

        Debug.Log("Won");
    }
}
