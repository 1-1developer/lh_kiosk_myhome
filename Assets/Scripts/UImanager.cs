using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UImanager : MonoBehaviour
{
    [Header("Modal Menu Screens")]
    [Tooltip("Only one modal interface can appear on-screen at a time.")]
    [SerializeField] ScreenMain m_HomeModalScreen;

    UIDocument m_MainMenuDocument;
    public UIDocument MainMenuDocument => m_MainMenuDocument;
    List<MenuScreen> m_AllModalScreens = new List<MenuScreen>();

    void SetupModalScreens()
    {
        if (m_HomeModalScreen != null)
            m_AllModalScreens.Add(m_HomeModalScreen);

    }
    void ShowModalScreen(MenuScreen modalScreen)
    {
        foreach (MenuScreen m in m_AllModalScreens)
        {
            if (m == modalScreen)
            {
                m?.ShowScreen();
            }
            else
            {
                m?.HideScreen();
            }
        }
    }
    void OnEnable()
    {
        m_MainMenuDocument = GetComponent<UIDocument>();
        SetupModalScreens();
        ShowHomeScreen();
    }
    public void ShowHomeScreen()
    {
        ShowModalScreen(m_HomeModalScreen);
    }
}
