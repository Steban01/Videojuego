using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMove1 : MonoBehaviour
{
    public Transform Goblin1;
    private float masmenos = 0.002f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Goblin1.position;

        // Actualizar posición en Z
        position.x += masmenos;
        Debug.Log(position.x);

        if (position.x < 47.0f && position.x > 46.0f)
        {
            masmenos = -0.002f;
            Goblin1.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        if (position.x < 45.0f && position.x > 44.0f)
        {
            masmenos = 0.002f;
            Goblin1.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        // Verificar si la posición actual en Z es mayor que el máximo alcanzado

        // Actualizar la posición del goblin
        Goblin1.position = position;

    }
}
