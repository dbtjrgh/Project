using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyIndexer
{
	public int[] a = new int[10];
    public int this[int i]
    {
        get
        {
            return a[i];
        }
        set
        {
            a[i] = value;
        }
    }

    private string temp = string.Empty;
    public string this[string a]
    {
        get
        {
            if (a == "a")
            {
                return "apple";
            }
            if (a == "b")
            {
                return "boat";
            }
            return "";
        }
        set
        {
            if (a != "a" || a != "b")
            {
                temp = value;
            }
        }
    }


    public MyIndexer() 
    {
        for(int i = 0; i < a.Length; i++)
        {
            a[i] = i;
        }
    }
}

public class IndexerTest : MonoBehaviour
{
    private void Start()
    {
        MyIndexer myIndexer = new MyIndexer();

        print(myIndexer[0]); // 1

        print(myIndexer["a"]);
        myIndexer["abc"] = "abc";
        print(myIndexer["c"]);
    }
}
