using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 先把 GameManager 设置为单例模式
    private static GameManager _instance;

    // 静态数据
    private PackageTable packageTable;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    // 添加 Instance 属性，方便外部调用，设置为公有，方便对数据的处理
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }


    void Start()
    {
        // 主动打开背包界面
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);  // 调用 UIManager 实例中打开界面的方法，同时传入 PackagePanel 背包界面常量名，打开背包界面
    }


    // 对静态数据处理的方法
    public PackageTable GetPackageTable()
    {
        // 使用 Unity 提供的 Resources.Load<> 去加载配置好的表格数据
        if(packageTable == null)  // 若已经加载过，就不用重复加载，直接使用缓存中的数据
        {
            packageTable = Resources.Load<PackageTable>("TableData/PackageTable");
        }
        return packageTable;
    }


    // 对动态数据加载的方法
    public List<PackageLocalItem> GetPackageLocalData()
    {
        return PackageLocalData.Instance.LoadPackage();  // 直接调用 PackageLocalData 实例中封装好的加载数据的方法 LoadPackage()
    }
    

    // 根据 id 取到表格中的指定数据的方法
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


    // 根据 uid 找到本地数据中动态数据的指定项的方法
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


    // 获取背包物品，并对背包物品按照预定规则进行排序，以确定显示优先级
    public List<PackageLocalItem> GetSortPackageLocalData()
    {
        List<PackageLocalItem> localItems = PackageLocalData.Instance.LoadPackage();
        localItems.Sort(new PackageItemComparer());
        return localItems;
    }


}


// 定义排序规则
public class PackageItemComparer : IComparer<PackageLocalItem>
{
    public int Compare(PackageLocalItem a, PackageLocalItem b)
    {
        PackageTableItem x = GameManager.Instance.GetPackageItemById(a.id);
        PackageTableItem y = GameManager.Instance.GetPackageItemById(b.id);
        // 首先按照 star 从大到小排序
        int starComparison = y.star.CompareTo(x.star);

        // 如果 star 相同，则按 id 从大到小排序
        if (starComparison == 0)
        {
            int idComparison = y.id.CompareTo(x.id);
            // 如果 id 相同，则按 level 从大到小排序
            if (idComparison == 0)
            {
                return b.level.CompareTo(a.level);
            }
            return idComparison;
        }
        return starComparison;
    }
}
