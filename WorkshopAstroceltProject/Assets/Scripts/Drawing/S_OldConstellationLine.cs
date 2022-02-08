using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_OldConstellationLine : MonoBehaviour
{
    private S_Global g_global;

    [Header("Editer Vars")]
    public float offset;

    [Header("Assigned when Spawned")]
    public LineRenderer lr_itSelf;
    public int i_index;

    public S_StarClass s_previousStar;
    public S_StarClass s_nextStar;

    private void Start()
    {
        g_global = S_Global.g_instance;
    }

    public void SetUp()
    {
        EdgeCollider2D _edge = lr_itSelf.GetComponent<EdgeCollider2D>();

        //Vector2[] _corners = new List<Vector2>();

        //_edge.points = _corners;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other = col.gameObject;
        if (other.CompareTag("Line")) //check if collider is a line
        {
            if (other.GetComponent<S_ConstellationLine>().i_index < i_index) //check which one has a larger index
            {
                //g_global.g_DrawingManager.GoBackOnce(lr_itSelf);
            }
        }
        //add functionality for running into another star
    }
}
