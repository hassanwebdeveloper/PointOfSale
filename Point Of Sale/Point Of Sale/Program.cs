﻿using POSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Of_Sale
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreen splash = new SplashScreen();


            Task dbInitializerTask = new Task(() =>
            {
                try
                {
                    POSDbUtility.InitializeDatabases();
                    splash.Invoke(new Action(() => { splash.Close(); }));

                }
                catch (Exception)
                {

                    throw;
                }
            });

            dbInitializerTask.Start();

            splash.ShowDialog();
            Application.Run(new LoginForm());
        }
    }
}
