using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenMap : MenuScreen
{
    const string MAPPOINT = "map_point";
    const string MAPBT = "map_bt";
    const string MAPCHARTBOX = "MapchartBox";
    const string MAPCHART = "map_chart";
    const string DATABOX = "DataBox";
    const string DATAE = "DataElement";
    const string DATACLOSEBT = "DataCloseBt";
    const string PG = "PG";



    public Sprite[] charts;
    public Sprite[] DataWay;
    public Sprite[] DataPrice;



    VisualElement m_MapchartBox;//버튼까지 포함된그.
    VisualElement m_Mapchart;//이미지 교체되는 엘리먼트
    VisualElement m_DataBox;
    VisualElement m_DataE;//이미지 교체되는 엘리먼트

    Button m_dataBTa;//위치공급호수
    Button m_dataBTb;//추정분양가

    Button m_dataCloseBt;//닫기

    List<Button> m_Pointers = new List<Button>();
    List<Button> m_Mapbt = new List<Button>();
    List<VisualElement> m_pointGroups = new List<VisualElement>();

    LineDrawer ld;

    int Dataindex;
    int topindex;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        for (int i = 0; i < 3; i++)
        {
            m_Mapbt.Add(m_Root.Q<Button>(MAPBT + $"{i}"));
        }

        m_MapchartBox = m_Root.Q<VisualElement>(MAPCHARTBOX);
        m_Mapchart = m_Root.Q<VisualElement>(MAPCHART);
        m_DataBox = m_Root.Q<VisualElement>(DATABOX);
        m_DataE = m_Root.Q<VisualElement>(DATAE);

        m_dataBTa = m_Root.Q<Button>(MAPBT + "4");
        m_dataBTb= m_Root.Q<Button>(MAPBT + "5");
        m_dataCloseBt = m_Root.Q<Button>(DATACLOSEBT);

        for (int i = 0; i < 18; i++)
        {
            m_Pointers.Add(m_Root.Q<Button>(MAPPOINT + $"{i}"));
            m_Pointers[i].RegisterCallback<ClickEvent>(evt => OnPointerClicked(i));
        }

        m_pointGroups.Add(m_Root.Q<VisualElement>("PG_nanum"));
        m_pointGroups.Add(m_Root.Q<VisualElement>("PG_choice"));
        m_pointGroups.Add(m_Root.Q<VisualElement>("PG_normal"));


        m_Mapbt[0].RegisterCallback<ClickEvent>(evt=> OnTopbtCilcked(0));//nanum
        m_Mapbt[1].RegisterCallback<ClickEvent>(evt => OnTopbtCilcked(1));//choice
        m_Mapbt[2].RegisterCallback<ClickEvent>(evt => OnTopbtCilcked(2));//normal

        m_dataCloseBt.RegisterCallback<ClickEvent>(OnCloseClicked);
        m_dataBTa.RegisterCallback<ClickEvent>(evt => OnDataBTClicked(0));
        m_dataBTb.RegisterCallback<ClickEvent>(evt => OnDataBTClicked(1));
    }
    private void OnCloseClicked(ClickEvent evt)
    {
        m_DataBox.style.display = DisplayStyle.None;
    }

    private void OnTopbtCilcked(int index)
    {
        topindex = index;
        showPointG(m_pointGroups[topindex]);
        m_Mapchart.style.backgroundImage = charts[topindex + 1].texture;
    }

    void OnPointerClicked(int index)
    {
        m_MapchartBox.style.display = DisplayStyle.None;
        m_DataBox.style.display = DisplayStyle.Flex;
        switch (Dataindex)
        {
            case 0:
                m_DataE.style.backgroundImage = DataWay[index].texture;
                break;
            case 1:
                m_DataE.style.backgroundImage = DataPrice[index].texture;
                break;
            default:
                break;
        }

    }

    void OnDataBTClicked(int index)
    {
        Dataindex = index;
        switch (index)
        {
            case 0:
                m_Mapchart.style.backgroundImage = charts[0].texture;
                break;
            case 1:
                m_Mapchart.style.backgroundImage = charts[topindex+1].texture;
                break;
            default:
                break;
        }
    }
    void showPointG(VisualElement g)
    {
        foreach (VisualElement a in m_pointGroups)
        {
            if (a == g)
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
