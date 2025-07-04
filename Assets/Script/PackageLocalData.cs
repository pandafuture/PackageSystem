using UnityEngine;
using System.Collections.Generic;

public class PackageLocalData
{
    // Ϊ��ʹ�÷��㣬��������Ϊ����ģʽ
    private static PackageLocalData _instance;

    public static PackageLocalData Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new PackageLocalData();
            }
            return _instance;
        }
    }


    // ʹ�� List ���������浱ǰ������Ʒ�Ķ�̬��Ϣ
    public List<PackageLocalItem> items;

    // �淽��
    public void savePackage()
    {
        // ʹ�� Unity �ṩ�� JsonUtility ���ߣ��ѱ����Ϣ���л�Ϊ�ַ���
        string inventoryJson = JsonUtility.ToJson(this);
        // ʹ�� PlayerPrefs ���ı����ݴ洢�����ص��ļ��У�����Ϊ PackageLocalData
        PlayerPrefs.SetString("PackageLocalData", inventoryJson);
        PlayerPrefs.Save();
    }

    // ��ȡ����
    public List<PackageLocalItem> LoadPackage()
    {
        // �����ж�Ҫ����������Ƿ��Ѵ��ڣ����Ѵ��ڣ���˵��֮ǰ�Ѷ�ȡ���ı���Ϣ����ֱ�ӷ��� items
        if(items != null)
        {
            return items;
        }
        if (PlayerPrefs.HasKey("PackageLocalData"))  // ��� PlayerPrefs ���Ƿ��м���Ϊ PackageLocalData ���ı����ݣ����û�оʹӱ��ص��ļ���ȡ��ȡ
        {
            // ʹ�� PlayerPrefs �ѱ��ص��ļ���ȡ���ڴ��У�ʹ֮��Ϊ�ַ���
            string inventoryJson = PlayerPrefs.GetString("PackageLocalData");
            // ʹ�� JsonUtility �������л�Ϊ packageLocalData ����� items �б�
            PackageLocalData packageLocalData = JsonUtility.FromJson<PackageLocalData>(inventoryJson);
            items = packageLocalData.items;
            return items;
        }
        else // ��� PlayerPrefs �в����� PackageLocalData ���ı����ݣ��ʹ����µĿ��б�
        {
            items = new List<PackageLocalItem>();
            return items;
        }
    }
}


[System.Serializable]
// �����������Ʒ�Ķ�̬�洢�Ĳ���
public class PackageLocalItem
{
    public string uid;  // Ψһ�ı�ʶ�� uid
    public int id;  // ��ʾ�����ĸ���Ʒ
    public int num;  // ��ʾ��Ʒ������
    public int level;  // ��Ʒ�ĵȼ�
    public bool isNew;  // �Ƿ�Ϊ�»�õ���Ʒ

    // ��д�������� ToString() �����������ӡ�͵���
    public override string ToString()
    {
        return string.Format("[id]:{0} [num]:{1}", id, num);
    }
}