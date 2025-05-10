using BooksManagement.model;
using BooksManagement.repository.interfaces;
using BooksManagement.service;

namespace BooksManagement.controller;

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
        _service = service;
        try
        {
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
            await InitModelBooks();
            InitializeListView();
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
            var booksList = (await _service.GetAllBooksAsync())?.ToList() ?? new List<Book>();
            _booksBindingSource.DataSource = booksList;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error fetching books: {ex.Message}");
        }
    }
    
    private void InitializeListView()
    {
        listViewBooks.Items.Clear();
        foreach(var item in _booksBindingSource.List)
        {
            if (item is Book book)
            {
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
                
                listViewBooks.Items.Add(listViewItem);
            }
        }
    }
    
    private void AddListViewSelectionListener()
    {
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
        textBoxTitle.Text = book.Title;
        textBoxAuthor.Text = book.Author;
        textBoxQuantity.Text = book.Quantity.ToString();
        textBoxGenre.Text = book.Genre;
        textBoxPrice.Text = book.Price.ToString("F2");
        textBoxYear.Text = book.YearPublished.ToString();
        
        textBoxBookTitle.Text = book.Title;
        textBoxBookAuthor.Text = book.Author;
    }
    
    private void label1_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    /**
     * Event handler for the "Delete" button click event.
     */
    private async void buttonDelete_Click(object sender, EventArgs e)
    {
        if (listViewBooks.SelectedItems.Count <= 0)
        {
            MessageBox.Show("Please select a book to delete.");
            return;
        }
        if (_booksBindingSource.List[listViewBooks.SelectedItems[0].Index] is Book selectedBook)
        {
            await _service.DeleteBookAsync(selectedBook.Id);
            await InitModelBooks();
            InitializeListView();
        }
    }

    private async void buttonAdd_Click(object sender, EventArgs e)
    {
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
        
        
        var title = textBoxTitle.Text;
        var author = textBoxAuthor.Text;
        var quantity = int.Parse(textBoxQuantity.Text);
        var genre = textBoxGenre.Text;
        var price = float.Parse(textBoxPrice.Text);
        var yearPublished = int.Parse(textBoxYear.Text);

        var newBook = new Book(title, author, quantity, genre, price, yearPublished);
        try
        {
            await _service.CreateBookAsync(newBook);
            MessageBox.Show($"Book {newBook.Title} successfully created.");
            ClearTextBoxes();
            await InitModelBooks();
            InitializeListView();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
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

    private async void buttonUpdate_Click(object sender, EventArgs e)
    {
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
        
        var title = textBoxTitle.Text;
        var author = textBoxAuthor.Text;
        var quantity = int.Parse(textBoxQuantity.Text);
        var genre = textBoxGenre.Text;
        var price = float.Parse(textBoxPrice.Text);
        var yearPublished = int.Parse(textBoxYear.Text);

        var book = await _service.GetBookByTitleAuthorAsync(title, author);
        var updatedBook = new Book(title, author, quantity, genre, price, yearPublished);
        updatedBook.Id = book.Id;
        try
        {
            await _service.UpdateBookAsync(updatedBook);
            MessageBox.Show($"Book {updatedBook.Title} successfully updated.");
            ClearTextBoxes();
            await InitModelBooks();
            InitializeListView();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    

    private async void buttonLend_Click(object sender, EventArgs e)
    {
        try
        {
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
        
            if(dateTimePickerFrom.Value > dateTimePickerTo.Value)
            {
                MessageBox.Show("The start date must be before the end date.");
                return;
            }
        
            var startDate = dateTimePickerFrom.Value;
            var endDate = dateTimePickerTo.Value;
        
            var book = await _service.GetBookByTitleAuthorAsync(bookTitle, bookAuthor);
            var lend = new Lending(book.Id,startDate,endDate);
            try
            {
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

    private async void buttonSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (textBoxSearch.Text == "")
            {
                MessageBox.Show("Please enter a title, author or year to search by.");
                return;
            
            }

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
                var author = textBoxSearch.Text;
                var booksList = await _service.GetAllBooksByAuthorAsync(author);
                _booksBindingSource.DataSource = booksList;
                InitializeListView();
                radioButtonAuthor.Checked = false;
                textBoxSearch.Text = "";
            }
            else if (radioButtonTitle.Checked)
            {
                var title = textBoxSearch.Text;
                var booksList =await _service.GetAllBooksByTitleAsync(title);
                _booksBindingSource.DataSource = booksList;
                InitializeListView();
                radioButtonTitle.Checked = false;
                textBoxSearch.Text = "";

            }
            else if (radioButtonYear.Checked)
            {
                var year = int.Parse(textBoxSearch.Text);
                var booksList =await _service.GetAllBooksByYearAsync(year);
                _booksBindingSource.DataSource = booksList;
                InitializeListView();
                radioButtonYear.Checked = false;
                textBoxSearch.Text = "";

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching for books: {ex.Message}");
        }
    }

    private async void buttonRefresh_Click(object sender, EventArgs e)
    {
        await InitModelBooks();
        InitializeListView();
    }


    private async void buttonSearchAvailable_Click(object sender, EventArgs e)
    {
        var bookTitle = textBoxBookTitle.Text;
        var bookAuthor = textBoxBookAuthor.Text;
    
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
}