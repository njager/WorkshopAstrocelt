using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTempScript : MonoBehaviour
{
    private S_Global g_global;

    public S_StarClass testStar1;
    public S_StarClass testStar2; 

    [Header("New Required Variables for Line Script")]
    public GameObject m_childLineRendererObject;

    public LineRenderer m_lineRendererInst;
    private BoxCollider2D m_box;
    public float f_boxOffsetX;
    public float f_boxOffsetY;
    public GameObject constellationLinePrefab;

    [Header("Required Variables from S_DrawingManager")]
    public int i_index;
    public Vector2 v2_prevLoc;

    public float f_lineWidth;

    public S_StarClass s_previousStar;
    public S_StarClass s_nextStar;

    public S_StarClass star3; 

    private void Awake()
    {
        m_lineRendererInst = m_childLineRendererObject.GetComponent<LineRenderer>();
    }
    void Start()
    {
        g_global = S_Global.g_instance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other = col.gameObject;
        if (other.CompareTag("Line")) //check if collider is a line
        {
            if (other.GetComponent<LineTempScript>().i_index < i_index) //check which one has a larger index
            {
                //g_global.g_DrawingManager.GoBackOnce(m_lineRendererInst);
                return; 
            }
        }
        //add functionality for running into another star
    }

    public float calculateXOffset(float _length)
    {
        float _offsetedLength = _length * (1-f_boxOffsetX);
        return _offsetedLength; 
    }

    public float calculateYOffset(float _width)
    {
        float _offsetedWidth = _width * (1 - f_boxOffsetY);
        return _offsetedWidth;
    }

    public void SetUp(S_StarClass _star)
    {
        //Grab Line Renderer point data
        Vector3 _startPoint = m_lineRendererInst.GetPosition(0);
        Vector3 _endPoint = m_lineRendererInst.GetPosition(1);

        // Grab the box collider
        m_box = gameObject.GetComponent<BoxCollider2D>();

        //Distance calculation aka Length
        float _newBoxLength= Mathf.Pow(Mathf.Pow((_endPoint.x - _startPoint.x),2) + Mathf.Pow((_endPoint.y - _startPoint.y), 2), 0.5f);
        //Debug.Log(_newBoxLength);

        //Width Grab
        float _lineWidth = f_lineWidth;

        //Set the new Box
        Vector2 _newBoxSize = new Vector2 (calculateXOffset(_newBoxLength), calculateYOffset(_lineWidth));
        m_box.size = _newBoxSize;

        // Keep original position
        Transform _originalPosition = gameObject.transform;

        // Need to move parent object to the center
        gameObject.transform.position = _startPoint + (_endPoint - _startPoint) / 2;

        //transform.LookAt(new Vector3(transform.position.x, transform.position.y, _star.gameObject.transform.position.z));
  
        // Calculate rotation, adapted code 
        Vector3 _difference = _star.gameObject.transform.position - transform.position;
        float _newZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, _newZ);

        ///<summary>
        /// https://answers.unity.com/questions/1023987/lookat-only-on-z-axis.html original code found in here
        ///</summary>
    }

    public void SpawnLine(S_StarClass _star1, S_StarClass _star2, Vector2 _loc1, Vector2 _loc2)
    {
        //Instiate the linePrefab and grab it's objects
        GameObject _newLineObject = Instantiate(constellationLinePrefab);
        LineTempScript _lineScript = _newLineObject.GetComponent<LineTempScript>();
        LineRenderer _newLine = _lineScript.m_childLineRendererObject.GetComponent<LineRenderer>(); 

        // Set line positions and width
        _newLine.SetPosition(0, _loc2);
        _newLine.SetPosition(1, _loc1);
        _newLine.startWidth = _lineScript.f_lineWidth;
        _newLine.endWidth = _lineScript.f_lineWidth; 

        // Run set up script
        _lineScript.SetUp(_star1);

        //Set Stars in lineScript
        _lineScript.s_previousStar = _star1;
        _lineScript.s_nextStar = _star2;

        _lineScript.i_index = g_global.g_DrawingManager.i_index;

        g_global.g_DrawingManager.i_index++;

        //set the vars for the stars so that they have the line theyre attached to, and the previous and next star
        _star1.s_star.m_nextLine = _newLine;
        _star2.s_star.m_previousLine = _newLine;

        _star1.s_star.m_next = _star2;
        _star2.s_star.m_previous = _star1;

        //set the previous star and loc
        s_previousStar = _star2;
        v2_prevLoc = _loc2;
    }

    // Test Function
    public void TestButton()
    {
        Vector2 _loc1 = new Vector2(0.0f, 0.79f);
        Vector2 _loc2 = new Vector2(2.51f, 5.08f);
        SpawnLine(testStar1, testStar2, _loc1, _loc2);
    }

    public void TestButton2()
    {
        Vector2 _loc1 = new Vector2(2.51f, 5.08f);
        Vector2 _loc2 = new Vector2(7.04f, 2.2f);
        SpawnLine(testStar2, star3, _loc1, _loc2);
    }
}
