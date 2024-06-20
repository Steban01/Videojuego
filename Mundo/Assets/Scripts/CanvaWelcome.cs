using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaWelcome : MonoBehaviour
{
    private static CanvaWelcome instance;
    public Canvas WelcCanva;
    public Canvas ProfCanva;
    public Transform Parm;
    public Transform Erald;
    private float speed = 3.0f;
    public GameObject camEra;
    // Start is called before the first frame update
    public void Awake()
    {
        camEra.gameObject.SetActive(false);
        instance = this;
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 positionP = Parm.position;
        Vector3 positionE = Erald.position;

        positionP.y += Mathf.Cos(Time.time) * Time.deltaTime * speed * 2;
        positionE.y += Mathf.Sin(Time.time) * Time.deltaTime * speed * 2;

        Parm.position = positionP;
        Erald.position = positionE;


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
