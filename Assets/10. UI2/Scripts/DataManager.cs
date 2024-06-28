using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 데이터를 참조하는 클레스
public class PlayerData2
{
	private int[] currencyArray =
		//Enum.GetValues : 열거형 타입 내의 요소 전부를 가져오는 함수
		new int[Enum.GetValues(typeof(CurrencyType)).Length];

	public int this[CurrencyType type]
	{
		get { return currencyArray[(int)type]; }
		set { currencyArray[(int)type] = value; }
	}
}

public class DataManager : MonoBehaviour
{
	public List<CurrencyData> currencyDataList;
	public UICurrencyList currencyList;
	public static DataManager Instance { get; private set; }

	public PlayerData2 playerData = new PlayerData2();

	public Action<CurrencyType, int> onCurrencyAmountChange; //delegate

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
        //foreach (CurrencyData currencyData in currencyDataList) {
        //	print(currencyData.currencyName);
        //}
        currencyList.Initialize();
	}

	public void AddCurrency(int param)
	{

		CurrencyType type = (CurrencyType)param;

		playerData[type]++;

		onCurrencyAmountChange?.Invoke(type, playerData[type]);

		print($"{type} 상승 : {playerData[type]}");

		//switch (type) {
		//	case CurrencyType.Coin:
		//		playerData[type]++;
		//		break;
		//	case CurrencyType.Food:
		//		break;
		//	case CurrencyType.Wood:
		//		break;
		//	case CurrencyType.Metal:
		//		break;
		//	case CurrencyType.Crystal:
		//		break;
		//	default:
		//		break;
		//}
	}

	// 응용
	public void AddCurrency(CurrencyType type, int amount)
    {

    }
}
