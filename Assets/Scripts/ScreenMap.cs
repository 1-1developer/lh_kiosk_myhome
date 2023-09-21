//using FigmaImporter.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenMap : MenuScreen
{
    const string MAPPOINT = "map_point";
    const string MAPBT = "map_bt";
    const string MAPCHARTBOX = "MapchartBox";
    const string MAPCHART = "map_chart";
    const string MAPCHART2 = "map_chart2";
    const string DATABOX = "DataBox";
    const string DATAE = "DataElement";
    const string DATACLOSEBT = "DataCloseBt";
    const string PG = "PG";



    public Sprite[] charts;
    public Sprite[] DataNew;
    public Sprite[] DataBefore;
    public Sprite[] dataButtonAOnOff;
    public Sprite[] dataButtonBOnOff;




    VisualElement m_MapchartBox;//버튼까지 포함된그.
    VisualElement m_Mapchart;//이미지 교체되는 엘리먼트
    VisualElement m_Mapchart2;//이미지 교체되는 엘리먼트
    VisualElement m_DataBox;
    VisualElement m_DataE;//이미지 교체되는 엘리먼트

    Button m_dataBTa;//위치공급호수
    Button m_dataBTb;//추정분양가

    Button m_dataCloseBt;//닫기
    Button m_homeBt;//홈버튼

    List<Button> m_Pointers = new List<Button>();
    List<Button> m_Mapbt = new List<Button>();
    List<VisualElement> m_pointGroups = new List<VisualElement>();

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
        m_Mapchart2 = m_Root.Q<VisualElement>(MAPCHART2);
        m_DataBox = m_Root.Q<VisualElement>(DATABOX);
        m_DataE = m_Root.Q<VisualElement>(DATAE);

        m_dataBTa = m_Root.Q<Button>(MAPBT + "4");
        m_dataBTb= m_Root.Q<Button>(MAPBT + "5");
        m_dataCloseBt = m_Root.Q<Button>(DATACLOSEBT);

        m_homeBt = m_Root.Q<Button>("btHome_Map");

        for (int i = 0; i < 20; i++)
        {
            m_Pointers.Add(m_Root.Q<Button>(MAPPOINT + $"{i}"));
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

        m_Pointers[0].RegisterCallback<ClickEvent>(evt => OnPointerClicked(0));
        m_Pointers[1].RegisterCallback<ClickEvent>(evt => OnPointerClicked(1));
        m_Pointers[2].RegisterCallback<ClickEvent>(evt => OnPointerClicked(2));
        m_Pointers[3].RegisterCallback<ClickEvent>(evt => OnPointerClicked(3));
        m_Pointers[4].RegisterCallback<ClickEvent>(evt => OnPointerClicked(4));
        m_Pointers[5].RegisterCallback<ClickEvent>(evt => OnPointerClicked(5));
        m_Pointers[6].RegisterCallback<ClickEvent>(evt => OnPointerClicked(6));
        m_Pointers[7].RegisterCallback<ClickEvent>(evt => OnPointerClicked(7));
        m_Pointers[8].RegisterCallback<ClickEvent>(evt => OnPointerClicked(8));
        m_Pointers[9].RegisterCallback<ClickEvent>(evt => OnPointerClicked(9));
        m_Pointers[10].RegisterCallback<ClickEvent>(evt => OnPointerClicked(10));
        m_Pointers[11].RegisterCallback<ClickEvent>(evt => OnPointerClicked(11));
        m_Pointers[12].RegisterCallback<ClickEvent>(evt => OnPointerClicked(12));
        m_Pointers[13].RegisterCallback<ClickEvent>(evt => OnPointerClicked(13));
        m_Pointers[14].RegisterCallback<ClickEvent>(evt => OnPointerClicked(14));
        m_Pointers[15].RegisterCallback<ClickEvent>(evt => OnPointerClicked(15));
        m_Pointers[16].RegisterCallback<ClickEvent>(evt => OnPointerClicked(16));
        m_Pointers[17].RegisterCallback<ClickEvent>(evt => OnPointerClicked(17));
        m_Pointers[18].RegisterCallback<ClickEvent>(evt => OnPointerClicked(18));
        m_Pointers[19].RegisterCallback<ClickEvent>(evt => OnPointerClicked(19));


        m_homeBt.RegisterCallback<ClickEvent>(OnHomeClicked);
    }

    private void OnHomeClicked(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        InitMap();
        m_MainMenuUIManager.ShowHomeScreen(); 
    }

    private void OnCloseClicked(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_DataBox.style.display = DisplayStyle.None;
        m_MapchartBox.style.display = DisplayStyle.Flex;
    }

    private void OnTopbtCilcked(int index)
    {
        StyleTopBt(index);
        AudioManager.PlayDefaultButtonSound();
        topindex = index;
        showPointG(m_pointGroups[topindex]);

        InitChartDisplay();
        m_Mapchart.style.backgroundImage = charts[topindex].texture;
    }

    void OnPointerClicked(int index)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MapchartBox.style.display = DisplayStyle.None;
        m_DataBox.style.display = DisplayStyle.Flex;
        switch (Dataindex)
        {
            case 0:
                m_DataE.style.backgroundImage = DataNew[index].texture;
                break;
            case 1:
                m_DataE.style.backgroundImage = DataBefore[index].texture;
                break;
            default:
                break;
        }

    }

    void OnDataBTClicked(int index)
    {
        AudioManager.PlayDefaultButtonSound();
        Dataindex = index;
        switch (index)
        {
            case 0:
                m_Mapchart.style.display = DisplayStyle.Flex;
                m_Mapchart2.style.display = DisplayStyle.None;
                m_Mapchart.style.backgroundImage = charts[topindex].texture;
                DataButtonsClicked(Dataindex);
                //m_Mapchart.style.backgroundImage = charts[0].texture;                
                break;
            case 1:
                m_Mapchart2.style.display = DisplayStyle.Flex;
                m_Mapchart.style.display = DisplayStyle.None;
                DataButtonsClicked(Dataindex);
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

    void StyleTopBt(int index)
    {
        Button bb = m_Mapbt[index];
        foreach (Button b in m_Mapbt)
        {
            if (bb == b)
                b.RemoveFromClassList("TopBt--un");
            else
                b.AddToClassList("TopBt--un");
        }
    }

    void InitChartDisplay()
    {
        Dataindex = 0;

        // 팝업창 닫기
        m_DataBox.style.display = DisplayStyle.None;
        m_MapchartBox.style.display = DisplayStyle.Flex;

        //표 차트 띄우기
        m_Mapchart.style.display = DisplayStyle.Flex;
        m_Mapchart2.style.display = DisplayStyle.None;
        //m_Mapchart.style.backgroundImage = charts[0].texture;
        DataButtonsClicked(0);

    }

    void DataButtonsClicked(int v)
    {
        m_dataBTa.style.backgroundImage = dataButtonAOnOff[v].texture;
        m_dataBTb.style.backgroundImage = dataButtonBOnOff[v].texture;
    }

        public void InitMap()
    {        
        StyleTopBt(0);
        showPointG(m_pointGroups[0]);
        m_Mapchart.style.backgroundImage = charts[0].texture;
        InitChartDisplay(); 
    }
}
