using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;


namespace TP1_Projet.ViewsModels
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        public ICommand MedecinCommand { get; private set; }

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            
            return _canExecute(parameter);
            //returner un booleen
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
       

        // on se refere de la clalsse ralycommand pour lier bouton avec le combobox
        // execute pointe vers lacible
        // AVec le bouton Creer dans inscription on va mettre Button Command="" pour le binding
    }
}
