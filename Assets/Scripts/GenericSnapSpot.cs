using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSnapSpot : MonoBehaviour {

	private Vector3 snapPosition;
	private Quaternion snapRotation;


	void Start()
	{
		snapPosition = transform.position;
		snapRotation = transform.rotation;
	}

	public void SnapPlayer()
	{
		CharacterInputController.ToggleCharacterInput(false);

		PlayerManager.SetTransformData(snapPosition, snapRotation);
	}

	public void UnsnapPlayer()
	{
		CharacterInputController.ToggleCharacterInput(true);
	}
}
