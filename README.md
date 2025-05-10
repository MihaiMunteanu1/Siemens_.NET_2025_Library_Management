
In this app, I’m using PostgreSQL as the database to store books and lendings. I’ve hidden my password in the main() function 

When you open the project, you’ll see the main view.
There is a table displaying all the books along with their properties.

Above the table, I’ve implemented a search functionality based on specific criteria (title, author, year). 
There are also two buttons: Search and Refresh, the latter resetting the table to its default state.

To search, fill in the textbox, select only one criterion, and press the Search button. The table will then display the filtered results.
![Screenshot 2025-05-10 214005](https://github.com/user-attachments/assets/c20ffe99-f971-442d-9b86-7d3b8a19a44c)

Search by criteria functionality
![Screenshot 2025-05-10 214820](https://github.com/user-attachments/assets/7c9ef796-f1c0-4555-9b56-0f50037dcd1a)

Below the table, I’ve added the Delete, Add, and Update functionalities.

To delete a book, select it from the list by clicking on its title, then press the Delete button. The list will update accordingly.

To add or update a book, either select one from the list (its details will appear in the textboxes) or enter the details manually.
Then, click Add to add a new book or Update to modify an existing one.

Create and Update functionalities
![Screenshot 2025-05-10 214919](https://github.com/user-attachments/assets/9b4b9049-bd48-4066-91bc-b165aa0fb6c8)


If a book is out of stock, its row will be highlighted in red.
![Screenshot 2025-05-10 215408](https://github.com/user-attachments/assets/4460ea53-b68a-4d49-88cd-5704c8571abc)

On the right side of the table, I’ve implemented the lending functionality.

First, select the From and Until dates for the borrowing period.
Then, click the Search Available Books button to view the books available for lending.
After selecting a book by clicking its title, the title and author will appear in the textboxes. Finally, click Lend Book to complete the process.
