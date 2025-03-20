using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Managers
{
    public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {

        private Vector3 localScaleButton;

        [FormerlySerializedAs("multiplicatorScale")] [SerializeField] private float AddScale;
        
        private void Start()
        {
            localScaleButton = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Vector3 scaleFutur = new Vector3(localScaleButton.x + AddScale, localScaleButton.y + AddScale);
            ReScale(scaleFutur);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ReScale(localScaleButton);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ReScale(localScaleButton);
        }

        private void ReScale(Vector3 targetVector3)
        {
            transform.localScale = targetVector3;
        }
    }
}
