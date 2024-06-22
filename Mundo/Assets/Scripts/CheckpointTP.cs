using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTP : MonoBehaviour
{
    // Define la posición de teletransporte
    public Vector3 posicionTeletransporte;
    public GameObject prota;
    private Vector3 checkPointActual;
    public KeyCode puntoDeGuardado = KeyCode.R;
    private float numeroEsmeraldas = 0;
    public GameObject muro;

    // Variables para el audio
    public AudioClip sonidoEsmeralda; // Clip de audio que se reproducirá al recoger una esmeralda
    public AudioClip sonidoCheckpoint; // Clip de audio que se reproducirá al tocar un checkpoint
    private AudioSource audioSource;

    // Método que se llama cuando el script es inicializado
    void Start()
    {
        // Asegura que el AudioSource esté configurado
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Método que se ejecuta al entrar en colisión con otro objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el personaje principal
        if (other.CompareTag("CheckPoint"))
        {
            // Establece el nuevo checkpoint
            checkPointActual = other.transform.position;
            Debug.Log("El personaje ha tocado un checkpoint en: " + checkPointActual);
            checkPointActual.y += 0.2f;
            Debug.Log("El checkpoint ajustado a: " + checkPointActual);

            // Reproduce el sonido de checkpoint
            ReproducirSonidoCheckpoint();
        }else if (other.CompareTag("Inicio"))
        {
            // Establece el nuevo checkpoint
            checkPointActual = other.transform.position;
            Debug.Log("El personaje ha tocado un checkpoint en: " + checkPointActual);
            checkPointActual.y += 0.2f;
            Debug.Log("El checkpoint ajustado a: " + checkPointActual);

        }
        else if (other.CompareTag("Esmeralda"))
        {
            // Incrementa el conteo de esmeraldas
            numeroEsmeraldas += 1;
            Debug.Log("Esmeralda recogida. Total ahora: " + numeroEsmeraldas);
            other.gameObject.SetActive(false);

            // Reproduce el sonido de esmeralda
            ReproducirSonidoEsmeralda();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Teletransporta al personaje al checkpoint actual
            Debug.Log("El personaje ha tocado un enemigo y será teletransportado a: " + checkPointActual);
            prota.transform.position = checkPointActual;

        }
        if (collision.gameObject.CompareTag("Lava"))
        {
            // Teletransporta al personaje al checkpoint actual
            Debug.Log("El personaje ha tocado lava y será teletransportado a: " + checkPointActual);
            prota.transform.position = checkPointActual;

        }

    }

    // Método que se ejecuta en cada cuadro
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

    // Método para reproducir el sonido de esmeralda
    private void ReproducirSonidoEsmeralda()
    {
        if (sonidoEsmeralda != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoEsmeralda);
            Debug.Log("Reproduciendo sonido de esmeralda.");
        }
        else
        {
            Debug.LogWarning("No se ha asignado un sonido de esmeralda o el AudioSource no está configurado.");
        }
        if(numeroEsmeraldas == 3)
        {
            muro.gameObject.SetActive(false);
            Debug.Log("Chao muro");
        }
    }

    // Método para reproducir el sonido de checkpoint
    private void ReproducirSonidoCheckpoint()
    {
        if (sonidoCheckpoint != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoCheckpoint);
            Debug.Log("Reproduciendo sonido de checkpoint.");
        }
        else
        {
            Debug.LogWarning("No se ha asignado un sonido de checkpoint o el AudioSource no está configurado.");
        }
    }

    // Método para obtener el número de esmeraldas
    public float GetNumeroEsmeraldas()
    {
        return numeroEsmeraldas;
    }
}
