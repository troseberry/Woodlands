using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInteract : MonoBehaviour 
{
	private bool canInteract = false;

	public int addAmount;
	public int removeAmount;
	public int setAmount;

	void Update()
	{
		if (Input.GetButtonDown("Interact") && canInteract) 
		{
			Debug.Log("Interacted");
			Debug.Log(transform.parent.gameObject.name);
			Debug.Log(gameObject.name);

			if (transform.parent.gameObject.name == "CurrencyTestObjects")
			{
				if (gameObject.name == "Add")
				{
					PlayerInventory.UpdateCurrencyValue(addAmount);
				}
				else if (gameObject.name == "Remove")
				{
					PlayerInventory.UpdateCurrencyValue(removeAmount);
				}
				else if (gameObject.name == "Set")
				{
					PlayerInventory.SetCurrencyValue(setAmount);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Player Entered");
			canInteract = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			canInteract = false;
		}
	}
}
