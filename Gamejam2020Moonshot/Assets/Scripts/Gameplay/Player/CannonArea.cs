using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Player
{
    public class CannonArea : MonoBehaviour
    {
        #region VARIABLES

        //[Header("Setup")]
        private SpriteRenderer sprite;
        private RectTransform rect;
        private BoxCollider2D collider;

        #endregion

        #region UNITY EVENTS

        void Start()
        {
            StartCoroutine(Setup());
        }

        private void OnMouseEnter()
        {
            ChangeColor(true);
        }

        private void OnMouseExit()
        {
            ChangeColor(false);
        }

        #endregion

        #region SETUP

        private IEnumerator Setup()
        {
            sprite = gameObject.GetComponent<SpriteRenderer>();
            rect = gameObject.GetComponent<RectTransform>();
            collider = gameObject.GetComponent<BoxCollider2D>();

            yield return new WaitForEndOfFrame();
            sprite.size = rect.sizeDelta;
            collider.size = rect.sizeDelta;
        }

        #endregion

        #region DEBUG

        private void ChangeColor(bool _enter)
        {
            sprite.color = _enter ? Color.grey : Color.clear;
        }

        #endregion
    }
}