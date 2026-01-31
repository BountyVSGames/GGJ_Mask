using Mono.Cecil.Cil;
using System.Diagnostics;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NumberCodeScript : MonoBehaviour
{

    private Camera m_Camera;
    public string Number;
    string curentNumber;
    public GameObject[] buttons;
    public TextMeshPro codeDisplay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
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
                
                foreach (GameObject button in buttons)
                {
                   // UnityEngine.Debug.Log(hit.collider.gameObject.name, hit.collider.gameObject);

                    if (hit.collider.gameObject == button)
                    {
                        Transform child = button.transform.GetChild(0);
                        TextMeshPro tmp = child.GetComponent<TextMeshPro>();                       
                        curentNumber += tmp.text;
                        codeDisplay.text = curentNumber;
                        CheckNummber();
                        
                    }
                }
            }

        }
    }

    void CheckNummber()
    {
        if (curentNumber.Length >= 4)
        {
            if (curentNumber == Number)
            {
                Object.Destroy(this.gameObject); 
            }
            else
            {
                curentNumber = "";
            }
        }
    }
}
