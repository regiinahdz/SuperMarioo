using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menu;
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;
    private Button botonCerrar;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        // Buscamos el botón
        botonJugar = root.Q<Button>("botonJugar");

        // Solo registramos si lo encontró
        if (botonJugar != null) 
        {
            botonJugar.RegisterCallback<ClickEvent>(AbrirMapita);
        }
        else 
        {
            Debug.LogError("ERROR: No se encontró un botón con el nombre 'botonJugar' en el UI Builder.");
        }

    }

    void OnDisable()
    {
        botonJugar.UnregisterCallback<ClickEvent>(AbrirMapita);
        //botonRegresa
    }

    private void AbrirMapita(ClickEvent evt)
    {
        SceneManager.LoadScene(1);
    }

   /* private void AbrirAyuda(ClickEvent evn)
    {
        SceneManager.LoadScene(2);
    }*/

}

