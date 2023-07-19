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
    [SerializeField] ScreenMap m_MapModalScreen;
    [SerializeField] ScreenQuiz m_QuizModalScreen;
    [SerializeField] ScreenAnswers m_AnswersModalScreen;
    [SerializeField] ScreenAllAnswer m_AllAnswersModalScreen;

    UIDocument m_MainMenuDocument;
    public UIDocument MainMenuDocument => m_MainMenuDocument;
    List<MenuScreen> m_AllModalScreens = new List<MenuScreen>();

    void SetupModalScreens()
    {
        if (m_HomeModalScreen != null)
            m_AllModalScreens.Add(m_HomeModalScreen);
        if (m_MapModalScreen != null)
            m_AllModalScreens.Add(m_MapModalScreen);
        if (m_QuizModalScreen != null)
            m_AllModalScreens.Add(m_QuizModalScreen);
        if (m_AnswersModalScreen != null)
            m_AllModalScreens.Add(m_AnswersModalScreen);
        if (m_AllAnswersModalScreen != null)
            m_AllModalScreens.Add(m_AllAnswersModalScreen);
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
    public void ShowMapScreen()
    {
        ShowModalScreen(m_MapModalScreen);
    }
    public void ShowQuizScreen()
    {
        ShowModalScreen(m_QuizModalScreen);
    }

    public void ShowAnswersScreen()
    {
        ShowModalScreen(m_AnswersModalScreen);
    }
    public void ShowAllnswersScreen()
    {
        ShowModalScreen(m_AllAnswersModalScreen);
    }
}
