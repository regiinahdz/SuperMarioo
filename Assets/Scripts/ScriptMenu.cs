//Regina Hernandez Moreno
//A01802688

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menu;
    private VisualElement Botones;
    private VisualElement PanelAyuda;
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;
    private Button botonCerrar;
    private Button botonCerrarPanel;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        Botones = root.Q<VisualElement>("Botones");
        PanelAyuda = root.Q<VisualElement>("PanelAyuda");

        // Buscamos el botón
        botonJugar = root.Q<Button>("BotonJugar");
        botonAyuda = root.Q<Button>("BotonAyuda");

        botonCerrarPanel = root.Q<Button>("BotonCerrarPanel");

        // Solo registramos si lo encontró
        if (botonJugar != null) 
        {
            botonJugar.RegisterCallback<ClickEvent>(AbrirMapita);
        }

        if (botonAyuda != null)
        {
            botonAyuda.RegisterCallback<ClickEvent>(AbrirAyuda);
        }

        if (botonCerrarPanel != null)
        {
            botonCerrarPanel.RegisterCallback<ClickEvent>(CerrarAyuda);
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

    private void AbrirAyuda(ClickEvent evn)
    {
        Botones.style.display = DisplayStyle.None;
        PanelAyuda.style.display = DisplayStyle.Flex;
    }
    private void CerrarAyuda(ClickEvent evn)
    {
        Botones.style.display = DisplayStyle.Flex;
        PanelAyuda.style.display = DisplayStyle.None;
    }

}

