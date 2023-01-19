using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListChildren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.childCount);
    }
}
