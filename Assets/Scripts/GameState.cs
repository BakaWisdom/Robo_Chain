using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public abstract class GameState
    {
        protected readonly PlaySystem mySystem;

        public GameState(PlaySystem mySystem)//should take in the system
        {
            this.mySystem = mySystem;
        }

        public virtual IEnumerator Move()
        {
            yield break;
        }

        public virtual IEnumerator Pause()
        {
            yield break;
        }

        public virtual IEnumerator Step()
        {
            yield break;
        }
    }