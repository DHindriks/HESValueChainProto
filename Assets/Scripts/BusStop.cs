using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BusStop : MonoBehaviour
{
    public List<BusLine> StoredLines;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject LinesStoredWindow;
    [SerializeField] GameObject LineIconPrefab;
    [SerializeField] TextMeshProUGUI Title;


    // Start is called before the first frame update
    void Start()
    {
        Title.text = gameObject.name;
    }

    void OnMouseDown()
    {
        if (!GetComponent<BuildPlacer>() && !BuildManager.Instance.OpenMenu)
        {
            OpenBuildingUI();
        }
    }

    void OpenBuildingUI()
    {
        BuildManager.Instance.OpenMenu = true;
        canvas.gameObject.SetActive(true);
        UpdateLineList();
    }

    public void CloseBuildingUI()
    {
        BuildManager.Instance.OpenMenu = false;
        canvas.gameObject.SetActive(false);
    }

    void UpdateLineList()
    {
        foreach (Transform obj in LinesStoredWindow.transform)
        {
            Destroy(obj.gameObject);
        }

        foreach (BusLine line in StoredLines)
        {
            GameObject icon = Instantiate(LineIconPrefab, LinesStoredWindow.transform);
            icon.GetComponent<RawImage>().color = line.LineColor;
            icon.GetComponentInChildren<TextMeshProUGUI>().text = line.BusNumber.ToString();
            icon.GetComponent<Button>().onClick.AddListener(delegate { line.OpenUI(); });
        }
    }
}
