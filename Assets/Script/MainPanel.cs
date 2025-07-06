using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;  // ��� UnityEditor ���ƿռ�

public class MainPanel : BasePanel  // �̳и�Ϊ BasePanel
{
    // ��ʼ�� UI
    private Transform UILottery;
    private Transform UIPackage;
    private Transform UIQuitBtn;


    protected override void Awake()
    {
        base.Awake();

        // ��ʼ�� UI
        InitUI();
    }


    // ��ʼ�� UI
    protected void InitUI()
    {
        UILottery = transform.Find("Top/LotteryBtn");
        UIPackage = transform.Find("Top/PackageBtn");
        UIQuitBtn = transform.Find("BottomLeft/QuitBtn");

        UILottery.GetComponent<Button>().onClick.AddListener(OnBtnLottery);
        UIPackage.GetComponent<Button>().onClick.AddListener(OnBtnPackage);
        UIQuitBtn.GetComponent<Button>().onClick.AddListener(OnQuitGame);
    }

    
    // �򿪳鿨���水ť
    private void OnBtnLottery()
    {
        print(">>>>> OnBtnLottery");
        UIManager.Instance.OpenPanel(UIConst.LotteryPanel);
        ClosePanel();
    }


    // �򿪱������水ť
    private void OnBtnPackage()
    {
        print(">>>>> OnBtnPackage");
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);
        ClosePanel();
    }


    // �˳���Ϸ��ť����Ҫ��� UnityEditor ���ƿռ�
    private void OnQuitGame()
    {
        print(">>>>> OnQuitGame");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
