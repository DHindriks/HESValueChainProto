using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance;

    //Default prices
    //BUILDCOSTS
   public float BusPriceFossil;

   public float BusPriceElectric;

   public float BusPriceHydrogen;

   public float BusStoragePrice;

   public float HydroPumpPrice;

   public float HydroPipelinePrice;



    //FUEL COSTS
   public float FossilFuelPrice;

   public float ElectricPrice;

   public float HydrogenPrice;

    //Maintenance/Recurring costs
    public float FossilBusMaintenance;

    public float ElectricBusMaintenance;

    public float HydrogenBusMaintenance;



    //TotalCosts Tracker
    [HideInInspector] public int BusstoragesBought;


    float TotalCosts;

    void Start()
    {
        Instance = this;
    }

    public float GetTotalCosts()
    {
        TotalCosts = (BusstoragesBought * BusStoragePrice);

        return TotalCosts;
    }

}
