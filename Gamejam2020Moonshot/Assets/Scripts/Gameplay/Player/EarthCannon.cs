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
        public float orbitSpeed;
        public float moveSpeed;

        [Header("Setup")]
        public GameObject joint;
        public SpriteRenderer cannon;

        //Private
        private bool selected = false;
        private float currentTime = 0;
        private float currentAngle = 0;

        #endregion

        #region UNITY EVENTS

        void Start()
        {
            Setup();
        }

        private void Update()
        {
            if(selected)
            {
                Vector2 _dir = Input.mousePosition - Camera.main.WorldToScreenPoint(joint.transform.position);
                currentAngle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
                RotateCannon(currentAngle, moveSpeed * Time.deltaTime);
            }
            else
            {
                currentAngle += orbitSpeed;
                RotateCannon(currentAngle);
            }
        }

        #endregion

        #region SETUP

        public void Setup()
        {
            currentAngle = 0;
            RotateCannon(currentAngle);
            SelectCannonDebug(false);
        }

        public void SelectCannon(bool _select)
        {
            selected = _select;
            SelectCannonDebug(selected);
        }

        public void RotateCannon(float _value, float _time = 0)
        {
            Quaternion _to = Quaternion.AngleAxis(_value, Vector3.forward);

            if (_time == 0)
                joint.transform.rotation = _to;
            else
                joint.transform.rotation = Quaternion.Slerp(joint.transform.rotation, _to, _time);
        }

        #endregion

        #region DEBUG

        public void SelectCannonDebug(bool _select)
        {
            cannon.color = _select ? Color.red : Color.white;
        }

        #endregion
    }
}