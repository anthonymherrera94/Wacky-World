using System;
using System.Collections.Generic;
using RuntimeSets;
using UnityEngine;
using UnityEngine.UI;

namespace Radar
{
    [RequireComponent(typeof(RawImage))]
    public class Radar : MonoBehaviour
    {
        public float blipWidth;
        [SerializeField] private float blipHeight;

        private RawImage background;
        private GameObject player;
        private readonly List<GameObject> blipsDrawn = new List<GameObject>();
        public float radarRange = 20;
        private float radarWidth;
        private float radarHeight;
        public List<RadarBlipConfig> blipSets = new List<RadarBlipConfig>();

        private void Awake()
        {
            background = GetComponent<RawImage>();
            player = GameObject.FindWithTag("Player");
        }

        void Start()
        {
            var rect = background.rectTransform.rect;
            radarWidth = rect.width;
            radarHeight = rect.height;
        }

        void Update()
        {
            ClearRadar();
            DisplayBlips();
        }

        private void DisplayBlips()
        {
            foreach (RadarBlipConfig blipSet in blipSets)
            {
                foreach (GameObject o in blipSet.set.GetSet())
                {
                    var toTarget = PlayerToTarget(o.transform.position);
                    if (toTarget.magnitude > radarRange)
                    {
                        continue;
                    }

                    var blipPos = ToBlipPos(toTarget);
                    DrawBlip(blipPos, blipSet.blip);
                }
            }
      
        }

        private void DrawBlip(Vector2 pos, GameObject prefab)
        {
            var blip = GameObject.Instantiate(prefab, transform.parent, true);
            var rt = blip.GetComponent<RectTransform>();
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, pos.x, blipWidth);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, pos.y, blipHeight);
            blipsDrawn.Add(blip);
        }

        private Vector2 ToBlipPos(Vector3 toTarget)
        {
            var normalIzedPosition = new Vector3(toTarget.x / radarRange, 0, toTarget.z / radarRange);
            var blipX = normalIzedPosition.x;
            var blipY = normalIzedPosition.z;
            blipX *= radarWidth / 2;
            blipY *= radarHeight / 2;
            blipX += radarWidth / 2;
            blipY += radarHeight / 2;
            return new Vector2(blipX, blipY);
        }


        private Vector3 PlayerToTarget(Vector3 targetPosition)
        {
            return targetPosition - player.transform.position;
        }

        private void ClearRadar()
        {
            removeAllBlips(blipsDrawn);
        }

        private void removeAllBlips(List<GameObject> blips)
        {
            foreach (var b in blips)
            {
                Destroy(b);
            }
        }

        [Serializable]
        public class RadarBlipConfig
        {
            [SerializeField] public RuntimeSet set;
            [SerializeField] public GameObject blip;
        
        }

    }
}