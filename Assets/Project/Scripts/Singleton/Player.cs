namespace Assets.Scripts.Singleton
{
    public sealed class Player
    {
        private static readonly Player instance = new Player();

        private Player()
        {

        }

        static Player()
        {
        }

        public static Player Instance
        {
            get { return instance; }
        }

        public int HeartHealth { get; set; }
        public int Sensitivity { get; set; } // 3, 8, 12, 20
    }
}