using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Task.Commands;
using Task.Models;
using Task.Services;
using Task.Views;
using System.Linq;
using Task.Helpers;

namespace Task.ViewModel
{

    /// <summary>
    /// Main Window Class.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Private Members
        private bool isRevisionLoaded;
        private string chosenXMLFilePath;
        private readonly IRevisionProvider _revisionProvider;
        #endregion

        #region Public Members
        /// <summary>
        /// Collection of Main Window UserControls.
        /// </summary>
        public ObservableCollection<UIElement> MainWindowControls { get; set; }
        /// <summary>
        /// Keeps revision elements.
        /// </summary>
        public ObservableCollection<ArrRevisionEntry> Revisions { get; } = new ObservableCollection<ArrRevisionEntry>();
        /// <summary>
        /// Chosen XML file path by the user.
        /// </summary>
        public string ChosenXMLFilePath
        {
            get { return chosenXMLFilePath; }
            set
            {
                chosenXMLFilePath = value;
                OnPropertyChanged(nameof(ChosenXMLFilePath));
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Main window constuctor. Creates Main Window Instance and injects dependency.
        /// </summary>
        public MainWindowViewModel(IRevisionProvider revisionProvider)
        {
            MainWindowControls = new ObservableCollection<UIElement> { new RevisionListView() };
            _revisionProvider = revisionProvider;
        }
        #endregion

        #region Events
        /// <summary>
        /// The event that is fired when property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        /// <summary>
        /// Actions when Load XML button is clicked.
        /// </summary>
        public ICommand LoadXmlButtonTextCommand => new CommandHandler(CanExecute, OnXMLLoad);
        /// <summary>
        /// Actions when Save XML button is clicked.
        /// </summary>
        public ICommand SaveXmlButtonTextCommand => new CommandHandler(CanExecute, OnXMLSave);
        /// <summary>
        /// Actions when Load XML file button is clicked.
        /// </summary>
        public ICommand ChooseXMLFile => new CommandHandler(CanExecute, OnXMLLoadFile);
        #endregion

        #region Methods

        /// <summary>
        /// A method that determines the execution condition. In this case hardcoded as always true.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private bool CanExecute(object parameter) => true;
        /// <summary>
        /// Actions when Load XML button is clicked.
        /// </summary>
        private void OnXMLLoad(object parameter)
        {
            // Check whether given path is empty or null
            if (ChosenXMLFilePath == null || ChosenXMLFilePath == "")
            {
                // Indicate a message
                MessageBox.Show("Please load xml revision file from the disk firstly!");
                return;
            }

            // Invoke a load method and assign result to the variable
            var revisions = _revisionProvider.LoadRevisions(ChosenXMLFilePath);
            if (revisions == null)
                return;

            // Clear revisions collection
            Revisions.Clear();
            foreach (var item in revisions)
            {
                // Add every revision to the collection
                Revisions.Add(item);
            }
            // Set a flag
            isRevisionLoaded = true;
            // Indicate a message
            MessageBox.Show("Revisions have been loaded properly");
        }
        /// <summary>
        /// Actions when save XML button is clicked.
        /// </summary>
        /// <param name="parameter"></param>
        private void OnXMLSave(object parameter)
        {
            // Check whether given path is empty or null and check if work plan are already loaded
            if (isRevisionLoaded == false || ChosenXMLFilePath == null || ChosenXMLFilePath == "")
            {
                MessageBox.Show("Please load Revisions firstly!");
                return;
            }
            // Invoke a save method
            _revisionProvider.SaveRevision(Revisions.ToList(), ChosenXMLFilePath);
        }
        /// <summary>
        /// Gets string of chosen file.
        /// </summary>
        /// <param name="parameter"></param>
        private void OnXMLLoadFile(object parameter)
        {
            // Assign string to result of SelectXMLFile method
            ChosenXMLFilePath = FileHelper.SelectXMLFile();

            if (ChosenXMLFilePath == null || ChosenXMLFilePath == "")
            {
                // Clear revisions collection
                Revisions.Clear();
                return;
            }
            // Automatically load revisions
            OnXMLLoad(this);


        }
        /// <summary>
        /// Invokes an PropertyChanged event.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Main Window loaded event. Fills window with UserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            MainWindowControls.Add(new RevisionListView());
        }

        #endregion
    }
}
