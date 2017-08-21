using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRooms 
{
	private static BedRoom bedRoom = new BedRoom();
	private static KitchenRoom kitchenRoom = new KitchenRoom();
	private static OfficeRoom officeRoom = new OfficeRoom();
	private static StudyRoom studyRoom = new StudyRoom();
	private static WorkshopRoom workshopRoom = new WorkshopRoom();


	public static BedRoom GetBedRoom() { return bedRoom; }

	public void SetBedRoom(BedRoom room) { bedRoom = room; }

	public static int GetBedRoomTier() { return bedRoom.GetCurrentTier(); }

	public static void SetBedRoomTier(int newTier) { bedRoom.SetCurrentTier(newTier); }

	public static int GetBedRoomValue() { return bedRoom.GetTierValueAtIndex(bedRoom.GetCurrentTier() - 1); }


	public static KitchenRoom GetKitchenRoom() { return kitchenRoom; }

	public static void SetKitchenRoom(KitchenRoom room) { kitchenRoom = room; }

	public static int GetKitchenRoomTier() { return kitchenRoom.GetCurrentTier(); }

	public static void SetKitchenRoomTier(int newTier) { kitchenRoom.SetCurrentTier(newTier); }

	public static int GetKitchenRoomValue() { return kitchenRoom.GetTierValueAtIndex(kitchenRoom.GetCurrentTier() - 1); }

	
	public static OfficeRoom GetOfficeRoom() { return officeRoom; }

	public static void SetOfficeRoom(OfficeRoom room) { officeRoom = room; }

	public static int GetOfficeRoomTier() { return officeRoom.GetCurrentTier(); }

	public static void SetOfficeRoomTier(int newTier) { officeRoom.SetCurrentTier(newTier); }

	public static int GetOfficeRoomValue() { return officeRoom.GetTierValueAtIndex(officeRoom.GetCurrentTier() - 1); }


	public static StudyRoom GetStudyRoom() { return studyRoom; }

	public static void SetStudyRoom(StudyRoom room) { studyRoom = room; }

	public static int GetStudyRoomTier() { return studyRoom.GetCurrentTier(); }

	public static void SetStudyRoomTier(int newTier) { studyRoom.SetCurrentTier(newTier); }

	public static int GetStudyRoomValue() { return studyRoom.GetTierValueAtIndex(studyRoom.GetCurrentTier() - 1); }


	public static WorkshopRoom GetWorkshopRoom() { return workshopRoom; }

	public static void SetStudyRoom(WorkshopRoom room) { workshopRoom = room; }

	public static int GetWorkshopRoomTier() { return workshopRoom.GetCurrentTier(); }

	public static void SetWorkshopRoomTier(int newTier) { workshopRoom.SetCurrentTier(newTier); }

	public static int GetWorkshopRoomValue() { return workshopRoom.GetTierValueAtIndex(workshopRoom.GetCurrentTier() - 1); }
}
