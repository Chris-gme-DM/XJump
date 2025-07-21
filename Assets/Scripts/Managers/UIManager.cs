using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// References for Canvas Elements, Set in Inspector and copy Canvas into GameScene
    /// References: OptionPanel, TitlePanel, ScorePanel
    /// </summary>
    [Header("Canvas References")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private Panel titlePanel;
    [SerializeField] private Panel optionsPanel;
    [SerializeField] private Panel scorePanel;

    [Header("OptionsPanels")]
    [SerializeField] private Panel musicSettingsPanel;
    [SerializeField] private Panel soundSettingsPanel;

    // Internal References
    private int score;
    private int musicVloume;
    private int soundVloume;

    // Public Getter for SoundSettings
    [HideInInspector] public int MusicVolume => musicVloume;
    [HideInInspector] public int SoundVolume => soundVloume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
=======
using TMPro;
using UnityEngine.UI;
/// <summary>
/// This script is managing the entire UI
/// Maybe we can connect he game to a player ID automatically if we ever implement a Save for the game or to track Highscores, which can be displayed in the Main Menu
/// References should be allocated in inspector
/// </summary>
public class UIManager : MonoBehaviour
{
    // References to be set in inspector
    [Header("MainPanels")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject scorePanel;

    [Header("MusicOptionsPanel")]
    [SerializeField] private GameObject musicOptionsPanel;
    [SerializeField] private Slider musicOptionSlider;
    [SerializeField] private TextMeshProUGUI musicOptionValueText;

    [Header("SoundOptionsPanel")]
    [SerializeField] private GameObject scoreOptionsPanel;
    [SerializeField] private Slider soundOptionsSlider;
    [SerializeField] private TextMeshProUGUI soundOptionsValueText;

    [Header("ScorePanel")]
    [SerializeField] private TextMeshProUGUI scoreValueText;
>>>>>>> 3e4b4f4 (UI feature rebuild)

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD

=======
        DisplayScore();
        MusicOptionValue();
>>>>>>> 3e4b4f4 (UI feature rebuild)
    }
    #region Display UI Elements
    /// <summary>
    /// The following methods handle displaying the elements of the UI like score, Music and sound value
    /// </summary>
    private void DisplayScore()
    {
        // Track the player "position"
        // calculate the highest position the player reached in game
        // Display that number, maybe with  a multiplier to enrich player feeling
    }
    private void MusicOptionValue()
    {
        // Read the slider input
        // Set the music volume accordingly
        // Set the text of the valueText accordingly
    }
    private void ScoreOptionValue()
    {
        // Read the slider input
        // Set the sound volume accordingly
        // Set the text of the valueText accordingly
    }
    #endregion
    #region DisplayUI
    /// <summary>
    /// The following methods handle the displaying the element Of the option Panél and may be expected to be further consrtucted if we decide upon a Main Menu Scene
    /// </summary>
    private void ToggleOptionsPanel()
    {
        optionsPanel.SetActive(!optionsPanel);
    }
    #endregion
}