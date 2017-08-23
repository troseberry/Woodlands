using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ContractGameInfo 
{
	private static ResourceQuantity payout;


	public static ResourceQuantity GetPayout() { return payout; }

	public static void SetPayout(ResourceQuantity newPayout ) { payout = newPayout; }

}
