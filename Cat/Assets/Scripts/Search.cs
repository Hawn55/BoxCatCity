using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : MonoBehaviour
{
    [SerializeField]
    CatController m_CatController;

    void OnTriggerEnter( Collider other )
    {
        if( other.tag == "Food" )
        {
            m_CatController.m_Goal = other.transform;
        }
    }
}
