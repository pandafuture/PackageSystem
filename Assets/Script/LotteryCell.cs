using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 添加引用 UI 的名称空间

public class LotteryCell : MonoBehaviour
{
    // 添加 UI 组件属性
    private Transform UIImage;
    private Transform UIStars;
    private Transform UINew;
    private PackageLocalItem packageLocalItem;
    private PackageTableItem packageTableItem;
    private LotteryPanel uiParent;

    private void Awake()
    {
        // 初始化 UI
        InitUI();
    }


    // 初始化 UI 方法
    void InitUI()
    {
        UIImage = transform.Find("Center/Image");
        UIStars = transform.Find("Bottom/Stars");
        //UINew = transform.Find("Top/New");
        //UINew.gameObject.SetActive(false);
    }


    // 刷新方法
    public void Refresh(PackageLocalItem packageLocalItem, LotteryPanel uiParent)
    {
        // 对基本数据进行初始化
        this.packageLocalItem = packageLocalItem;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(this.packageLocalItem.id);
        this.uiParent = uiParent;

        // 刷新 UI 图片信息
        RefreshImage();
        // 刷新星级
        RefreshStars();
    }


    // UI 图片刷新方法，需要添加引用 UI 的名称空间
    private void RefreshImage()
    {
        Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
        Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
        UIImage.GetComponent<Image>().sprite = temp;
    }

    // 星级刷新方法
    public void RefreshStars()
    {
        for( int i = 0; i < UIStars.childCount; i++)
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
