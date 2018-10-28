using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactoryNamespace
{
    public class NPCSpawner : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public abstract class Enemy
    {
        public int health;
        public int attackPower;

        public abstract void Move();
        public abstract void Attack();
    }

    public abstract class Friendly
    {
        public int health;
        public int attackPower;

        public abstract void Move();
        public abstract void Attack();
    }

    public class FlyingEnemey : Enemy
    {
        public FlyingEnemey()
        {
            health = 10;
            attackPower = 1;
        }

        public override void Attack()
        {
            Debug.Log("Flying Enemy Attack !");
        }

        public override void Move()
        {
            Debug.Log("Flying Enemy Move !");
        }
    }

    public class WalkingEnemy : Enemy
    {
        public WalkingEnemy()
        {
            health = 10;
            attackPower = 1;
        }

        public override void Attack()
        {
            Debug.Log("WalkingEnemy  Attack !");
        }

        public override void Move()
        {
            Debug.Log("WalkingEnemy  Move !");
        }
    }

    public class FlyingFriendly : Friendly
    {
        public FlyingFriendly()
        {
            health = 10;
            attackPower = 1;
        }

        public override void Attack()
        {
            Debug.Log("FlyingFriendly  Attack !");
        }

        public override void Move()
        {
            Debug.Log("FlyingFriendly Move !");
        }
    }

    public class WalkingFriendly : Friendly
    {
        public WalkingFriendly()
        {
            health = 10;
            attackPower = 1;
        }

        public override void Attack()
        {
            Debug.Log("WalkingFriendly  Attack !");
        }

        public override void Move()
        {
            Debug.Log("WalkingFriendly  Move !");
        }
    }
}


