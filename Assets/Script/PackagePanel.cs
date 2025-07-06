using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 将背包界面设置为三个模式
public enum PackageMode
{
    normal,  // 普通模式
    delete,  // 删除模式
    sort,  //排序模式（未来可拓展实现）
}


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

    // 用来表示当前背包界面处于哪个状态
    public PackageMode curMode = PackageMode.normal;

    // 用来容纳选择删除时，所有被选中的物品的 uid
    public List<string> deleteChooseUid;

    // 记录当前选中的是哪一个物品
    private string _chooseUid;  // 表示当前选中的物品是哪一个 uid


    // 外部使用时，则使用不带下滑线的 chooseUID ，用来获取当前选中的物品是哪个并从外部选择这个物品并设置这个物品的 Uid
    public string chooseUID
    {
        get
        {
            return _chooseUid;
        }
        set
        {
            // 如果获取到一个新的值，就刷新整个详情界面
            _chooseUid = value;
            RefreshDetail();  // 调用刷新详情界面的方法
        }
    }


    // 给外部提供一个方法，用来添加删除选中项到 List<string> deleteChooseUid 中
    public void AddChooseDeleteUid(string uid)
    {
        this.deleteChooseUid ??= new List<string>();
        if (!this.deleteChooseUid.Contains(uid))
        {
            this.deleteChooseUid.Add(uid);
        }
        else
        {
            this.deleteChooseUid.Remove(uid);
        }
        RefreshDeletePanel();
    }


    // 刷新整个界面的删除状态
    private void RefreshDeletePanel()
    {
        RectTransform scrollContent = UIScrollView.GetComponent<ScrollRect>().content;
        foreach(Transform cell in scrollContent)
        {
            PackageCell packageCell = cell.GetComponent<PackageCell>();
            // 刷新物品选中状态
            packageCell.RefreshDeleteState();
        }
    }


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


    // 刷新详情界面的方法
    private void RefreshDetail()
    {
        // 找到 uid 对应的动态数据
        PackageLocalItem localItem = GameManager.Instance.GetPackageLocalItemByUId(chooseUID);

        // 刷新详情界面
        UIDetailPanel.GetComponent<PackageDetail>().Refresh(localItem, this);
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
        UIBottomMenus.gameObject.SetActive(true);
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

        // 关闭背包界面后打开主界面，即返回主界面
        UIManager.Instance.OpenPanel(UIConst.MainPanel);
    }
    private void OnClickLeft()
    {
        print(">>>>> OnClickLeft");
    }
    private void OnClickRight()
    {
        print(">>>>> OnClickRight");
    }

    
    // 在删除界面中点击返回按钮，就退出删除模式
    private void OnDeleteBack()
    {
        print(">>>>> OnDeleteBack");
        curMode = PackageMode.normal;  // 背包界面状态回到普通状态
        UIDeletePanel.gameObject.SetActive(false);  // 关闭删除界面
        // 退出删除模式后要重置选中的删除列表
        deleteChooseUid = new List<string>();
        // 最后刷新整个界面中删除物品的选中状态
        RefreshDeletePanel();
    }


    // 确认删除
    private void OnDeleteConfirm()
    {
        print(">>>>> OnDeleteConfirm");

        // 先进行合法性判断
        if(this.deleteChooseUid == null)
        {
            return;
        }
        if(this.deleteChooseUid.Count == 0)
        {
            return;
        }

        // 执行删除操作
        GameManager.Instance.DeletePackageItems(this.deleteChooseUid);
        // 删除完成后刷新整个背包界面
        RefreshUI();
    }


    // 点击左下角的删除按钮，进入删除模式
    private void OnDelete()
    {
        print(">>>>> OnDelete");
        curMode = PackageMode.delete;  // 背包界面状态进入删除模式
        UIDeletePanel.gameObject.SetActive(true);  // 打开删除界面
    }
    private void OnDetail()
    {
        print(">>>>> OnDetail");
    }
}
