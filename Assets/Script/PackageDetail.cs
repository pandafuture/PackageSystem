using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // ������� UI �����ƿռ�

public class PackageDetail : MonoBehaviour
{
    // �ȸ� PackageDetail ��������ԣ������е� UI �ӽڵ�
    private Transform UIStars;
    private Transform UIDescription;
    private Transform UIIcon;
    private Transform UITitle;
    private Transform UILevelText;
    private Transform UISkillDescription;


    // ��Ϊ������Ʒ��չʾ����Ҫ���õ������Ʒ�Ķ�̬��Ϣ����̬��Ϣ�����������ĸ��߼���uiParent)
    private PackageLocalItem packageLocalData;
    private PackageTableItem packageTableItem;
    private PackagePanel uiParent;


    // ����Щ���Խ��г�ʼ��
    private void Awake()
    {
        InitUIName();

        // ������֤��ģ���߼��Ƿ���ȷ
        Test();
    }


    // ���Է���
    private void Test()
    {
        // ����ĳһ����Ʒ�Ķ�̬��Ϣ�����������������г�ʼ��
        Refresh(GameManager.Instance.GetPackageLocalData()[1], null);
    }


    private void InitUIName()
    {
        // ʹ�� transform.Find() �ҵ���Ʒ��Ӧ��·��
        UIStars = transform.Find("Center/Stars");
        UIDescription = transform.Find("Center/Description");
        UIIcon = transform.Find("Center/Icon");
        UITitle = transform.Find("Top/Title");
        UILevelText = transform.Find("Bottom/LevelPnl/LevelText");
        UISkillDescription = transform.Find("Bottom/Description");
    }


    // ˢ�����������������巽����ͨ������һ����̬���ݺ� uiParent ��ʵ��������������ˢ��
    public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
    {
        // ��ʼ������̬���ݡ���̬���ݡ��������߼�
        this.packageLocalData = packageLocalData;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
        this.uiParent = uiParent;


        // �� UI �������Ϣ���г�ʼ��
        // �ȼ�
        UILevelText.GetComponent<Text>().text = string.Format("Lv.{0}/40", this.packageLocalData.level.ToString());

        // �������
        UIDescription.GetComponent<Text>().text = this.packageTableItem.description;

        // ��ϸ����
        UISkillDescription.GetComponent<Text>().text = this.packageTableItem.skillDescription;

        // ��Ʒ����
        UITitle.GetComponent<Text>().text = this.packageTableItem.name;

        // ͼƬ����
        Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
        Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
        UIIcon.GetComponent<Image>().sprite = temp;

        // ˢ���Ǽ�
        RefreshStars();

    }


    // ˢ���Ǽ��ķ���
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
