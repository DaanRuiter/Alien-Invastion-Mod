using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlienInvasion.Fleets;

namespace AlienInvasion
{
    public enum ShipType
    {
        Worker,
        Fighter,
        Frigate,
        Cruiser,
        Destroyer,
        Mothership
    }

    namespace Ships
    {
        abstract class AlienShipBase : MonoBehaviour
        {
            protected int shipIndex;
            protected int internalFleetIndex;
            protected int health;
            protected string pilotName;
            protected ShipType type;
            protected AlienFleet fleet;

            public AlienShipBase(int shipIndex, int internalFleetIndex, int health, string pilotName, ShipType type, AlienFleet fleet)
            {
                this.shipIndex = shipIndex;
                this.internalFleetIndex = internalFleetIndex;
                this.health = health;
                this.pilotName = pilotName;
                this.type = type;
                this.fleet = fleet;
            }

            public AlienFleet Fleet
            {
                get
                {
                    return fleet;
                }
            }

            public ShipType Type
            {
                get
                {
                    return type;
                }
            }

            public string PilotName
            {
                get
                {
                    return pilotName;
                }
                set
                {
                    pilotName = value;
                }
            }

            public int Health
            {
                get
                {
                    return health;
                }
                set
                {
                    health = value;
                }
            }

            public int InternalFleetIndex
            {
                get 
                {
                    return internalFleetIndex;
                }
                set
                {
                    internalFleetIndex = value;
                }
            }

            public int ShipIndex
            {
                get
                {
                    return shipIndex;
                }
                set
                {
                    shipIndex = value;
                }
            }
        }
    }        
}
