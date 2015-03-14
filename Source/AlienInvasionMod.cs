using ICities;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlienInvasion.Fleets;
using AlienInvasion.Empire.ModGUI;
using AlienInvasion.Empire;

namespace AlienInvasion
{
    namespace Main
    {
        public class AlienInvasionMain : IUserMod
        {
            public string Name
            {
                get { return "Alien Invasion"; }
            }
            public string Description
            {
                get { return "Protect your city against the Alien Empire by doing their quests or by destroying their fleets. By: Chequered."; }
            }
        }

        public class AlienInvasionSetup : IThreadingExtension
        {
            private AlienInvasionMod _mod;
            private float _simulationTimeDelta;
            private GameObject gameObject;

            #region RequiredMethods
            public void OnBeforeSimulationTick() { }
            public void OnAfterSimulationFrame() { }
            public void OnAfterSimulationTick() { }
            public void OnReleased() {}
            public void OnCreated(IThreading threading) { }
            #endregion

            private bool createdModObject = false;
            public void OnUpdate(float realTimeDelta, float simulationTimeDelta) 
            {
                if(!createdModObject)
                {
                    gameObject = Camera.main.gameObject;
                    gameObject.AddComponent<AlienInvasionMod>();
                    _mod = gameObject.GetComponent<AlienInvasionMod>();
                    createdModObject = true;
                }
                _simulationTimeDelta = simulationTimeDelta;
            }
        
            public void OnBeforeSimulationFrame()
            {
                if(_mod != null)
                {
                    _mod.Tick(_simulationTimeDelta);
                }
            }

        }

        public class AlienInvasionMod : MonoBehaviour
        {
            private int _ticks;
            private int _frames;
            private EmpireGUI _gui;
            private AlienEmpire _empire;

            private void Start()
            {
                //create the alien empire
                _empire = new AlienEmpire();

                //create our GUI
                gameObject.AddComponent<EmpireGUI>();
                _gui = GetComponent<EmpireGUI>();
                _gui.SetEmpire(_empire);
            }

            private void Update()
            {
                _frames++;
            }

            public void Tick(float delta)
            {
                _ticks++;
                _empire.Tick(delta);
            }

            public void Destroy()
            {
                Destroy(this.gameObject);
            }

            private void OnGUI()
            {
                //All UI is currently really crappy and will be completely redone later. Its all for debugging right now.
                GUI.Label(new Rect(100, 20, 100, 50), ("Frame:" + _frames));
                GUI.Label(new Rect(100, 80, 100, 50), ("Tick:" + _ticks));
            }
        }
    }
}

