using UnityEngine;
using MelonLoader;
using SLZ.Rig;

namespace VignetteRemover
{
    public class Remover
    {
        private Transform _vignetteObj;
        private Transform _openControllerRig;
        private Transform _trackingSpace;
        private Transform _head;
        private RigManager _rigManager;
        public void AutoDisable()
        {
            if (Main.Enabled)
            {
                _rigManager = BoneLib.Player.rigManager;
                _openControllerRig = _rigManager.transform.Find("[OpenControllerRig]");
                _trackingSpace = _openControllerRig.transform.Find("TrackingSpace");
                _head = _trackingSpace.transform.Find("Head");
                _vignetteObj = _head.transform.Find("Vignetter (Clone)");
                _vignetteObj.gameObject.SetActive(false);
            }
        }
        public void Enable()
        {
            _rigManager = BoneLib.Player.rigManager;
            _openControllerRig = _rigManager.transform.Find("[OpenControllerRig]");
            _trackingSpace = _openControllerRig.transform.Find("TrackingSpace");
            _head = _trackingSpace.transform.Find("Head");
            _vignetteObj = _head.transform.Find("Vignetter (Clone)");
            _vignetteObj.gameObject.SetActive(true);
        }

        public void Disable()
        {
            _rigManager = BoneLib.Player.rigManager;
            _openControllerRig = _rigManager.transform.Find("[OpenControllerRig]");
            _trackingSpace = _openControllerRig.transform.Find("TrackingSpace");
            _head = _trackingSpace.transform.Find("Head");
            _vignetteObj = _head.transform.Find("Vignetter (Clone)");
            _vignetteObj.gameObject.SetActive(false);
        }
    }
}