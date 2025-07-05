using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �糡����ȫ�� UI ������
public class UIManager
{
    // ���Ƚ� UIManager ����Ϊ����ģʽ
    private static UIManager _instance;

    // �κν��涼��Ҫһ�����Թ��صĵط����ѹ��صĸ��ڵ��Ϊ uiRoot ���� UI ���ĸ��ڵ�
    private Transform _uiRoot;

    // ������ϵ���ñ����ֵ����洢
    private Dictionary<string, string> pathDict;

    // Ԥ�Ƽ������ֵ�
    private Dictionary<string, GameObject> prefabDict;

    // ���滺���ֵ䣬�洢��ǰ�Ѵ򿪵Ľ���
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


    // ���� UI ���ڵ� uiRoot
    public Transform UIRoot
    {
        get
        {
            if(_uiRoot == null)
            {
                if (GameObject.Find("Canvas"))
                {
                    _uiRoot = GameObject.Find("Canvas").transform;  // �ѻ��� Canvas ��Ϊ���ڵ�
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
        InitDicts();  // �����ֵ��ʼ������
    }


    // ��ʼ���ֵ�
    private void InitDicts()
    {
        // ��ʼ��Ԥ�Ƽ��ֵ�
        prefabDict = new Dictionary<string, GameObject>();
        // ��ʼ�����滺���ֵ�
        panelDict = new Dictionary<string, BasePanel>();
        // �ѽ���·�����õ���ӳ���ϵ���ֵ���
        pathDict = new Dictionary<string, string>()
        {
            // ���� PackagePanel ��Ӧ��·��
            {UIConst.PackagePanel, "Package/PackagePanel" },
        };
    }


    public BasePanel GetPanel(string name)
    {
        BasePanel panel = null;
        // ����Ƿ��Ѵ�
        if(panelDict.TryGetValue(name, out panel))
        {
            return panel;
        }
        return null;
    }


    // ���ڴ򿪽���
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        // ���ȼ����������Ƿ����
        if(panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("�����Ѵ򿪣�" + name);
            return null;
        }

        // ���·���Ƿ�������
        string path = "";
        if(!pathDict.TryGetValue(name, out path))
        {
            Debug.Log("�������ƴ��󣬻���δ����·����" + name);
            return null;
        }

        // ����ʹ�û���Ľ���Ԥ�Ƽ�
        GameObject panelPrefab = null;
        // ����Ԥ�Ƽ������ֵ��в鿴���Ƿ�֮ǰ�ѱ����ع�����������ع��˾�ֱ��������
        if(!prefabDict.TryGetValue(name, out panelPrefab))
        {
            // ���û�б����ع����Ͱ������س������ҷ��ڻ����ֵ���
            string realPath = "Prefab/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }

        // �򿪽���
        // ��Ԥ�Ƽ����س������������� UIRoot �£�ʹ���Ϊ UIRoot ��һ���ӽڵ�
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        // ������ӵ� panelDict �У���ʾ��������Ѿ�����
        panelDict.Add(name, panel);
        panel.OpenPanel(name);
        return panel;
    }

    // ���ڹرս���
    public bool ClosePanel(string name)
    {
        BasePanel panel = null;

        // �����������Ƿ��� panelDict ��
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("����δ�򿪣�" + name);
            return false;
        }

        // ��������Ѿ��򿪣���ִ���������� ClosePanel()
        panel.ClosePanel();
        return true;
    }
}


// �洢�������Ƶĳ�����
public class UIConst
{
    // ���� PackagePanel ����
    public const string PackagePanel = "PackagePanel";
}
