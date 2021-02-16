using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    [SerializeField]
    Light leftlight = null;
    [SerializeField]
    Light rightlight = null;
    [SerializeField]
    GameObject ball = null;
    [SerializeField]
    GameController m_GameCont = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == ball)
        {
            m_GameCont.Goal();
        }
    }

    public void setLightColor(Color col)
    {
        leftlight.color = col;
        rightlight.color = col;
    }
}
