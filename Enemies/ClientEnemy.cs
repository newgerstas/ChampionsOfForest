﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ChampionsOfForest.Enemies
{
    public class ClientEnemy
    {
        private ulong id;
        public List<EnemyProgression.Abilities> abilities;
        public float damagemult;
        public ClientEnemy(ulong id,float damage, List<EnemyProgression.Abilities> abilities)
        {
            this.damagemult = damage;
            this.abilities = abilities;
            this.id = id;
            if (!EnemyManager.clientEnemies.ContainsKey(id))
            {
                EnemyManager.clientEnemies.Add(id, this);
            }
            else
            {
                EnemyManager.clientEnemies.Remove(id);

                EnemyManager.clientEnemies.Add(id, this);

            }
        }
     
    }
}
