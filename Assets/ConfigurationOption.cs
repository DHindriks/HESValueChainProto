using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfigurationOption : MonoBehaviour
{
    [SerializeField] PriceScriptableObject Value;
    [SerializeField] TMP_InputField InputField;


    // Start is called before the first frame update
    void Start()
    {
        InputField.text = Value.Value.ToString();
    }

    public void SetValue()
    {
        Value.Value = float.Parse(InputField.text);
    }
}
