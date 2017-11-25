using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(TestQuantity))]
public class TestQuantityDrawer : PropertyDrawer 
{
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
		return Screen.width < 500 ? (16f + 18f) : 16f;
        // return 100;
        // return Screen.width < 333 ? (16f + 18f) : 75f;
	}

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
		label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
        // EditorGUIUtility.labelWidth = 40f;


        // Rect treesRect = new Rect(position.x, position.y, 100, 15);
        // Rect treeGradeRect = new Rect(position.x + 100, position.y, 100, 15);
        // Rect logsRect = new Rect(position.x, position.y + 25, 100, 15);
        // Rect logGradeRect = new Rect(position.x + 100, position.y + 25, 100, 15);
        // Rect firewoodRect = new Rect(position.x, position.y + 50, 100, 15);
        // Rect firewoodGradeRect = new Rect(position.x + 100, position.y + 50, 100, 15);
        
		// EditorGUI.PropertyField(treesRect, property.FindPropertyRelative("trees"), new GUIContent("Trees"));
		// EditorGUI.PropertyField(treeGradeRect, property.FindPropertyRelative("treeGrade"), new GUIContent("Grade"));

        // EditorGUI.PropertyField(logsRect, property.FindPropertyRelative("logs"), new GUIContent("Logs"));
		// EditorGUI.PropertyField(logGradeRect, property.FindPropertyRelative("logGrade"), new GUIContent("Grade"));

        // EditorGUI.PropertyField(firewoodRect, property.FindPropertyRelative("firewood"), new GUIContent("Firewood"));
		// EditorGUI.PropertyField(firewoodGradeRect, property.FindPropertyRelative("firewoodGrade"), new GUIContent("Grade"));


        

        Rect treesRect = new Rect(position.x, position.y, 50, 15);
        Rect logsRect = new Rect(position.x + 50, position.y, 50, 15);
        Rect firewoodRect = new Rect(position.x + 100, position.y, 50, 15);

        Rect treeGradeRect = new Rect(position.x + 150, position.y, 50, 15);
        Rect logGradeRect = new Rect(position.x + 200, position.y, 50, 15);
        Rect firewoodGradeRect = new Rect(position.x + 250, position.y, 50, 15);

        if (position.height > 16f) {
			position.height = 16f;
			// EditorGUI.indentLevel += 1;

			treeGradeRect = EditorGUI.IndentedRect(position);
            // treeGradeRect.x += 50f;
			treeGradeRect.y += 18f;

            logGradeRect = EditorGUI.IndentedRect(position);
            logGradeRect.x += 50f;
			logGradeRect.y += 18f;

            firewoodGradeRect = EditorGUI.IndentedRect(position);
            firewoodGradeRect.x += 100f;
			firewoodGradeRect.y += 18f;
		}
        
        EditorGUIUtility.labelWidth = 50f;
		EditorGUI.PropertyField(treesRect, property.FindPropertyRelative("trees"), GUIContent.none);
        EditorGUI.PropertyField(logsRect, property.FindPropertyRelative("logs"), GUIContent.none);
        EditorGUI.PropertyField(firewoodRect, property.FindPropertyRelative("firewood"), GUIContent.none);

		EditorGUI.PropertyField(treeGradeRect, property.FindPropertyRelative("treeGrade"), GUIContent.none);
		EditorGUI.PropertyField(logGradeRect, property.FindPropertyRelative("logGrade"), GUIContent.none);
		EditorGUI.PropertyField(firewoodGradeRect, property.FindPropertyRelative("firewoodGrade"), GUIContent.none);
        

        EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}
}