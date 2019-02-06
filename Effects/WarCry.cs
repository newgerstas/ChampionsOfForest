﻿using ChampionsOfForest.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheForest.Utils;
using UnityEngine;

namespace ChampionsOfForest.Effects
{
    public class WarCry
    {
        public static Material particleMaterial;




        public static void Cast(Vector3 pos,float radius,bool GiveDamage,bool GiveArmor =false,int ArmorAmount =1)
        {
            if (ModSettings.IsDedicated) return;
            if((LocalPlayer.Transform.position - pos).sqrMagnitude < radius * radius)
            {
                GiveEffect(GiveDamage,GiveArmor,ArmorAmount);
            }
        }
        public static void GiveEffect(bool giveEffect2,bool giveEffect3,int ArmorAmount =1)
        {
            BuffDB.AddBuff(5, 45, 1.1f, 120);
            BuffDB.AddBuff(14, 46,  1.1f, 120);
            if (giveEffect2)
            {
                BuffDB.AddBuff(9, 47, 1.1f, 120);
            }
            if (giveEffect3)
            {
                BuffDB.AddBuff(15, 48,  ArmorAmount, 120);
            }
        }
        public static void SpawnEffect(Vector3 pos,float radius)
        {
            GameObject o = new GameObject("__SHOUTPARTICLES__");

            o.transform.position = pos;
            o.transform.rotation = Quaternion.Euler(90, 0, 0);
            o.transform.localScale = Vector3.one * radius / 50;

            GameObject.Destroy(o, 1);
          var ps =  o.AddComponent<ParticleSystem>();
            ParticleSystem.MainModule main = ps.main;
            ParticleSystem.EmissionModule emission = ps.emission;
            ParticleSystem.ShapeModule shape = ps.shape;
            var limit = ps.limitVelocityOverLifetime;
            ParticleSystemRenderer rend = ps.GetComponent<ParticleSystemRenderer>();

            main.loop = false;
            main.duration = 0.5f;
            main.startLifetime = 0.5f;
            main.startSpeed = 200;
            main.startSize = 5;
            main.startColor = new Color(0.8f, 0.255f, 0.0545f, 0.49f);
            main.gravityModifier = -3;

            emission.rateOverTime = 2000;

            shape.shapeType = ParticleSystemShapeType.Circle;

            limit.dampen = 0.2f;
            limit.limit = 1;

            if (particleMaterial == null)
            {
                particleMaterial = new Material(Shader.Find("Particles/Additive"));
                particleMaterial.mainTexture = Res.ResourceLoader.GetTexture(111);
                particleMaterial.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                particleMaterial.mainTextureScale = new Vector2(22, 1);
            }
            rend.material = particleMaterial;
            rend.renderMode = ParticleSystemRenderMode.Stretch;
            rend.lengthScale = 2.5f;
           

        }
    }
}