using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [CreateAssetMenu]
    public class ColorPaletteUI : ScriptableObject
    {
        public string id;

        public Color lightBackgroundColor;
        public Color darkBackgroundColor;
        public Color foregroundColor;
        public Color highlightColor;
        public Color textColor;
    }
}