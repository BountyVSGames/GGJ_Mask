using UnityEngine;
using TMPro;


public class CountDownClock : MonoBehaviour
{
    public float timeRemaning = 60f;
    public TextMeshPro clockText;

    void Update()
    {
        if (timeRemaning > 0)
        {
            timeRemaning -= Time.deltaTime;
            UpdateText();
        }
        else
        {
            timeRemaning = 0f;
            clockText.text = "00:00";
            //print("Time is over");
        }
    }

    void UpdateText()
    {
        float minutes = Mathf.FloorToInt(timeRemaning / 60);
        float seconds = Mathf.FloorToInt(timeRemaning % 60);
        clockText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
