using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTP : MonoBehaviour
{

    // Define la posici�n de teletransporte
    public Vector3 posicionTeletransporte;
    public GameObject prota;
    private Vector3 checkPointActual;
    public KeyCode puntoDeGuardado = KeyCode.R;
    private float numeroEsmeraldas = 0;

    // M�todo que se ejecuta al entrar en colisi�n con otro objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el personaje principal
        if (other.CompareTag("CheckPoint"))
        {
            // Teletransporta al personaje a la posici�n deseada

            checkPointActual = other.transform.position;
            Debug.Log("El personaje ha sido teletransportado a: " + checkPointActual);
            checkPointActual.y += 0.2f;
            Debug.Log("El personaje ha sido teletransportado a: " + checkPointActual);
        }
        if (other.CompareTag("Lava"))
        {
            // Teletransporta al personaje a la posici�n 
            Debug.Log("LAVAAAA");
            prota.transform.position = checkPointActual;
        }
        if (other.CompareTag("Esmeralda"))
        {
            numeroEsmeraldas += 1;
            Debug.Log("Una masss " + numeroEsmeraldas);
        }
    }
    // M�todo que se ejecuta en cada cuadro
    private void Update()
    {
        // Verifica si se presiona la tecla de reset
        if (Input.GetKeyDown(puntoDeGuardado))
        {
            if (checkPointActual != Vector3.zero)
            {
                prota.transform.position = checkPointActual;
                Debug.Log("Personaje teletransportado a: " + checkPointActual + " por reset");
            }
            else
            {
                Debug.Log("No hay checkpoint establecido para el reset.");
            }
        }
    }
    public float GetNumeroEsmeraldas()
    {
        return numeroEsmeraldas;
    }
}
