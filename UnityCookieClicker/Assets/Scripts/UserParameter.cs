using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserParameter : MonoBehaviour {
    
	public static int PlayerYaruki;
	public static int PlayerYarukiBase;
	public static int PlayerYarukiUpRate = 1;
	public static int PlayerYarukiGetQuantity = PlayerYarukiBase * PlayerYarukiUpRate;
	public static int Fan, Income;
	
    void Start () {
		updateYarukiGetQuantity ();
	}

	public void updateYarukiGetQuantity () {
		PlayerYarukiGetQuantity = PlayerYarukiBase * PlayerYarukiUpRate;
	}

}
