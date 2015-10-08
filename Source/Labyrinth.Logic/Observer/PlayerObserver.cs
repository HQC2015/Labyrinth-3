namespace Labyrinth.Logic.Observer
{
    using Interfaces;
    using System.Collections.Generic;

    public class PlayerObserver
    {
        private readonly List<IObservered> listeners = new List<IObservered>();
        private int currentScore;
        private int playerX;
        private int playerY;

        public PlayerObserver()
        {
        }

        public PlayerObserver(int currentScore, int playerX, int playerY)
        {
            this.currentScore = currentScore;
            this.playerX = playerX;
            this.playerY = playerY;
        }

        public int CurrentScore
        {
            get
            {
                return this.currentScore;
            }
            set
            {
                this.currentScore = value;
                this.Notify();
            }
        }

        public int PlayerX
        {
            get
            {
                return this.playerX;
            }
            set
            {
                this.playerX = value;
                this.Notify();
            }
        }

        public int PlayerY
        {
            get
            {
                return this.playerY;
            }
            set
            {
                this.playerY = value;
                this.Notify();
            }
        }

        public void Attach(IObservered listener)
        {
            this.listeners.Add(listener);
        }

        public void Dettach(IObservered listener)
        {
            this.listeners.Remove(listener);
        }

        private void Notify()
        {
            foreach(var observed in listeners)
            {
                observed.Update(this.CurrentScore, this.playerX, this.playerY);
            }
        }
    }
}
