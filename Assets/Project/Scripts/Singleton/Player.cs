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
    }
}