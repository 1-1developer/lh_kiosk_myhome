using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimator : MonoBehaviour
{
    [SerializeField] private float animationDuration = 5f;
    private LineRenderer lineRenderer;
    private Vector3[] linePoints;
    private int pointsCount;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        pointsCount = lineRenderer.positionCount;
        linePoints = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++){
            linePoints[i] = lineRenderer.GetPosition(i);
        }
        StartCoroutine(AnimationLine());
    }

    private IEnumerator AnimationLine()
    {
        float segmentDuration = animationDuration / pointsCount;

        for (int i = 0; i < pointsCount - 1; i++){
            float startTime = Time.time;

            Vector3 startPosition = linePoints[i];
            Vector3 endPosition = linePoints[i + 1];

            Vector3 pos = startPosition;
            while (pos != endPosition)
            {
                float t = (Time.time - startTime) / segmentDuration;
                pos = Vector3.Lerp(startPosition, endPosition, t);

                for (int j = i+1; j < pointsCount; j++)
                    lineRenderer.SetPosition(j, pos);
                yield return null;
            }
        }
    }

    void Update()
    {
        
    }
}
