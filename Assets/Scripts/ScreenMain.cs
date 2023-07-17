using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenMain : MenuScreen
{
    const string MAINBT1 = "mainbt1";
    const string MAINBT2 = "mainbt2";

    Button mainbt1;
    Button mainbt2;

    LineDrawer ld;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        mainbt1 = m_Root.Q<Button>(MAINBT1);
        mainbt2 = m_Root.Q<Button>(MAINBT2);

        mainbt1.RegisterCallback<ClickEvent>(onMain1Clicked);
        mainbt2.RegisterCallback<ClickEvent>(onMain1Clicked);
    }

    private void onMain1Clicked(ClickEvent evt)
    {
        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
