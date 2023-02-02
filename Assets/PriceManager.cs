using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance;

    //Default prices
    //BUILDCOSTS
   public PriceScriptableObject BusPriceFossil;

   public PriceScriptableObject BusPriceElectric;

   public PriceScriptableObject BusPriceHydrogen;

   public PriceScriptableObject BusStoragePrice;

   public PriceScriptableObject HydroPumpPrice;

   public PriceScriptableObject HydroPipelinePrice;



    //FUEL COSTS
   public PriceScriptableObject FossilFuelPrice;

   public PriceScriptableObject ElectricPrice;

   public PriceScriptableObject HydrogenPrice;

    public PriceScriptableObject KGHydrogenNeeded;
    public PriceScriptableObject KWHNeededPerKGHydro;

    //EMISSIONS
    [SerializeField] BuslineManager buslineManager;
    public PriceScriptableObject KGGreyHydroEmmissionPerKM;
    public PriceScriptableObject KGGreenHydroEmmissionPerKM;
    public PriceScriptableObject KGDieselEmmissionPerKM;
    float TotalEmissions;


    //TotalCosts Tracker
    [HideInInspector] public int BusstoragesBought;


    float TotalCosts;
    [SerializeField] TextMeshProUGUI TotalPriceTXT;
    [SerializeField] TextMeshProUGUI EmissionsTXT;

    void Start()
    {
        Instance = this;
        Invoke("GetTotalEmissions", 0.1f);
    }

    public float GetTotalCosts()
    {
        TotalCosts = (BusstoragesBought * BusStoragePrice.Value);

        TotalPriceTXT.text = "Totale Kosten: €" + TotalCosts.ToString();

        return TotalCosts;
    }

    public float GetTotalEmissions()
    {
        TotalEmissions = 0;

        foreach (BusLine line in buslineManager.Buslines)
        {
            switch(line.Fueltype)
            {
                case FuelTypes.Waterstof:
                    TotalEmissions += line.KGCO2EmissionsGreenHydrogenPerKM;
                    break;

                case FuelTypes.Elektrisch:
                    TotalEmissions += line.KGCO2EmissionsGreenHydrogenPerKM;
                    break;

                case FuelTypes.Diesel:
                    TotalEmissions += line.KGCO2EmissionsDieselPerKM;
                    break;
            }
        }

        EmissionsTXT.text = "Totale uitstoot: " + TotalEmissions + " KG CO2 per week";
        return TotalEmissions;
    }

}
