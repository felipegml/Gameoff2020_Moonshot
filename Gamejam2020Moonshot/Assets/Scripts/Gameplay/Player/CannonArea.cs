using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Player
{
    public class CannonArea : MonoBehaviour
    {
        #region VARIABLES

        [Header("Setup")]
        public SpriteRenderer sprite;

        #endregion

        #region UNITY EVENTS

        void Start()
        {
            StartCoroutine(Setup());
        }

        #endregion

        #region SETUP

        private IEnumerator Setup()
        {
            RectTransform _rect = gameObject.GetComponent<RectTransform>();
            yield return new WaitForEndOfFrame();
            sprite.size = _rect.sizeDelta;
        }

        #endregion
    }
}