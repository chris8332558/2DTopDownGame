using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] int maxLevel = 15;
    [SerializeField] int currentLevel;
    [SerializeField] float currentExp;
    [SerializeField] float requiredExp = 100f;

    public int CurrentLevel { get => currentLevel; private set => currentLevel = value; }
    public float CurrentExp { get => currentExp; private set => requiredExp = value; }
    public int MaxLevel { get => maxLevel; }
    public float RequriedExp { get => requiredExp; }

    private void OnEnable()
    {
        GamePlayEvents.PlayerAddExp.AddListener(AddExp);
    }

    private void OnDisable()
    {
        GamePlayEvents.PlayerAddExp.RemoveListener(AddExp);
    }

    private void LevelUp()
    {
        currentLevel += 1;
        UpdateExp();
        Debug.Log("LevelUp: " + currentLevel + "/" + maxLevel);
        GamePlayEvents.PlayerLevelUp.Invoke();
	}

    private void AddExp(float anAmount)
    {
        currentExp += anAmount;
        HandleLevelUp();
	}

    private void HandleLevelUp()
    { 
	    if (currentLevel < maxLevel && currentExp >= requiredExp)
        {
            LevelUp();
		}
	}

    private void UpdateExp()
    {
        requiredExp *= 1.3f;
        currentExp = 0;
	}
}
