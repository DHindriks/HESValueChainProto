﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public void InstatiateBuildingPrefab(GameObject buildingPrefab)
    {
        Instantiate(buildingPrefab);
    }

}
