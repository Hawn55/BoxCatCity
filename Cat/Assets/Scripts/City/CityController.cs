using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class CityController : MonoBehaviour
{
    [SerializeField]
    VolumeProfile m_VolumeProfile;

    [SerializeField]
    AudioSource m_VoiceAudioSource;

    [SerializeField]
    AudioClip m_CatAudio;

    void Start()
    {
        StartCoroutine( CatVoice() );
    }

    IEnumerator CatVoice()
    {
        yield return new WaitForSeconds( 3f );
        m_VoiceAudioSource.Play();
    }
}
