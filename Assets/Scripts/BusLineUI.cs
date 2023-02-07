using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BusLineUI : MonoBehaviour
{
    BusLine ThisLine;

    [SerializeField] GameObject StorageSelectionPrefab;

    [SerializeField] TextMeshProUGUI Title;
    [SerializeField] TextMeshProUGUI StoredOn;
    [SerializeField] TextMeshProUGUI FuelType;
    // Start is called before the first frame update
    void OnEnable()
    {
        ThisLine = GetComponentInParent<BusLine>();
        UpdateData();
    }

    void UpdateData()
    {
        Title.text = "Buslijn " + ThisLine.BusNumber.ToString();

        if (ThisLine.LineStorage)
        {
            StoredOn.text = "StallingsPlaats: " + ThisLine.LineStorage.BuildingName;
        }else
        {
            StoredOn.text = "Geen stalplaats";
        }

        FuelType.text = "Brandstof: " + ThisLine.Fueltype;
    }

    public void toggleUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void PickNewStorage()
    {
        GameObject StoragePicker = Instantiate(StorageSelectionPrefab);
        StoragePicker.GetComponentInChildren<CreateStorageList>().LineToChange = ThisLine;
    }
}
