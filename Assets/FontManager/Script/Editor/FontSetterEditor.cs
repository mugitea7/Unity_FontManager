using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Linq;
using UnityEngine;

namespace Mugitea.Fontmanager
{
    [CustomEditor(typeof(FontSetter))]
    [CanEditMultipleObjects]
    public class FontSetterEditor : Editor
    {
        private FontSetter fontSetter = null;

        private void Awake()
        {
            fontSetter = (FontSetter)target;
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            var obj = GameObject.FindGameObjectWithTag("FontManager");

            if (obj == null)
            {
                Debug.Log("There are no FontManager(FontmanagerがHierarchyに存在しません).", fontSetter);
                var fontManagerObj = (GameObject)Resources.Load("Prefab/FontManager");

                if (fontManagerObj != null)
                {
                    fontManagerObj = Instantiate(fontManagerObj);
                    fontManagerObj.name = "FontManager";
                    Debug.Log("Created FontManager.", fontSetter);

                    foreach (var target in targets.OfType<FontSetter>())
                    {
                        target.fontManager = fontManagerObj.GetComponent<FontManager>();
                    }
                }
                else
                    Debug.LogError("FontManager -> Resources -> FontManager.prefab is not found. please create FontManager.", fontSetter);

            }
            else
            {
                foreach (var target in targets.OfType<FontSetter>())
                {
                    target.fontManager = obj.GetComponent<FontManager>();
                }
            }

            List<string> labels = new List<string>();

            foreach (var font in fontSetter.fontManager.fonts)
            {
                labels.Add(font.typeName);
            }

            int index = EditorGUILayout.Popup("FontList", fontSetter.index, labels.ToArray());

            foreach (var target in targets.OfType<FontSetter>())
            {
                target.index = index;
                target.ChangeFont();
            }

            EditorApplication.QueuePlayerLoopUpdate();



            if (EditorGUI.EndChangeCheck())
            {
                var scene = SceneManager.GetActiveScene();
                EditorSceneManager.MarkSceneDirty(scene);
            }
        }
    }
}