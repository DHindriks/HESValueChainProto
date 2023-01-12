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

    //Maintenance/Recurring costs
    public PriceScriptableObject FossilBusMaintenance;

    public PriceScriptableObject ElectricBusMaintenance;

    public PriceScriptableObject HydrogenBusMaintenance;



    //TotalCosts Tracker
    [HideInInspector] public int BusstoragesBought;


    float TotalCosts;
    [SerializeField] TextMeshProUGUI TotalPriceTXT;

    void Start()
    {
        Instance = this;
    }

    public float GetTotalCosts()
    {
        TotalCosts = (BusstoragesBought * BusStoragePrice.Value);

        TotalPriceTXT.text = "Totale Kosten: €" + TotalCosts.ToString();

        return TotalCosts;
    }

}
