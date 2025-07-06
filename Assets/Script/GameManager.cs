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
        // ����������������в���
        UIManager.Instance.OpenPanel(UIConst.MainPanel);

        // �������򿪳鿨������в���
        //UIManager.Instance.OpenPanel(UIConst.LotteryPanel);

        // �����򿪱�������
        //UIManager.Instance.OpenPanel(UIConst.PackagePanel);  // ���� UIManager ʵ���д򿪽���ķ�����ͬʱ���� PackagePanel �������泣�������򿪱�������
    }


    // ɾ�������Ʒ�ķ���
    // ɾ�������Ʒ�ķ���
    public void DeletePackageItems(List<string> uids)
    {
        foreach(string uid in uids)
        {
            DeletePackageItem(uid, false);
        }
        PackageLocalData.Instance.savePackage();
    }
    //ɾ��������Ʒ�ķ���
    public void DeletePackageItem(string uid, bool needSave = true)
    {
        PackageLocalItem packageLocalItem = GetPackageLocalItemByUId(uid);
        if (packageLocalItem == null)
            return;
        PackageLocalData.Instance.items.Remove(packageLocalItem);
        if (needSave)
        {
            PackageLocalData.Instance.savePackage();
        }
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
    

    // ������Ʒ���ͻ�ȡ���õı������
    // 1�������� 2��ʳ��
    public List<PackageTableItem> GetPackageTableByType(int type)
    {
        List<PackageTableItem> packageItems = new List<PackageTableItem>();
        foreach(PackageTableItem packageItem in GetPackageTable().DataList)
        {
            if(packageItem.type == type)
            {
                packageItems.Add(packageItem);
            }
        }
        return packageItems;
    }


    // �鿨�ľ����߼������飩
    public PackageLocalItem GetLotteryRandom1()
    {
        // ��ȡ���������ı������
        List<PackageTableItem> packageItems = GetPackageTableByType(GameConst.PackageTypeWeapon);
        // ���������ȡһ������
        int index = Random.Range(0, packageItems.Count);
        PackageTableItem packageItem = packageItems[index];
        // �����������ʼ��Ϊ��̬���ݣ���Ϊ���ս�����ظ����
        PackageLocalItem packageLocalItem = new()
        {
            uid = System.Guid.NewGuid().ToString(),
            id = packageItem.id,
            num = 1,
            level = 1,
            isNew = CheckWeaponIsNew(packageItem.id),
        };
        // �ѳ鵽�Ŀ����д浵���� PackageLocalData ���б��棬������ Json ��ʽ�洢�ڱ��ص��ı��ļ���
        PackageLocalData.Instance.items.Add(packageLocalItem);
        PackageLocalData.Instance.savePackage();
        return packageLocalItem;
    }

    // ʮ��
    public List<PackageLocalItem> GetLotteryDandom10(bool sort = false)
    {
        // ����鿨
        List<PackageLocalItem> packageLocalItems = new();
        for(int i = 0; i < 10; i++)
        {
            PackageLocalItem packageLocalItem = GetLotteryRandom1();
            packageLocalItems.Add(packageLocalItem);
        }
        // ��������
        if (sort)
        {
            packageLocalItems.Sort(new PackageItemComparer());
        }
        return packageLocalItems;
    }


    // �ж������ǲ����»�õ�
    public bool CheckWeaponIsNew(int id)
    {
        foreach(PackageLocalItem packageLocalItem in GetPackageLocalData())
        {
            if(packageLocalItem.id == id)
            {
                return false;
            }
        }
        return true;
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


// �洢��Ʒ���͵ĳ�����
public class GameConst
{
    // �������ͳ���
    public const int PackageTypeWeapon = 1;
    // ʳ�����ͳ���
    public const int PackageTypeFood = 2;
}
