using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private float currentBattery = 100f;
    [SerializeField] private float batteryDrainRate = 1f;

    [SerializeField] private Image batteryImage; // Reference to your Image component
    [SerializeField] private Text batteryText; // Reference to your UI Text

    private void Update()
    {
        // Check if flashlight is active and battery is not empty
        if (flashlight.enabled && currentBattery > 0f)
        {
            // Drain battery
            currentBattery -= batteryDrainRate * Time.deltaTime;

            // Update UI text with battery level
            batteryText.text = $"{Mathf.RoundToInt(currentBattery)}";

            // Calculate the color based on battery percentage
            float batteryPercentage = Mathf.Clamp01(currentBattery / 100f);
            Color batteryColor = Color.Lerp(new Color(0.5f, 1f, 0.5f), new Color(1f, 0.5f, 0.5f), 1f - batteryPercentage);

            // Apply the calculated color to the Image
            batteryImage.color = batteryColor; 
        }

        // Check if battery is empty and turn off flashlight
        if (currentBattery <= 0f)
        {
            flashlight.enabled = false;
            currentBattery = 0f; // Ensure battery doesn't go below 0
            batteryText.text = "0"; // Update the text when battery is empty
            batteryImage.color = Color.red; // Set the color to red when empty
        }
    }

    // Public method to toggle flashlight state
    public void ToggleFlashlight()
    {
        flashlight.enabled = !flashlight.enabled; // Toggle flashlight state
    }
}