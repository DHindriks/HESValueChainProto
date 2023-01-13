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

    public FuelTypes Fueltype;

    [SerializeField] GameObject LineConfigMenu;

    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> StopPositions = new List<Vector3>();
        line = GetComponent<LineRenderer>();
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

    public void ChangeFuelType(FuelTypes type)
    {
        Fueltype = type;
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

    public void OpenUI()
    {
        LineConfigMenu.SetActive(true);
    }
}