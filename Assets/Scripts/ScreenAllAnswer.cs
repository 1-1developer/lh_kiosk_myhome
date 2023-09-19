using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using System;

public class ScreenAllAnswer : MenuScreen
{
    const string ANSWER = "answer"; //결과화면 선택
    const string GAllbt = "GAllbt0"; //버튼그룹
    const string Home = "answer_backbgtt"; //홈버튼
    //const string LAST = "icon_last"; //이전
    //const string NEXT = "icon_next"; //다음
    const string all_bt = "all_bt"; //버튼들


    Button m_Homebt;
    //Button m_lastbt;
    //Button m_nextbt;
    VisualElement m_GAllbt;

    List<VisualElement> m_answers = new List<VisualElement>();
    List<Button> m_answerBt = new List<Button>();


    //int pageindex;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_Homebt = m_Root.Q<Button>(Home);
        //m_lastbt = m_Root.Q<Button>(LAST);
        //m_nextbt = m_Root.Q<Button>(NEXT);
        m_GAllbt = m_Root.Q<Button>(GAllbt);

        m_answers.Clear();
        for (int i = 1; i < 8; i++)
        {
            m_answers.Add(m_Root.Q<VisualElement>(ANSWER + $"{i}"));
        }
        for (int i = 0; i < 7; i++)
        {
            m_answerBt.Add(m_Root.Q<Button>(all_bt + $"{i}"));
        }

        m_answerBt[0].RegisterCallback<ClickEvent>(evt => OnAnswerClicked(0));
        m_answerBt[1].RegisterCallback<ClickEvent>(evt => OnAnswerClicked(1));
        m_answerBt[2].RegisterCallback<ClickEvent>(evt => OnAnswerClicked(2));
        m_answerBt[3].RegisterCallback<ClickEvent>(evt => OnAnswerClicked(3));
        m_answerBt[4].RegisterCallback<ClickEvent>(evt => OnAnswerClicked(4));
        m_answerBt[5].RegisterCallback<ClickEvent>(evt => OnAnswerClicked(5));
        m_answerBt[6].RegisterCallback<ClickEvent>(evt => OnAnswerClicked(6));


        m_Homebt.RegisterCallback<ClickEvent>(OnHomeBt);
        //m_lastbt.RegisterCallback<ClickEvent>(OnLastBt);
        //m_nextbt.RegisterCallback<ClickEvent>(OnNextBt);

        //showGroup(0);
    }

    private void OnAnswerClicked(int i)
    {
        AudioManager.PlayDefaultButtonSound();
        showResult(i);
        m_MainMenuUIManager.ShowAnswersScreen();
    }

    private void OnHomeBt(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        //showGroup(0);
        m_MainMenuUIManager.ShowHomeScreen();
    }

    //private void OnLastBt(ClickEvent evt)
    //{
    //    AudioManager.PlayDefaultButtonSound();
    //    if (pageindex <= 0)
    //    {
    //        return;
    //    }
    //    pageindex--;
    //    showGroup(pageindex);
    //    SetLsstNext();
    //}
    //private void OnNextBt(ClickEvent evt)
    //{
    //    AudioManager.PlayDefaultButtonSound();
    //    if (pageindex >= 2)
    //    {
    //        return;
    //    }
    //    pageindex++;
    //    showGroup(pageindex);
    //    SetLsstNext();
    //}
    //void SetLsstNext()
    //{
    //    switch (pageindex)
    //    {
    //        case 0:
    //            m_lastbt.RemoveFromClassList("NextBt--enable");
    //            break;
    //        case 1:
    //            m_lastbt.AddToClassList("NextBt--enable");
    //            m_nextbt.AddToClassList("NextBt--enable");
    //            break;
    //        case 2:
    //            m_nextbt.RemoveFromClassList("NextBt--enable");
    //            break;
    //        default:
    //            break;
    //    }
    //}
    //void showGroup(int index)
    //{
    //    VisualElement v = m_Gallanswers[index];
    //    foreach (VisualElement vv in m_Gallanswers)
    //    {
    //        if (v == vv)
    //            vv.style.display = DisplayStyle.Flex;
    //        else
    //            vv.style.display = DisplayStyle.None;
    //    }
    //}

    void showResult(int index)
    {
        VisualElement v = m_answers[index];

        foreach (VisualElement a in m_answers)
        {
            if (v == a)
            {
                a.style.display = DisplayStyle.Flex;
            }
            else
            {
                a.style.display = DisplayStyle.None;
            }
        }
    }
}
