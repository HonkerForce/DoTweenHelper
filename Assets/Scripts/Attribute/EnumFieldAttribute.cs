using UnityEditor;
using UnityEngine;

namespace DoTweenHelper.Attribute
{
	public class EnumFieldAttribute : PropertyAttribute
	{
		public bool isBinary { get; private set; }
		
		public EnumFieldAttribute(bool isBinaryEnum = true)
		{
			isBinary = isBinaryEnum;
		}
	}

	[CustomPropertyDrawer(typeof(EnumFieldAttribute))]
	public class EnumFieldAttributeDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var field = attribute as EnumFieldAttribute;
			if (field.isBinary)
			{
				property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
			}
		}
	}
}