using ICities;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlienInvasion.Factories;
using AlienInvasion.Ships;

namespace AlienInvasion
{
    namespace Fleets
    {
        public class AlienFleet
        {
            private List<GameObject> _ships;
            private Factory _factory;
            private Vector3 _spawnPoint;

            public AlienFleet()
            {
                _ships = new List<GameObject>();
                _factory = new Factory(true);
            }

            public void CreateShip(ShipType type)
            {
                _ships.Add(_factory.CreateShip(type));
            }

            public int ShipCount
            {
                get
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

            public AlienShipBase FleetCaptain
            {
                get
                {
                    if(_ships.Count >= 1)
                    {
                        return _ships[0];
                    }
                    else
                    {
                        //print(warning, no ship captain found)
                        return null;
                    }
                }
            }

            public Vector3 SpawnPoint
            {
                get
                {
                    return _spawnPoint;
                }
                set
                {
                    _spawnPoint = value;
                }
            }
        }
    }
}
