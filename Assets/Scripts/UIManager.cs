using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameController m_GameCont = null;
    [SerializeField]
    TMP_Text m_GoalText = null;
    [SerializeField]
    TMP_Text m_BlockText = null;
    [SerializeField]
    Slider m_Slider = null;

    private bool m_bSlideRight = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_GoalText.text = m_GameCont.numGoals.ToString();
        m_BlockText.text = m_GameCont.numBlocks.ToString();

        if (m_bSlideRight == true)
        {
            if (m_Slider.value < 1.0f)
            {
                m_Slider.value += 0.01f;
            }
            else
            {
                m_bSlideRight = false; 
            }
        }
        else
        {
            if (m_Slider.value > 0.5f)
            {
                m_Slider.value -= 0.01f;
            }
            else
            {
                m_bSlideRight = true; 
            }
        }

    }
}
