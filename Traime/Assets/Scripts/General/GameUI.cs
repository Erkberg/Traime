using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Traime
{
    public class GameUI : MonoBehaviour
    {
        public ColorPaletteUI colorPalette;

        private void Start()
        {
            AdjustColors();
        }
        
        public void AdjustColors()
        {
            List<GameObject> rootObjects = SceneManager.GetActiveScene().GetRootGameObjects().ToList();
            List<ColoredUIElement> coloredUIElements = rootObjects.SelectMany(g => g.GetComponentsInChildren<ColoredUIElement>(true)).ToList();

            foreach (ColoredUIElement coloredUIElement in coloredUIElements)
            {
                switch (coloredUIElement.type)
                {
                    case ColoredUIElement.Type.None:
                        coloredUIElement.SetColor(Color.white);
                        break;
                    
                    case ColoredUIElement.Type.LightBackground:
                        coloredUIElement.SetColor(colorPalette.lightBackgroundColor);
                        break;
                    
                    case ColoredUIElement.Type.DarkBackground:
                        coloredUIElement.SetColor(colorPalette.darkBackgroundColor);
                        break;

                    case ColoredUIElement.Type.Foreground:
                        coloredUIElement.SetColor(colorPalette.foregroundColor);
                        break;

                    case ColoredUIElement.Type.Text:
                        coloredUIElement.SetColor(colorPalette.textColor);
                        break;
                    
                    default:
                        coloredUIElement.SetColor(Color.white);
                        break;
                }
            }
        }
    }
}

