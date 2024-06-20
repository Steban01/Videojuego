using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDCanva : MonoBehaviour
{
    // Start is called before the first frame update
    public CheckpointTP checkpointScript;
    public TextMeshProUGUI esmeraldasText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        esmeraldasText.text = checkpointScript.GetNumeroEsmeraldas().ToString();

    }
}
