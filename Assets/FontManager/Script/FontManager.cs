using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mugitea.Fontmanager
{
    public class FontManager : MonoBehaviour
    {
        public List<FontList> fonts = new List<FontList>();
    }

    [Serializable]
    public class FontList
    {
        public string typeName;
        public Font font;
    }
}