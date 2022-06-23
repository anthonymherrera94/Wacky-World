using System;
using System.Collections.Generic;
using UnityEngine;

namespace Collectables
{
    public enum ShardType { Red, Green, Blue }
    public class Collector : MonoBehaviour {
        private bool redShard;
        private bool blueShard;
        private bool greenShard;

        public delegate void ShardChanged(bool red, bool green, bool blue);
        public event ShardChanged OnShardChanged;

        // If this mask gets stupid big we can switch to a HashSet
        
        public string[] ItemMask;
        private Dictionary<string, int> Collection = new Dictionary<string, int>();

        public void Add(string collectableName, int collectableCount)
        {
            if (!Collection.ContainsKey(collectableName))
                Collection.Add(collectableName, 0);

            Collection[collectableName] = Collection[collectableName] + collectableCount;

            Debug.Log($"{collectableName}: {Collection[collectableName]}");
        }

        public void AddShard(ShardType shard)
        {
            if (shard == ShardType.Red) redShard = true;
            if (shard == ShardType.Green) greenShard = true;
            if (shard == ShardType.Blue) blueShard = true;

            OnShardChanged?.Invoke(redShard, greenShard, blueShard);
        }
    }
}
