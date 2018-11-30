namespace AvControls.ExtendableList
{
    internal class HeightProvider
    {
        public HeightProvider()
        {
            MinimalBlockHeight = 20;
        }

        public HeightProvider(int minimalBlockHeight)
        {
            MinimalBlockHeight = 20;
            MinimalBlockHeight = minimalBlockHeight;
        }

        public int MinimalBlockHeight { get; set; }
    }
}