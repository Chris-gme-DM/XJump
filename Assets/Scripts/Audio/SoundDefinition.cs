using UnityEngine;
/// <summary>
/// Sound Definitions as Scriptably objects act as lawyer for AudioClips and offer scalabilty to the SoundManager
/// </summary>
[CreateAssetMenu(fileName = "NewSoundDefintion", menuName = "Scriptable Objects/Audio/Sound")]
public class SoundDefinition : ScriptableObject
{
    [SerializeField] private string id;// Use names like "JumpSound" etc. to define sounds
    [SerializeField] private AudioClip clip;
    [SerializeField] [Range(0f, 1f)] private float volume = 1f;
    // For Pitch Randomization
    [SerializeField] [Range(0f, 2f)] private float minPitch = 0.9f;
    [SerializeField] [Range(0f, 2f)] private float maxPitch = 1.1f;

    [SerializeField] bool loop = false;
   
    // Public getters to allow SoundManager to access the data
    // If you expect me to explain the fields I suggest you learn the basics of sound.
    // See Physics > Waves > Soundwaves and their properties, in any physics textbook of your trust
    public string ID => id;
    public AudioClip AudioClip => clip;
    public float Volume => volume;
    public float MinPitch => minPitch;
    public float MaxPitch => maxPitch;
    public bool Loop => loop;
}
