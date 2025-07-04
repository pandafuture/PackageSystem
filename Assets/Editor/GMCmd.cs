using System;  // ��� System ���ƿռ�
using System.Collections;
using System.Collections.Generic;
using UnityEditor;  // ��� UnityEditor ���ƿռ�
using UnityEngine;

public class GMCmd : MonoBehaviour
{
    // ��дһ����̬��������������������� Unity ���� MenuItem ����֤ Unity �༭�������˵���������һ����ť���Ա����ǵ��ִ����Ӧ���߼�����Ҫ��� UnityEditor ���ƿռ�
    [MenuItem("CMCmd/��ȡ���")]
    public static void ReadTable()  // ��̬��������Ϊ ��ȡ���
    {
        // �����õı�������������ҽ��м򵥵Ĵ�ӡ����ӡ�����˾ʹ����ӡ�ɹ�
        PackageTable packageTable = Resources.Load<PackageTable>("TableData/PackageTable");
        foreach(PackageTableItem packageItem in packageTable.DataList)
        {
            Debug.Log(string.Format("��id��:{0}����nama��:{1}", packageItem.id, packageItem.name));
        }
    }


    [MenuItem("CMCmd/����������������")]
    public static void CreateLocalPackageData()
    {
        // �����������ݲ����浽����
        // ��ȡ��������ʵ������������Ʒ�б��ʼ��Ϊ���б�
        PackageLocalData.Instance.items = new List<PackageLocalItem>();
        // ����������Ʒ
        for(int i = 1; i < 9; i++)
        {
            // ��������Ʒ
            PackageLocalItem packageLocalItem = new()
            {
                uid = Guid.NewGuid().ToString(),  // Guid ��Ҫ��� System ���ƿռ�������һ��Ψһ���ַ���
                id = i,
                num = i,
                level = i,
                isNew = i % 2 == 1
            };
            // ��ӵ�����
            PackageLocalData.Instance.items.Add(packageLocalItem);
        }
        PackageLocalData.Instance.savePackage();  // ��������
    }


    [MenuItem("CMCmd/��ȡ������������")]
    public static void ReadLocalPackageData()
    {
        // ��ȡ����
        List<PackageLocalItem> readItems = PackageLocalData.Instance.LoadPackage();  // ���ö�ȡ����
        foreach (PackageLocalItem item in readItems)
        {
            Debug.Log(item);
        }
    }
}
