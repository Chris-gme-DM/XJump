using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Ausio Mixers")]
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private string musicVolumeParam = "MusicVolume";
    [SerializeField] private string sfxVolumeParam = "SFXVolume";

    [Header("Music Setup")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioMixerGroup musicMixerGroup;

    [Header("Sound Setup")]
    [SerializeField] private AudioSource sfxAudioSourcePrefab;
    [SerializeField] private int sfxPoolSize = 10;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;

    [Header("Sound Definitions")]
    [SerializeField] private List<SoundDefinition> allSoundDefinitions;

    private Dictionary<string, SoundDefinition> soundDictionary = new();
    private Queue<AudioSource> queue;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Initialize Music and Sounds
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
