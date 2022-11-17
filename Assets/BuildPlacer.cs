using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlacer : MonoBehaviour
{
    [SerializeField] LayerMask mask; //TODO: fix mask not working
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, mask))
        {
            transform.position = hit.point;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(this);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Destroy(this.gameObject);
        }
    }
}
