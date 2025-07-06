using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // ������� UI �����ƿռ�

public class LotteryPanel : BasePanel  // �̳еĸ����Ϊ BasePanel
{
    // ��ʼ�� UI
    private Transform UIClose;
    private Transform UICenter;
    private Transform UILottery10;
    private Transform UILottery1;
    private GameObject LotteryCellPrefab;


    protected override void Awake()
    {
        base.Awake();
        // ��ʼ�� UI
        InitUI();

        // �Գ鿨��Ʒ������Ʒ��Ԥ�Ƽ���ʼ��
        InitPrefab();
    }

    
    // ��ʼ�� UI
    private void InitUI()
    {
        UIClose = transform.Find("TopRight/Close");
        UICenter = transform.Find("Center");
        UILottery10 = transform.Find("Bottom/Lottery10");
        UILottery1 = transform.Find("Bottom/Lottery1");

        // ע������ť�¼�����Ҫ������� UI �����ƿռ�
        UILottery10.GetComponent<Button>().onClick.AddListener(OnLottery10Btn);  // ʮ�鰴ť
        UILottery1.GetComponent<Button>().onClick.AddListener(OnLottery1Btn);  // ���鰴ť

        // ע���˳���ť�ĵ���¼�
        UIClose.GetComponent<Button>().onClick.AddListener(OnClose);
    }


    // ��ʼ���鿨��Ʒ������Ʒ��Ԥ����
    private void InitPrefab()
    {
        LotteryCellPrefab = Resources.Load("Prefab/Panel/Lottery/LotteryItem") as GameObject;
    }


    // ��ӵ���¼�
    // ���鰴ť
    private void OnLottery1Btn()
    {
        print(">>>>>>>>>> OnLottery1Btn");

        // ����������������ԭ�������п�Ƭ
        for (int i = 0; i < UICenter.childCount; i++)
        {
            Destroy(UICenter.GetChild(i).gameObject);
        }
        // �ٳ鿨���һ���µ���Ʒ
        PackageLocalItem item = GameManager.Instance.GetLotteryRandom1();

        Transform LotteryCellTran = Instantiate(LotteryCellPrefab.transform, UICenter) as Transform;
        // �Կ�Ƭ����Ϣչʾˢ��
        LotteryCell lotteryCell = LotteryCellTran.GetComponent<LotteryCell>();
        lotteryCell.Refresh(item, this);
    }

    // ʮ�鰴ť
    private void OnLottery10Btn()
    {
        print(">>>>>>>>>> OnLottery10Btn");


        // �鿨���ʮ���µ���Ʒ���ȴ��ڱ���������
        List<PackageLocalItem> packageLocalItems = GameManager.Instance.GetLotteryDandom10(sort: true);

        // ����������������ԭ�������п�Ƭ
        for(int i = 0; i < UICenter.childCount; i++)
        {
            Destroy(UICenter.GetChild(i).gameObject);
        }

        // ��ʵ������ʮ����Ʒ
        foreach(PackageLocalItem item in packageLocalItems)
        {
            Transform LotteryCellTran = Instantiate(LotteryCellPrefab.transform, UICenter) as Transform;

            // �Կ�Ƭ��Ϣչʾˢ��
            LotteryCell lotteryCell = LotteryCellTran.GetComponent<LotteryCell>();
            lotteryCell.Refresh(item, this);
        }
    }


    // �رհ�ť
    private void OnClose()
    {
        print(">>>>>>>>>> OnClose");
        // �鿨����ر�ʱҲӦ�ô������棬������������
        ClosePanel();
        UIManager.Instance.OpenPanel(UIConst.MainPanel);
    }


}
