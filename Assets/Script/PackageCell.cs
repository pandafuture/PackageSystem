using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 添加引用 UI 的名称空间


// 用来管理背包中每一个单独的子物品
public class PackageCell : MonoBehaviour
{
    // 添加物品的 UI 属性
    private Transform UIIcon;
    private Transform UIHead;
    private Transform UINew;
    private Transform UISelect;
    private Transform UILevel;
    private Transform UIStars;
    private Transform UIDeleteSelect;

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

        UIDeleteSelect.gameObject.SetActive(false);
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
}
