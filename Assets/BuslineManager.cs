using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuslineManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI OptionDisplay;
    public List<BusLine> Buslines;

    public enum BuslineDisplay
    {
        Buslines,
        Fueltypes,
        BuslinesFueltypes
    }
    public BuslineDisplay CurrentDispSetting = BuslineDisplay.Buslines;

    [Space(5), Tooltip("Single Display mats")]
    public Material SimpleColorBase;
    public Color HydrogenFuel;
    public Color ElectricFuel;
    public Color FossilFuel;

    [Space(5), Tooltip("Combined Display mats")]
    public Material HydrogenCombo;
    public Material ElectricCombo;
    public Material FossilCombo;

    void Start()
    {
        foreach(BusLine line in Buslines)
        {
            line.Manager = this;
        }

    }

    public void SetNewOption()
    {
        switch(OptionDisplay.text)
        {
            case "Buslijnen":
                CurrentDispSetting = BuslineDisplay.Buslines;
                break;

            case "Brandstoftypes":
                CurrentDispSetting = BuslineDisplay.Fueltypes;
                break;

            case "Gecombineerd":
                CurrentDispSetting = BuslineDisplay.BuslinesFueltypes;
                break;
        }

        foreach (BusLine line in Buslines)
        {
            line.RefreshDisplay();
        }
    }

}
