using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using NGit;
using NGit.Api;
using NGit.Transport;
using AutoItX3Lib;


namespace GitBegin
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
    
	public partial class MainWindow : Window
	{
        enum GridType { MainMenu, FileViewer, CommitHistory, RepositoryCreation, RepositorySelect, Commit, Login, Pull, RepositoryMain, OpenRepo, DeleteRepo, SettingsMenu, Help };
        GridType lastGrid = GridType.MainMenu;
        string activeRepoPath = "";
        NGit.Api.Git repository;
        string activeURI = "";
        bool terminalMode = false;
        bool tutorialMode = false;
        bool commandMode = false;
        AutoItX3 autoIt = new AutoItX3();
        BuildbotClass buildbot = new BuildbotClass();
        string WorkingDirectoryPath = @"C:\git\test_buildbot";

		public MainWindow()
		{
			this.InitializeComponent();
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Visible;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Hidden;
			DeleteRepoBoxGrid.Visibility = Visibility.Hidden;
			SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            BuildbotGrid_green.Visibility = Visibility.Hidden;
            BuildbotGrid_red.Visibility = Visibility.Hidden;
            autoIt.AutoItSetOption("WinTitleMatchMode", 2);
            buildbot.ExecuteCommandAsync(WorkingDirectoryPath);
            lastGrid = GridType.MainMenu;
			HistoryListEntry1.Visibility = Visibility.Visible;
			HistoryListEntry2.Visibility = Visibility.Visible;
			HistoryListEntry3.Visibility = Visibility.Visible;
			HistoryListEntry4.Visibility = Visibility.Visible;
			HistoryListEntry5.Visibility = Visibility.Visible;
			HistoryListEntry6.Visibility = Visibility.Visible;
			HistoryListEntry7.Visibility = Visibility.Visible;
			HistoryListEntry8.Visibility = Visibility.Visible;
			HistoryListEntry9.Visibility = Visibility.Visible;
			HistoryListEntry10.Visibility = Visibility.Visible;
			HistoryListEntry11.Visibility = Visibility.Visible;
			HistoryListEntry12.Visibility = Visibility.Visible;
			
			HistoryListEntry13.Visibility = Visibility.Visible;
			HistoryListEntry14.Visibility = Visibility.Visible;
			HistoryListEntry15.Visibility = Visibility.Visible;
			HistoryListEntry16.Visibility = Visibility.Visible;
			
			HistoryListEntry17.Visibility = Visibility.Visible;
			HistoryListEntry18.Visibility = Visibility.Visible;
			HistoryListEntry19.Visibility = Visibility.Visible;
			HistoryListEntry20.Visibility = Visibility.Visible;
			HistoryListEntry21.Visibility = Visibility.Visible;
			HistoryListEntry22.Visibility = Visibility.Visible;
			HistoryListEntry23.Visibility = Visibility.Visible;
			HistoryListEntry24.Visibility = Visibility.Visible;
			HistoryListEntry25.Visibility = Visibility.Visible;
			HistoryListEntry26.Visibility = Visibility.Visible;
			HistoryListEntry27.Visibility = Visibility.Visible;
			HistoryListEntry28.Visibility = Visibility.Visible;
		}
        public void Go_To_Last_Grid(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (lastGrid)
            {
                case GridType.MainMenu:
                    Go_To_MainMenuGrid(sender, e);
                    break;
                case GridType.FileViewer:
                    Go_To_FileViewerGrid(sender, e);
                    break;
                case GridType.CommitHistory:
                    Go_To_CommitHistoryGrid(sender, e);
                    break;
                case GridType.RepositoryCreation:
                    Go_To_RepositoryCreationGrid(sender, e);
                    break;
                case GridType.RepositorySelect:
                    Go_To_RepositorySelectGrid(sender, e);
                    break;
                case GridType.Commit:
                    Go_To_CommitGrid(sender, e);
                    break;
                case GridType.Login:
                    Go_To_LoginGrid(sender, e);
                    break;
                case GridType.Pull:
                    Go_To_PullGrid(sender, e);
                    break;
                case GridType.RepositoryMain:
                    Go_To_RepositoryMainGrid(sender, e);
                    break;
                case GridType.OpenRepo:
                    Go_To_OpenRepoGrid(sender, e);
                    break;
                case GridType.SettingsMenu:
                    Go_To_SettingsGrid(sender, e);
                    break;
                case GridType.Help:
                    Go_To_HelpGrid(sender, e);
                    break;
                default:
                    break;
            }
        }

		private void Button_Mouse_Enter(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}
		private void Go_To_MainMenuGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Visible;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Hidden;
			DeleteRepoBoxGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.MainMenu;
		}
        private void Clone_Repo_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            //string rootedPath = Repository.Init(path + "\\" + name, bareRepo);
            string cloneDestination = FolderPathTextBox3.Text;
            if (terminalMode)
            {
                checkTerminal();
                autoIt.WinActivate("cmd.exe");
                autoIt.WinWaitActive("cmd.exe");
                activeRepoPath = cloneDestination;
                string cmd = "git clone " + activeURI + " " + cloneDestination;
                autoIt.Send(cmd + "\r");
                //autoIt.WinActivate("MainWindow");
            }
            else
            {


                var credentials = new UsernamePasswordCredentialsProvider("michael4243", "surprises0");
                CredentialsProvider.SetDefault(credentials);
                // Let's clone the NGit repository
                var clone = Git.CloneRepository()
                    .SetDirectory(@activeRepoPath)
                    .SetURI(activeURI);

                // Execute and return the repository object we'll use for further commands
                repository = clone.Call();
                //Console.WriteLine(rootedPath);
                Go_To_RepositoryMainGrid(sender, e);
            }
            
        }
        private void Done_Cloning(object sender, System.Windows.RoutedEventArgs e)
        {
            if (terminalMode)
                openActivePath();
            Go_To_RepositoryMainGrid(sender, e);
        }
        private void Open_Repo_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            string s =  FolderPathTextBox4.Text + "/" + RepoNameTextBox1.Text+  ".git";
            activeURI = s;
            if (terminalMode)
            {
                activeRepoPath = FolderPathTextBox4.Text;
                if (s.StartsWith("C:\\"))
                {
                    openActivePath();
                }
                
            }
            else
            {
                var credentials = new UsernamePasswordCredentialsProvider("michael4243", "surprises0");
                CredentialsProvider.SetDefault(credentials);
            }
            Go_To_RepositoryMainGrid(sender, e);
        }
        private void Create_Repo_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            string s = FolderPathTextBox.Text;
            activeRepoPath = s;
            activeURI = s;
            bool bareRepo = (bool)BareRepo.IsChecked;
            //Create_Repo(FolderPathTextBox.Text, RepoNameTextBox.Text, bareRepo);

            if (terminalMode)
            {
                checkTerminal();
                autoIt.WinActivate("cmd.exe");
                autoIt.WinWaitActive("cmd.exe");
                string cmd = "git init";
                if (bareRepo)
                    cmd += " --bare";
                autoIt.Send("mkdir " + activeRepoPath + "\r");
                autoIt.Send("cd " + activeRepoPath + "\r");
                autoIt.Send(cmd + "\r");
                autoIt.WinActivate("MainWindow");
            }
            else
            {
                var clone = Git.Init()
                    .SetDirectory(@activeRepoPath)
                    .SetBare(bareRepo);

                // Execute and return the repository object we'll use for further commands
                repository = clone.Call();
            }
            Go_To_RepositoryMainGrid(sender, e);
        }
        private void Commit_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            var author = new PersonIdent("Michael", "mkell49@lsu.edu");
            string message = FolderPathTextBox1.Text;

            if (terminalMode)
            {
                //openActivePath();
                autoIt.WinActivate("cmd.exe");
                autoIt.Send("git commit -m \"" + activeRepoPath + "\"" + "\r");
                autoIt.WinActivate("MainWindow");
            }
            else
            {
                var commit = repository.Commit()
                    .SetMessage(message)
                    .SetAuthor(author)
                    .SetAll(true) // This automatically stages modified and deleted files
                    .Call();

                // Our new commit's hash
                var hash = commit.Id;
                //using (var repo = new Repository(activeRepoPath))
                //{

                // Create the committer's signature and commit
                //Signature author = new Signature("Default User", "email@email.com", DateTime.Now);
                //Signature committer = author;

                // Commit to the repository
                //Commit commit = repo.Commit(message, author, committer);
                //}
            }
            Go_To_RepositoryMainGrid(sender, e);
        }

        private void Push_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            if (terminalMode)
            {
                openActivePath();
                string cmd = "git push";
                autoIt.Send(cmd + "\r");
                autoIt.WinActivate("MainWindow");
            }
            else
            {
                var push = repository.Push().Call();
            }
        }
        private void checkTerminal()
        {
            if (autoIt.WinExists("cmd.exe") == 0)
            {
                System.Diagnostics.Process.Start("C:\\Windows\\system32\\cmd.exe");
            }
        }
        private void openActivePath()
        {
            checkTerminal();
            autoIt.WinActivate("cmd.exe");
            autoIt.WinWaitActive("cmd.exe");
            string cmd = "cd " + activeRepoPath;
            autoIt.Send(cmd + "\r");
            autoIt.WinActivate("MainWindow");
        }
        private void Toggle_Terminal_Mode(object sender, System.Windows.RoutedEventArgs e)
        {
            terminalMode = !terminalMode;
            if (terminalMode)
            {
                TerminalButton.Content = "Disable Terminal Window";
                checkTerminal();
            }
            else
            {
                TerminalButton.Content = "Use Terminal Window";
            }
        }

        private void Go_To_SettingsGrid(object sender, System.Windows.RoutedEventArgs e)
        {
            FileViewerGrid.Visibility = Visibility.Hidden;
            MainMenuGrid.Visibility = Visibility.Hidden;
            CommitHistoryGrid.Visibility = Visibility.Hidden;
            RepositoryCreationGrid.Visibility = Visibility.Hidden;
            RepositorySelectGrid.Visibility = Visibility.Hidden;
            CommitGrid.Visibility = Visibility.Hidden;
            LoginGrid.Visibility = Visibility.Hidden;
            PullGrid.Visibility = Visibility.Hidden;
            RepositoryMainGrid.Visibility = Visibility.Hidden;
            OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Visible;
			HelpGrid.Visibility = Visibility.Hidden;
        }
		private void Go_To_HelpGrid(object sender, System.Windows.RoutedEventArgs e)
        {
            FileViewerGrid.Visibility = Visibility.Hidden;
            MainMenuGrid.Visibility = Visibility.Hidden;
            CommitHistoryGrid.Visibility = Visibility.Hidden;
            RepositoryCreationGrid.Visibility = Visibility.Hidden;
            RepositorySelectGrid.Visibility = Visibility.Hidden;
            CommitGrid.Visibility = Visibility.Hidden;
            LoginGrid.Visibility = Visibility.Hidden;
            PullGrid.Visibility = Visibility.Hidden;
            RepositoryMainGrid.Visibility = Visibility.Hidden;
            OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Visible;
        }
        private void Go_To_FileViewerGrid(object sender, System.Windows.RoutedEventArgs e)
        {
            FileViewerGrid.Visibility = Visibility.Visible;
            MainMenuGrid.Visibility = Visibility.Hidden;
            CommitHistoryGrid.Visibility = Visibility.Hidden;
            RepositoryCreationGrid.Visibility = Visibility.Hidden;
            RepositorySelectGrid.Visibility = Visibility.Hidden;
            CommitGrid.Visibility = Visibility.Hidden;
            LoginGrid.Visibility = Visibility.Hidden;
            PullGrid.Visibility = Visibility.Hidden;
            RepositoryMainGrid.Visibility = Visibility.Hidden;
            OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.FileViewer;
        }
		private void Go_To_CommitHistoryGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Hidden;
			CommitHistoryGrid.Visibility = Visibility.Visible;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.CommitHistory;
		}
		private void Go_To_RepositoryCreationGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Hidden;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Visible;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.RepositoryCreation;
		}
		private void Go_To_RepositorySelectGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Hidden;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Visible;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.RepositorySelect;
		}
		private void Go_To_CommitGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Hidden;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Visible;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.Commit;
		}
		private void Go_To_LoginGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Hidden;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Visible;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.Login;
		}
		private void Go_To_PullGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Hidden;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Visible;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.Pull;
		}
		private void Go_To_OpenRepoGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Hidden;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Hidden;
			OpenRepoGrid.Visibility = Visibility.Visible;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.OpenRepo;
		}
		private void Go_To_RepositoryMainGrid(object sender, System.Windows.RoutedEventArgs e)
		{
            FileViewerGrid.Visibility = Visibility.Hidden;
			MainMenuGrid.Visibility = Visibility.Hidden;
			CommitHistoryGrid.Visibility = Visibility.Hidden;
			RepositoryCreationGrid.Visibility = Visibility.Hidden;
			RepositorySelectGrid.Visibility = Visibility.Hidden;
			CommitGrid.Visibility = Visibility.Hidden;
			LoginGrid.Visibility = Visibility.Hidden;
			PullGrid.Visibility = Visibility.Hidden;
			RepositoryMainGrid.Visibility = Visibility.Visible;
			OpenRepoGrid.Visibility = Visibility.Hidden;
			DeleteRepoBoxGrid.Visibility = Visibility.Hidden;
            SettingsMenuGrid.Visibility = Visibility.Hidden;
			HelpGrid.Visibility = Visibility.Hidden;
            lastGrid = GridType.RepositoryMain;
		}

		private void RedXButtonClick(object sender, System.Windows.RoutedEventArgs e)
		{
			DeleteRepoBoxGrid.Visibility = Visibility.Visible;
		}
	}

    class BuildbotClass
    {
        int result;
        string activeURI = "git@github.com:gbibek/test_buildbot.git";


        public BuildbotClass()
        {
            result = 1;
            /*var clone = Git.CloneRepository()
                .SetDirectory(activeRepopath)
                .SetURI(activeURI);
           
            var repo = clone.Call();*/

        }
        public void Merge()
        {

        }


        public void print_result()
        {
            Console.WriteLine(result);
        }


        public void git_pool(object WorkingDirectory)
        {
            var repository = Git.Open((String)WorkingDirectory);
            int test_value = 0;
            ICollection<TrackingRefUpdate> refUpdate = null;
            // string WorkingDirectory = @"C:\clone_git\test_buildbot";


            // Console.WriteLine(repository.Status().Call().IsClean());

            //    ((MainWindow)System.Windows.Application.Current.MainWindow).BuildbotGrid_green.Dispatcher.Invoke(

            while (true)
            {
                repository.Pull().Call();
                while (test_value == 0)
                {

                    // Console.WriteLine("test_value : {0} ---",test_value);
                    FetchResult result = repository.Fetch().Call();
                    refUpdate = result.GetTrackingRefUpdates();
                    test_value = refUpdate.Count;
                    // Console.Write(test_value);


                }
                repository.Pull().Call();
                if (ExecuteCommand((String)WorkingDirectory) == 0)
                {
                    Application.Current.Dispatcher.BeginInvoke(
                 System.Windows.Threading.DispatcherPriority.Background,
                 new Action(() => ((MainWindow)System.
                         Windows.Application.Current.MainWindow).
                         BuildbotGrid_green.Visibility
                         = Visibility.Visible));
                    Thread.Sleep(10000);

                    Application.Current.Dispatcher.BeginInvoke(
                 System.Windows.Threading.DispatcherPriority.Background,
                 new Action(() => ((MainWindow)System.
                         Windows.Application.Current.MainWindow).
                         BuildbotGrid_green.Visibility
                         = Visibility.Hidden));


                }
                else
                {

                    Application.Current.Dispatcher.BeginInvoke(
                  System.Windows.Threading.DispatcherPriority.Background,
                  new Action(() => ((MainWindow)System.
                          Windows.Application.Current.MainWindow).
                          BuildbotGrid_red.Visibility
                          = Visibility.Visible));

                    Thread.Sleep(10000);

                    Application.Current.Dispatcher.BeginInvoke(
                  System.Windows.Threading.DispatcherPriority.Background,
                  new Action(() => ((MainWindow)System.
                          Windows.Application.Current.MainWindow).
                          BuildbotGrid_red.Visibility
                          = Visibility.Hidden));

                }
                test_value = 0;
            }
            //Console.WriteLine("Something changed");

        }

        public void ExecuteCommandAsync(string WorkingDirectoryPath)
        {
            try
            {
                Thread objThread = new Thread(new ParameterizedThreadStart(git_pool));
                objThread.IsBackground = true;
                objThread.Priority = ThreadPriority.AboveNormal;
                objThread.Start(WorkingDirectoryPath);
            }

            catch (ThreadStartException objException)
            {
                // Log the exception
                Console.WriteLine(objException.Message);
            }
            catch (ThreadAbortException objException)
            {
                // Log the exception
                Console.WriteLine(objException.Message);
            }
            catch (Exception objException)
            {
                // Log the exception
                Console.WriteLine(objException.Message);
            }
        }


        public int ExecuteCommand(string WorkingDirectory)
        {
            int my_result;
            try
            {

                System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo();


                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.FileName = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc";
                procStartInfo.Arguments = "simple_hello_world.cs";
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                procStartInfo.WorkingDirectory = WorkingDirectory;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();

                my_result = proc.ExitCode;

                return my_result;
            }
            catch (Exception objException)
            {
                // Log the exception
                return -1;
            }

        }
    }
}