using System;
using UnityEngine;

namespace AlienInvasion
{
    namespace Ships
    {
        class ShipComponent : MonoBehaviour
        {
            private AlienShipBase _shipBase;

            public void SetShipBase(Type baseClass)
            {
                _shipBase = (AlienShipBase)Activator.CreateInstance(baseClass.BaseType);
            }

            public AlienShipBase ShipBase
            {
                get
                {
                    if(_shipBase != null)
                    {
                        return _shipBase;
                    }
                    else
                    {
                        //print(this objects base has not been set or it has been destroyed. This warning should never show up.)
                        return null;
                    }
                }
            }
        }
    }
}
