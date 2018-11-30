namespace CAS.UI.Logging
{
    internal class ModeProvider
    {
        private ILogger logger;
        private Program.Action action;

        public ModeProvider(ILogger logger, Program.Action action)
        {
            this.logger = logger;
            this.action = action;
        }

        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        public Program.Action Action
        {
            get { return action; }
            set { action = value; }
        }
    }
}