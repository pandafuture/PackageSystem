using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;  // 添加 UnityEditor 名称空间

public class MainPanel : BasePanel  // 继承改为 BasePanel
{
    // 初始化 UI
    private Transform UILottery;
    private Transform UIPackage;
    private Transform UIQuitBtn;


    protected override void Awake()
    {
        base.Awake();

        // 初始化 UI
        InitUI();
    }


    // 初始化 UI
    protected void InitUI()
    {
        UILottery = transform.Find("Top/LotteryBtn");
        UIPackage = transform.Find("Top/PackageBtn");
        UIQuitBtn = transform.Find("BottomLeft/QuitBtn");

        UILottery.GetComponent<Button>().onClick.AddListener(OnBtnLottery);
        UIPackage.GetComponent<Button>().onClick.AddListener(OnBtnPackage);
        UIQuitBtn.GetComponent<Button>().onClick.AddListener(OnQuitGame);
    }

    
    // 打开抽卡界面按钮
    private void OnBtnLottery()
    {
        print(">>>>> OnBtnLottery");
        UIManager.Instance.OpenPanel(UIConst.LotteryPanel);
        ClosePanel();
    }


    // 打开背包界面按钮
    private void OnBtnPackage()
    {
        print(">>>>> OnBtnPackage");
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);
        ClosePanel();
    }


    // 退出游戏按钮，需要添加 UnityEditor 名称空间
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
