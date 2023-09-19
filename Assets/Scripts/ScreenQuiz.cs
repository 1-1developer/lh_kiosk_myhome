using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenQuiz : MenuScreen
{
    const string ANSWER = "answer"; //결과화면 선택
    const string YES = "quiz_yes1";
    const string NO = "quiz_no1";
    const string Quiz = "quiz_q";
    const string QUIZBUTTON = "quiz_bt";
    const string QUIZTYPE1 = "quiz_type1";
    const string QUIZTYPE2 = "quiz_type2";  

    public Sprite[] quizes;
    //public Animator reckAnimator; //사다리

    VisualElement m_Quiz;
    VisualElement m_quizType1;
    VisualElement m_quizType2;

    Button m_YesBt;
    Button m_NoBt;
    Button m_HomeBt;

    List<VisualElement> answers = new List<VisualElement>();
    List<VisualElement> answers_Reorder = new List<VisualElement>();
    List<Button> quizButtons = new List<Button>();

    //public string curAnswer ="";

    //string[] s_Qs = {"y","n","yy","yyy","yyyy","yyyyy", "yyyyn","yyyynn", "yyyyyn" ,
    //"yyyn","yyyny","yyynn","yyynyy","yyynyn","yyynyyn","yyynynn"};

    //string[] s_Answers = {"yn","ny","nn", "yyn", "yyyyny", "yyyyyy", "yyyyyny", "yyyyynn", 
    //    "yyyynny", "yyyynnn", "yyynyyy", "yyynyyny", "yyynyynn", "yyynyny",
    //   "yyynynny", "yyynynnn", "yyynny", "yyynnn" };

    enum QuizState
    {
        STEP1,
        STEP2,
        STEP3,
        STEP4,
        STEP5,
        STEP6
    }

    QuizState quizState;
    bool YesNoChecker;
    int selectionChecker;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_YesBt = m_Root.Q<Button>(YES);
        m_NoBt = m_Root.Q<Button>(NO);
        m_HomeBt = m_Root.Q<Button>("quiz_backbt__");

        m_Quiz = m_Root.Q<VisualElement>(Quiz);
        m_quizType1 = m_Root.Q<VisualElement>(QUIZTYPE1);
        m_quizType2 = m_Root.Q<VisualElement>(QUIZTYPE2);

        for (int i = 1; i < 8; i++)
        {
            answers.Add(m_Root.Q<VisualElement>(ANSWER+$"{i}"));
        }
        for (int i = 0; i < 4; i++)
        {
            quizButtons.Add(m_Root.Q<Button>(QUIZBUTTON + $"{i}"));
        }

        AnswersReorder();
    }
    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        m_YesBt.RegisterCallback<ClickEvent>(OnYesClicked);
        m_NoBt.RegisterCallback<ClickEvent>(OnNoClicked);
        m_HomeBt.RegisterCallback<ClickEvent>(OnHomeClicked);

        //4지선다
        quizButtons[0].RegisterCallback<ClickEvent>(evt => OnSelectionCliked(0));
        quizButtons[1].RegisterCallback<ClickEvent>(evt => OnSelectionCliked(1));
        quizButtons[2].RegisterCallback<ClickEvent>(evt => OnSelectionCliked(2));
        quizButtons[3].RegisterCallback<ClickEvent>(evt => OnSelectionCliked(3));

    }
    private void OnHomeClicked(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowHomeScreen();
        InitQuiz();
        //reckAnimator.SetInteger("ID", 99);
    }
    private void OnYesClicked(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        YesNoChecker = true;
        UpdateState();

        //curAnswer += "y";
        //ShowQuiz();
        //FindResult();
    }
    private void OnNoClicked(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        YesNoChecker = false;
        UpdateState();

        //curAnswer += "n";
        //ShowQuiz();
        //FindResult();
    }
    private void OnSelectionCliked(int v)
    {
        AudioManager.PlayDefaultButtonSound();
        selectionChecker = v+1;
        UpdateState();
    }

    void UpdateState()
    {
        switch(quizState)
        {
            case QuizState.STEP1:
                Step1();
                break;
            case QuizState.STEP2:
                Step2();
                break;
            case QuizState.STEP3:
                Step3();
                break;
            case QuizState.STEP4:
                Step4();
                break;
            case QuizState.STEP5:
                Step5();
                break;
            case QuizState.STEP6:
                Step6();
                break;
        }
    }
    private void Step1()
    {
        selectionChecker = 0;
        quizState = QuizState.STEP2;

        if(YesNoChecker == true)
        {
            m_quizType2.style.display = DisplayStyle.Flex;
            m_quizType1.style.display = DisplayStyle.None;
        }
        else if(YesNoChecker == false)
        {
            SetQuiz(2);
        }
    }
    private void Step2()
    {
        if (selectionChecker == 1 || selectionChecker == 2)
        {
            quizState = QuizState.STEP3;
            m_quizType2.style.display = DisplayStyle.None;
            m_quizType1.style.display = DisplayStyle.Flex;
            SetQuiz(3);
        }
        else if (selectionChecker == 3)
        {
            ShowResult(0);
            InitQuiz();
        }
        else if (selectionChecker == 4)
        {
            ShowResult(6);
            InitQuiz();
        }

        if (YesNoChecker == true && selectionChecker == 0)
        {
            ShowResult(2);
            InitQuiz();
        }
        else if (YesNoChecker == false && selectionChecker == 0)
        {
            ShowResult(6);
            InitQuiz();
        }
    }
    private void Step3()
    {
        quizState = QuizState.STEP4;
        if (YesNoChecker == true)
        {            
            SetQuiz(4);
        }
        else if (YesNoChecker == false)
        {
            SetQuiz(5);
        }
    }
    private void Step4()
    {
        if(m_Quiz.style.backgroundImage == quizes[4].texture)
        {
            if (YesNoChecker == true)
            {
                ShowResult(5);
                InitQuiz();
            }
            else
            {
                quizState = QuizState.STEP5;
                SetQuiz(6);
            }
        }
        else 
        {
            quizState = QuizState.STEP5;
            if (YesNoChecker == true)
            {
                SetQuiz(7);
            }
            else
            {
                SetQuiz(8);
            }        
        }
    }
    private void Step5()
    {
        if (m_Quiz.style.backgroundImage == quizes[6].texture) //y12yn
        {
            if (YesNoChecker == true)   //y12yny
            {
                ShowResult(4);          
            }
            else                        //y12ynn
            {
                ShowResult(0);
            }
            InitQuiz();
        }
        else if(m_Quiz.style.backgroundImage == quizes[7].texture) //y12ny
        {
            if (YesNoChecker == true) //y12nyy
            {
                ShowResult(1);
                InitQuiz();
            }
            else                      //y12nyn
            {
                quizState = QuizState.STEP6;
                SetQuiz(9);
            }
        }
        else                                                      //y12nn
        {
            if (YesNoChecker == true) //y12nny
            {
                ShowResult(3);
                InitQuiz();
            }
            else                      //y12nnn
            {
                quizState = QuizState.STEP6;
                SetQuiz(10);
            }
        }
    }
    private void Step6()  //    y12nyn    y12nnn
    {
            if (YesNoChecker == true)
            {
                if(m_Quiz.style.backgroundImage == quizes[9].texture) //y12nyny
                {
                    ShowResult(3);
                }
                else                                                  //y12nnny
                {
                    ShowResult(2);
                }
            }
            else       //    y12nynn    y12nnnn
            {
                ShowResult(0);
            }
            InitQuiz();
    }

    void SetQuiz(int index)
    {
        m_Quiz.style.backgroundImage = quizes[index].texture;
    }
    public void InitQuiz()
    {
        SetQuiz(0);
        quizState = QuizState.STEP1;
        m_quizType2.style.display = DisplayStyle.None;
        m_quizType1.style.display = DisplayStyle.Flex;

        //curAnswer = "";
        //reckAnimator.SetInteger("ID", 99);
    }
    void ShowResultScreen()
    {
        m_MainMenuUIManager.ShowAnswersScreen();
    }
    void ShowResult(int i)
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
        ShowResultScreen();
    }
    //void ShowQuiz()
    //{
    //    for (int i = 0; i < s_Qs.Length; i++)
    //    {
    //        if (s_Qs[i] == curAnswer)
    //        {
    //            SetQuiz(i + 1);
    //            Debug.Log($"{i + 1}번쨰");
    //            Debug.Log($"{s_Qs[i]}");
    //            //reckAnimator.SetInteger("ID", i);
    //        }
    //    }
    //}
    //void FindResult()
    //{
    //    for (int i = 0; i < s_Answers.Length; i++)
    //    {
    //        if (curAnswer == s_Answers[i])
    //        {
    //            ShowResult(i);
    //            ShowRe();
    //            //reckAnimator.SetInteger("ID", 30+i);
    //            ShowQuiz();
    //        }
    //    }
    //}
    void AnswersReorder()
    {
        /*"yn","ny","nn", "yyn", "yyyyny", "yyyyyy", "yyyyyny", "yyyyynn", 
        "yyyynny", "yyyynnn", "yyynyyy", "yyynyyny", "yyynyynn", "yyynyny",
        "yyynynny", "yyynynnn", "yyynny", "yyynnn"*/
        answers_Reorder.Add(answers[0]);
        answers_Reorder.Add(answers[1]);
        answers_Reorder.Add(answers[2]);
        answers_Reorder.Add(answers[3]);
        answers_Reorder.Add(answers[4]);
        answers_Reorder.Add(answers[5]);
        answers_Reorder.Add(answers[6]);
    }    
}
