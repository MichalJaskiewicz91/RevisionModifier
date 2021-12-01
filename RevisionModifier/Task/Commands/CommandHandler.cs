using System;
using System.Windows.Input;

namespace Task.Commands
{
    /// <summary>
    /// A class that handles commands.
    /// </summary>
    public class CommandHandler : ICommand
    {
        #region Private Members

        /// <summary>
        /// Private member that is Predicate delegate type.
        /// </summary>
        private readonly Predicate<object> _canExecute;
        /// <summary>
        /// Private member that is Action delegate type.
        /// </summary>
        private readonly Action<object> _execute;
        #endregion

        #region Public Memebers
        /// <summary>
        /// A property that checks if method can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
        /// <summary>
        /// A property that executes passed method.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// A Conctructor that takes two parameters and assigns them to private members.
        /// </summary>
        /// <param name="canExecute"></param>
        /// <param name="execute"></param>
        public CommandHandler(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
        #endregion

        #region Events
        /// <summary>
        /// Occurs when changes occur that affect whether the command is to be executed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

    }
}
