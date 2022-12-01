using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
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
