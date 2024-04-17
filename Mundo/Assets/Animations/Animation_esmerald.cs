using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_esmerald : MonoBehaviour
{
    public float speed = 1.0f; // Velocidad de la animación
    public float maxHeight = 2.0f; // Altura máxima a la que subirá el objeto

    private float initialY; // Posición inicial en Y

    void Start()
    {
        // Guarda la posición inicial en Y del objeto
        initialY = transform.position.y;
    }

    void Update()
    {
        // Calcula la posición Y a la que debe moverse en este frame
        float newY = initialY + Mathf.Sin(Time.time * speed) * maxHeight;

        // Actualiza la posición del objeto con la nueva posición Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
