using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 添加引用 UI 的名称空间

public class LotteryPanel : BasePanel  // 继承的父类改为 BasePanel
{
    // 初始化 UI
    private Transform UIClose;
    private Transform UICenter;
    private Transform UILottery10;
    private Transform UILottery1;
    private GameObject LotteryCellPrefab;


    protected override void Awake()
    {
        base.Awake();
        // 初始化 UI
        InitUI();

        // 对抽卡物品的子物品的预制件初始化
        InitPrefab();
    }

    
    // 初始化 UI
    private void InitUI()
    {
        UIClose = transform.Find("TopRight/Close");
        UICenter = transform.Find("Center");
        UILottery10 = transform.Find("Bottom/Lottery10");
        UILottery1 = transform.Find("Bottom/Lottery1");

        // 注册点击按钮事件，需要添加引用 UI 的名称空间
        UILottery10.GetComponent<Button>().onClick.AddListener(OnLottery10Btn);  // 十抽按钮
        UILottery1.GetComponent<Button>().onClick.AddListener(OnLottery1Btn);  // 单抽按钮

        // 注册退出按钮的点击事件
        UIClose.GetComponent<Button>().onClick.AddListener(OnClose);
    }


    // 初始化抽卡物品的子物品的预制体
    private void InitPrefab()
    {
        LotteryCellPrefab = Resources.Load("Prefab/Panel/Lottery/LotteryItem") as GameObject;
    }


    // 添加点击事件
    // 单抽按钮
    private void OnLottery1Btn()
    {
        print(">>>>>>>>>> OnLottery1Btn");

        // 先销毁整个容器中原本的所有卡片
        for (int i = 0; i < UICenter.childCount; i++)
        {
            Destroy(UICenter.GetChild(i).gameObject);
        }
        // 再抽卡获得一张新的物品
        PackageLocalItem item = GameManager.Instance.GetLotteryRandom1();

        Transform LotteryCellTran = Instantiate(LotteryCellPrefab.transform, UICenter) as Transform;
        // 对卡片做信息展示刷新
        LotteryCell lotteryCell = LotteryCellTran.GetComponent<LotteryCell>();
        lotteryCell.Refresh(item, this);
    }

    // 十抽按钮
    private void OnLottery10Btn()
    {
        print(">>>>>>>>>> OnLottery10Btn");


        // 抽卡获得十张新的物品，先存在本地数据中
        List<PackageLocalItem> packageLocalItems = GameManager.Instance.GetLotteryDandom10(sort: true);

        // 先销毁整个容器中原本的所有卡片
        for(int i = 0; i < UICenter.childCount; i++)
        {
            Destroy(UICenter.GetChild(i).gameObject);
        }

        // 再实例化这十个物品
        foreach(PackageLocalItem item in packageLocalItems)
        {
            Transform LotteryCellTran = Instantiate(LotteryCellPrefab.transform, UICenter) as Transform;

            // 对卡片信息展示刷新
            LotteryCell lotteryCell = LotteryCellTran.GetComponent<LotteryCell>();
            lotteryCell.Refresh(item, this);
        }
    }


    // 关闭按钮
    private void OnClose()
    {
        print(">>>>>>>>>> OnClose");
        // 抽卡界面关闭时也应该打开主界面，即返回主界面
        ClosePanel();
        UIManager.Instance.OpenPanel(UIConst.MainPanel);
    }


}
