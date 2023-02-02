using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BusLine : MonoBehaviour
{
    public int BusNumber;
    public Color LineColor;
    Color FuelColor;

    [SerializeField] List<BusStop> busStopsOnRoute;


    public BusStorage DefaultStorage;


    [SerializeField] GameObject LineConfigMenu;

    LineRenderer line;

    [HideInInspector] public BuslineManager Manager;
    [Space(20), Tooltip("Line data values")]

    public FuelTypes Fueltype;
    public BusStorage LineStorage;
    public int RidesPerWeek;
    public float KMPerRide;
    public float TotalKMPerWeek;
    public float RequiredHydrogenKGPerWeek;
    public float HydrogenCostsPerWeek;
    public float RequiredKWHForHydrogen;
    public float KGCO2EmissionsGreenHydrogenPerKM;
    public float KGCO2EmissionsGreyHydrogenPerKM;
    public float KGCO2EmissionsDieselPerKM;

    public TextMeshProUGUI RidesPerWeekUI;
    public TextMeshProUGUI KMPerRideUI;
    public TextMeshProUGUI TotalKMPerWeekUI;
    public TextMeshProUGUI RequiredHydrogenKGPerWeekUI;
    public TextMeshProUGUI HydrogenCostsPerWeekUI;
    public TextMeshProUGUI RequiredKWHForHydrogenUI;
    public TextMeshProUGUI KGCO2EmissionsGreenHydrogenPerKMUI;
    public TextMeshProUGUI KGCO2EmissionsGreyHydrogenPerKMUI;
    public TextMeshProUGUI KGCO2EmissionsDieselPerKMUI;

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> StopPositions = new List<Vector3>();
        line = GetComponent<LineRenderer>();
        RefreshDisplay();

        foreach (BusStop stop in busStopsOnRoute) 
        {
            StopPositions.Add(stop.transform.position);
            stop.StoredLines.Add(this);
        }


        line.positionCount = StopPositions.Count;
        line.SetPositions(StopPositions.ToArray());

        if (DefaultStorage)
        {
            SetStorage(DefaultStorage);
        }else
        {
            Debug.LogError("No default storage for this line");
        }
       
    }

    void CalculateStats()
    {
        TotalKMPerWeek = RidesPerWeek * KMPerRide;
        RequiredHydrogenKGPerWeek = TotalKMPerWeek * PriceManager.Instance.KGHydrogenNeeded.Value;
        HydrogenCostsPerWeek = RequiredHydrogenKGPerWeek * PriceManager.Instance.HydrogenPrice.Value;
        RequiredKWHForHydrogen = RequiredHydrogenKGPerWeek * PriceManager.Instance.KWHNeededPerKGHydro.Value;
        KGCO2EmissionsDieselPerKM = TotalKMPerWeek * PriceManager.Instance.KGDieselEmmissionPerKM.Value;
        KGCO2EmissionsGreenHydrogenPerKM = TotalKMPerWeek * PriceManager.Instance.KGGreenHydroEmmissionPerKM.Value;
        KGCO2EmissionsGreyHydrogenPerKM = TotalKMPerWeek * PriceManager.Instance.KGGreyHydroEmmissionPerKM.Value;
    }

    public void ChangeFuelType(FuelTypes type)
    {
        Fueltype = type;
        PriceManager.Instance.GetTotalEmissions();

        RefreshDisplay();
    }

    public void RefreshUI()
    {
        RidesPerWeekUI.text = "Aantal ritten per week: " + RidesPerWeek;
        KMPerRideUI.text = "Kilometer per rit: " + KMPerRide;
        TotalKMPerWeekUI.text = "Totale kilometers per week: " + TotalKMPerWeek;
        RequiredHydrogenKGPerWeekUI.text = "Benodigde hoeveelheid waterstof: " + RequiredHydrogenKGPerWeek + " KG";
        HydrogenCostsPerWeekUI.text = "Kosten waterstof per week: " + "€" + HydrogenCostsPerWeek;
        RequiredKWHForHydrogenUI.text = "Benodigde kilowattuur: " + RequiredKWHForHydrogen;
        KGCO2EmissionsGreenHydrogenPerKMUI.text = "Uitstoot groene waterstof per kilometer: " + KGCO2EmissionsGreenHydrogenPerKM + " KG";
        KGCO2EmissionsGreyHydrogenPerKMUI.text = "Uitstoot grijze waterstof per kilometer: " + KGCO2EmissionsGreyHydrogenPerKM + " KG";
        KGCO2EmissionsDieselPerKMUI.text = "Uitstoot diesel per kilometer: " + KGCO2EmissionsDieselPerKM + " KG";


    }

    public void RefreshDisplay()
    {
        CalculateStats();

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

        RefreshUI();

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