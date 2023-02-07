using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateStorageList : MonoBehaviour
{
    [SerializeField] Button Selectionprefab;

    public BusLine LineToChange;

    void Start()
    {
        foreach (GameObject Storage in GameObject.FindGameObjectsWithTag("BusStorage"))
        {
            Button SelectionBtn = Instantiate(Selectionprefab, transform);
            SelectionBtn.GetComponentInChildren<TextMeshProUGUI>().text = Storage.GetComponent<BusStorage>().BuildingName;

            SelectionBtn.onClick.AddListener(delegate { Destroy(transform.root.gameObject); });
            SelectionBtn.onClick.AddListener(delegate { LineToChange.SetStorage(Storage.GetComponent<BusStorage>()); });
        }
    }

}
