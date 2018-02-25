using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserParameter : MonoBehaviour {

    public static ulong PlayerYaruki = 100;
    public static ulong PlayerYarukiBase = 1;
	public static ulong PlayerYarukiUpRate = 1;
	public static ulong PlayerYarukiGetQuantity = PlayerYarukiBase * PlayerYarukiUpRate;
	public static ulong Fan = 0;
	public static ulong Income = 0;

    // Use this for initialization
    void Start () {
		updateYarukiGetQuantity ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateYarukiGetQuantity () {
		PlayerYarukiGetQuantity = PlayerYarukiBase * PlayerYarukiUpRate;
	}

}
