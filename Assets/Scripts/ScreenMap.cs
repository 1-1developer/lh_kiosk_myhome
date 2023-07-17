using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenMap : MenuScreen
{
    const string MAPPOINT = "map_point";
    const string MAPBT = "map_bt";
    const string MAPCHART = "MapchartBox";

    VisualElement m_MapchartBos;

    List<Button> m_Pointers = new List<Button>();
    List<Button> m_Mapbt = new List<Button>();

    LineDrawer ld;
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        for (int i = 0; i < 3; i++)
        {
            m_Mapbt.Add(m_Root.Q<Button>(MAPBT + $"{i}"));
        }
        for (int i = 0; i < 18; i++)
        {
            m_Pointers.Add(m_Root.Q<Button>(MAPPOINT + $"{i}"));
        }

        m_Mapbt[0].RegisterCallback<ClickEvent>(onMain1Clicked);
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
