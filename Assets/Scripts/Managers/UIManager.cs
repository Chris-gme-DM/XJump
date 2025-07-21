using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;


/// <summary>
/// This script is managing the entire UI
/// Maybe we can connect he game to a player ID automatically if we ever implement a Save for the game or to track Highscores, which can be displayed in the Main Menu
/// References should be allocated in inspector
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    // References to be set in inspector
    [Header("MainPanels")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject scorePanel;

    [Header("MusicOptionsPanel")]
    [SerializeField] private GameObject musicOptionsPanel;
    [SerializeField] private UnityEngine.UI.Slider musicOptionSlider;

    [Header("SoundOptionsPanel")]
    [SerializeField] private GameObject scoreOptionsPanel;
    [SerializeField] private UnityEngine.UI.Slider soundOptionsSlider;

    [Header("ScorePanel")]
    [SerializeField] private TextMeshProUGUI scoreValueText;
    // To Enrich UX i made a multiplier here because big number = good player, much fun
    [SerializeField] private float scoreValueMultiplier = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {
        DisplayScore();
        MusicOptionValue();
        SoundOptionValue();
    }
    #region Display UI Elements
    /// <summary>
    /// The following methods handle displaying the elements of the UI like score, Music and sound value
    /// </summary>
    private void DisplayScore()
    {
        // Track the player "y-position"
        // calculate the highest position the player reached in game
        // Display that number, maybe with  a multiplier to enrich player feeling
    }
    private void MusicOptionValue()
    {
        // Read the slider input
        // Set the music volume accordingly
        // Set the text of the valueText accordingly
    }
    private void SoundOptionValue()
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
    public void ToggleOptionsPanel()
    {
        optionsPanel.SetActive(!optionsPanel);
    }
    #endregion
}
