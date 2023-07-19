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

    public Transform[] m_points;

    public LineMover lineMover;

    public Transform[] route0;
    public Transform[] route1;
    public Transform[] route2;
    public Transform[] route3;
    public Transform[] route4;
    public Transform[] route5;
    public Transform[] route6;
    public Transform[] route7;
    public Transform[] route8;
    public Transform[] route9;
    public Transform[] route10;
    public Transform[] route11;
    public Transform[] route12;
    public Transform[] route13;
    public Transform[] route14;
    public Transform[] route15;

    VisualElement m_Quiz;

    Button m_YesBt;
    Button m_NoBt;

    Button m_HomeBt;

    List<VisualElement> answers = new List<VisualElement>();
    List<VisualElement> answers_Reorder = new List<VisualElement>();

    public string curAnswer="";

    string[] s_Qs = {"y","n","yy","yyy","yyyy","yyyyy", "yyyyn","yyyynn", "yyyyyn" ,
    "yyyn","yyyny","yyynn","yyynyy","yyynyn","yyynyyn","yyynynn"};

    string[] s_Answers = {"yn","ny","nn", "yyn", "yyyyny", "yyyyyy", "yyyyyny", "yyyyynn", 
        "yyyynny", "yyyynnn", "yyynyyy", "yyynyyny", "yyynyynn", "yyynyny",
        "yyynynny", "yyynynnn", "yyynny", "yyynnn" };
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_YesBt = m_Root.Q<Button>(YES);
        m_NoBt = m_Root.Q<Button>(NO);

        m_HomeBt = m_Root.Q<Button>("quiz_backbt__");

        m_Quiz = m_Root.Q<VisualElement>(Quiz);

        for (int i = 1; i < 18; i++)
        {
            answers.Add(m_Root.Q<VisualElement>(ANSWER+$"{i}"));
        }

        m_YesBt.RegisterCallback<ClickEvent>(onYesClicked);
        m_NoBt.RegisterCallback<ClickEvent>(onNoClicked);
        m_HomeBt.RegisterCallback<ClickEvent>(onHomeClicked);

        answersReorder();
    }

    private void onHomeClicked(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowHomeScreen();
        initQuiz();
    }
    private void onYesClicked(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        curAnswer += "y";
        ShowQuiz();
        findresult();
    }

    private void onNoClicked(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        curAnswer += "n";
        ShowQuiz();
        findresult();
    }

    void setQuiz(int index)
    {
        m_Quiz.style.backgroundImage = quizes[index].texture;
    }

    public void initQuiz()
    {
        setQuiz(0);
        curAnswer = "";
        lineMover.initLine();
    }

    void drawLine(int index)
    {
        switch (index)
        {
            case 0:
                lineMover.setRoute(route0);
                break;
            case 1:
                lineMover.setRoute(route1);
                break;
            case 2:
                lineMover.setRoute(route2);
                break;
            case 3:
                lineMover.setRoute(route3);
                break;
            case 4:
                lineMover.setRoute(route4);
                break;
            case 5:
                lineMover.setRoute(route5);
                break;
            case 6:
                lineMover.setRoute(route6);
                break;
            case 7:
                lineMover.setRoute(route7);
                break;
            case 8:
                lineMover.setRoute(route8);
                break;
            case 9:
                lineMover.setRoute(route9);
                break;
            case 10:
                lineMover.setRoute(route10);
                break;
            case 11:
                lineMover.setRoute(route11);
                break;
            case 12:
                lineMover.setRoute(route12);
                break;
            case 13:
                lineMover.setRoute(route13);
                break;
            case 14:
                lineMover.setRoute(route14);
                break;
            case 15:
                lineMover.setRoute(route15);
                break;

            default:
                break;
        }
    }
    void findresult()
    {
        for (int i = 0; i < s_Answers.Length; i++)
        {
            if (curAnswer == s_Answers[i])
            {
                showResult(i);
                m_MainMenuUIManager.ShowAnswersScreen();
                initQuiz();
            }
        }
    }
    void showResult(int i)
    {
        VisualElement aa = answers_Reorder[i];
        foreach (VisualElement a in answers_Reorder)
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
        for (int i = 0; i < s_Qs.Length; i++)
        {
            if (s_Qs[i]==curAnswer)
            {
                setQuiz(i+1);
                Debug.Log($"{i+1}번쨰");
                Debug.Log($"{s_Qs[i]}");
                drawLine(i);
            }
        }
    }

    void answersReorder()
    {
        /*"yn","ny","nn", "yyn", "yyyyny", "yyyyyy", "yyyyyny", "yyyyynn", 
        "yyyynny", "yyyynnn", "yyynyyy", "yyynyyny", "yyynyynn", "yyynyny",
        "yyynynny", "yyynynnn", "yyynny", "yyynnn"*/

        answers_Reorder.Add(answers[0]);
        answers_Reorder.Add(answers[2]);
        answers_Reorder.Add(answers[0]);
        answers_Reorder.Add(answers[1]);
        answers_Reorder.Add(answers[9]);
        answers_Reorder.Add(answers[12]);
        answers_Reorder.Add(answers[13]);//yyyyyny
        answers_Reorder.Add(answers[14]);
        answers_Reorder.Add(answers[10]);
        answers_Reorder.Add(answers[11]);//yyyynnn
        answers_Reorder.Add(answers[6]);//yyynyyy
        answers_Reorder.Add(answers[7]);//yyynyyny
        answers_Reorder.Add(answers[8]);//yyynyynn
        answers_Reorder.Add(answers[5]);//yyynyny
        answers_Reorder.Add(answers[4]);//yyynynny
        answers_Reorder.Add(answers[3]);//yyynynnn
        answers_Reorder.Add(answers[15]);//yyynny
        answers_Reorder.Add(answers[16]);//yyynnn
    }

}
