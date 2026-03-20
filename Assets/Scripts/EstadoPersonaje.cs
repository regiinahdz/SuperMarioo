using UnityEngine;

public class EstadoPersonaje : MonoBehaviour
{
    public bool estaEnpiso {get; private set;} = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
       estaEnpiso = true; // Si el personaje colisiona con un objeto que tiene un collider 2D, se asigna el valor true a la variable estaEnpiso para indicar que el personaje está en el suelo 
       print(estaEnpiso); 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        estaEnpiso = false; // Si el personaje deja de colisionar con un objeto que tiene un collider 2D, se asigna el valor false a la variable estaEnpiso para indicar que el personaje ya no está en el suelo
        print(estaEnpiso);
    }
}

