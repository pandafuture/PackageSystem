using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 添加引用 UI 的名称空间

public class PackageDetail : MonoBehaviour
{
    // 先给 PackageDetail 类添加属性，即所有的 UI 子节点
    private Transform UIStars;
    private Transform UIDescription;
    private Transform UIIcon;
    private Transform UITitle;
    private Transform UILevelText;
    private Transform UISkillDescription;


    // 作为背包物品的展示区，要先拿到这个物品的动态信息、静态信息、整个背包的父逻辑（uiParent)
    private PackageLocalItem packageLocalData;
    private PackageTableItem packageTableItem;
    private PackagePanel uiParent;


    // 对这些属性进行初始化
    private void Awake()
    {
        InitUIName();

        // 用于验证此模块逻辑是否正确
        Test();
    }


    // 测试方法
    private void Test()
    {
        // 传入某一个物品的动态信息来对整个详情界面进行初始化
        Refresh(GameManager.Instance.GetPackageLocalData()[1], null);
    }


    private void InitUIName()
    {
        // 使用 transform.Find() 找到物品对应的路径
        UIStars = transform.Find("Center/Stars");
        UIDescription = transform.Find("Center/Description");
        UIIcon = transform.Find("Center/Icon");
        UITitle = transform.Find("Top/Title");
        UILevelText = transform.Find("Bottom/LevelPnl/LevelText");
        UISkillDescription = transform.Find("Bottom/Description");
    }


    // 刷新整个详情界面的主体方法，通过传入一个动态数据和 uiParent 来实现整个详情界面的刷新
    public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
    {
        // 初始化：动态数据、静态数据、父物体逻辑
        this.packageLocalData = packageLocalData;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
        this.uiParent = uiParent;


        // 对 UI 组件的信息进行初始化
        // 等级
        UILevelText.GetComponent<Text>().text = string.Format("Lv.{0}/40", this.packageLocalData.level.ToString());

        // 简短描述
        UIDescription.GetComponent<Text>().text = this.packageTableItem.description;

        // 详细描述
        UISkillDescription.GetComponent<Text>().text = this.packageTableItem.skillDescription;

        // 物品名称
        UITitle.GetComponent<Text>().text = this.packageTableItem.name;

        // 图片加载
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
            if (this.packageTableItem.star > i)
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
