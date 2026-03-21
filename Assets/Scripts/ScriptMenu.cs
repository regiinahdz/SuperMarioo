//Regina Hernandez Moreno
//A01802688

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menu;
    private VisualElement Menumenu;
    private VisualElement Footer;
    private VisualElement Botones;
    private VisualElement PanelAyuda;
    private VisualElement PanelCreditos;
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;
    private Button botonCerrar;
    private Button botonCerrarAyuda;
    private Button botonCerrarCreditos;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        Menumenu = root.Q<VisualElement>("Menumenu");
        Footer = root.Q<VisualElement>("Footer");
        Botones = root.Q<VisualElement>("Botones");
        PanelAyuda = root.Q<VisualElement>("PanelAyuda");
        PanelCreditos = root.Q<VisualElement>("PanelCreditos");

        // Buscamos el botón
        botonJugar = root.Q<Button>("BotonJugar");
        botonAyuda = root.Q<Button>("BotonAyuda");
        botonCreditos = root.Q<Button>("BotonCreditos");
        botonCerrar = root.Q<Button>("BotonCerrar");
        botonCerrarAyuda = root.Q<Button>("BotonCerrarAyuda");
        botonCerrarCreditos = root.Q<Button>("BotonCerrarCreditos");

        /// Registro de eventos con validación para evitar errores
        if (botonJugar != null) botonJugar.RegisterCallback<ClickEvent>(AbrirMapita);
        if (botonAyuda != null) botonAyuda.RegisterCallback<ClickEvent>(AbrirAyuda);
        if (botonCreditos != null) botonCreditos.RegisterCallback<ClickEvent>(AbrirCreditos);
        if (botonCerrar != null) botonCerrar.RegisterCallback<ClickEvent>(SalirDelJuego);
        if (botonCerrarAyuda != null) botonCerrarAyuda.RegisterCallback<ClickEvent>(CerrarPanel);
        if (botonCerrarCreditos != null) botonCerrarCreditos.RegisterCallback<ClickEvent>(CerrarPanel);
    }

    // OnDisable limpia los eventos para evitar errores de memoria
    void OnDisable()
    {
        if (botonJugar != null) botonJugar.UnregisterCallback<ClickEvent>(AbrirMapita);
        if (botonAyuda != null) botonAyuda.UnregisterCallback<ClickEvent>(AbrirAyuda);
        if (botonCreditos != null) botonCreditos.UnregisterCallback<ClickEvent>(AbrirCreditos);
        if (botonCerrar != null) botonCerrar.UnregisterCallback<ClickEvent>(SalirDelJuego);
        if (botonCerrarAyuda != null) botonCerrarAyuda.UnregisterCallback<ClickEvent>(CerrarPanel);
        if (botonCerrarCreditos != null) botonCerrarCreditos.UnregisterCallback<ClickEvent>(CerrarPanel);
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

    private void AbrirCreditos(ClickEvent evn)
    {
        // Usamos display None para ocultar el fondo y mostrar créditos
        if (Menumenu != null) Menumenu.style.display = DisplayStyle.None;
        if (Footer != null) Footer.style.display = DisplayStyle.None;
        if (PanelCreditos != null) PanelCreditos.style.display = DisplayStyle.Flex;
    }

    private void CerrarPanel(ClickEvent evn)
    {
        // Regresamos todo a la normalidad
        if (Menumenu != null) Menumenu.style.display = DisplayStyle.Flex;
        if (Botones != null) Botones.style.display = DisplayStyle.Flex;
        if (Footer != null) Footer.style.display = DisplayStyle.Flex;
                
        if (PanelAyuda != null) PanelAyuda.style.display = DisplayStyle.None;
        if (PanelCreditos != null) PanelCreditos.style.display = DisplayStyle.None;
    }

    private void SalirDelJuego(ClickEvent evn)
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}

