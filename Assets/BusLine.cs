using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusLine : MonoBehaviour
{
    public int BusNumber;
    public Color LineColor;
    Color FuelColor;

    [SerializeField] List<BusStop> busStopsOnRoute;

    public BusStorage LineStorage;

    public BusStorage DefaultStorage;

    public FuelTypes Fueltype;

    [SerializeField] GameObject LineConfigMenu;

    LineRenderer line;

    [HideInInspector] public BuslineManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> StopPositions = new List<Vector3>();
        line = GetComponent<LineRenderer>();
        RefreshDisplay();

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

        RefreshDisplay();
    }

    public void RefreshDisplay()
    {

        if (Fueltype == FuelTypes.Diesel)
        {
            FuelColor = Manager.FossilFuel;
        }
        else if (Fueltype == FuelTypes.Elektrisch)
        {
            FuelColor = Manager.ElectricFuel;
        }
        else if (Fueltype == FuelTypes.Waterstof)
        {
            FuelColor = Manager.HydrogenFuel;
        }

        switch (Manager.CurrentDispSetting)
        {
            case BuslineManager.BuslineDisplay.Buslines:
                line.material = Manager.SimpleColorBase;
                line.startColor = LineColor;
                line.endColor = LineColor;
                break;

            case BuslineManager.BuslineDisplay.Fueltypes:
                line.material = Manager.SimpleColorBase;
                line.startColor = FuelColor;
                line.endColor = FuelColor;
                break;

            case BuslineManager.BuslineDisplay.BuslinesFueltypes:
                switch (Fueltype)
                {
                    case FuelTypes.Diesel:
                        line.material = Manager.FossilCombo;
                        break;
                    case FuelTypes.Elektrisch:
                        line.material = Manager.ElectricCombo;
                        break;
                    case FuelTypes.Waterstof:
                        line.material = Manager.HydrogenCombo;
                        break;
                }
                line.startColor = LineColor;
                line.endColor = LineColor;
                break;
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

    public void OpenUI()
    {
        LineConfigMenu.SetActive(true);
    }
}