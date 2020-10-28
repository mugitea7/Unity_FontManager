using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Mugitea.Fontmanager
{
    [RequireComponent(typeof(Text))]
    [ExecuteAlways]
    public class FontSetter : MonoBehaviour
    {
        public FontManager fontManager;
        private Text text;
        public int index = 0;

        private void OnEnable()
        {
#if UNITY_EDITOR
            EditorApplication.update += ChangeFont;
#endif
        }

        private void OnDisable()
        {
#if UNITY_EDITOR
            EditorApplication.update -= ChangeFont;
#endif
        }

        public void ChangeFont()
        {
            if (text == null)
                text = GetComponent<Text>();

            if (text.font != fontManager.fonts[index].font)
                text.font = fontManager.fonts[index].font;
        }
    }
}