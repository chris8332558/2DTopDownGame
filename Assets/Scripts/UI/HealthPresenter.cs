using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] Image healthBarRed;
    [SerializeField] Health health;

    private void Update()
    {
        healthBarRed.fillAmount = health.currentHealth / health.maxHealth;
    }
}
