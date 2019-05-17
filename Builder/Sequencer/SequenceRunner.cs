using System.Collections.Generic;
using System.Linq;

namespace Builder.Sequencer
{
    public class SequenceRunner
    {
        public bool HasFinishedRunning { get; private set; }

        private IEnumerable<ActionBase> _actions;

        private List<ActionBase> _actionsToRun;
        private List<ActionBase> _currentlyRunningActions;

        public void Load(IEnumerable<ActionBase> sequences)
        {
            _actions = sequences.ToList();
        }

        public void Run()
        {
            HasFinishedRunning = false;
            _actionsToRun = _actions.ToList();
            _currentlyRunningActions = new List<ActionBase>();
            BatchActions();
        }

        public void Update()
        {
            if (_currentlyRunningActions == null || HasFinishedRunning)
            {
                return;
            }

            foreach (var action in _currentlyRunningActions.ToList())
            {
                action.Update();

                if (action.HasFinishedExecution)
                {
                    _currentlyRunningActions.Remove(action);
                }
            }

            if (!_currentlyRunningActions.Any(cra => cra.Blocking))
            {
                BatchActions();
            }

            if (!_actionsToRun.Any() && !_currentlyRunningActions.Any())
            {
                HasFinishedRunning = true;
            }
        }

        private void BatchActions()
        {
            foreach (var action in _actionsToRun.ToList())
            {
                action.Start();
                _currentlyRunningActions.Add(action);
                _actionsToRun.Remove(action);

                if (action.Blocking)
                {
                    return;
                }
            }
        }
    }
}
