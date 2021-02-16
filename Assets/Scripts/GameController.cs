using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject m_Ball = null;
    [SerializeField]
    GameObject m_Net = null;
    [SerializeField]
    GameObject m_Goalie = null;
    [SerializeField]
    AudioClip m_GoalSound;
    [SerializeField]
    AudioClip m_BlockSound;

    public bool bBallInPlay;
    public bool bPlayCompelete = false;

    public int numGoals;
    public int numBlocks;

    private BallPhysics m_BallProjComp = null;
    private NetBehaviour m_NetBehaviour = null;

    // Start is called before the first frame update
    void Start()
    {
        m_BallProjComp = m_Ball.GetComponent<BallPhysics>();
        Assert.IsNotNull(m_BallProjComp, "No Projectile Compononet Found");

        m_NetBehaviour = m_Net.GetComponent<NetBehaviour>();
        Assert.IsNotNull(m_NetBehaviour, "No Net Behaviour Found");
    }

    // Update is called once per frame
    void Update()
    {
        HandleUserInput();
    }
    public void GoalieBlock()
    {
        if (!bPlayCompelete)
        {
            AudioSource.PlayClipAtPoint(m_BlockSound, transform.position);
            m_NetBehaviour.setLightColor(Color.red);
            numBlocks++;
            bPlayCompelete = true;
        }
    }

    public void Goal()
    {
        if (!bPlayCompelete)
        {
            AudioSource.PlayClipAtPoint(m_GoalSound, transform.position);
            m_NetBehaviour.setLightColor(Color.green);
            numGoals++;
            bPlayCompelete = true;
        }
    }

    private void HandleUserInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_BallProjComp.OnKickBall();
            //launch
        }

        if (Input.GetKey(KeyCode.W))
        {
            //m_BallProjComp.OnMoveForward(0.05f);
            m_BallProjComp.OnMoveUp(0.05f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //m_BallProjComp.OnMoveBackward(0.05f);
            m_BallProjComp.OnMoveDown(0.05f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_BallProjComp.OnMoveRight(0.05f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_BallProjComp.OnMoveLeft(0.05f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            m_BallProjComp.Reset();

            m_NetBehaviour.setLightColor(Color.white);
            bPlayCompelete = false;
        }
    }
}
