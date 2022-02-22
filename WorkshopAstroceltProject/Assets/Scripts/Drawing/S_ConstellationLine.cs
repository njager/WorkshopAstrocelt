using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ConstellationLine : MonoBehaviour
{
    private S_Global g_global;

    public S_StarClass s_previousStar;
    public S_StarClass s_nextStar;

    [Header("New Required Variables for Line Script")]
    public GameObject m_childLineRendererObject;

    public LineRenderer m_lineRendererInst;
    private CapsuleCollider2D m_cap;
    public float f_boxOffsetX;
    public float f_boxOffsetY;
    public GameObject constellationLinePrefab;
    public int i_index;
    public float f_lineWidth;
    public S_StarClass s_nullStarInst;

    private void Awake()
    {
        m_lineRendererInst = m_childLineRendererObject.GetComponent<LineRenderer>();
        g_global = S_Global.Instance;
        g_global.g_lst_lineRendererList.Add(gameObject);
        g_global.g_lineMultiplierManager.lst_tempList.Add(gameObject);
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other = col.gameObject;
        if (other.CompareTag("Line")) //check if collider is a line
        {
            if (other.GetComponent<S_ConstellationLine>().i_index < i_index) //check which one has a larger index
            {
                g_global.g_DrawingManager.GoBackOnce(this.gameObject);
                //g_global.g_DrawingManager.ConstellationReset();
            }
        }
        if (other.CompareTag("Star"))
        {
            if(other!=s_previousStar.gameObject && other!= s_nextStar.gameObject && other!=s_nullStarInst)
            {
                Debug.Log("encountered another star in path");
                g_global.g_DrawingManager.GoBackOnce(this.gameObject);
            }
            else { return; }
        }
        if (other.CompareTag("Meteor"))
        {
            Debug.Log("encountered a Meteor chain in path");
            g_global.g_DrawingManager.GoBackOnce(this.gameObject);
           
        }
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

        if(_startPoint == _endPoint) { g_global.g_DrawingManager.GoBackOnce(this.gameObject); }

        // Grab the box collider
        m_cap = gameObject.GetComponent<CapsuleCollider2D>();

        //Distance calculation aka Length
        float _newBoxLength= Mathf.Pow(Mathf.Pow((_endPoint.x - _startPoint.x),2) + Mathf.Pow((_endPoint.y - _startPoint.y), 2), 0.5f);
        //Debug.Log(_newBoxLength);

        //Width Grab
        float _lineWidth = f_lineWidth;

        //Set the new Box
        Vector2 _newBoxSize = new Vector2 (calculateXOffset(_newBoxLength), calculateYOffset(_lineWidth));
        m_cap.size = _newBoxSize;

        // Keep original position
        Transform _originalPosition = gameObject.transform;

        // Need to move parent object to the center
        gameObject.transform.position = _startPoint + (_endPoint - _startPoint) / 2;
  
        // Calculate rotation, adapted code 
        Vector3 _difference = _star.gameObject.transform.position - transform.position;
        float _newZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, _newZ);

        ///<summary>
        /// https://answers.unity.com/questions/1023987/lookat-only-on-z-axis.html original code found in here
        ///</summary>
    }
}
