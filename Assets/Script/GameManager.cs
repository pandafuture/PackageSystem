using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �Ȱ� GameManager ����Ϊ����ģʽ
    private static GameManager _instance;

    // ��̬����
    private PackageTable packageTable;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    // ��� Instance ���ԣ������ⲿ���ã�����Ϊ���У���������ݵĴ���
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }


    void Start()
    {
        // �����򿪱�������
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);  // ���� UIManager ʵ���д򿪽���ķ�����ͬʱ���� PackagePanel �������泣�������򿪱�������
    }


    // �Ծ�̬���ݴ���ķ���
    public PackageTable GetPackageTable()
    {
        // ʹ�� Unity �ṩ�� Resources.Load<> ȥ�������úõı������
        if(packageTable == null)  // ���Ѿ����ع����Ͳ����ظ����أ�ֱ��ʹ�û����е�����
        {
            packageTable = Resources.Load<PackageTable>("TableData/PackageTable");
        }
        return packageTable;
    }


    // �Զ�̬���ݼ��صķ���
    public List<PackageLocalItem> GetPackageLocalData()
    {
        return PackageLocalData.Instance.LoadPackage();  // ֱ�ӵ��� PackageLocalData ʵ���з�װ�õļ������ݵķ��� LoadPackage()
    }
    

    // ���� id ȡ������е�ָ�����ݵķ���
    public PackageTableItem GetPackageItemById(int id)
    {
        List<PackageTableItem> packageDataList = GetPackageTable().DataList;
        foreach(PackageTableItem item in packageDataList)
        {
            if(item.id == id)
            {
                return item;
            }
        }
        return null;
    }


    // ���� uid �ҵ����������ж�̬���ݵ�ָ����ķ���
    public PackageLocalItem GetPackageLocalItemByUId(string uid)
    {
        List<PackageLocalItem> packageDataList = GetPackageLocalData();
        foreach(PackageLocalItem item in packageDataList)
        {
            if(item.uid == uid)
            {
                return item;
            }
        }
        return null;
    }


    // ��ȡ������Ʒ�����Ա�����Ʒ����Ԥ���������������ȷ����ʾ���ȼ�
    public List<PackageLocalItem> GetSortPackageLocalData()
    {
        List<PackageLocalItem> localItems = PackageLocalData.Instance.LoadPackage();
        localItems.Sort(new PackageItemComparer());
        return localItems;
    }


}


// �����������
public class PackageItemComparer : IComparer<PackageLocalItem>
{
    public int Compare(PackageLocalItem a, PackageLocalItem b)
    {
        PackageTableItem x = GameManager.Instance.GetPackageItemById(a.id);
        PackageTableItem y = GameManager.Instance.GetPackageItemById(b.id);
        // ���Ȱ��� star �Ӵ�С����
        int starComparison = y.star.CompareTo(x.star);

        // ��� star ��ͬ���� id �Ӵ�С����
        if (starComparison == 0)
        {
            int idComparison = y.id.CompareTo(x.id);
            // ��� id ��ͬ���� level �Ӵ�С����
            if (idComparison == 0)
            {
                return b.level.CompareTo(a.level);
            }
            return idComparison;
        }
        return starComparison;
    }
}
