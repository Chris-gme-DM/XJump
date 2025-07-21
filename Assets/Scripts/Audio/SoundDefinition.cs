using UnityEngine;
/// <summary>
/// Sound Definitions as Scriptably objects act as lawyer for AudioClips and offer scalabilty to the SoundManager
/// </summary>
[CreateAssetMenu(fileName = "NewSoundDefintion", menuName = "Scriptable Objects/Audio/Sound")]
public class SoundDefinition : ScriptableObject
{
    [SerializeField] private string id;// Use names like "JumpSound" etc. to define sounds
    [SerializeField] private AudioClip clip;
    [Range(0f, 1f)] private float volume = 1f;
    [Range(0f, 1f)] private float pitch = 1f;
    [SerializeField] bool loop = false;
}
