using UnityEngine;
using TMPro; 

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] PlayerLevel playerLevel;
    [SerializeField] TMP_Text LevelText;

    private void Update()
    {
        LevelText.text = "Level:" + playerLevel.CurrentLevel + " / " + playerLevel.MaxLevel;
    }
}
