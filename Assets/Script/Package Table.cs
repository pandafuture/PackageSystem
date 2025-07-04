using System;  // ��� System ���ƿռ�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// CreateAssetMenu���ԣ�����Ҽ�ʱ�������� Unity �д���һ�������ļ�����������������һ���ǲ˵������ƣ���һ���Ǵ������ļ�������
[CreateAssetMenu(menuName = "Pandafuture/PackageData", fileName = "PackageTable")]
public class PackageTable : ScriptableObject  // �޸� PackageTable �ĸ���Ϊ ScriptableObject ����������ļ��е�ÿһ����Ǳ����е�һ������
{
    //ʹ��һ�� List ����������Ʒ
    public List<PackageTableItem> DataList = new List<PackageTableItem>();
}


// ��� Serializable Unity���ԣ��Ա������ Unity �б༭����Ҫ��� System ���ƿռ�
[System.Serializable]
// �����������Ʒ�����Ĳ���
public class PackageTableItem
{
    public int id;  // ��Ʒ��Ψһ��ʶID
    public int type;  // ��Ʒ�����ͣ�����/ʳ��ȵȣ�
    public int star;  // ��Ʒ���Ǽ�����
    public string name;  // ��Ʒ������
    public string description;  // ��Ʒ�ļ�����
    public string skillDescription;  // ��Ʒ����ϸ����
    public string imagePath;  // ��ƷͼƬ��·��
    public int num;  // ��Ʒ������
}