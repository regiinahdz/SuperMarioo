//Regina Hernandez Moreno
//A01802688

using UnityEngine;
using UnityEngine.InputSystem;

public class MuevePersonaje : MonoBehaviour
{
     [SerializeField]
    private InputAction accionMover;
    [SerializeField]
    private InputAction accionSaltar;
    private Rigidbody2D rb; // componente que le da velocidad al personaje
    private EstadoPersonaje estado;
    private float velocidadX = 7f;

    private float VelocidadY = 7f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D del objeto para poder manipular su velocidad
        estado = GetComponentInChildren<EstadoPersonaje>(); // Obtiene el componente EstadoPersonaje del objeto para verificar si el personaje está en el suelo antes de permitirle saltar
    }

    void OnEnable()
    {
        accionSaltar.Enable();
        accionSaltar.performed += saltar; // Cuando se realice la acción de salto, se llamará al método saltar 

    } 

    void OnDisable()
    {
        accionSaltar.Disable();
        accionSaltar.performed -= saltar; // Cuando se deshabilite el script, se eliminará la suscripción al evento de salto
    }

    public void saltar(InputAction.CallbackContext context)
    {
        if(estado.estaEnpiso) // Verifica si el personaje está en el suelo antes de permitirle saltar
        {
            rb.linearVelocityY = VelocidadY; // Asigna la velocidad de salto al componente Rigidbody2D para que el personaje salte
        }
        else 
        {
        // El salto "no jala" porque no está tocando el suelo
        Debug.LogWarning("error");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 movimiento /*vector de movimiento*/ = accionMover.ReadValue<Vector2>();
        //transform.position = (Vector2)transform.position + Time.deltaTime * velocidadX * movimiento;
        rb.linearVelocityX = velocidadX * movimiento.x; // Asigna la velocidad horizontal al componente Rigidbody2D para que el personaje se mueva horizontalmente   
    }
}