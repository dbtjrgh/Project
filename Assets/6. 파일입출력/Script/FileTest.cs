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


        // 이러면 비효율적이므로 X
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

            // 텍스트 파일을 출력할 경로(파일명, 확장자 포함)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData를 Json 문자열로 변환
            string json = JsonConvert.SerializeObject(data);  // JsonUtility.ToJson(data);
            // 파일 출력(경로, 내용);
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear();
        // Load
        string[] names = { "전사", "마법사" };

        // StreamingAsset 폴더 안에 있는 Json 파일을 모두 읽어서 
        // readfromJson 리스트에 Add 하시오.
        // 힌트 
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

            // 유효성 검사
            if (File.Exists(path))
            {
                // 파일로부터 Json 포맷으로 문자열을 가져옴
                string json = File.ReadAllText(path);
                // Json포맷의 데이터를 파싱하여 playerData인스턴스 생성 후 값 할당.

                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
    }

}
// 다른 형태로 데이터를 취급하기 위해 직렬화 과정이 필요함
[Serializable]
public class PlayerData // 데이터 호환성이 필요한 데이터 객체이기 떄문에 직렬화 함.
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

