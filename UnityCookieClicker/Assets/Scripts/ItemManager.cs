using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
	private const int MoviePostCostBase = 100;
	private const int BlogPostCostBase = 1000;
	private const int LiveCostBase = 10000;
	private const int EventAppearanceCostBase = 100000;
	private const int SponsorContractCostBase = 1000000;

	public static float CostUpRate = 10.0f;

	[SerializeField]
	public static int MoviePostNum;
	[SerializeField]
	public static int BlogPostNum;
	[SerializeField]
	public static int LiveNum;
	[SerializeField]
	public static int EventAppearanceNum;
	[SerializeField]
	public static int SponsorContractNum;

	public static int MoviePostCurrentCost;
	public static int BlogPostCurrentCost;
	public static int LiveCurrentCost;
	public static int EventAppearanceCurrentCost;
	public static int SponsorContractCurrentCost;

	public static int MoviePostIncreaseRate = 1;
	public static int BlogPostIncreaseRate = 10;
	public static int LiveIncreaseRate = 100;
	public static int EventAppearanceIncreaseRate = 1000;
	public static int SponsorContractIncreaseRate = 10000;

	// Use this for initialization
	void Start () {
		updateAllCurrentCost ();
	}

	public void updateAllCurrentCost () {
		updateMoviePostCurrentCost ();
		updateBlogPostCurrentCost ();
		updateLiveCurrentCost ();
		updateEventAppearancetCurrentCost ();
		updateSponsorContractCurrentCost ();
	}
	public void updateMoviePostCurrentCost () {
		MoviePostCurrentCost = calculatCost(Base:MoviePostCostBase, CurrentNum:MoviePostNum);
	}
	public void updateBlogPostCurrentCost () {
		BlogPostCurrentCost = calculatCost(Base:BlogPostCostBase, CurrentNum:BlogPostNum);
	}
	public void updateLiveCurrentCost () {
		LiveCurrentCost = calculatCost(Base:LiveCostBase, CurrentNum:LiveNum);
	}
	public void updateEventAppearancetCurrentCost () {
		EventAppearanceCurrentCost = 
			calculatCost(Base:EventAppearanceCostBase, CurrentNum:EventAppearanceNum);
	}
	public void updateSponsorContractCurrentCost () {
		SponsorContractCurrentCost =
			calculatCost(Base:SponsorContractCostBase, CurrentNum:SponsorContractNum);
	}
	public int calculatCost (int Base, int CurrentNum) {
		int cal = Mathf.FloorToInt(Base * ((CostUpRate + (float)CurrentNum) /CostUpRate));
		return cal;
	}
}