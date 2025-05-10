using BooksManagement.controller;
using BooksManagement.repository.databases;
using BooksManagement.repository.interfaces;
using BooksManagement.service;
using Npgsql;

namespace BooksManagement;
using BooksManagement.model;
static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=rocco1512;Database=booksmanagement";
        var dbProviderFactory = NpgsqlFactory.Instance;

        IBookRepository bookRepository = new BookDbRepository(connectionString, dbProviderFactory);    
        ILendingRepository lendingRepository = new LendingDbRepository(connectionString, dbProviderFactory);
        
        IService service = new Service(bookRepository, lendingRepository);
        
        var mainView = new MainView();
        mainView.Load += async (sender, e) => 
        {
            try 
            {
                await mainView.SetService(service);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error initializing application: {ex.Message}");
            }
        };        
        
        Application.Run(mainView);


        

    }
}