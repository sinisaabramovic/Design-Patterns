using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype{
    public class Prototype : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            // Create a prototype
            Bandit bandit1 = new Bandit("0", "Bandit");
            Knight knight1 = new Knight("1", "Knight");

            // Create a Clone
            Bandit bandit2 = (Bandit)bandit1.Clone();
            Knight knight2 = (Knight)knight1.Clone();

            // Calling methods from cloned objects
            knight2.Attack();
            bandit2.Attack();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    // This is a prototype
    public abstract class Enemy
    {
        private string _id;
        private string _name;

        public Enemy(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public abstract Enemy Clone();
        public abstract void Attack();
    }

    // Derivate class
    public class Bandit : Enemy
    {
        public Bandit(string id, string name) : base(id,name)
        {
            
        }

        public override void Attack()
        {
            Debug.Log("Bandit has attacked!");
        }

        public override Enemy Clone()
        {
            return (Enemy)this.MemberwiseClone();
        }
    }

    // Derivate class
    public class Knight : Enemy
    {
        public Knight(string id, string name) : base(id, name)
        {
            
        }

        public override void Attack()
        {
            Debug.Log("Knight is attacking!");
        }

        public override Enemy Clone()
        {
            return (Enemy)this.MemberwiseClone();
        }
    }
}

