using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ConstellationLine : MonoBehaviour
{
    private S_Global g_global;

    private CapsuleCollider2D m_cap;

    [Header("Previous and Next Stars")]
    public S_StarClass s_previousStar;
    public S_StarClass s_nextStar;

    [Header("New Required Variables for Line Script")]
    public GameObject m_childLineRendererObject;

    public LineRenderer m_lineRendererInst;
    public GameObject constellationLinePrefab;
    public int i_index;

    [Header("Materials and Colors")]
    public Material m_dottedLine;
    public Material m_solidLine;
    public Color cl_errorLineColor;
    public Color cl_correctLineColor;

    [Header("Offset Vars")]
    public float f_boxOffsetX;
    public float f_boxOffsetY;

    [Header("Variable Line Width")]
    [SerializeField] float f_lineWidthMin;
    [SerializeField] float f_lineWidthMax;

    public float f_lineWidth;
    public float f_lineLength;

    [Header("Conditional Vars")]
    public S_StarClass s_nullStarInst;
    public bool b_starAdded = false;

    

    private void Awake()
    {
        g_global = S_Global.Instance;
        g_global.g_ls_lineRendererList.Add(gameObject);
        m_lineRendererInst = m_childLineRendererObject.GetComponent<LineRenderer>();
        
        //Set variable width, min .11, max 0.175
        f_lineWidth = Random.Range(f_lineWidthMin, f_lineWidthMax);
    }

    /// <summary>
    /// Fix the problem with lines resetting
    /// </summary>
    public void TriggerLineTransfer()
    {
        g_global.g_ls_lineRendererList.Remove(gameObject);
        g_global.g_ls_completedLineRendererList.Add(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Is there collision");
        GameObject other = col.gameObject;
        if (other.CompareTag("Meteor"))
        {
            Debug.Log("encountered a Meteor chain in path");

            //change the color to error
            m_lineRendererInst.startColor = cl_errorLineColor;
            m_lineRendererInst.endColor = cl_errorLineColor;
        }
        else if (other.CompareTag("Line")) //check if collider is a line
        {
            //print("Theres a line");
            //Use if lines connecting to the same stars are colliding if(&& other.GetComponent<LineRenderer>() != _prevLine)
            if (s_previousStar.s_star.m_previousLine)
            {
                //Debug.Log(" Line with this index:"+ i_index);
                S_ConstellationLine _prevLine = s_previousStar.s_star.m_previousLine;

                //execute if the lines arnt next to eachother
                if(other.GetComponent<S_ConstellationLine>().i_index != _prevLine.i_index)
                {
                    if (other.GetComponent<S_ConstellationLine>().i_index < i_index) //check which one has a larger index and if it is equal to the previous line
                    {
                        Debug.Log("Hit another Line connected to the stars");

                        //change the color to error
                        m_lineRendererInst.startColor = cl_errorLineColor;
                        m_lineRendererInst.endColor = cl_errorLineColor;
                    }
                }
            }
            else if (other.GetComponent<S_ConstellationLine>().i_index < i_index ) //check which one has a larger index and if it is equal to the previous line
            {
                Debug.Log("Hit another Line with lower index");

                //change the color to error
                m_lineRendererInst.startColor = cl_errorLineColor;
                m_lineRendererInst.endColor = cl_errorLineColor;
            }
        }
        else if (other.CompareTag("Star")) //check if the col is a star
        {
            if(other!=s_previousStar.gameObject && other!= s_nextStar.gameObject && other!=s_nullStarInst)
            {
                Debug.Log("encountered another star in path");

                //change the color to error
                m_lineRendererInst.startColor = cl_errorLineColor;
                m_lineRendererInst.endColor = cl_errorLineColor;
            }
            else
            {
                if (!b_starAdded)
                {
                    //make the line wait to go to the constellation manager too delete itself
                    StartCoroutine(g_global.g_ConstellationManager.LineWait(s_nextStar));
                    b_starAdded = true;
                }
            }
        }
    }

    /// <summary>
    /// This Function calculates the X offset
    /// - Riley
    /// </summary>
    public float calculateXOffset(float _length)
    {
        float _offsetedLength = _length * (1-f_boxOffsetX);
        return _offsetedLength; 
    }

    /// <summary>
    /// This Function calculates the Y offset
    /// - Riley
    /// </summary>
    public float calculateYOffset(float _width)
    {
        float _offsetedWidth = _width * (1-f_boxOffsetY);
        return _offsetedWidth;
    }

    /// <summary>
    /// This function sets up the line and set the collider
    /// - Riley
    /// </summary>
    public void SetUp(S_StarClass _star)
    {
        //Grab Line Renderer point data
        Vector3 _startPoint = m_lineRendererInst.GetPosition(0);
        Vector3 _endPoint = m_lineRendererInst.GetPosition(1);

        if(_startPoint == _endPoint)
        {
            Debug.Log("This should trigger a too small constellation degug");
        }
        else
        {
            // Grab the box collider
            m_cap = gameObject.GetComponent<CapsuleCollider2D>();

            f_lineLength = Mathf.Pow((_endPoint.x - _startPoint.x), 2) + Mathf.Pow((_endPoint.y - _startPoint.y), 2);
            //Distance calculation aka Length
            float _newBoxLength = Mathf.Pow(f_lineLength, 0.5f);
            //Debug.Log(_newBoxLength);

            //Width Grab
            float _lineWidth = f_lineWidth;

            //Set the new Box
            Vector2 _newBoxSize = new Vector2(calculateXOffset(_newBoxLength), calculateYOffset(_lineWidth));
            m_cap.size = _newBoxSize;

            // Keep original position
            Transform _originalPosition = gameObject.transform;

            // Need to move parent object to the center
            gameObject.transform.position = _startPoint + (_endPoint - _startPoint) / 2;

            // Calculate rotation
            Vector3 _difference = _star.gameObject.transform.position - transform.position;
            float _newZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, _newZ);
            g_global.g_lineMultiplierManager.lst_lineLengthList.Add(f_lineLength);

            //change the color to normal
            m_lineRendererInst.startColor = cl_correctLineColor;
            m_lineRendererInst.endColor = cl_correctLineColor;
        }
    }

    /// <summary>
    /// This function resets the line renderer so that it uses a solid line
    /// </summary>
    public void ResetLineColorAndMaterial()
    {
        //make the line a solid one
        m_lineRendererInst.material = m_solidLine;
    }
}
