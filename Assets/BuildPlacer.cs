using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildPlacer : MonoBehaviour
{
    [SerializeField] LayerMask mask;

    public UnityEvent BuildPlaced;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, mask))
        {
            transform.position = hit.point;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BuildPlaced.Invoke();
            Destroy(this);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Destroy(this.gameObject);
        }
    }
}
