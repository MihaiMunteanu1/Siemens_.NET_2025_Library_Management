
In this app i`m using PostgreSQL as the database to store the books and the lendings, so here i hid my password on main() function.

When opening the project you will see the main view.
There is table where you can see all the books and there properties.
Above the table is where i implemented the searching by some criterias(title, author, year) functionality, following
the Search Button and the Refresh Button which brings the list to normal.

To search you need to fill the TextBox and select only one criteria, then you can press the Search button and the list 
will be updated with the requested informations.
![Screenshot 2025-05-10 214005](https://github.com/user-attachments/assets/c20ffe99-f971-442d-9b86-7d3b8a19a44c)

Search by some criterias functionality
![Screenshot 2025-05-10 214820](https://github.com/user-attachments/assets/7c9ef796-f1c0-4555-9b56-0f50037dcd1a)

Under the table is where i implemented the Delete, Add and Update functionalities.

To delete you need to select one book from the list( you can select it by clicking on it`s title), then you can pressed the delete button
and the list will be updated without the deleted book.

To add or update a book, you can either select one from the list and it's details will pe written in the textboxes or you can write them by hand.
After that, you click Add to add a book to the library or update to update it`s properties.
Create and Update functionalities
![Screenshot 2025-05-10 214919](https://github.com/user-attachments/assets/9b4b9049-bd48-4066-91bc-b165aa0fb6c8)


When a book is out of stock for lending, it`s background will turn red.
![Screenshot 2025-05-10 215408](https://github.com/user-attachments/assets/4460ea53-b68a-4d49-88cd-5704c8571abc)

On the right of the table is where i designed the lending functionality.
At first you can select the From date and until date you want to borrow a book and then you can click 'Search Available Books' button to see 
which ones you can borrow. Then again by clicking one`s title theres title and author will be written in the textboxes and then you can click
'Lend book' to borrow it.
