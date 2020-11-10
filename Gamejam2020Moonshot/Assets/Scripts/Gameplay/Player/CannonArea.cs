using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Common.CommonData;

namespace Gameplay.Player
{
    public class CannonArea : MonoBehaviour
    {
        #region VARIABLES

        [Header("Setup")]
        public int id;

        //Private
        private SpriteRenderer sprite;
        private RectTransform rect;
        private BoxCollider2D collider;

        //Events
        public static event CustomEvent SelectArea_Event;

        #endregion

        #region UNITY EVENTS

        void Start()
        {
            StartCoroutine(Setup());
        }

        private void OnMouseEnter()
        {
            //ChangeColor(true);
            SelectArea_Event?.Invoke(new object[] { id, true });
        }

        private void OnMouseExit()
        {
            //ChangeColor(false);
            SelectArea_Event?.Invoke(new object[] { id, false });
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