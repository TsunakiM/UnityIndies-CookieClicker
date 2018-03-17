using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveGameExtension {
	public static class SaveGameEx {
		// PlayerPrefs Keys
		public const string KEY_YARUKI = "YARUKI";

		public const string KEY_FUN = "FUN";
		public const string KEY_INCOME = "INCOME";

		public const string KEY_MOVIE = "MOVIE_NUM";
		public const string KEY_BLOG = "BLOG_NUM";
		public const string KEY_LIVE = "LIVE_NUM";
		public const string KEY_EVENT = "EVENT_NUM";
		public const string KEY_SPONSOR = "SPONSOR_NUM";

		public static void SaveGameData () {
			PlayerPrefs.SetInt (KEY_YARUKI, UserParameter.PlayerYaruki);

			PlayerPrefs.SetInt (KEY_FUN, UserParameter.Fan);
			PlayerPrefs.SetInt (KEY_INCOME, UserParameter.Income);

			PlayerPrefs.SetInt (KEY_MOVIE, ItemManager.MoviePostNum);
			PlayerPrefs.SetInt (KEY_BLOG, ItemManager.BlogPostNum);
			PlayerPrefs.SetInt (KEY_LIVE, ItemManager.LiveNum);
			PlayerPrefs.SetInt (KEY_EVENT, ItemManager.EventAppearanceNum);
			PlayerPrefs.SetInt (KEY_SPONSOR, ItemManager.SponsorContractNum);
		}

		public static void LoadGameData () {
			UserParameter.PlayerYaruki = PlayerPrefs.GetInt (KEY_YARUKI, (int)100);

			UserParameter.Fan = PlayerPrefs.GetInt (KEY_FUN, (int)0);
			UserParameter.Income = PlayerPrefs.GetInt (KEY_INCOME, (int)0);

			ItemManager.MoviePostNum = PlayerPrefs.GetInt (KEY_MOVIE, (int)0);
			ItemManager.BlogPostNum = PlayerPrefs.GetInt (KEY_BLOG, (int)0);
			ItemManager.LiveNum = PlayerPrefs.GetInt (KEY_LIVE, 0);
			ItemManager.EventAppearanceNum = PlayerPrefs.GetInt(KEY_EVENT, (int)0);
			ItemManager.SponsorContractNum = PlayerPrefs.GetInt (KEY_SPONSOR, (int)0);
			Debug.Log("Load Success!");
		}	
	}
}
