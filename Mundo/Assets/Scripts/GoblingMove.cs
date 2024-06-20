using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GoblingMove : MonoBehaviour
{
    public Transform Goblin1;
    private float masmenos = 0.003f;
    // Start is called before the first frame update
    void Start()
    {

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

        // Verificar si la posición actual en Z es mayor que el máximo alcanzado

        // Actualizar la posición del goblin
        Goblin1.position = position;

    }
}
