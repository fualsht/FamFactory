
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Threading;
using ModBox.FamFactory.Revit.FamFactoryAddIn.Properties;
using System.Data;
using ModBox.FamFactory.Revit.Manager;

namespace ModBox.FamFactory.Revit
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    public class FamFactoryAddin : IExternalApplication
    {
        static readonly string assemplyPath = System.Reflection.Assembly.GetAssembly(typeof(FamFactoryAddin)).Location;
        

        public static DataSet famFactoryDataSet;
        public static FamFactoryViewModel famFactoryManager;
        
        internal Autodesk.Revit.ApplicationServices.Application RevitApplicationService;
        internal System.Data.SQLite.SQLiteConnection sQLiteConnection;
        //public static ModBox.FamFactory.DataProvidor.Installation.InstallationConfiguration installationConfiguration;
        //public static ModBox.FamFactory.DataProvidor.Objects.FamFactoryUser activeUser;
        //public static ModBox.FamFactory.ObjectControls.FamFactoryViewModel famFactoryViewModel;

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("FamFactory");

            RibbonPanel famFactoryLogInRibbonPanel = application.CreateRibbonPanel("FamFactory", "Login");
            RibbonPanel famFactoryRibbonPanel = application.CreateRibbonPanel("FamFactory", "FamFactory");
            RibbonPanel famFactorySettingsRibbonPanel = application.CreateRibbonPanel("FamFactory", "Settings");
            RibbonPanel helpRibbonPanel = application.CreateRibbonPanel("FamFactory", "Help");

            PushButtonData LibraryButtonData = new PushButtonData("LibraryButton", "Library", assemplyPath, "ModBox.FamFactory.Revit.FamFactoryLibraryCommand");
            LibraryButtonData.LargeImage = BitmapToImageSource(Resources.LibraryIcon32);
            LibraryButtonData.Image = BitmapToImageSource(Resources.LibraryIcon16);

            PushButtonData SettingsButtonData = new PushButtonData("SettingsButton", "Settings", assemplyPath, "ModBox.FamFactory.Revit.FamFactorySettingsCommand");
            SettingsButtonData.LargeImage = BitmapToImageSource(Resources.SettingsIcon32);
            SettingsButtonData.Image = BitmapToImageSource(Resources.SettingsIcon16);

            PushButtonData PalleteButtonData = new PushButtonData("PalleteButton", "Pallete", assemplyPath, "ModBox.FamFactory.Revit.FamFactoryPalleteCommand");
            PalleteButtonData.LargeImage = BitmapToImageSource(Resources.PalletWindowOpenIcon32);
            PalleteButtonData.Image = BitmapToImageSource(Resources.PalletWindowOpenIcon16);

            PushButtonData UsersButtonData = new PushButtonData("UsersButton", "Users", assemplyPath, "ModBox.FamFactory.Revit.FamFactoryUsersCommand");
            UsersButtonData.LargeImage = BitmapToImageSource(Resources.UsersIcon32);
            UsersButtonData.Image = BitmapToImageSource(Resources.UsersIcon16);

            PushButtonData TemplatesButtonData = new PushButtonData("TemplatesButton", "Templates", assemplyPath, "ModBox.FamFactory.Revit.FamFactoryTemplatesCommand");
            TemplatesButtonData.LargeImage = BitmapToImageSource(Resources.TemplateIcon32);
            TemplatesButtonData.Image = BitmapToImageSource(Resources.TemplateIcon16);

            PushButtonData HelpButtonData = new PushButtonData("HelpButton", "Help", assemplyPath, "ModBox.FamFactory.Revit.FamFactoryHelpCommand");
            HelpButtonData.LargeImage = BitmapToImageSource(Resources.HelpIcon32);
            HelpButtonData.Image = BitmapToImageSource(Resources.HelpIcon16);

            PushButtonData AboutButtonData = new PushButtonData("AboutButton", "About", assemplyPath, "ModBox.FamFactory.Revit.FamFactoryAboutCommand");
            AboutButtonData.LargeImage = BitmapToImageSource(Resources.AboutIcon32);
            AboutButtonData.Image = BitmapToImageSource(Resources.AboutIcon16);

            PushButtonData LoginButtonData = new PushButtonData("LogInButton", "Log In", assemplyPath, "ModBox.FamFactory.Revit.FamFactoryLoginCommand");
            LoginButtonData.AvailabilityClassName = "ModBox.FamFactory.Revit.LoginButtonAvailabile";
            LoginButtonData.LargeImage = BitmapToImageSource(Resources.LogIn32);
            LoginButtonData.Image = BitmapToImageSource(Resources.LogIn16);

            PushButtonData LogOutButtonData = new PushButtonData("LogOutButton", "Log Out", assemplyPath, "ModBox.FamFactory.Revit.FamFactoryLogOutCommand");
            LogOutButtonData.AvailabilityClassName = "ModBox.FamFactory.Revit.LogOutButtonAvailabile";
            LogOutButtonData.LargeImage = BitmapToImageSource(Resources.LogOut32);
            LogOutButtonData.Image = BitmapToImageSource(Resources.LogOut16);

            famFactoryLogInRibbonPanel.AddItem(LoginButtonData);
            famFactoryLogInRibbonPanel.AddItem(LogOutButtonData);

            famFactoryRibbonPanel.AddItem(LibraryButtonData);

            famFactorySettingsRibbonPanel.AddItem(TemplatesButtonData);
            famFactorySettingsRibbonPanel.AddStackedItems(PalleteButtonData, UsersButtonData, SettingsButtonData);

            helpRibbonPanel.AddStackedItems(HelpButtonData, AboutButtonData);

            application.ControlledApplication.ApplicationInitialized += ControlledApplication_ApplicationInitialized;

            return Result.Succeeded;
        }

        private void ControlledApplication_ApplicationInitialized(object sender, Autodesk.Revit.DB.Events.ApplicationInitializedEventArgs e)
        {
            RevitApplicationService = sender as Autodesk.Revit.ApplicationServices.Application;
            sQLiteConnection = FamFactoryDataSet.GetSQlteConnection(@"c:\temp\famFactoryDatabase.db");
            famFactoryDataSet = new DataSet("famFactoryDatabase");

            string file = @"c:\temp\famFactoryDatabase.db";
            if (!System.IO.File.Exists(file))
            {
                FamFactoryDataSet.CreateSQliteDataBase(file, Resources.FamFactoryDBTables, famFactoryDataSet);
                FamFactoryDataSet.InstallRequierments(sQLiteConnection, famFactoryDataSet);
            }
            else
                FamFactoryDataSet.InitilizeDataSet(famFactoryDataSet);

            famFactoryManager = new FamFactoryViewModel(famFactoryDataSet, sQLiteConnection, RevitApplicationService);
            User u = famFactoryManager.UsersViewModel.InternalCollection[0];
            famFactoryManager.LogIn(u);


            //installationConfiguration = new DataProvidor.Installation.InstallationConfiguration();
            //installationConfiguration.Load("config.xml");
            //famFactoryDBContext = ModBox.FamFactory.DataProvidor.FamFactoryDBContext.Instance(installationConfiguration.connectionData);
            //famFactoryViewModel = new ObjectControls.FamFactoryViewModel(famFactoryDBContext);

            //if (string.IsNullOrEmpty(ReadWriteProperteis.AuthenticationKey) || string.IsNullOrEmpty(ReadWriteProperteis.UserName))
            //{
            //    LogIn(famFactoryDBContext, true);
            //}
            //else
            //{
            //    activeUser = famFactoryDBContext.AuthenticateUser(ReadWriteProperteis.UserName, ReadWriteProperteis.AuthenticationKey);
            //    TaskDialog taskDialog = new TaskDialog("Logged In");
            //    if (activeUser != null && activeUser.IsAuthenticated == true)
            //    {
            //        activeUser.LogIn();
            //        taskDialog.Show();
            //    }
            //}
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            //if (activeUser != null)
            //    activeUser.LogOut();
            //else
            //{
            //    ReadWriteProperteis.AuthenticationKey = string.Empty;
            //    ReadWriteProperteis.UserName = string.Empty;
            //    ReadWriteProperteis.SaveSettings();
            //}

            return Result.Succeeded;
        }

        private ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            BitmapImage bitmaimage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;


                bitmaimage.BeginInit();
                bitmaimage.StreamSource = memory;
                bitmaimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmaimage.EndInit();
            }
            return bitmaimage;
        }

        //public static void LogIn(FamFactory.DataProvidor.FamFactoryDBContext context, bool forceShowDialogue)
        //{
        //    ObjectControls.LogInWindow logIn;
        //    if (forceShowDialogue)
        //    {
        //    logIn:
        //        logIn = new ObjectControls.LogInWindow(ObjectControls.LogInWindow.DisplayModes.SignIn);
        //        if (logIn.ShowDialog() == true)
        //        {
        //            activeUser = context.AuthenticateUser(logIn.UserName, logIn.Password);
        //            if (activeUser != null && activeUser.IsAuthenticated)
        //            {
        //                if (logIn.RememberPassword == true)
        //                {
        //                    ReadWriteProperteis.UserName = logIn.UserName;
        //                    ReadWriteProperteis.AuthenticationKey = logIn.Password;
        //                    ReadWriteProperteis.SaveSettings();
        //                }
        //                else
        //                {
        //                    ReadWriteProperteis.UserName = string.Empty;
        //                    ReadWriteProperteis.AuthenticationKey = string.Empty;
        //                    ReadWriteProperteis.SaveSettings();
        //                }
        //                TaskDialog taskDialog = new TaskDialog("Logged In");
        //                if (activeUser != null && activeUser.IsAuthenticated == true)
        //                {
        //                    activeUser.LogIn();
        //                    taskDialog.Show();
        //                }
        //            }
        //            else if ((activeUser != null && activeUser.IsAuthenticated == false) || activeUser == null)
        //            {
        //                TaskDialog dialog = new TaskDialog("Login Error:");
        //                dialog.MainContent = "Invalid Username or Password!";
        //                dialog.MainIcon = TaskDialogIcon.TaskDialogIconError;
        //                if (dialog.Show() == TaskDialogResult.Close)
        //                    goto logIn;
        //            }
        //        }

        //        if (activeUser == null)
        //        {
        //            if (logIn.ForgotPassword)
        //            {
        //                context.SendResetUserPasswordEmail(logIn.UserName);
        //                goto logIn;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        activeUser = context.AuthenticateUser(ReadWriteProperteis.UserName, ReadWriteProperteis.AuthenticationKey);
        //        TaskDialog taskDialog = new TaskDialog("Logged In");
        //        if (activeUser != null && activeUser.IsAuthenticated == true)
        //        {
        //            activeUser.LogIn();
        //            taskDialog.Show();
        //        }
        //    }
        //}
    }


    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactoryLibraryCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog taskDialog = new TaskDialog("Library");
            taskDialog.MainContent = "FamFactory Library. - Comming Soon.";
            taskDialog.Show();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactorySettingsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            FamFactoryAddin.famFactoryManager.LaunchManagerWindow(); 

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactoryPalleteCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog taskDialog = new TaskDialog("Pallet");
            taskDialog.MainContent = "FamFactory Pallet. - Comming Soon.";
            taskDialog.Show();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactoryUsersCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //FamFactoryAddin.famFactoryViewModel.UsersViewModel.OpenUsersDialog(FamFactoryAddin.activeUser);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactoryTemplatesCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog taskDialog = new TaskDialog("Templates");
            taskDialog.MainContent = "FamFactory Templates. - Comming Soon.";
            taskDialog.Show();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactoryHelpCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog taskDialog = new TaskDialog("Help");
            taskDialog.MainContent = "FamFactory Help. - Comming Soon.";
            taskDialog.Show();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactoryAboutCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog taskDialog = new TaskDialog("About");
            taskDialog.MainContent = "FamFactory About. - Comming Soon.";
            taskDialog.Show();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactoryLoginCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //ModBox.FamFactory.DataProvidor.FamFactoryDBContext famFactoryDBContext = ModBox.FamFactory.DataProvidor.FamFactoryDBContext.Instance(FamFactoryAddin.installationConfiguration.connectionData);
            //if (FamFactoryAddin.activeUser != null)
            //{
            //    if (MessageBox.Show(string.Format("Login As: {0}?", ReadWriteProperteis.UserName), "Login As", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //        FamFactoryAddin.LogIn(famFactoryDBContext, false);
            //    else
            //        FamFactoryAddin.LogIn(famFactoryDBContext, true);
            //}
            //else
            //    FamFactoryAddin.LogIn(famFactoryDBContext, true);

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class FamFactoryLogOutCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //FamFactoryAddin.activeUser.LogOut();
            //FamFactoryAddin.activeUser = null;
            return Result.Succeeded;
        }
    }

    public class LoginButtonAvailabile : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            //try
            //{
            //    if (FamFactoryAddin.activeUser != null && FamFactoryAddin.activeUser.IsLoggedIn)
            //        return false;
            //    else
            //        return true;
            //}
            //catch
            //{
            //    return false;
            //}
            return true;
        }
    }

    public class LogOutButtonAvailabile : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            //try
            //{
            //    if (FamFactoryAddin.activeUser != null && FamFactoryAddin.activeUser.IsLoggedIn)
            //        return true;
            //    else
            //        return false;
            //}
            //catch
            //{
            //    return false;
            //}
            return true;
        }
    }
}