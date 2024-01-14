using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CharacterProperties))]
    public class CharacterPropertiesCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            CharacterProperties properties = (CharacterProperties)target;

            RangeField("Speed", ref properties.minSpeed, ref properties.maxSpeed);
            RangeField("Stamina", ref properties.minStamina, ref properties.maxStamina);
            RangeField("Maneuverability", ref properties.minManeuverability, ref properties.maxManeuverability);
        }

        #region Tools

        private void RangeField(string fieldName, ref float minValue, ref float maxValue)
        {
            EditorGUILayout.LabelField(fieldName, EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Min", GUILayout.Width(30));
            minValue = EditorGUILayout.FloatField(minValue, GUILayout.Width(50));
            EditorGUILayout.LabelField("Max", GUILayout.Width(30));
            maxValue = EditorGUILayout.FloatField(maxValue, GUILayout.Width(50));
            EditorGUILayout.EndHorizontal();
            DrawLine();
        }
    
        private void DrawLine()
        {
            EditorGUILayout.Space();
            var rect = EditorGUILayout.BeginHorizontal();
            Handles.color = Color.gray;
            Handles.DrawLine(new Vector2(rect.x - 15, rect.y), new Vector2(rect.width + 15, rect.y));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }

        #endregion
    }
}
