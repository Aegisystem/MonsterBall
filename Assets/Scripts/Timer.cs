using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.outlineWidth = 0.5f;
        tmp.outlineColor = Color.black;
        tmp.color = Color.green;
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        time = GameManager.Instance.time;
        if (time > 0)
        {
            if(time<10f && time > 9f) tmp.color = Color.red;
            UpdateTimerText();
            
        }
        else
        {
            time = 0;
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);

        tmp.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

   
}