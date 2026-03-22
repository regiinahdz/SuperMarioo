using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Regresa : MonoBehaviour
{
    private UIDocument menu;
    private Button botonRegresa;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement; //no sabes el tipo de dato que es rootVisualElement, por eso se usa var

        botonRegresa = root.Q<Button>("BotonRegresar");
        botonRegresa.clicked += Regresar;

    }

    void OnDisable()
    {
        botonRegresa.clicked -= Regresar;
    }

    void Regresar()
    {
        SceneManager.LoadScene(0);
    }
}
