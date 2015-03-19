using System;
using AlienInvasion.Fleets;

namespace AlienInvasion
{
    namespace Ships
    {
        class WorkerShip : AlienShipBase
        {
            public WorkerShip(int shipIndex, int internalFleetIndex, int health, string pilotName, ShipType type, AlienFleet fleet)
                : base(shipIndex, internalFleetIndex, health, pilotName, type, fleet)
            {

            }
        }
    }
}
