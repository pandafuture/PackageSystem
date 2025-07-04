using UnityEngine;
using System.Collections.Generic;

public class PackageLocalData
{
    // 为了使用方便，将其设置为单例模式
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


    // 使用 List 容器来缓存当前所有物品的动态信息
    public List<PackageLocalItem> items;

    // 存方法
    public void savePackage()
    {
        // 使用 Unity 提供的 JsonUtility 工具，把表格信息序列化为字符串
        string inventoryJson = JsonUtility.ToJson(this);
        // 使用 PlayerPrefs 把文本数据存储到本地的文件中，键名为 PackageLocalData
        PlayerPrefs.SetString("PackageLocalData", inventoryJson);
        PlayerPrefs.Save();
    }

    // 读取方法
    public List<PackageLocalItem> LoadPackage()
    {
        // 首先判断要缓存的数据是否已存在，若已存在，则说明之前已读取过文本信息，就直接返回 items
        if(items != null)
        {
            return items;
        }
        if (PlayerPrefs.HasKey("PackageLocalData"))  // 检查 PlayerPrefs 中是否有键名为 PackageLocalData 的文本数据，如果没有就从本地的文件中取读取
        {
            // 使用 PlayerPrefs 把本地的文件读取到内存中，使之成为字符串
            string inventoryJson = PlayerPrefs.GetString("PackageLocalData");
            // 使用 JsonUtility 来反序列化为 packageLocalData 再填充 items 列表
            PackageLocalData packageLocalData = JsonUtility.FromJson<PackageLocalData>(inventoryJson);
            items = packageLocalData.items;
            return items;
        }
        else // 如果 PlayerPrefs 中不存在 PackageLocalData 的文本数据，就创建新的空列表
        {
            items = new List<PackageLocalItem>();
            return items;
        }
    }
}


[System.Serializable]
// 背包表格中物品的动态存储的参数
public class PackageLocalItem
{
    public string uid;  // 唯一的标识符 uid
    public int id;  // 表示它是哪个物品
    public int num;  // 表示物品的数量
    public int level;  // 物品的等级
    public bool isNew;  // 是否为新获得的物品

    // 重写这个子类的 ToString() ，方便后续打印和调试
    public override string ToString()
    {
        return string.Format("[id]:{0} [num]:{1}", id, num);
    }
}