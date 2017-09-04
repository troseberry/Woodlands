using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ContractGameInfo 
{
	private static DevResourceQuantity payout;


	public static DevResourceQuantity GetPayout() { return payout; }

	public static void SetPayout(DevResourceQuantity newPayout ) { payout = newPayout; }

}
