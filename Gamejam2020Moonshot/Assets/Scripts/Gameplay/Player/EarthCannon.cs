using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Player
{
    public class EarthCannon : MonoBehaviour
    {
        #region VARIABLES

        [Header("Data")]
        public int id;
        public Vector2 angleLimit;

        [Header("Setup")]
        public GameObject joint;
        public SpriteRenderer cannon;

        //Private
        private bool selected = false;

        #endregion

        #region UNITY EVENTS

        void Start()
        {
            Setup();

            //Add Events
            CannonArea.SelectArea_Event += CannonArea_SelectArea_Event;
        }

        private void OnDestroy()
        {
            //Remove Events
            CannonArea.SelectArea_Event -= CannonArea_SelectArea_Event;
        }

        private void Update()
        {
            if(selected)
            {
                Vector2 _dir = Input.mousePosition - Camera.main.WorldToScreenPoint(joint.transform.position);
                float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
                RotateCannon(_angle);
            }
        }

        #endregion

        #region EVENTS

        private void CannonArea_SelectArea_Event(object[] obj = null)
        {
            if ((int)obj[0] == id)
            {
                selected = (bool)obj[1];
                SelectCannon(selected);
            }
        }

        #endregion

        #region SETUP

        public void Setup()
        {
            joint.transform.localRotation = Quaternion.Euler(0, 0, 0);
            SelectCannon(false);
        }

        public void RotateCannon(float _value)
        {
            //if(_value > angleLimit.x && _value < angleLimit.y)
            joint.transform.rotation = Quaternion.AngleAxis(_value, Vector3.forward);
        }

        #endregion

        #region DEBUG

        public void SelectCannon(bool _select)
        {
            cannon.color = _select ? Color.red : Color.white;
        }

        #endregion
    }
}