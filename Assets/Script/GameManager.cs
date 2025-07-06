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
        // 先主动打开主界面进行测试
        UIManager.Instance.OpenPanel(UIConst.MainPanel);

        // 先主动打开抽卡界面进行测试
        //UIManager.Instance.OpenPanel(UIConst.LotteryPanel);

        // 主动打开背包界面
        //UIManager.Instance.OpenPanel(UIConst.PackagePanel);  // 调用 UIManager 实例中打开界面的方法，同时传入 PackagePanel 背包界面常量名，打开背包界面
    }


    // 删除添加物品的方法
    // 删除多个物品的方法
    public void DeletePackageItems(List<string> uids)
    {
        foreach(string uid in uids)
        {
            DeletePackageItem(uid, false);
        }
        PackageLocalData.Instance.savePackage();
    }
    //删除单个物品的方法
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
    

    // 根据物品类型获取配置的表格数据
    // 1：武器， 2：食物
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


    // 抽卡的具体逻辑（单抽）
    public PackageLocalItem GetLotteryRandom1()
    {
        // 获取所有武器的表格数据
        List<PackageTableItem> packageItems = GetPackageTableByType(GameConst.PackageTypeWeapon);
        // 从中随机抽取一件武器
        int index = Random.Range(0, packageItems.Count);
        PackageTableItem packageItem = packageItems[index];
        // 把这个武器初始化为动态数据，作为最终结果返回给玩家
        PackageLocalItem packageLocalItem = new()
        {
            uid = System.Guid.NewGuid().ToString(),
            id = packageItem.id,
            num = 1,
            level = 1,
            isNew = CheckWeaponIsNew(packageItem.id),
        };
        // 把抽到的卡进行存档，用 PackageLocalData 进行保存，最终以 Json 格式存储在本地的文本文件中
        PackageLocalData.Instance.items.Add(packageLocalItem);
        PackageLocalData.Instance.savePackage();
        return packageLocalItem;
    }

    // 十抽
    public List<PackageLocalItem> GetLotteryDandom10(bool sort = false)
    {
        // 随机抽卡
        List<PackageLocalItem> packageLocalItems = new();
        for(int i = 0; i < 10; i++)
        {
            PackageLocalItem packageLocalItem = GetLotteryRandom1();
            packageLocalItems.Add(packageLocalItem);
        }
        // 武器排序
        if (sort)
        {
            packageLocalItems.Sort(new PackageItemComparer());
        }
        return packageLocalItems;
    }


    // 判断武器是不是新获得的
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


// 存储物品类型的常量表
public class GameConst
{
    // 武器类型常量
    public const int PackageTypeWeapon = 1;
    // 食物类型常量
    public const int PackageTypeFood = 2;
}
