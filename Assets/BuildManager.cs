using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    public bool OpenMenu = false;

    void Start()
    {
        Instance = this;
    }

    public void InstatiateBuildingPrefab(GameObject buildingPrefab)
    {
        Instantiate(buildingPrefab);
    }



}

public enum FuelTypes
{
    Diesel,
    Elektrisch,
    Waterstof
}
