using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class GamePauser : MonoBehaviour
{
    UIManager uiManager; // Reference to the UIManager script

    void Start()
    {
        // Find the UIManager in the scene using the updated method
        uiManager = gameObject.GetComponent<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene. Please ensure it is present.");
        }
    }

    // With a GUI Button
    public void TogglePauseGame()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
        }
        if (uiManager != null)
        {
            uiManager.ToggleOptionsPanel(); // Show the pause menu if UIManager is available
        }
    }

    // With the ESC key
    public void TogglePauseGame(CallbackContext ctx)
    {
        if (!ctx.performed) return; // Only toggle on action performed
        
        TogglePauseGame(); // Call the method to toggle pause state
    }
}
