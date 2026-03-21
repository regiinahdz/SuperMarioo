// Regina Hernandez Moreno
// A01802688

using UnityEngine;
using UnityEngine.UIElements;

public class CarruselInfinito : MonoBehaviour
{
    private VisualElement infoCreditos; 
    private float alturaBloque = 0;   

    [SerializeField] float velocidad = 40f; 
    private float posicionYActual = 0;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        // Buscamos el elemento que tiene el texto
        infoCreditos = root.Q<VisualElement>("unVisualElement");

        if (infoCreditos != null)
        {
            infoCreditos.RegisterCallback<GeometryChangedEvent>(evt => {
                // Altura de un ciclo (la mitad del total)
                alturaBloque = infoCreditos.layout.height / 2;
            });
        }
    }

    void Update()
    {
        if (infoCreditos == null || alturaBloque <= 0) return;

        // Aumentamos la posición linealmente
        posicionYActual -= velocidad * Time.deltaTime;

        // Si ya pasó el primer bloque, reiniciamos a 0
        if (posicionYActual <= -alturaBloque)
        {
            posicionYActual = 0;
        }

        // --- SOLUCIÓN PARA 2D ---
        // En lugar de usar Vector3, usamos Translate. 
        // Esto mueve el elemento solo en X e Y (estilo CSS).
        infoCreditos.style.translate = new Translate(0, posicionYActual, 0);
    }
}