using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillLabel : MonoBehaviour
{
    string labelName;
    Text labelComponent;
    // Start is called before the first frame update
    void Start()
    {
        labelName = transform.name;
        labelComponent = GetComponentInChildren<Text>();
        labelComponent.text = labelName;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
