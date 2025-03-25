using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public PasscodeManager passcodeManager;
    public void OnButtonPress(int assignedNumber)
    {
        if (passcodeManager == null)
        {
            Debug.LogError("PasscodeManager is not assigned!");
            return;
        }

        Debug.Log($"Button {assignedNumber} pressed!");
        //passcodeManager.AddUsedNumbers(assignedNumber, passcodeManager.GetNextNumber2());
    }
}
