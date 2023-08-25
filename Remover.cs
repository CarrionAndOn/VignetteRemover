using UnityEngine;

namespace VignetteRemover
{
    public class Remover
    {
        public static void Enable(GameObject _vignetteObj)
        {
            _vignetteObj.SetActive(true);
        }

        public static void Disable(GameObject _vignetteObj)
        {
            _vignetteObj.SetActive(false);
        }
    }
}