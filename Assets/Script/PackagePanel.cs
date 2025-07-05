using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackagePanel : BasePanel  // PackagePanle �̳��� BasePanel
{
    // �Ը��� UI ��������Խ��г�ʼ��
    private Transform UIMenu;
    private Transform UIMenuWeapon;
    private Transform UIMenuFood;
    private Transform UITabName;
    private Transform UICloseBtn;
    private Transform UICenter;
    private Transform UIScrollView;
    private Transform UIDetailPanel;
    private Transform UILeftBtn;
    private Transform UIRightBtn;
    private Transform UIDeletePanel;
    private Transform UIDeleteBackBtn;
    private Transform UIDeleteInfoText;
    private Transform UIDeleteConfirmBtn;
    private Transform UIBottomMenus;
    private Transform UIDeleteBtn;
    private Transform UIDetailBtn;

    // ����������Ԥ�Ƽ�����
    public GameObject PackageUIItemPrefab;


    override protected void Awake()
    {
        base.Awake();
        InitUI();
    }


    private void Start()
    {
        RefreshUI();  // UI ˢ�·���
    }


    private void InitUI()
    {
        InitUIName();  // ��ʼ������ UI ���

        InitClick();  // ����¼�
    }


    // UI ˢ�·���
    private void RefreshUI()
    {
        RefreshScroll();  // ˢ�¹�������
    }


    // ˢ�¹�����������
    private void RefreshScroll()
    {
        //���������������ԭ������Ʒ
        RectTransform scrollContent = UIScrollView.GetComponent<ScrollRect>().content;
        for (int i = 0; i < scrollContent.childCount; i++)
        {
            Destroy(scrollContent.GetChild(i).gameObject);
        }

        // ʹ�� GameManager �з�װ�õĻ�ȡ�������ݵķ��������õ���ǰ�������еı������ݣ����Ҹ�����Щ����ȥ��ʼ����������
        foreach (PackageLocalItem localData in GameManager.Instance.GetSortPackageLocalData())
        {
            Transform PackageUIItem = Instantiate(PackageUIItemPrefab.transform, scrollContent) as Transform;
            PackageCell packageCell = PackageUIItem.GetComponent<PackageCell>();
            
            // ˢ�������Ʒ��״̬
            packageCell.Refresh(localData, this);
        }
    }


    private void InitUIName()
    {
        // ʹ�� transform.Find() ����·��ȥ������
        UIMenu = transform.Find("TopCenter/Menu");
        UIMenuWeapon = transform.Find("TopCenter/Menus/Weapon");
        UIMenuFood = transform.Find("TopCenter/Menus/Food");

        UITabName = transform.Find("LeftTop/TabName");

        UICloseBtn = transform.Find("RightTop/Close");

        UICenter = transform.Find("Center");
        UIScrollView = transform.Find("Center/Scroll View");
        UIDetailPanel = transform.Find("Center/DetailPanel");

        UILeftBtn = transform.Find("Left/Button");
        UIRightBtn = transform.Find("Right/Button");

        UIDeletePanel = transform.Find("Bottom/DeletePanel");
        UIDeleteBackBtn = transform.Find("Bottom/DeletePanel/Back");
        UIDeleteInfoText = transform.Find("Bottom/DeletePanel/InfoText");
        UIDeleteConfirmBtn = transform.Find("Bottom/DeletePanel/ConfirmBtn");
        UIBottomMenus = transform.Find("Bottom/BottomMenus");
        UIDeleteBtn = transform.Find("Bottom/BottomMenus/DeleteBtn");
        UIDetailBtn = transform.Find("Bottom/BottomMenus/DetailBtn");

        // �������� DeletePanel �� BottomMenus �Ŀɼ��Գ�ʼ��Ϊ���ɼ�
        UIDeletePanel.gameObject.SetActive(false);
        UIBottomMenus.gameObject.SetActive(false);
    }


    // �ѽ����г��ֵİ�ť��ע�����¼�
    private void InitClick()
    {
        UIMenuWeapon.GetComponent<Button>().onClick.AddListener(OnClickWeapon);
        UIMenuFood.GetComponent<Button>().onClick.AddListener(OnClickFood);
        UICloseBtn.GetComponent<Button>().onClick.AddListener(OnClickClose);
        UILeftBtn.GetComponent<Button>().onClick.AddListener(OnClickLeft);
        UIRightBtn.GetComponent<Button>().onClick.AddListener(OnClickRight);

        UIDeleteBackBtn.GetComponent<Button>().onClick.AddListener(OnDeleteBack);
        UIDeleteConfirmBtn.GetComponent<Button>().onClick.AddListener(OnDeleteConfirm);
        UIDeleteBtn.GetComponent<Button>().onClick.AddListener(OnDelete);
        UIDetailBtn.GetComponent<Button>().onClick.AddListener(OnDetail);
    }


    // ��ӵ���¼�
    private void OnClickWeapon()
    {
        print(">>>>> OnClickWeapon");
    }
    private void OnClickFood()
    {
        print(">>>>> OnClickFood");
    }

    // PackagePanel ����� �ر� ��ť
    private void OnClickClose()
    {
        print(">>>>> OnClickClose");
        ClosePanel();  // ��������Ĺرշ���������Щ
        //UIManager.Instance.ClosePanel(UIConst.PackagePanel);
    }
    private void OnClickLeft()
    {
        print(">>>>> OnClickLeft");
    }
    private void OnClickRight()
    {
        print(">>>>> OnClickRight");
    }
    private void OnDeleteBack()
    {
        print(">>>>> OnDeleteBack");
    }
    private void OnDeleteConfirm()
    {
        print(">>>>> OnDeleteConfirm");
    }
    private void OnDelete()
    {
        print(">>>>> OnDelete");
    }
    private void OnDetail()
    {
        print(">>>>> OnDetail");
    }
}
