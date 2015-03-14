using ICities;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlienInvasion.Fleets;

namespace AlienInvasion
{
    namespace Empire
    {

        public class AlienEmpire
        {
            private List<AlienFleet> _fleets;

            public AlienEmpire()
            {
                _fleets = new List<AlienFleet>();
            }

            public List<AlienFleet> GetFleets()
            {
                return _fleets;
            }

            public void Tick(float deltaTime)
            {
                if(Input.GetKeyUp(KeyCode.K))
                {
                    AlienFleet newFleet = new AlienFleet();
                    for (int i = 0; i < 5; i++)
                    {
                        newFleet.CreateShip(ShipType.Fighter);
                    }
                    _fleets.Add(newFleet);
                }
            }
        }

        namespace ModGUI
        {
            public class EmpireGUI : MonoBehaviour
            {
                private Rect _fleetCountPos;
                private AlienEmpire _empire;

                public void SetEmpire(AlienEmpire empire)
                {
                    _empire = empire;
                }

                private void Start()
                {
                    _fleetCountPos = new Rect(185, 20, 150, 30);
                }

                private void OnGUI()
                {
                    GUI.Label(_fleetCountPos, "Fleets: " + FleetCount());
                    for (int i = 0; i < _empire.GetFleets().Count; i++)
                    {
                        AlienFleet _fleet = _empire.GetFleets()[i];
                        GUI.Label(new Rect(250, (30 + (15 * i)), 100, 45), "Ships: " + _fleet.ShipCount());
                    }
                }

                private int FleetCount()
                {
                    if (_empire != null)
                    {
                        return _empire.GetFleets().Count;
                    }
                    else
                    {
                        return 0;
                    }
                }

            }
        }
    }
}
