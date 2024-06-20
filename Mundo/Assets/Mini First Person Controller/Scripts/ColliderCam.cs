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
            // Si no tiene un collider, a�adir uno
            otherCollider = collision.gameObject.AddComponent<BoxCollider>();
        }

        // Aqu� puedes a�adir m�s l�gica seg�n necesites
        Debug.Log("Colisionado con: " + collision.gameObject.name);
    }
}
