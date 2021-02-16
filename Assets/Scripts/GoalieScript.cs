using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GoalieScript : MonoBehaviour
{
    bool bMovingRight = false;

    [SerializeField]
    GameObject ball = null;
    [SerializeField]
    GameController m_GameCont = null;
    [SerializeField]
    public bool b_Move = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(b_Move)
            Block();
    }

    void Block()
    {
        if (bMovingRight == true)
        {
            if (transform.position.x <= 5.0f)
            {
                transform.Translate(0.5f, 0.0f, 0.0f, Space.World);
            }
            else
                bMovingRight = false;
        }
        else
        {
            if (transform.position.x >= -5.0f)
            {
                transform.Translate(-0.55f, 0.0f, 0.0f, Space.World);
            }
            else
                bMovingRight = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ball)
        {
            m_GameCont.GoalieBlock();
        }
    }
}
