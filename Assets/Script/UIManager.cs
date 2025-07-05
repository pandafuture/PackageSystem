using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 跨场景的全局 UI 管理器
public class UIManager
{
    // 首先将 UIManager 设置为单例模式
    private static UIManager _instance;

    // 任何界面都需要一个可以挂载的地方，把挂载的根节点称为 uiRoot ，即 UI 最顶层的父节点
    private Transform _uiRoot;

    // 搭建界面关系配置表，用字典来存储
    private Dictionary<string, string> pathDict;

    // 预制件缓存字典
    private Dictionary<string, GameObject> prefabDict;

    // 界面缓存字典，存储当前已打开的界面
    public Dictionary<string, BasePanel> panelDict;

    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }


    // 设置 UI 根节点 uiRoot
    public Transform UIRoot
    {
        get
        {
            if(_uiRoot == null)
            {
                if (GameObject.Find("Canvas"))
                {
                    _uiRoot = GameObject.Find("Canvas").transform;  // 把画布 Canvas 作为根节点
                }
                else
                {
                    _uiRoot = new GameObject("Canvas").transform;
                }
            }
            return _uiRoot;
        }
    }


    private UIManager()
    {
        InitDicts();  // 调用字典初始化方法
    }


    // 初始化字典
    private void InitDicts()
    {
        // 初始化预制件字典
        prefabDict = new Dictionary<string, GameObject>();
        // 初始化界面缓存字典
        panelDict = new Dictionary<string, BasePanel>();
        // 把界面路径配置到这映射关系的字典中
        pathDict = new Dictionary<string, string>()
        {
            // 配置 PackagePanel 对应的路径
            {UIConst.PackagePanel, "Package/PackagePanel" },
        };
    }


    public BasePanel GetPanel(string name)
    {
        BasePanel panel = null;
        // 检查是否已打开
        if(panelDict.TryGetValue(name, out panel))
        {
            return panel;
        }
        return null;
    }


    // 用于打开界面
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        // 首先检查这个界面是否打开了
        if(panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("界面已打开：" + name);
            return null;
        }

        // 检查路径是否有配置
        string path = "";
        if(!pathDict.TryGetValue(name, out path))
        {
            Debug.Log("界面名称错误，或者未配置路径：" + name);
            return null;
        }

        // 加载使用缓存的界面预制件
        GameObject panelPrefab = null;
        // 先在预制件缓存字典中查看，是否之前已被加载过，如果被加载过了就直接拿来用
        if(!prefabDict.TryGetValue(name, out panelPrefab))
        {
            // 如果没有被加载过，就把他加载出来并且放在缓存字典中
            string realPath = "Prefab/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }

        // 打开界面
        // 把预制件加载出来，并挂载在 UIRoot 下，使其成为 UIRoot 的一个子节点
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        // 把它添加到 panelDict 中，表示这个界面已经打开了
        panelDict.Add(name, panel);
        panel.OpenPanel(name);
        return panel;
    }

    // 用于关闭界面
    public bool ClosePanel(string name)
    {
        BasePanel panel = null;

        // 检查这个界面是否在 panelDict 中
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("界面未打开：" + name);
            return false;
        }

        // 如果界面已经打开，则执行这个界面的 ClosePanel()
        panel.ClosePanel();
        return true;
    }
}


// 存储界面名称的常量表
public class UIConst
{
    // 新增 PackagePanel 常量
    public const string PackagePanel = "PackagePanel";
}
