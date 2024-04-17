using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaWelcome : MonoBehaviour
{
    private static CanvaWelcome instance;
    public Canvas WelcCanva;
    public Canvas ProfCanva;
    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void B_ProfileCanva()
    {
        WelcCanva.gameObject.SetActive(false);
        ProfCanva.gameObject.SetActive(true);
    }
    public static CanvaWelcome GetInstance()
    {
        return instance == null ? instance = new CanvaWelcome() : instance;
    }
}
