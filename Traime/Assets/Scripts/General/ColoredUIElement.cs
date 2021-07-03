using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Traime
{
    public class ColoredUIElement : MonoBehaviour
    {
        public Type type;
        public Graphic graphic;

        private void Reset()
        {
            graphic = GetComponent<Graphic>();
        }

        public void SetColor(Color color)
        {
            graphic.color = color;
        }

        public enum Type
        {
            None,
            LightBackground,
            DarkBackground,
            Foreground,
            Highlight,
            Text
        }
    }
}