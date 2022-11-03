using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusLine : MonoBehaviour
{
    [SerializeField] int BusNumber;
    [SerializeField] Color LineColor;
    [SerializeField] List<BusStop> busStopsOnRoute;

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        List<Vector3> StopPositions = new List<Vector3>();
        line.startColor = LineColor;
        line.endColor = LineColor;

        foreach (BusStop stop in busStopsOnRoute) 
        {
            StopPositions.Add(stop.transform.position);
        }


        line.positionCount = StopPositions.Count;
        line.SetPositions(StopPositions.ToArray());

    }

    // Update is called once per frame
    void Update()
    {

    }
}