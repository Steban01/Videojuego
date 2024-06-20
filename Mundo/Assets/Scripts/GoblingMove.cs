using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblingMove : MonoBehaviour
{
    public Transform Goblin1;
    public AudioClip goblinSound; // Clip de audio que se reproducirá periódicamente
    private AudioSource audioSource;
    private float masmenos = 0.003f;

    // Parámetros para la audibilidad del sonido
    public float sonidoMinDistancia = 1.0f; // Distancia mínima para escuchar el sonido a volumen completo
    public float sonidoMaxDistancia = 10.0f; // Distancia máxima a la que el sonido se escucha

    // Start is called before the first frame update
    void Start()
    {
        // Asegura que el AudioSource esté configurado
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = goblinSound;

        // Configura las propiedades de spatialization
        audioSource.spatialBlend = 1.0f; // Hace que el sonido sea 3D
        audioSource.minDistance = sonidoMinDistancia;
        audioSource.maxDistance = sonidoMaxDistancia;

        // Inicia la reproducción periódica del audio
        StartCoroutine(PlayGoblinSound());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Goblin1.position;

        // Actualizar posición en Z
        position.z += masmenos;

        if (position.z < 4.0f && position.z > 3.0f)
        {
            masmenos = 0.003f;
            Goblin1.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (position.z < 7.0f && position.z > 6.0f)
        {
            masmenos = -0.003f;
            Goblin1.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        // Actualizar la posición del goblin
        Goblin1.position = position;
    }

    // Coroutine para reproducir el sonido del goblin a intervalos regulares
    private IEnumerator PlayGoblinSound()
    {
        while (true)
        {
            // Esperar 15 segundos
            yield return new WaitForSeconds(15f);

            // Reproducir el sonido si hay un audio asignado y el AudioSource está configurado
            if (audioSource != null && goblinSound != null)
            {
                audioSource.Play();
                Debug.Log("Reproduciendo sonido del goblin.");
            }
            else
            {
                Debug.LogWarning("No se ha asignado un sonido de goblin o el AudioSource no está configurado.");
            }
        }
    }
}
