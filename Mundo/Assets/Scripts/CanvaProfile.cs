using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaProfile : MonoBehaviour
{
    private static CanvaProfile instance;
    public Canvas ProfCanva;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void B_OnHandleButtonStart()
    {
        ProfCanva.gameObject.SetActive(false);
    }

    public static CanvaProfile GetInstance()
    {
        return instance == null ? instance = new CanvaProfile() : instance;
    }
}
