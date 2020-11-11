using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Common.CommonData;

namespace Gameplay.Player
{
    public class CannonControl : MonoBehaviour
    {
        #region VARIABLES

        [Header("Setup")]
        public List<EarthCannon> cannons = new List<EarthCannon>();

        //Events
        public static event CustomEvent SelectArea_Event;

        #endregion

        #region UNITY EVENTS

        void Start()
        {
            SelectCannon(0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                SelectCannon(0);
            else if (Input.GetKeyDown(KeyCode.W))
                SelectCannon(1);
            else if (Input.GetKeyDown(KeyCode.E))
                SelectCannon(2);
            else if (Input.GetKeyDown(KeyCode.R))
                SelectCannon(3);
        }

        #endregion

        #region SETUP

        public void SelectCannon(int _index)
        {
            for(int i = 0; i < cannons.Count; i++)
                cannons[i].SelectCannon(false);

            cannons[_index].SelectCannon(true);
        }

        #endregion
    }
}