using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    [SerializeField]
    public Transform m_Goal;

    [SerializeField]
    Transform[] m_RotationPos;

    NavMeshAgent agent;
    Animator animator;

    [SerializeField]
    BoxCollider m_BoxCollider;

    [Header( "声" )]
    [SerializeField]
    AudioSource m_VoiceAudioSource;

    [SerializeField]
    AudioClip m_CatAudio;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Reset()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }



    void Update()
    {
        if( m_Goal != null )
        {
            agent.destination = m_Goal.position;
            m_Goal = null;

            if( m_VoiceAudioSource != null ) m_VoiceAudioSource.Play();
        }
        else
        {

        }

        animator.SetFloat( "Speed", agent.velocity.sqrMagnitude );
    }
}