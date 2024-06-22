using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BeeMovement1 : MonoBehaviour
{
    public Transform Bee1;
    public float masmenos = 0.003f;
    private float cambio = -1f;
    public float cambio = -1f;
    public bool x;
    private float velocidad;



    // Start is called before the first frame update
    void Start()
    {
        velocidad = masmenos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Bee1.position;

        if (x)
        {
            // Actualizar posición en x
            position.x += velocidad;

            if (cambio > 0)
            {
                velocidad = masmenos;
                Bee1.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
            else
            {
                velocidad = -masmenos;
                Bee1.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
        }
        else if (!x)
        {
            // Actualizar posición en Z
            position.z += velocidad;

            if (cambio > 0)
            {
                velocidad = masmenos;
                Bee1.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                velocidad = -masmenos;
                Bee1.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        // Actualizar la posición del goblin
        Bee1.position = position;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el personaje principal
        if (other.CompareTag("TerrenoZ"))
        {
            cambio *= -1;
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TerrenoZ"))
        {
            cambio *= -1;
        }


    }
}
