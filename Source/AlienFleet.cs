using ICities;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlienInvasion.Factories;

namespace AlienInvasion
{
    namespace Fleets
    {
        public class AlienFleet
        {
            private List<GameObject> _ships;
            private Factory _factory;


            public AlienFleet()
            {
                _ships = new List<GameObject>();
                _factory = new Factory(true);
            }

            public void CreateShip(ShipType type)
            {
                _ships.Add(_factory.CreateShip(type));
            }

            public int ShipCount()
            {
                if(_ships != null)
                {
                    return _ships.Count;
                }else
                {
                    return 0;
                }
            }
        }
    }
}
