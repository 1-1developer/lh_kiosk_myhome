using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenQuiz : MenuScreen
{
    const string ANSWER = "answer"; //결과화면 선택

    const string YES = "quiz_yes1";
    const string NO = "quiz_no1";
    const string Quiz = "quiz_q";

    public Sprite[] quizes;

    
    
    VisualElement m_Quiz;

    Button m_YesBt;
    Button m_NoBt;

    Button m_HomeBt;

    List<VisualElement> answers = new List<VisualElement>();

    public string curAnswer="";

    string[] Qs = {"y","n","yy","yyy","yyyy","yyyyy", "yyyyn","yyyynn" };
    string[] Answers = {"yn","ny","nn", "yyn", "yyyyynn", "yyyyyy", "yyyyyny", "yyyyynn", "yyyynny", "yyyynnn" };
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_YesBt = m_Root.Q<Button>(YES);
        m_NoBt = m_Root.Q<Button>(NO);

        m_HomeBt = m_Root.Q<Button>("quiz_backbt");

        m_Quiz = m_Root.Q<VisualElement>(Quiz);

        for (int i = 1; i < 19; i++)
        {
            answers.Add(m_Root.Q<VisualElement>(ANSWER+$"{i}"));
        }

        m_YesBt.RegisterCallback<ClickEvent>(onYesClicked);
        m_NoBt.RegisterCallback<ClickEvent>(onNoClicked);
        m_HomeBt.RegisterCallback<ClickEvent>(onHomeClicked);
    }

    private void onHomeClicked(ClickEvent evt)
    {
        m_MainMenuUIManager.ShowHomeScreen();
        initQuiz();
    }
    private void onYesClicked(ClickEvent evt)
    {
        curAnswer += "y";
        findresult();
    }

    private void onNoClicked(ClickEvent evt)
    {
        curAnswer += "n";
        findresult();
    }

    void setQuiz(int index)
    {
        m_Quiz.style.backgroundImage = quizes[index].texture;
    }

    void initQuiz()
    {
        setQuiz(0);
        curAnswer = "";
    }

    void findresult()
    {
        foreach (string s in Answers)
        {
            if (s==curAnswer)
            {
                m_MainMenuUIManager.ShowAnswersScreen();
                initQuiz();
                switch (s)
                {
                    case "yn":
                        showResult(answers[0]);
                        break;
                    case "ny":
                        showResult(answers[17]);
                        break;
                    case "nn":
                        showResult(answers[0]);
                        break;
                    case "yyn":
                        showResult(answers[1]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    void showResult(VisualElement aa)
    {
        foreach (VisualElement a in answers)
        {
            if (aa == a)
            {
                a.style.display = DisplayStyle.Flex;
            }
            else
            {
                a.style.display = DisplayStyle.None;
            }
        }
    }
    void ShowQuiz()
    {
        for (int i = 0; i < Qs.Length; i++)
        {

        }
        //foreach (string s in Qs)
        //{
        //    if (s==curAnswer)
        //    {
        //        switch (s)
        //        {
        //            default:
        //        }
        //    }
        //}
    }
}
