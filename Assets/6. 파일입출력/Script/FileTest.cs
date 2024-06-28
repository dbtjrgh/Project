using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class FileTest : MonoBehaviour
{
    // public PlayerData playerData;

	public Text text;

    public List<PlayerData> playerDatas;
    public List<PlayerData> readFromJson = new List<PlayerData>();

    private void Start()
    {
        // text.text = "Hello World!";

        StringBuilder sb = new StringBuilder();

        sb.Append("Data Path : ");
        sb.AppendLine(Application.dataPath);
        sb.Append("Pers data path : ");
        sb.AppendLine(Application.persistentDataPath);
        sb.Append("Str data path : ");
        sb.AppendLine(Application.streamingAssetsPath);


        // �̷��� ��ȿ�����̹Ƿ� X
        //string path = Application.dataPath; 
        //path += "\n";
        //path += Application.persistentDataPath;
        //path += "\n";
        //path += Application.streamingAssetsPath;

        text.text = sb.ToString();

        

        // print(JsonUtility.ToJson(new PlayerData()));
        // print(JsonUtility.ToJson(new SkillData()));
    }

    public void Save()
    {
        // Save
        foreach (PlayerData data in playerDatas)
        {
            print(JsonUtility.ToJson(data));

            // �ؽ�Ʈ ������ ����� ���(���ϸ�, Ȯ���� ����)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData�� Json ���ڿ��� ��ȯ
            string json = JsonConvert.SerializeObject(data);  // JsonUtility.ToJson(data);
            // ���� ���(���, ����);
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear();
        // Load
        string[] names = { "����", "������" };

        // StreamingAsset ���� �ȿ� �ִ� Json ������ ��� �о 
        // readfromJson ����Ʈ�� Add �Ͻÿ�.
        // ��Ʈ 
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);
        FileInfo[] files = di.GetFiles("*.json");

        foreach (FileInfo file in files)
        {
            string jsonContent = File.ReadAllText(file.FullName);
            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonContent);
            readFromJson.Add(data);
        }


        foreach (PlayerData data in readFromJson)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.Json";

            // ��ȿ�� �˻�
            if (File.Exists(path))
            {
                // ���Ϸκ��� Json �������� ���ڿ��� ������
                string json = File.ReadAllText(path);
                // Json������ �����͸� �Ľ��Ͽ� playerData�ν��Ͻ� ���� �� �� �Ҵ�.

                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
    }

}
// �ٸ� ���·� �����͸� ����ϱ� ���� ����ȭ ������ �ʿ���
[Serializable]
public class PlayerData // ������ ȣȯ���� �ʿ��� ������ ��ü�̱� ������ ����ȭ ��.
{
    public string name;
    public float exp;
    public int level;
    public int hp;
    public int attack;
    public int[] items;
    public List<SkillData> skills;
}

[Serializable]
public class SkillData
{
    public int id;
    public int level;
    public UpgradeType upgrade;
}

public enum UpgradeType
{
    Attack,
    Defence,
    Speed,
    HP
}

