using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject canvasGame;
	public GameObject fanScore;
	public GameObject incomeScore;
	public GameObject yarukiScore;
	private DateTime lastDateTime;
	private const int ADD_TIME = 3;

	int fanUpRate;
	int incomeUpRate;
	static float RateOfReturn = 0.05f;

	// Use this for initialization
	void Start () {
		lastDateTime = DateTime.UtcNow;
	}
	
	// Update is called once per frame
	void Update () {
		RefreshScoreText ();
		// 現在時刻から、最後にFanとIncomeを更新した時間を引くことで、差分の時間を求める
		TimeSpan timeSpan = DateTime.UtcNow - lastDateTime;

		if (timeSpan >= TimeSpan.FromSeconds (ADD_TIME)) {
			while (timeSpan >= TimeSpan.FromSeconds (ADD_TIME)) {
				updateFanAndIncome ();
				timeSpan -= TimeSpan.FromSeconds (ADD_TIME);
			}
		}
	}
	
	void updateFanAndIncome () {
		lastDateTime = DateTime.UtcNow;
		UserParameter.Fan += calculatFanUpRate ();
		UserParameter.Income += calculatIncomeUpRate ();
	}
	// Fan算出式
	int calculatFanUpRate () {
		double uprate;
		int sumItemNum = ItemManager.MoviePostNum + ItemManager.BlogPostNum + ItemManager.LiveNum + ItemManager.EventAppearanceNum + ItemManager.SponsorContractNum + 1; // 末尾の+1はゼロ除算防止用
		uprate = Math.Sqrt((UserParameter.PlayerYarukiGetQuantity / sumItemNum)) - 1;
		uprate = Math.Ceiling(uprate);
		return (int)uprate;
	}
	// Income算出式
	int calculatIncomeUpRate () {
		int uprate;
		uprate = Mathf.FloorToInt(UserParameter.Fan * RateOfReturn);
		return uprate;
	}
	// スコア表示のリフレッシュ
	public void RefreshScoreText () {
		fanScore.GetComponent<Text> ().text = ": " + UserParameter.Fan.ToString("N0");
		incomeScore.GetComponent<Text> ().text = ": " + UserParameter.Income.ToString("N0");
		yarukiScore.GetComponent<Text> ().text = "YARUKI:\n" + UserParameter.PlayerYaruki.ToString("N0");
	}
}
