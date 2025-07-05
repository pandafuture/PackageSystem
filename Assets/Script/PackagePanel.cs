using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackagePanel : BasePanel  // PackagePanle 继承自 BasePanel
{
    // 对各个 UI 组件的属性进行初始化
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

    // 背包子物体预制件属性
    public GameObject PackageUIItemPrefab;


    override protected void Awake()
    {
        base.Awake();
        InitUI();
    }


    private void Start()
    {
        RefreshUI();  // UI 刷新方法
    }


    private void InitUI()
    {
        InitUIName();  // 初始化各个 UI 组件

        InitClick();  // 点击事件
    }


    // UI 刷新方法
    private void RefreshUI()
    {
        RefreshScroll();  // 刷新滚动容器
    }


    // 刷新滚动容器方法
    private void RefreshScroll()
    {
        //先清理滚动容器中原本的物品
        RectTransform scrollContent = UIScrollView.GetComponent<ScrollRect>().content;
        for (int i = 0; i < scrollContent.childCount; i++)
        {
            Destroy(scrollContent.GetChild(i).gameObject);
        }

        // 使用 GameManager 中封装好的获取本地数据的方法，来拿到当前身上所有的背包数据，并且根据这些数据去初始化滚动容器
        foreach (PackageLocalItem localData in GameManager.Instance.GetSortPackageLocalData())
        {
            Transform PackageUIItem = Instantiate(PackageUIItemPrefab.transform, scrollContent) as Transform;
            PackageCell packageCell = PackageUIItem.GetComponent<PackageCell>();
            
            // 刷新这个物品的状态
            packageCell.Refresh(localData, this);
        }
    }


    private void InitUIName()
    {
        // 使用 transform.Find() 根据路径去绑定属性
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

        // 对子物体 DeletePanel 和 BottomMenus 的可见性初始化为不可见
        UIDeletePanel.gameObject.SetActive(false);
        UIBottomMenus.gameObject.SetActive(false);
    }


    // 把界面中出现的按钮都注册点击事件
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


    // 添加点击事件
    private void OnClickWeapon()
    {
        print(">>>>> OnClickWeapon");
    }
    private void OnClickFood()
    {
        print(">>>>> OnClickFood");
    }

    // PackagePanel 界面的 关闭 按钮
    private void OnClickClose()
    {
        print(">>>>> OnClickClose");
        ClosePanel();  // 调用自身的关闭方法更方便些
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
