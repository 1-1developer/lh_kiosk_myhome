using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMover : MonoBehaviour
{
    TrailRenderer trailRenderer;

    [SerializeField]
    float speed;
    public Transform startPos; 
    public Transform startPos2;
    List<Vector3> reorderPositions = new List<Vector3>();
    List<Vector3> positions = new List<Vector3>();
    bool reached=false;
    public bool stop = false;

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.time = 0;

        Transform[] r = { startPos, startPos2 };

        trailRenderer.transform.position = startPos.position;

        trailRenderer.time = 1000;
        stop = true;

    }
    private void Update()
    {
        GoLine();
    }
    float curdistance;
    int index;
    public void setRoute(Transform[] r)
    {
        reorderPositions.Clear();
        for (int i = 0; i < r.Length; i++)
        {
            reorderPositions.Add(r[i].position);
        }
        trailRenderer.time = 1000;
        index = 0;
        stop = false;
    }
    void GoLine()
    {
        if (index >= reorderPositions.Count)
        {
            stop = true;
            return;
        }
        if (stop)
        {
            return;
        }
        Vector3 startpos = reorderPositions[index];
        Vector3 goal = reorderPositions[index+1];
        Debug.Log("i:" + index);
        Debug.Log("i2:" + reorderPositions.Count);
        Vector3 curpos = startpos;

        float distance = Vector3.Distance(startpos, goal);
        curdistance+= speed * Time.deltaTime;
        if (curdistance <= distance)
        {
            curpos = Vector3.Lerp(startpos, goal, curdistance / distance);
            trailRenderer.transform.position = curpos;
        }
        else if (Vector3.Distance(curpos, goal)<.05f)
        {
            reached = true;
            curdistance = 0;
            index++;
        }
    }
    public void initLine()
    {
        stop = true;
        trailRenderer.transform.position = startPos.position;
        index = 0;
        curdistance = 0;
        trailRenderer.time = 0;
    }
}

