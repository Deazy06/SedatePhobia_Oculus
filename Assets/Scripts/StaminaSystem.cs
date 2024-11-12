using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float sprintCost = 10f; // Stamina cost per second of sprinting
    public float staminaRegenRate = 5f; // Stamina regeneration rate per second
    public Image staminaBar; // Reference to the UI Image for stamina

    private bool isSprinting = false;

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar();
    }

    void Update()
    {
        if (isSprinting)
        {
            if (currentStamina > 0)
            {
                currentStamina -= sprintCost * Time.deltaTime;
                if (currentStamina < 0) currentStamina = 0;
            }
            else
            {
                isSprinting = false; // Stop sprinting if stamina is depleted
            }
        }
        else
        {
            if (currentStamina < maxStamina)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                if (currentStamina > maxStamina) currentStamina = maxStamina;
            }
        }

        UpdateStaminaBar();
    }

    public void ToggleSprinting(bool sprint)
    {
        isSprinting = sprint;
    }

    private void UpdateStaminaBar()
    {
        if (staminaBar != null)
        {
            staminaBar.fillAmount = currentStamina / maxStamina;
        }
    }
}