using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private Camera m_Camera;
    public bool isUnlocked = false;

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
                if (hit.transform == this.transform)
                {
                    Debug.Log("Puzzle Unlocked");
                    isUnlocked = true;
                }
            }

        }
    }
}
