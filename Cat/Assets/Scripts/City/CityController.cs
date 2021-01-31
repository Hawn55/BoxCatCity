using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Header( "テキスト" )]
    [SerializeField]
    GameObject m_Title;

    [SerializeField]
    GameObject m_TapArea;

    [Header( "ステージパネル" )]
    [SerializeField]
    GameObject m_StageIcon;

    [SerializeField]
    Animator m_Panel;

    void Start()
    {
        Screen.SetResolution( 1280, 800, false, 60 );

        m_TapArea.gameObject.SetActive( false );

        if( StaticRunTime.stage == 0 )
        {
            StartCoroutine( CatVoice() );
        }
        else
        {
            StartCoroutine( OnTap() );
        }

        m_SkyFogVolume.profile.TryGet( out sky );
    }

    void Update()
    {
        sec = Time.deltaTime;
        sky.rotation.value += 1 * sec;

        if( Input.GetMouseButtonDown( 0 ) )
        {
            if( m_TapArea.gameObject.activeSelf )
            {
                StartCoroutine( OnTap() );
            }
        }
    }

    IEnumerator CatVoice()
    {
        yield return new WaitForSeconds( 3f );
        m_VoiceAudioSource.Play();

        yield return new WaitForSeconds( 1f );

        m_TapArea.gameObject.SetActive( true );
    }

    IEnumerator OnTap()
    {
        m_MainCameraAnimator.enabled = true;
        m_TapArea.gameObject.SetActive( false );
        m_Title.SetActive( false );

        yield return new WaitForSeconds( 2f );

        m_StageIcon.SetActive( true );
    }

    public void OnIconTap()
    {
        m_Panel.enabled = true;
    }

    public void OnStageTap()
    {
        StaticRunTime.stage = 1;
        SceneManager.LoadScene( "Stage" + StaticRunTime.stage.ToString() );
    }
}
