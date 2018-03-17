using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SaveGameExtension;

public class StartScenesManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		SaveGameEx.LoadGameData();
		afterLoadRefresh();
	}

	void afterLoadRefresh () {
		UserParameter.PlayerYarukiBase = 
			(ItemManager.MoviePostNum * ItemManager.MoviePostIncreaseRate) + 
			(ItemManager.BlogPostNum * ItemManager.BlogPostIncreaseRate) +
			(ItemManager.LiveNum * ItemManager.LiveIncreaseRate) +
			(ItemManager.EventAppearanceNum * ItemManager.EventAppearanceIncreaseRate) +
			(ItemManager.SponsorContractNum * ItemManager.SponsorContractIncreaseRate)
			+1 
			;
	}
}
