using System;
using UnityEngine;
using TMPro;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private float initTime; 
    [SerializeField] private float currentTime; 
    [SerializeField] private TextMeshProUGUI timerUI;

    private float minute;
    private float second;

    private void Awake()
    {
        currentTime = initTime;
        timerUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        SecondsToMinutes();
        timerUI.text = minute.ToString("00") + ":" + second.ToString("00");
    }

    private void SecondsToMinutes()
    {
        second = TimeSpan.FromSeconds(currentTime).Seconds;
        minute = TimeSpan.FromSeconds(currentTime).Minutes;
	}

}
