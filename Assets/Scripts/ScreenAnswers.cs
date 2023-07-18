using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenAnswers : MenuScreen
{

    const string answer_bt = "answer_bt";

    Button m_answerBt0;
    Button m_answerBt1;

    Button m_HomeBt;


    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_answerBt0 = m_Root.Q<Button>(answer_bt+"0");
        m_answerBt1 = m_Root.Q<Button>(answer_bt+"1");
        m_HomeBt = m_Root.Q<Button>("answer_backbg");

        m_answerBt0.RegisterCallback<ClickEvent>(OnanswerBt0);
        m_answerBt1.RegisterCallback<ClickEvent>(OnanswerBt1);
        m_HomeBt.RegisterCallback<ClickEvent>(onHomeClicked);

    }
    private void onHomeClicked(ClickEvent evt)
    {
        m_MainMenuUIManager.ShowHomeScreen();
    }
    void OnanswerBt0(ClickEvent evt)
    {
        m_MainMenuUIManager.ShowMapScreen();
    }
    void OnanswerBt1(ClickEvent evt)
    {
        //전체유형보기
    }
}
