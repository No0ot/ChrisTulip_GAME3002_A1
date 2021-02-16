using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;

public class BallPhysics : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_vInitialVelocity = Vector3.zero;
    [SerializeField]
    Slider m_PowerValue;
    [SerializeField]
    float fDelta;
    [SerializeField]
    float fTheta;

    public Rigidbody m_rb = null;
    private GameObject m_TargetDisplay = null;

    private bool m_bKickBall = true;

    private float m_fDistanceToTarget = 0f;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 xNormal = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem here! No Rigidbody attached");

        CreateTargetDisplay();
        m_fDistanceToTarget = (m_TargetDisplay.transform.position - transform.position).magnitude;
        startPosition = transform.position;
        xNormal = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        m_fDistanceToTarget = (m_TargetDisplay.transform.position - transform.position).magnitude;
    }

    private void CreateTargetDisplay()
    {
        m_TargetDisplay = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        m_TargetDisplay.transform.position = new Vector3(0.0f, 2.0f, 12.0f);
        m_TargetDisplay.transform.localScale = new Vector3(1.5f, 0.1f, 1.5f);
        m_TargetDisplay.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        m_TargetDisplay.GetComponent<Renderer>().material.color = Color.red;
        m_TargetDisplay.GetComponent<Collider>().enabled = false;
    }

    public void OnKickBall()
    {
        // H = Vi^2 * sin^2(theta) / 2g
        // R = 2Vi^2 * cos(theta) * sin(theta) / g

        // Vi = sqrt(2gh) / sin(tan^-1(4h/r))
        // theta = tan^-1(4h/r)

        // Vy = V * sin(theta)
        // Vz = V * cos(theta)

        if (m_bKickBall)
        {
            m_bKickBall = false;
            float fMaxHeight = m_TargetDisplay.transform.position.y;
            float fRange = (m_fDistanceToTarget * 2);
            fTheta = Mathf.Atan((4 * fMaxHeight) / (fRange));

            float fInitVelMag = Mathf.Sqrt((2 * Mathf.Abs(Physics.gravity.y) * fMaxHeight)) / Mathf.Sin(fTheta);


            Vector3 VectortoTarget = (m_TargetDisplay.transform.position - transform.position);
            fDelta = (Vector3.Dot(VectortoTarget, xNormal) / (VectortoTarget.magnitude) * xNormal.magnitude);

            m_vInitialVelocity.x = fInitVelMag * Mathf.Cos(fTheta) * Mathf.Sin(fDelta);
            m_vInitialVelocity.y = fInitVelMag * Mathf.Sin(fTheta);
            m_vInitialVelocity.z = fInitVelMag* Mathf.Cos(fTheta) * Mathf.Cos(fDelta);


            m_rb.velocity = m_vInitialVelocity * m_PowerValue.value;
        }
    }

    #region INPUT_FUNCTIONS
    public void OnMoveRight(float val) 
    {
        m_TargetDisplay.transform.Translate(val, 0.0f, 0.0f, Space.World);
    }
    public void OnMoveLeft(float val) 
    {
        m_TargetDisplay.transform.Translate(-val, 0.0f, 0.0f, Space.World);
    }

    public void OnMoveUp(float val) 
    {
        m_TargetDisplay.transform.Translate(0.0f, val, 0.0f, Space.World);
    }
    public void OnMoveDown(float val)
    {
        m_TargetDisplay.transform.Translate(0.0f, -val, 0.0f, Space.World);
    }

    public void Reset()
    {
        transform.position = startPosition;
        m_bKickBall = true ;
        m_vInitialVelocity = Vector3.zero;
        m_rb.velocity = Vector3.zero;
        m_rb.angularVelocity = Vector3.zero;

    }
    #endregion
}
