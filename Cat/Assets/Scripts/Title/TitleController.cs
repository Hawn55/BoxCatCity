using System.Collections;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip audioClip1;

    void Start()
    {
        StartCoroutine( CatVoice() );
    }

    IEnumerator CatVoice()
    {
        //while( true )
        //{
            yield return new WaitForSeconds( 3f );
            audioSource.Play();
        //}
    }
}
