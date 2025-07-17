using UnityEngine;
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

    // Update is called once per frame
    void Update()
    {

    }
}
