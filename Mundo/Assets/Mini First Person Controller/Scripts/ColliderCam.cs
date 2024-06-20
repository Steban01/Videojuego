using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisiona tiene un collider
        Collider otherCollider = collision.collider;
        if (otherCollider == null)
        {
            // Si no tiene un collider, añadir uno
            otherCollider = collision.gameObject.AddComponent<BoxCollider>();
        }

        // Aquí puedes añadir más lógica según necesites
        Debug.Log("Colisionado con: " + collision.gameObject.name);
    }
}
