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

    //public Animator reckAnimator; //사다리

    public Sprite[] quizes;

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
        //reckAnimator.SetInteger("ID", 99);

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
        //reckAnimator.SetInteger("ID", 99);
    }

    void findresult()
    {
        for (int i = 0; i < s_Answers.Length; i++)
        {
            if (curAnswer == s_Answers[i])
            {
                showResult(i);
                showre();
                //reckAnimator.SetInteger("ID", 30+i);
                ShowQuiz();
            }
        }
    }
    void showre()
    {
        m_MainMenuUIManager.ShowAnswersScreen();
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
                //reckAnimator.SetInteger("ID", i);
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
