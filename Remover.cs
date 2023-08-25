using UnityEngine;

namespace VignetteRemover
{
    public class Remover
    {
        private static GameObject _vignetterObj;
        public void AutoDisable()
        {
            GameObject gameObject = GameObject.Find("Vignetter (Clone)");
            _vignetterObj = gameObject;
            if (Main.Enabled)
            {
                _vignetterObj.SetActive(false);
            }
        }
        public void Enable()
        {
            _vignetterObj.SetActive(true);
        }

        public void Disable()
        {
            _vignetterObj.SetActive(false);
        }
    }
}