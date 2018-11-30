namespace CAS.UI.Logging
{
    internal class ModeProvider
    {
        private ILogger _logger;
        private Program.Action _action;

        public ModeProvider(ILogger logger, Program.Action action)
        {
            _logger = logger;
            _action = action;
        }

        public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        public Program.Action Action
        {
            get { return _action; }
            set { _action = value; }
        }
    }
}