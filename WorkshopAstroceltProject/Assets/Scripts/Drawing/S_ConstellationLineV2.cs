using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ConstellationLineV2 : MonoBehaviour
{
    // control points for a single spline segment curve:
    [SerializeField] private Transform control0, control1, control2, control3;

    // the two line renderers: the control polyline, and the spline curve itself:
    [SerializeField] private LineRenderer splineCurve;

    // how many points on the spline curve?
    //   (the more points you set, the smoother the curve will be)
    [Range(8, 512)][SerializeField] private int curvePoints = 16;


    void Start()
    {
        if (splineCurve.positionCount != curvePoints)
        {
            splineCurve.positionCount = curvePoints;
        }

        Matrix4x4 splineMatrix = new Matrix4x4( // COLUMN MAJOR!
            new Vector4(-1, 3, -3, 1), // TODO
            new Vector4(3, -6, 3, 0), // TODO
            new Vector4(-3, 3, 0, 0), // TODO
            new Vector4(1, 0, 0, 0) // TODO
        );


        // and now compute the spline curve, point by point:
        for (int i = 0; i < curvePoints; i++)
        {
            float u = (float)i / (float)(curvePoints - 1);

            Matrix4x4 controlMatrix = new Matrix4x4(
               control0.position,
               control1.position,
               control2.position,
               control3.position
            );

            Vector4 uRow = new Vector4(Mathf.Pow(u, 3), Mathf.Pow(u, 2), u, 1);

            Vector4 splinePointPosition = controlMatrix * splineMatrix * uRow;

            splineCurve.SetPosition(i, (Vector2)splinePointPosition);
        }
    }



}
