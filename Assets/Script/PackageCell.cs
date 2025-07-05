using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;  // 添加引用 UI 的名称空间


// 用来管理背包中每一个单独的子物品
// 让 PackageCell 类继承三个接口，分别对应鼠标的点击、进入、退出三种回调方式
public class PackageCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // 添加物品的 UI 属性
    private Transform UIIcon;
    private Transform UIHead;
    private Transform UINew;
    private Transform UISelect;
    private Transform UILevel;
    private Transform UIStars;
    private Transform UIDeleteSelect;

    // 添加动画相关两个 UI 属性
    private Transform UISelectAni;
    private Transform UIMouseOverAni;

    private PackageLocalItem packageLocalData;  // 当前物品的动态数据
    private PackageTableItem packageTableItem;  // 当前物品的静态数据
    private PackagePanel uiParent;  // 当前物品的父物品(PackagePanel)

    private void Awake()
    {
        InitUIName();
    }


    private void InitUIName()
    {
        // 使用 transform.Find() 根据路径去绑定属性
        UIIcon = transform.Find("Top/Icon");
        UIHead = transform.Find("Top/Head");
        UINew = transform.Find("Top/New");
        UILevel = transform.Find("Bottom/LevelText");
        UIStars = transform.Find("Bottom/Stars");
        UISelect = transform.Find("Select");
        UIDeleteSelect = transform.Find("DeleteSelect");

        // 绑定动画相关的属性
        UIMouseOverAni = transform.Find("MouseOverAni");
        UISelectAni = transform.Find("SelectAni");

        UIDeleteSelect.gameObject.SetActive(false);

        // 初始化两个动画相关的属性为关闭状态
        UIMouseOverAni.gameObject.SetActive(false);
        UISelectAni.gameObject.SetActive(false);
    }


    // 刷新这个物品的状态的方法，要传进当前物品的动态数据、静态数据、父物体
    public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
    {
        // 数据初始化
        this.packageLocalData = packageLocalData;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
        this.uiParent = uiParent;

        // 对 UI 组件的信息进行初始化
        // 等级信息，使用 <Text> 需要引用 using UnityEngine.UI 名称空间
        UILevel.GetComponent<Text>().text = "Lv." + this.packageLocalData.level.ToString();
        // 是否新获得
        UINew.gameObject.SetActive(this.packageLocalData.isNew);
        // 物品的图片，通过配置的路径去加载这个图片
        Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
        Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
        UIIcon.GetComponent<Image>().sprite = temp;
        // 刷新星级
        RefreshStars();
    }


    // 刷新星级的方法
    public void RefreshStars()
    {
        for(int i = 0; i < UIStars.childCount; i++)
        {
            Transform star = UIStars.GetChild(i);
            if(this.packageTableItem.star > i)
            {
                star.gameObject.SetActive(true);
            }
            else
            {
                star.gameObject.SetActive(false);
            }
        }
    }


    // 实现鼠标点击的回调方法
    public void OnPointerClick(PointerEventData eventData)
    {
        // 打印当前执行的方法的方法名以及这一数据
        Debug.Log("OnPointerClick: " + eventData.ToString());

        // 判断当前点击选中的物品是否和父物品的 uid 一样，如果一样则代表是重复点击，不执行任何逻辑
        if (this.uiParent.chooseUID == this.packageLocalData.uid)
            return;
        // 如果不一样，则代表点击到了新物品身上，就把 uiParent 的 uid 设置为当前选中物品的 uid ，进而刷新详情界面
        this.uiParent.chooseUID = this.packageLocalData.uid;

        // 播放鼠标选择动效
        UISelectAni.gameObject.SetActive(true);
        UISelectAni.GetComponent<Animator>().SetTrigger("In");
    }


    // 实现鼠标进入的回调方法
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter: " + eventData.ToString());

        // 播放鼠标进入动效
        UIMouseOverAni.gameObject.SetActive(true);
        UIMouseOverAni.GetComponent<Animator>().SetTrigger("In");
    }


    // 实现鼠标退出的回调方法
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit: " + eventData.ToString());

        // 播放鼠标退出动效
        UIMouseOverAni.GetComponent<Animator>().SetTrigger("Out");
    }
}
