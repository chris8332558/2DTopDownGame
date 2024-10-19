using UnityEngine;
using UnityEngine.UI;

public class ExpPresenter : MonoBehaviour
{
    [SerializeField] private PlayerLevel playerLevel;
    [SerializeField] private Image ExpImage;

    private void Update()
    {
        UpdateExp();
    }

    private void UpdateExp()
    {
        ExpImage.fillAmount = playerLevel.CurrentExp / playerLevel.RequriedExp;
    }
}
