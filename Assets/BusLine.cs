using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusLine : MonoBehaviour
{
    public int BusNumber;
    public Color LineColor;
    [SerializeField] List<BusStop> busStopsOnRoute;

    public BusStorage LineStorage;

    public BusStorage DefaultStorage;

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

        if (DefaultStorage)
        {
            SetStorage(DefaultStorage);
        }else
        {
            Debug.LogError("NO default storage for this line");
        }
       
    }

    public void SetStorage(BusStorage NewStorage)
    {
        if (LineStorage)
        {
            LineStorage.StoredLines.Remove(this);
        }

        LineStorage = NewStorage;
        LineStorage.StoredLines.Add(this);

    }

    // Update is called once per frame
    void Update()
    {

    }
}