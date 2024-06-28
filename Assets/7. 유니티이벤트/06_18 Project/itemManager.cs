using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject itemPrefab;
    public Transform content;
    public float textureScrollSpeed = 1.0f;

    [SerializeField]
    private List<Sprite> itemSprites;

    private Dictionary<string, Sprite> items = new Dictionary<string, Sprite>()
    {
        {"Item 1", null}
    };

    void Start()
    {
        // itemSprites 리스트의 크기 확인 및 유효성 검사
        if (itemSprites.Count > 1)
        {
            items.Add("Item 2", itemSprites[1]);
        }

        if (itemSprites.Count > 2)
        {
            items.Add("Item 3", itemSprites[2]);
        }

        //foreach (var item in items)
        //{
        //    GameObject newItem = Instantiate(itemPrefab, content);
        //    ItemUI itemUI = newItem.GetComponent<ItemUI>();
        //    itemUI.SetData(item.Key, item.Value);
        //}

        //scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
    }

    void OnScrollValueChanged(Vector2 scrollPosition)
    {
        float offsetY = scrollPosition.y * textureScrollSpeed;
    }
}
