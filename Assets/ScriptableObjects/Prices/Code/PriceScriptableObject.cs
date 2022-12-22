using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PriceScriptableObject", menuName = "ScriptableObjects/PriceValue")]
public class PriceScriptableObject : ScriptableObject
{
    public float Value = 0;
}
