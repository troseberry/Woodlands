using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdditions
{
	private static CoffeeMakerAddition coffeeMakerAddition = new CoffeeMakerAddition();
	private static FireplaceAddition fireplaceAddition = new FireplaceAddition();
	private static FrontPorchAddition frontPorchAddition = new FrontPorchAddition();
	private static WoodworkingBenchAddition woodworkingBenchAddition = new WoodworkingBenchAddition();

	public static CoffeeMakerAddition GetCoffeeMakerAddition() { return coffeeMakerAddition; }
	public static void SetCoffeeMakerAddition(CoffeeMakerAddition addition) { coffeeMakerAddition = addition; }

	public static FireplaceAddition GetFireplaceAddition() { return fireplaceAddition; }
	public static void SetFireplaceAddition(FireplaceAddition addition) { fireplaceAddition = addition; }

	public static FrontPorchAddition GetFrontPorchAddition() { return frontPorchAddition; }
	public static void SetFrontPorchAddition(FrontPorchAddition addition) { frontPorchAddition = addition; }

	public static WoodworkingBenchAddition GetWoodworkingBenchAddition() { return woodworkingBenchAddition; }
	public static void SetWoodworkingBenchAddition(WoodworkingBenchAddition addition) { woodworkingBenchAddition = addition; }
}
