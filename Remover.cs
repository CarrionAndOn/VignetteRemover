using UnityEngine;

namespace VignetteRemover
{
    public class Remover
    {
        private static GameObject _vignetterObj;
        public static void AutoDisable()
        {
            GameObject gameObject = GameObject.Find("Vignetter (Clone)");
            _vignetterObj = gameObject;
            if (Main.Enabled)
            {
                _vignetterObj.SetActive(false);
            }
        }
        public static void Enable()
        {
            _vignetterObj.SetActive(true);
        }

        public static void Disable()
        {
            _vignetterObj.SetActive(false);
        }
    }
}