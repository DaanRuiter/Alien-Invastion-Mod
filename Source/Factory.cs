using ICities;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ShipType
{
    Fighter,
    Frigate,
    Cruiser,
    Destroyer,
    Mothership
}

namespace AlienInvasion
{
    namespace Factories
    {
        

        public class Factory
        {
            private Shader _diffuseShader;
            private Texture2D _placeholderTexture;
            private bool _materialsPrebuilt;

            private Vector3 _shipScale;

            public Factory(bool autoBuildMaterials = false)
            {
                if (autoBuildMaterials)
                {
                    BuildMaterials();
                }
                _shipScale = new Vector3(0, 0, 0);
            }

            private void BuildMaterials()
            {
                _diffuseShader = Shader.Find("Legacy Shaders/Diffuse");
                _placeholderTexture = new Texture2D(2, 2);

                _placeholderTexture.SetPixel(0, 0, Color.white);
                _placeholderTexture.SetPixel(0, 1, Color.white);
                _placeholderTexture.SetPixel(1, 0, Color.white);
                _placeholderTexture.SetPixel(1, 1, Color.white);

                _placeholderTexture.Apply();

                _materialsPrebuilt = true;
            }

            public GameObject CreateShip(ShipType type)
            {
                GameObject ship = CreateShipObject();
                ship.AddComponent<TrailRenderer>();

                ship.transform.position = RandomPos();

                return ship;
            }

            private GameObject CreateShipObject()
            {
                GameObject ship = GameObject.CreatePrimitive(PrimitiveType.Capsule);

                if (!_materialsPrebuilt)
                {
                    BuildMaterials();
                }

                ship.GetComponent<Renderer>().sharedMaterial.shader = _diffuseShader;
                ship.GetComponent<Renderer>().sharedMaterial.mainTexture = _placeholderTexture;

                _shipScale.x = Random.Range(18f, 23f);
                _shipScale.y = Random.Range(3f, 5f);
                _shipScale.z = _shipScale.x;
                ship.transform.localScale = _shipScale;

                return ship;
            }

            private Vector3 RandomPos()
            {
                Vector3 randomPos = new Vector3(0, 0, 0);
                randomPos.x = Random.Range(-600, 600);
                randomPos.y = Random.Range(75, 250);
                randomPos.z = Random.Range(-600, 600);
                return randomPos;
            }
        }
    }
}


