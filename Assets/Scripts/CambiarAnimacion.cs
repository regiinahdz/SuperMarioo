//Regina Hernandez Moreno
//A01802688

using UnityEngine;

public class CambiarAnimacion : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator; //nos permite acceder a los parametros de la animacion para cambiarla dependiendo de la velocidad del personaje
    private SpriteRenderer sr; //nos permite acceder a la propiedad flipX para voltear el sprite dependiendo de la direccion del movimiento del personaje
    private EstadoPersonaje estado;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D del personaje
        animator = GetComponent<Animator>(); // Obtener el componente Animator del personaje
        sr = GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer del personaje
        estado = GetComponentInChildren<EstadoPersonaje>(); // Obtener el componente EstadoPersonaje del personaje
    }

    // Update is called once per frame
    void Update()
    {
        //Animacion de caminar
        animator.SetFloat("velocidad", Mathf.Abs(rb.linearVelocityX));
        //sr.flipX = rb.linearVelocityX < 0; // Voltea el sprite dependiendo de la dirección del movimiento del personaje (valor booleano que se asigna a flipX, si es true el sprite se voltea horizontalmente, si es false el sprite se mantiene en su posición original)
        if (Mathf.Abs(rb.linearVelocityX) > 0.1f) 
        {
            // Si va a la derecha (velocidad positiva), activamos el flip para que mire a la derecha
            // Si va a la izquierda (velocidad negativa), desactivamos el flip para que use su pose original
            sr.flipX = rb.linearVelocityX > 0;
        }
        //Animacion de salto
        animator.SetBool("enPiso", estado.estaEnpiso); // Asigna el valor de la variable estaEnpiso del componente EstadoPersonaje al parámetro "estaEnPiso" del Animator para controlar la animación de salto dependiendo de si el personaje está en el suelo o no
    
    }
}

