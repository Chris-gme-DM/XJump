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

    readonly private Dictionary<string, SoundDefinition> soundDictionary = new();
    readonly private Queue<AudioSource> sfxAudioSourcePool;
    #region Initialization
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSoundManager();
        }
        else
            Destroy(gameObject);
    }
    private void InitializeSoundManager()
    {
        // Populate soundDictionary for quick loopup
        foreach (SoundDefinition sd in allSoundDefinitions)
        {
            if (!soundDictionary.TryAdd(sd.ID, sd))
                Debug.LogWarning($"Duplicate SoundDefinition ID found: {sd.ID}");
        }
        // Initialize SFX AudioSourcePool
        for(int i = 0; i < sfxPoolSize; i++)
        {
            AudioSource sfxSource = Instantiate(sfxAudioSourcePrefab, transform);
            sfxSource.outputAudioMixerGroup = sfxMixerGroup;
            sfxSource.playOnAwake = false;
            sfxSource.loop = false;
            sfxSource.gameObject.SetActive(false);
            sfxAudioSourcePool.Enqueue(sfxSource);

        }
        // Configure music audio source
        if(musicAudioSource != null && musicMixerGroup != null)
        {
            musicAudioSource.outputAudioMixerGroup = musicMixerGroup;
        }
    }
    #endregion
    #region Play and Stop functions
    /// <summary>
    /// Plays sound effect by its ID
    /// </summary>
    /// param name = "soundID"> ID of the sound to play </param>
    /// <returns> True if the sound was played, otherwise false
    public bool PlaySFX(string soundID)
    {
        if (soundDictionary.TryGetValue(soundID, out SoundDefinition soundDefinition))
        {
            if (sfxAudioSourcePool.Count > 0)
            {
                AudioSource sfxSource = sfxAudioSourcePool.Dequeue();
                sfxSource.gameObject.SetActive(true);
                sfxSource.clip = soundDefinition.AudioClip;
                sfxSource.volume = soundDefinition.Volume;
                sfxSource.pitch = Random.Range(soundDefinition.MinPitch, soundDefinition.MaxPitch);
                sfxSource.Play();
                StartCoroutine(ReturnSFXSourceToPool(sfxSource, soundDefinition.AudioClip.length));
                return true;
            }
        }
        return false;
    }
    private IEnumerator ReturnSFXSourceToPool(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        source.Stop();
        source.clip = null;
        source.gameObject.SetActive(false);
        sfxAudioSourcePool.Enqueue(source);
    }
    /// <summary>
    /// Plays music by its ID. It will stop any currently playing music.
    /// </summary>
    /// <param name="musicID"> ID of the music to play.</param>
    public void PlayMusic(string musicID)
    {
        if(soundDictionary.TryGetValue(musicID, out SoundDefinition soundDefinition))
        {
            if(musicAudioSource.isPlaying)
                musicAudioSource.Stop();
            musicAudioSource.clip = soundDefinition.AudioClip;
            musicAudioSource.volume = soundDefinition.Volume;
            musicAudioSource.pitch = 1f;
            musicAudioSource.loop = soundDefinition.Loop;
            musicAudioSource.Play();
        }
    }
    /// <summary>
    /// Stops the currently playing music.
    /// </summary>
    public void StopMusic()
    {
        if (musicAudioSource != null && musicAudioSource.isPlaying)
        {
            musicAudioSource.Stop();
        }
    }
    #endregion
    #region Setting Functions and helpers
    /// <summary>
    /// Set the music volume
    /// </summary>
    /// <param name="volume"> Volume for the music (0 - 1f) </param>
    public void SetMusicVolume(float volume)
    {
        SetVolume(masterMixer, musicVolumeParam, volume);
    }
    /// <summary>
    /// Gets the current music volume normalized (0.0 to 1.0).
    /// </summary>
    public float GetMusicVolumeNormalized()
    {
        return GetVolumeNormalized(masterMixer, musicVolumeParam);
    }
    /// <summary>
    /// Set Sound Volume
    /// </summary>
    /// <param name="volume"> Volume for the sound (0 - 1f) </param>
    public void SetSoundVolume(float volume)
    {
        SetVolume(masterMixer, sfxVolumeParam, volume);
    }
    /// <summary>
    /// Gets the current SFX volume normalized (0.0 to 1.0).
    /// </summary>
    public float GetSFXVolumeNormalized()
    {
        return GetVolumeNormalized(masterMixer, sfxVolumeParam);
    }
    /// <summary>
    /// Helper method to set the volume of music and sound respectively
    /// </summary>
    /// <param name="mixer"> AudioMixer to modify</param>
    /// <param name="parameterName"> name of exposed parameter in the AudioMixer </param>
    /// <param name="volume"> Volume value, normalized (0 - 1f) </param>
    private void SetVolume(AudioMixer mixer, string parameterName, float volume)
    {
        // A common conversion: 0 -> -80dB silent, 1 -> 0dB (full Volume)
        float dbVolume = Mathf.Log10(Mathf.Max(volume, 0.0001f))*20;
        mixer.SetFloat(parameterName, dbVolume);
    }
    /// <summary>
    /// Helper to get volume from an AudioMixer parameter and normalize it (0.0 to 1.0).
    /// </summary>
    /// <param name="mixer">The AudioMixer to query.</param>
    /// <param name="parameterName">The name of the exposed parameter on the mixer.</param>
    /// <returns>Normalized volume (0.0 to 1.0).</returns>
    private float GetVolumeNormalized(AudioMixer mixer, string parameterName)
    {
        float dbVolume;
        if (mixer.GetFloat(parameterName, out dbVolume))
        {
            // Convert decibels back to a normalized (0-1) range.
            // Assuming -80dB is silence and 0dB is max.
            return Mathf.Pow(10, dbVolume / 20);
        }
        return 0f; // Return 0 if parameter not found
    }
    #endregion
}
