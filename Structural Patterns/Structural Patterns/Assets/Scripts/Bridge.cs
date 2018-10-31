using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Similar to Adapter Pattern
// 
namespace Bridge
{
    public class Bridge : MonoBehaviour
    {
        Enemy imp;
        Enemy goblin;
        // Use this for initialization
        void Start()
        {
            imp = new WanderingEnemy(new Imp());
            goblin = new WanderingEnemy(new Goblin());

            imp.Attack();
            goblin.Attack();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public abstract class AttackAPI
    {
        protected string name;
        protected int attackPower;

        public abstract void attackImplementation();
    }

    public class Imp : AttackAPI
    {
        public Imp()
        {
            name = "Imp";
            attackPower = 1;
        }
        public override void attackImplementation()
        {
            Debug.Log(string.Format("{0} deals {1} damage", name, attackPower));
        }
    }

    public abstract class Enemy
    {
        protected AttackAPI attackAPI;

        protected Enemy(AttackAPI paramAttackAPI)
        {
            this.attackAPI = paramAttackAPI;
        }

        public abstract void Attack();
       
    }

    public class WanderingEnemy : Enemy
    {
        public WanderingEnemy(AttackAPI api) : base(api)
        {
            
        }
        
        public override void Attack()
        {
            attackAPI.attackImplementation();
        }
    }

    public class Goblin : AttackAPI
    {
        public Goblin()
        {
            name = "Goblin";
            attackPower = 3;
        }

        public override void attackImplementation()
        {
            Debug.Log(string.Format("{0} deals {1} damage", name, attackPower));
        }
    }
}

