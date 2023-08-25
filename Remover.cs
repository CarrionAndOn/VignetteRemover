using UnityEngine;

namespace VignetteRemover
{
    public class Remover
    {
        public void Enable(GameObject VignetteObj)
        {
            VignetteObj.SetActive(true);
        }

        public void Disable(GameObject VignetteObj)
        {
            VignetteObj.SetActive(false);
        }
    }
}