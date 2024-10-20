using System;
using UnityEngine;
using TMPro;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private float initTime; 
    [SerializeField] private float currentTime; 
    [SerializeField] private TextMeshProUGUI timerText;

    private float minute;
    private float second;

    private void Awake()
    {
        currentTime = initTime;
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            SecondsToMinutes();
            timerText.text = minute.ToString("00") + ":" + second.ToString("00");
        }
    }

    private void SecondsToMinutes()
    {
        second = TimeSpan.FromSeconds(currentTime).Seconds;
        minute = TimeSpan.FromSeconds(currentTime).Minutes;
	}

}
