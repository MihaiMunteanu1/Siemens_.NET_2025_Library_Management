using BooksManagement.model;
using BooksManagement.service;

namespace BooksManagement.controller;

/**
 * MainView class that represents the main user interface for managing books.
 * It provides functionality to add, update, delete, lend, and search for books.
 */
public partial class MainView : Form
{
    
    private IService _service;
    private readonly BindingSource _booksBindingSource = new();
    
    public MainView()
    {
        InitializeComponent();
        Width = 1100;
        Height = 630;
    }

    public async Task SetService(IService service)
    {
        // Initialize the service
        _service = service;
        try
        {
            // Load data
            await LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}");
        }
    }

    private async Task LoadData()
    {
        try
        {
            // Initialize the model books
            await InitModelBooks();
            
            // Initialize the list view
            InitializeListView();
            
            // Add selection listener to the list view
            // So that when a book is selected, its details are displayed in the text boxes
            AddListViewSelectionListener();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing data: {ex.Message}");
        }
    }

    private async Task InitModelBooks()
    {
        try
        {
            // Fetch all books from the service and bind them to the list view
            var booksList = (await _service.GetAllBooksAsync())?.ToList() ?? new List<Book>();
            
            // Set the data source for the list view
            _booksBindingSource.DataSource = booksList;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error fetching books: {ex.Message}");
        }
    }
    
    private void InitializeListView()
    {
        // Clear the existing items in the list view
        listViewBooks.Items.Clear();
        
        foreach(var item in _booksBindingSource.List)
        {
            if (item is Book book)
            {
                // Create a new ListViewItem for each book
                var listViewItem = new ListViewItem(new[]
                {
                    book.Title,
                    book.Author,
                    book.Quantity.ToString(),
                    book.Genre,
                    book.Price.ToString("F2"),
                    book.YearPublished.ToString()
                });

                // Set color based on quantity
                if (book.Quantity == 0)
                {
                    listViewItem.BackColor = Color.LightCoral;
                }
                
                // Add the ListViewItem to the list view
                listViewBooks.Items.Add(listViewItem);
            }
        }
    }
    
    private void AddListViewSelectionListener()
    {
        // Add an event handler for the SelectedIndexChanged event of the list view
        // This event is triggered when the user selects a different book in the list view
        // The event handler updates the text boxes with the details of the selected book
        listViewBooks.SelectedIndexChanged += (sender, e) =>
        {
            if (listViewBooks.SelectedItems.Count <= 0) return;
            if (_booksBindingSource.List[listViewBooks.SelectedItems[0].Index] is Book selectedBook)
            {
                UpdateTextBoxes(selectedBook);
            }
        };
    }
    
    private void UpdateTextBoxes(Book book)
    {
        // Update the text boxes with the details of the selected book
        
        textBoxTitle.Text = book.Title;
        textBoxAuthor.Text = book.Author;
        textBoxQuantity.Text = book.Quantity.ToString();
        textBoxGenre.Text = book.Genre;
        textBoxPrice.Text = book.Price.ToString("F2");
        textBoxYear.Text = book.YearPublished.ToString();
        
        textBoxBookTitle.Text = book.Title;
        textBoxBookAuthor.Text = book.Author;
    }
    /**
     * Event handler for the "Delete" button click event.
     * It deletes the selected book from the list view and updates the data source.
     * If no book is selected, it shows a message box to prompt the user to select a book.
     * If an error occurs during deletion, it shows an error message.
     */
    
    private async void buttonDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (listViewBooks.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select a book to delete.");
                return;
            }
            
            // Geting the selected book from the binding source
            // and delete it using the service
            if (_booksBindingSource.List[listViewBooks.SelectedItems[0].Index] is Book selectedBook)
            {
                await _service.DeleteBookAsync(selectedBook.Id);
                await InitModelBooks();
                InitializeListView();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting book: {ex.Message}");
        }
    }

    /**
     * Event handler for the "Add" button click event.
     * It adds a new book to the list view and updates the data source.
     * If any input field is empty, it shows a message box to prompt the user to fill it.
     * If an error occurs during addition, it shows an error message.
     */
    private async void buttonAdd_Click(object sender, EventArgs e)
    {
        try
        {
            // Validate input fields
            if(textBoxTitle.Text == "")
            {
                MessageBox.Show("Please enter a title.");
                return;
            }
            if(textBoxAuthor.Text == "")
            {
                MessageBox.Show("Please enter an author.");
                return;
            }
            if(textBoxQuantity.Text == "")
            {
                MessageBox.Show("Please enter a quantity.");
                return;
            }
            if(textBoxGenre.Text == "")
            {
                MessageBox.Show("Please enter a genre.");
                return;
            }
            if(textBoxPrice.Text == "")
            {
                MessageBox.Show("Please enter a price.");
                return;
            }
            if(textBoxYear.Text == "")
            {
                MessageBox.Show("Please enter a year.");
                return;
            }
        
            // Creating a new book object with the input data
            var title = textBoxTitle.Text;
            var author = textBoxAuthor.Text;
            var quantity = int.Parse(textBoxQuantity.Text);
            var genre = textBoxGenre.Text;
            var price = float.Parse(textBoxPrice.Text);
            var yearPublished = int.Parse(textBoxYear.Text);

            var newBook = new Book(title, author, quantity, genre, price, yearPublished);
            try
            {
                // Adding the new book to the database using the service
                await _service.CreateBookAsync(newBook);
            
                MessageBox.Show($"Book {newBook.Title} successfully created.");
                ClearTextBoxes();
            
                // Refreshing the list view to show the updated list of books
                await InitModelBooks();
                InitializeListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding book: {ex.Message}");
        }
    }
    
    
    /**
     * Function for clearing the text boxes after making a change.
     */
    private void ClearTextBoxes()
    {
        textBoxTitle.Clear();
        textBoxAuthor.Clear();
        textBoxQuantity.Clear();
        textBoxGenre.Clear();
        textBoxPrice.Clear();
        textBoxYear.Clear();
        
        textBoxBookTitle.Clear();
        textBoxBookAuthor.Clear();
    }

    /**
     * Event handler for the "Update" button click event.
     * If any input field is empty, it shows a message box to prompt the user to fill it.
     * Searches for the book by title and author to set the id.
     * If an error occurs during update, it shows an error message.
     * Updates the book in the database using the service.
     */
    private async void buttonUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            // Validate input fields
            if(textBoxTitle.Text == "")
            {
                MessageBox.Show("Please enter a title.");
                return;
            }
            if(textBoxAuthor.Text == "")
            {
                MessageBox.Show("Please enter an author.");
                return;
            }
            if(textBoxQuantity.Text == "")
            {
                MessageBox.Show("Please enter a quantity.");
                return;
            }
            if(textBoxGenre.Text == "")
            {
                MessageBox.Show("Please enter a genre.");
                return;
            }
            if(textBoxPrice.Text == "")
            {
                MessageBox.Show("Please enter a price.");
                return;
            }
            if(textBoxYear.Text == "")
            {
                MessageBox.Show("Please enter a year.");
                return;
            }
        
            // Creating a new book object with the input data
            var title = textBoxTitle.Text;
            var author = textBoxAuthor.Text;
            var quantity = int.Parse(textBoxQuantity.Text);
            var genre = textBoxGenre.Text;
            var price = float.Parse(textBoxPrice.Text);
            var yearPublished = int.Parse(textBoxYear.Text);

            // Searching for the book by title and author so we can set the id
            var book = await _service.GetBookByTitleAuthorAsync(title, author);
            var updatedBook = new Book(title, author, quantity, genre, price, yearPublished);
            updatedBook.Id = book.Id;
            try
            {
                // Updating the book in the database using the service
                await _service.UpdateBookAsync(updatedBook);
                MessageBox.Show($"Book {updatedBook.Title} successfully updated.");
                
                // Refreshing the list view to show the updated list of books
                ClearTextBoxes();
                await InitModelBooks();
                InitializeListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating book: {ex.Message}");
        }
    }

    
    /**
     * Event handler for the "Lend" button click event.
    * If any input field is empty, it shows a message box to prompt the user to fill it.
    * If an error occurs during lending, it shows an error message.
    * Lends the book in the database using the service.
     */
    private async void buttonLend_Click(object sender, EventArgs e)
    {
        try
        {
            // Validate input fields
            if (listViewBooks.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select a book to lend.");
                return;
            }

            if (textBoxBookTitle.Text == "")
            {
                MessageBox.Show("Please enter a book title.");
                return;
            }
        
            if (textBoxBookAuthor.Text == "")
            {
                MessageBox.Show("Please enter a book author.");
                return;
            }
        
            var bookTitle = textBoxBookTitle.Text;
            var bookAuthor = textBoxBookAuthor.Text;
        
            // Validate date range
            if(dateTimePickerFrom.Value > dateTimePickerTo.Value)
            {
                MessageBox.Show("The start date must be before the end date.");
                return;
            }
        
            var startDate = dateTimePickerFrom.Value;
            var endDate = dateTimePickerTo.Value;
        
            // Searching for the book by title and author so we can set the book id of the lending
            var book = await _service.GetBookByTitleAuthorAsync(bookTitle, bookAuthor);
            var lend = new Lending(book.Id,startDate,endDate);
            
            try
            {
                // Lend the book in the database using the service
                await _service.LendBookAsync(lend,startDate, endDate);
                MessageBox.Show($"Book {book.Title} successfully lended.");
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error lending book: {ex.Message}");
        }
    }

    /**
     * Event handler for the "Search" button click event.
     * If no criteria is selected, it shows a message box to prompt the user to select one.
     * If an error occurs during search, it shows an error message.
     * Searches for books by title, author or year using the service.
     */
    private async void buttonSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (textBoxSearch.Text == "")
            {
                MessageBox.Show("Please enter a title, author or year to search by.");
                return;
            
            }

            // Check if exactly one radio button is checked
            var count = 0;
            if (radioButtonAuthor.Checked)
                count++;
            if (radioButtonTitle.Checked )
                count++;
            if(radioButtonYear.Checked)
                count++;

            if (count != 1)
            {
                MessageBox.Show("Please select a criteria to search by.");
                return;
            }
        
            if (radioButtonAuthor.Checked)
            {
                // Search for books by author
                var author = textBoxSearch.Text;
                var booksList = await _service.GetAllBooksByAuthorAsync(author);
                
                // Set the data source for the list view
                _booksBindingSource.DataSource = booksList;
                // Refresh the list view to display the search results
                InitializeListView();
                
                // Clear the search text box and uncheck the radio button
                radioButtonAuthor.Checked = false;
                textBoxSearch.Text = "";
            }
            else if (radioButtonTitle.Checked)
            {
                // Search for books by title
                var title = textBoxSearch.Text;
                var booksList =await _service.GetAllBooksByTitleAsync(title);
                
                // Set the data source for the list view
                _booksBindingSource.DataSource = booksList;
                // Refresh the list view to display the search results
                InitializeListView();
                
                // Clear the search text box and uncheck the radio button
                radioButtonTitle.Checked = false;
                textBoxSearch.Text = "";

            }
            else if (radioButtonYear.Checked)
            {
                // Search for books by year
                var year = int.Parse(textBoxSearch.Text);
                
                // Check if the year is valid
                if (year < 0)
                {
                    MessageBox.Show("Please enter a valid year.");
                    return;
                }
                
                var booksList =await _service.GetAllBooksByYearAsync(year);
                
                // Set the data source for the list view
                _booksBindingSource.DataSource = booksList;

                // Refresh the list view to display the search results
                InitializeListView();
                
                // Clear the search text box and uncheck the radio button
                radioButtonYear.Checked = false;
                textBoxSearch.Text = "";

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching for books: {ex.Message}");
        }
    }

    /**
     * Event handler for the "Refresh" button click event.
     * It refreshes the list view with the latest data from the database.
     * If an error occurs during refresh, it shows an error message.
     */
    private async void buttonRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            await InitModelBooks();
            InitializeListView();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error refreshing books: {ex.Message}");
        }
    }


    /**
     * Event handler for the "Search Available" button click event.
     * It searches for available books in the specified date range.
     * If the start date is after the end date, it shows a message box to prompt the user to correct it.
     * If an error occurs during search, it shows an error message.
     */
    private async void buttonSearchAvailable_Click(object sender, EventArgs e)
    {
        try
        {
            if(dateTimePickerFrom.Value > dateTimePickerTo.Value)
            {
                MessageBox.Show("The start date must be before the end date.");
                return;
            }
    
            var startDate = dateTimePickerFrom.Value;
            var endDate = dateTimePickerTo.Value;
    
            try
            {
                // Get available books for the specified period
                var availableBooks = await _service.GetAvailableBooksInPeriodAsync(startDate, endDate);
        
                // Update the binding source with the available books
                _booksBindingSource.DataSource = availableBooks;
        
                // Refresh the list view to display the available books
                InitializeListView();
        
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for available books: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching for available books to lend: {ex.Message}");
        }
    }
}