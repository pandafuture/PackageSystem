using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // ������� UI �����ƿռ�

public class LotteryCell : MonoBehaviour
{
    // ��� UI �������
    private Transform UIImage;
    private Transform UIStars;
    private Transform UINew;
    private PackageLocalItem packageLocalItem;
    private PackageTableItem packageTableItem;
    private LotteryPanel uiParent;

    private void Awake()
    {
        // ��ʼ�� UI
        InitUI();
    }


    // ��ʼ�� UI ����
    void InitUI()
    {
        UIImage = transform.Find("Center/Image");
        UIStars = transform.Find("Bottom/Stars");
        //UINew = transform.Find("Top/New");
        //UINew.gameObject.SetActive(false);
    }


    // ˢ�·���
    public void Refresh(PackageLocalItem packageLocalItem, LotteryPanel uiParent)
    {
        // �Ի������ݽ��г�ʼ��
        this.packageLocalItem = packageLocalItem;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(this.packageLocalItem.id);
        this.uiParent = uiParent;

        // ˢ�� UI ͼƬ��Ϣ
        RefreshImage();
        // ˢ���Ǽ�
        RefreshStars();
    }


    // UI ͼƬˢ�·�������Ҫ������� UI �����ƿռ�
    private void RefreshImage()
    {
        Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
        Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
        UIImage.GetComponent<Image>().sprite = temp;
    }

    // �Ǽ�ˢ�·���
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
