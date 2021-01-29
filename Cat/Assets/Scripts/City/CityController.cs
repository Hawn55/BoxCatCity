using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CityController : MonoBehaviour
{
    [Header( "カメラアニメーション" )]
    [SerializeField]
    Animator m_MainCameraAnimator;

    [Header( "空環境" )]
    [SerializeField] Volume m_SkyFogVolume;

    HDRISky sky;
    float sec;
    float rot;

    [Header( "声" )]
    [SerializeField]
    AudioSource m_VoiceAudioSource;

    [SerializeField]
    AudioClip m_CatAudio;

    void Start()
    {
        StartCoroutine( CatVoice() );

        m_SkyFogVolume.profile.TryGet( out sky );
    }

    void Update()
    {
        sec = Time.deltaTime;
        sky.rotation.value += 1 * sec;
    }

    IEnumerator CatVoice()
    {
        yield return new WaitForSeconds( 3f );
        m_VoiceAudioSource.Play();

        yield return new WaitForSeconds( 1f );
        m_MainCameraAnimator.enabled = true;
    }
}
