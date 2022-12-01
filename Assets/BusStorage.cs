using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BusStorage : MonoBehaviour
{

    //UI variables
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI TitleObj;
    [SerializeField] GameObject LinesStoredWindow;
    [SerializeField] GameObject LineIconPrefab;

    //Stat variables
    public List<BusLine> StoredLines;

    public string BuildingName;

    [SerializeField] int HydrogenPumps;

    [SerializeField] int HydrogenStored;
    
    void Start()
    {
        if (canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(false);
        }

        SetName(BuildingName);

    }

    public void SetName(string NewName)
    {
        BuildingName = NewName;
        TitleObj.text = NewName;
    }

    void UpdateLineList()
    {
        foreach(Transform obj in LinesStoredWindow.transform)
        {
            Destroy(obj.gameObject);
        }

        foreach(BusLine line in StoredLines)
        {
            GameObject icon = Instantiate(LineIconPrefab, LinesStoredWindow.transform);
            icon.GetComponent<RawImage>().color = line.LineColor;
            icon.GetComponentInChildren<TextMeshProUGUI>().text = line.BusNumber.ToString();
            icon.GetComponent<Button>().onClick.AddListener(delegate{ line.OpenUI(); });
        }
    }

    void OnMouseDown()
    {
        if (!GetComponent<BuildPlacer>())
        {
            OpenBuildingUI();
        }
    }

    void OpenBuildingUI()
    {
        canvas.gameObject.SetActive(true);
        UpdateLineList();
    }

    public void CloseBuildingUI()
    {
        canvas.gameObject.SetActive(false);
    }
}
