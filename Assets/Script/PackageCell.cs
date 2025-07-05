using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;  // ������� UI �����ƿռ�


// ������������ÿһ������������Ʒ
// �� PackageCell ��̳������ӿڣ��ֱ��Ӧ���ĵ�������롢�˳����ֻص���ʽ
public class PackageCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // �����Ʒ�� UI ����
    private Transform UIIcon;
    private Transform UIHead;
    private Transform UINew;
    private Transform UISelect;
    private Transform UILevel;
    private Transform UIStars;
    private Transform UIDeleteSelect;

    // ��Ӷ���������� UI ����
    private Transform UISelectAni;
    private Transform UIMouseOverAni;

    private PackageLocalItem packageLocalData;  // ��ǰ��Ʒ�Ķ�̬����
    private PackageTableItem packageTableItem;  // ��ǰ��Ʒ�ľ�̬����
    private PackagePanel uiParent;  // ��ǰ��Ʒ�ĸ���Ʒ(PackagePanel)

    private void Awake()
    {
        InitUIName();
    }


    private void InitUIName()
    {
        // ʹ�� transform.Find() ����·��ȥ������
        UIIcon = transform.Find("Top/Icon");
        UIHead = transform.Find("Top/Head");
        UINew = transform.Find("Top/New");
        UILevel = transform.Find("Bottom/LevelText");
        UIStars = transform.Find("Bottom/Stars");
        UISelect = transform.Find("Select");
        UIDeleteSelect = transform.Find("DeleteSelect");

        // �󶨶�����ص�����
        UIMouseOverAni = transform.Find("MouseOverAni");
        UISelectAni = transform.Find("SelectAni");

        UIDeleteSelect.gameObject.SetActive(false);

        // ��ʼ������������ص�����Ϊ�ر�״̬
        UIMouseOverAni.gameObject.SetActive(false);
        UISelectAni.gameObject.SetActive(false);
    }


    // ˢ�������Ʒ��״̬�ķ�����Ҫ������ǰ��Ʒ�Ķ�̬���ݡ���̬���ݡ�������
    public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
    {
        // ���ݳ�ʼ��
        this.packageLocalData = packageLocalData;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
        this.uiParent = uiParent;

        // �� UI �������Ϣ���г�ʼ��
        // �ȼ���Ϣ��ʹ�� <Text> ��Ҫ���� using UnityEngine.UI ���ƿռ�
        UILevel.GetComponent<Text>().text = "Lv." + this.packageLocalData.level.ToString();
        // �Ƿ��»��
        UINew.gameObject.SetActive(this.packageLocalData.isNew);
        // ��Ʒ��ͼƬ��ͨ�����õ�·��ȥ�������ͼƬ
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


    // ʵ��������Ļص�����
    public void OnPointerClick(PointerEventData eventData)
    {
        // ��ӡ��ǰִ�еķ����ķ������Լ���һ����
        Debug.Log("OnPointerClick: " + eventData.ToString());

        // �жϵ�ǰ���ѡ�е���Ʒ�Ƿ�͸���Ʒ�� uid һ�������һ����������ظ��������ִ���κ��߼�
        if (this.uiParent.chooseUID == this.packageLocalData.uid)
            return;
        // �����һ�������������������Ʒ���ϣ��Ͱ� uiParent �� uid ����Ϊ��ǰѡ����Ʒ�� uid ������ˢ���������
        this.uiParent.chooseUID = this.packageLocalData.uid;

        // �������ѡ��Ч
        UISelectAni.gameObject.SetActive(true);
        UISelectAni.GetComponent<Animator>().SetTrigger("In");
    }


    // ʵ��������Ļص�����
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter: " + eventData.ToString());

        // ���������붯Ч
        UIMouseOverAni.gameObject.SetActive(true);
        UIMouseOverAni.GetComponent<Animator>().SetTrigger("In");
    }


    // ʵ������˳��Ļص�����
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit: " + eventData.ToString());

        // ��������˳���Ч
        UIMouseOverAni.GetComponent<Animator>().SetTrigger("Out");
    }
}
