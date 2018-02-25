using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
	private const uint MoviePostCostBase = 100;
	private const uint BlogPostCostBase = 1000;
	private const uint LiveCostBase = 10000;
	private const uint EventAppearanceCostBase = 100000;
	private const uint SponsorContractCostBase = 1000000;

	public static float CostUpRate = 10.0f;

	public static uint MoviePostNum = 0;
	public static uint BlogPostNum = 0;
	public static uint LiveNum = 0;
	public static uint EventAppearanceNum = 0;
	public static uint SponsorContractNum = 0;

	public static uint MoviePostCurrentCost;
	public static uint BlogPostCurrentCost;
	public static uint LiveCurrentCost;
	public static uint EventAppearanceCurrentCost;
	public static uint SponsorContractCurrentCost;

	public static uint MoviePostIncreaseRate = 1;
	public static uint BlogPostIncreaseRate = 10;
	public static uint LiveIncreaseRate = 100;
	public static uint EventAppearanceIncreaseRate = 1000;
	public static uint SponsorContractIncreaseRate = 10000;

	// Use this for initialization
	void Start () {
		updateAllCurrentCost ();	
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public uint calculatCost (uint Base, uint CurrentNum) {
		int cal = Mathf.FloorToInt(Base * ((CostUpRate + (float)CurrentNum) /CostUpRate));
		return (uint)cal;
	}
}