using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using SaveGameExtension;

public class ItemBtn : MonoBehaviour {
	public GameObject itemCostObject;
	public GameObject itemNumObject;
	public string objectTag;

	GameObject itemManager;
	GameObject itemListNowYaruki;
	bool canBuyItem;

	// Use this for initialization
	void Start () {
		itemManager = GameObject.Find("ItemManagerObject");
		itemListNowYaruki = GameObject.Find("TextNowYaruki");
		tagSet ();
	}
	
	// Update is called once per frame
	void Update () {
		// 表示が何故かバグるので、Update関数で処理
		refreshItemList ();
	}
	// アタッチされたボタンをタップしたときの挙動
	public void tapItemBtn () {
		addItemNum ();
		SaveGameEx.SaveGameData();
	}
	// アタッチしたボタンの表示更新
	void refreshText (int itemCost, int itemNum) {
		itemCostObject.GetComponent<Text> ().text = " " + itemCost.ToString("N0") + "Y";
		itemNumObject.GetComponent<Text> ().text = itemNum.ToString("N0") + " ";
		itemListNowYaruki.GetComponent<ItemListNowYaruki> ().refreshItemListYarukiText ();
	}
	// アタッチされているボタンのタグを取得
	void tagSet () {
		objectTag = this.gameObject.tag;
		if (objectTag == null) {
			Debug.Log("ERROR: ItemBtn.tagSet failed to find objectTag.");
		}
	}
	// 購入できるかどうかの判定
	void itemBuyProcessing (int needCost) {
		canBuyItem = true;
		if (UserParameter.PlayerYaruki < needCost) {
			canBuyItem = false;
			return;
		}
		UserParameter.PlayerYaruki -= needCost;
	}

	// タグで判定して処理分けする超絶よくない書き方。次回は設計段階から考えたい。
	// 各refreshTextは、SponsorContractが初回だけ正常に更新できないバグがあったため、暫定解決としてUpdate関数で都度呼ぶようにしてあります。
	void addItemNum () {
		switch (objectTag) {
			case "MoviePost":
				itemBuyProcessing(ItemManager.MoviePostCurrentCost);
				if (canBuyItem) {
					ItemManager.MoviePostNum++;
					UserParameter.PlayerYarukiBase += ItemManager.MoviePostIncreaseRate;
					itemManager.GetComponent<ItemManager> ().updateMoviePostCurrentCost();
					// refreshText(ItemManager.MoviePostCurrentCost, ItemManager.MoviePostNum);
				}
				break;
			case "BlogPost":
				itemBuyProcessing(ItemManager.BlogPostCurrentCost);
				if (canBuyItem) {
					ItemManager.BlogPostNum++;
					UserParameter.PlayerYarukiBase += ItemManager.BlogPostIncreaseRate;
					itemManager.GetComponent<ItemManager> ().updateBlogPostCurrentCost();
					// refreshText(ItemManager.BlogPostCurrentCost, ItemManager.BlogPostNum);
				}
				break;
			case "Live":
				itemBuyProcessing(ItemManager.LiveCurrentCost);
				if (canBuyItem) {
					ItemManager.LiveNum++;
					UserParameter.PlayerYarukiBase += ItemManager.LiveIncreaseRate;
					itemManager.GetComponent<ItemManager> ().updateLiveCurrentCost();
					// refreshText(ItemManager.LiveCurrentCost, ItemManager.LiveNum);
				}
				break;
			case "EventAppearancet":
				itemBuyProcessing(ItemManager.EventAppearanceCurrentCost);
				if (canBuyItem) {
					ItemManager.EventAppearanceNum++;
					UserParameter.PlayerYarukiBase += ItemManager.EventAppearanceIncreaseRate;
					itemManager.GetComponent<ItemManager> ().updateEventAppearancetCurrentCost();
					// refreshText(ItemManager.EventAppearanceCurrentCost, ItemManager.EventAppearanceNum);
				}
				break;
			case "SponsorContract":
				itemBuyProcessing(ItemManager.SponsorContractCurrentCost);
				if (canBuyItem) {
					ItemManager.SponsorContractNum++;
					UserParameter.PlayerYarukiBase += ItemManager.SponsorContractIncreaseRate;
					itemManager.GetComponent<ItemManager> ().updateSponsorContractCurrentCost();
					// refreshText(ItemManager.SponsorContractCurrentCost, ItemManager.SponsorContractNum);
				}
				break;
			default:
				Debug.Log("ERROR: ItemBtn.cs addItemNum method failure.");
				break;
		}
	}

	// 画面遷移をしたときの値リロード用
	void refreshItemList () {
		switch (objectTag) {
			case "MoviePost":
				refreshText(ItemManager.MoviePostCurrentCost, ItemManager.MoviePostNum);
				break;
			case "BlogPost":
				refreshText(ItemManager.BlogPostCurrentCost, ItemManager.BlogPostNum);
				break;
			case "Live":
				refreshText(ItemManager.LiveCurrentCost, ItemManager.LiveNum);
				break;
			case "EventAppearancet":
				refreshText(ItemManager.EventAppearanceCurrentCost, ItemManager.EventAppearanceNum);
				break;
			case "SponsorContract":
				refreshText(ItemManager.SponsorContractCurrentCost, ItemManager.SponsorContractNum);
				break;
			default:
				Debug.Log("ERROR: ItemBtn.cs refreshItemList method failure.");
				break;
		}

	}
}
