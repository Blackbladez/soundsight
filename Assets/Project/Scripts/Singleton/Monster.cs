namespace Assets.Scripts.Singleton
{
    public sealed class Monster
    {
        private static readonly Monster instance = new Monster();

        private Monster()
        {
        }

        static Monster()
        {
        }

        public static Monster Instance
        {
            get { return instance; }
        }
    }
}