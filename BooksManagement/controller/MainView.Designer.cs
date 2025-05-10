using System.ComponentModel;

namespace BooksManagement.controller;

partial class MainView
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new System.Windows.Forms.Label();
        panel1 = new System.Windows.Forms.Panel();
        listViewBooks = new System.Windows.Forms.ListView();
        columnHeader1 = new System.Windows.Forms.ColumnHeader();
        columnHeader2 = new System.Windows.Forms.ColumnHeader();
        columnHeader3 = new System.Windows.Forms.ColumnHeader();
        columnHeader4 = new System.Windows.Forms.ColumnHeader();
        columnHeader5 = new System.Windows.Forms.ColumnHeader();
        columnHeader6 = new System.Windows.Forms.ColumnHeader();
        textBoxTitle = new System.Windows.Forms.TextBox();
        textBoxAuthor = new System.Windows.Forms.TextBox();
        textBoxQuantity = new System.Windows.Forms.TextBox();
        textBoxPrice = new System.Windows.Forms.TextBox();
        textBoxYear = new System.Windows.Forms.TextBox();
        buttonAdd = new System.Windows.Forms.Button();
        buttonUpdate = new System.Windows.Forms.Button();
        buttonDelete = new System.Windows.Forms.Button();
        dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
        dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
        buttonLend = new System.Windows.Forms.Button();
        panel2 = new System.Windows.Forms.Panel();
        buttonSearchAvailable = new System.Windows.Forms.Button();
        label12 = new System.Windows.Forms.Label();
        label11 = new System.Windows.Forms.Label();
        label10 = new System.Windows.Forms.Label();
        textBoxBookAuthor = new System.Windows.Forms.TextBox();
        label7 = new System.Windows.Forms.Label();
        textBoxBookTitle = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label8 = new System.Windows.Forms.Label();
        label9 = new System.Windows.Forms.Label();
        textBoxGenre = new System.Windows.Forms.TextBox();
        textBoxSearch = new System.Windows.Forms.TextBox();
        radioButtonTitle = new System.Windows.Forms.RadioButton();
        radioButtonAuthor = new System.Windows.Forms.RadioButton();
        radioButtonYear = new System.Windows.Forms.RadioButton();
        buttonSearch = new System.Windows.Forms.Button();
        buttonRefresh = new System.Windows.Forms.Button();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(900, 38);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(555, 91);
        label1.TabIndex = 0;
        label1.Text = "Admin Controller";
        label1.Click += label1_Click;
        // 
        // panel1
        // 
        panel1.BackColor = System.Drawing.Color.Linen;
        panel1.Controls.Add(label1);
        panel1.Location = new System.Drawing.Point(3, -1);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(2341, 172);
        panel1.TabIndex = 1;
        // 
        // listViewBooks
        // 
        listViewBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
        listViewBooks.Location = new System.Drawing.Point(79, 327);
        listViewBooks.Name = "listViewBooks";
        listViewBooks.Size = new System.Drawing.Size(1463, 596);
        listViewBooks.TabIndex = 2;
        listViewBooks.UseCompatibleStateImageBehavior = false;
        listViewBooks.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Name = "columnHeader1";
        columnHeader1.Text = "Title";
        columnHeader1.Width = 104;
        // 
        // columnHeader2
        // 
        columnHeader2.Name = "columnHeader2";
        columnHeader2.Text = "Author";
        columnHeader2.Width = 124;
        // 
        // columnHeader3
        // 
        columnHeader3.Name = "columnHeader3";
        columnHeader3.Text = "Quantity";
        columnHeader3.Width = 134;
        // 
        // columnHeader4
        // 
        columnHeader4.Name = "columnHeader4";
        columnHeader4.Text = "Genre";
        columnHeader4.Width = 129;
        // 
        // columnHeader5
        // 
        columnHeader5.Name = "columnHeader5";
        columnHeader5.Text = "Price";
        columnHeader5.Width = 105;
        // 
        // columnHeader6
        // 
        columnHeader6.Name = "columnHeader6";
        columnHeader6.Text = "PublishedYear";
        columnHeader6.Width = 343;
        // 
        // textBoxTitle
        // 
        textBoxTitle.Location = new System.Drawing.Point(110, 1126);
        textBoxTitle.Name = "textBoxTitle";
        textBoxTitle.Size = new System.Drawing.Size(327, 43);
        textBoxTitle.TabIndex = 3;
        // 
        // textBoxAuthor
        // 
        textBoxAuthor.Location = new System.Drawing.Point(508, 1126);
        textBoxAuthor.Name = "textBoxAuthor";
        textBoxAuthor.Size = new System.Drawing.Size(280, 43);
        textBoxAuthor.TabIndex = 4;
        // 
        // textBoxQuantity
        // 
        textBoxQuantity.Location = new System.Drawing.Point(861, 1126);
        textBoxQuantity.Name = "textBoxQuantity";
        textBoxQuantity.Size = new System.Drawing.Size(114, 43);
        textBoxQuantity.TabIndex = 5;
        // 
        // textBoxPrice
        // 
        textBoxPrice.Location = new System.Drawing.Point(1285, 1126);
        textBoxPrice.Name = "textBoxPrice";
        textBoxPrice.Size = new System.Drawing.Size(130, 43);
        textBoxPrice.TabIndex = 6;
        // 
        // textBoxYear
        // 
        textBoxYear.Location = new System.Drawing.Point(1478, 1126);
        textBoxYear.Name = "textBoxYear";
        textBoxYear.Size = new System.Drawing.Size(193, 43);
        textBoxYear.TabIndex = 7;
        // 
        // buttonAdd
        // 
        buttonAdd.Location = new System.Drawing.Point(580, 1235);
        buttonAdd.Name = "buttonAdd";
        buttonAdd.Size = new System.Drawing.Size(249, 70);
        buttonAdd.TabIndex = 8;
        buttonAdd.Text = "Add";
        buttonAdd.UseVisualStyleBackColor = true;
        buttonAdd.Click += buttonAdd_Click;
        // 
        // buttonUpdate
        // 
        buttonUpdate.Location = new System.Drawing.Point(947, 1235);
        buttonUpdate.Name = "buttonUpdate";
        buttonUpdate.Size = new System.Drawing.Size(249, 70);
        buttonUpdate.TabIndex = 9;
        buttonUpdate.Text = "Update";
        buttonUpdate.UseVisualStyleBackColor = true;
        buttonUpdate.Click += buttonUpdate_Click;
        // 
        // buttonDelete
        // 
        buttonDelete.Location = new System.Drawing.Point(755, 944);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new System.Drawing.Size(249, 70);
        buttonDelete.TabIndex = 10;
        buttonDelete.Text = "Delete";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += buttonDelete_Click;
        // 
        // dateTimePickerFrom
        // 
        dateTimePickerFrom.Location = new System.Drawing.Point(135, 293);
        dateTimePickerFrom.Name = "dateTimePickerFrom";
        dateTimePickerFrom.Size = new System.Drawing.Size(454, 43);
        dateTimePickerFrom.TabIndex = 11;
        // 
        // dateTimePickerTo
        // 
        dateTimePickerTo.Location = new System.Drawing.Point(130, 415);
        dateTimePickerTo.Name = "dateTimePickerTo";
        dateTimePickerTo.Size = new System.Drawing.Size(459, 43);
        dateTimePickerTo.TabIndex = 12;
        // 
        // buttonLend
        // 
        buttonLend.Location = new System.Drawing.Point(426, 495);
        buttonLend.Name = "buttonLend";
        buttonLend.Size = new System.Drawing.Size(249, 70);
        buttonLend.TabIndex = 13;
        buttonLend.Text = "Lend Book";
        buttonLend.UseVisualStyleBackColor = true;
        buttonLend.Click += buttonLend_Click;
        // 
        // panel2
        // 
        panel2.BackColor = System.Drawing.Color.OldLace;
        panel2.Controls.Add(buttonSearchAvailable);
        panel2.Controls.Add(label12);
        panel2.Controls.Add(label11);
        panel2.Controls.Add(label10);
        panel2.Controls.Add(textBoxBookAuthor);
        panel2.Controls.Add(label7);
        panel2.Controls.Add(textBoxBookTitle);
        panel2.Controls.Add(buttonLend);
        panel2.Controls.Add(dateTimePickerFrom);
        panel2.Controls.Add(dateTimePickerTo);
        panel2.Location = new System.Drawing.Point(1578, 327);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(729, 596);
        panel2.TabIndex = 14;
        // 
        // buttonSearchAvailable
        // 
        buttonSearchAvailable.Location = new System.Drawing.Point(60, 495);
        buttonSearchAvailable.Name = "buttonSearchAvailable";
        buttonSearchAvailable.Size = new System.Drawing.Size(302, 70);
        buttonSearchAvailable.TabIndex = 30;
        buttonSearchAvailable.Text = "Search Available Books";
        buttonSearchAvailable.UseVisualStyleBackColor = true;
        buttonSearchAvailable.Click += buttonSearchAvailable_Click;
        // 
        // label12
        // 
        label12.Location = new System.Drawing.Point(309, 370);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(261, 42);
        label12.TabIndex = 24;
        label12.Text = "Until:";
        // 
        // label11
        // 
        label11.Location = new System.Drawing.Point(309, 248);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(261, 42);
        label11.TabIndex = 23;
        label11.Text = "From:";
        // 
        // label10
        // 
        label10.Location = new System.Drawing.Point(280, 127);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(261, 42);
        label10.TabIndex = 22;
        label10.Text = "Book`s Author";
        // 
        // textBoxBookAuthor
        // 
        textBoxBookAuthor.Location = new System.Drawing.Point(130, 181);
        textBoxBookAuthor.Name = "textBoxBookAuthor";
        textBoxBookAuthor.Size = new System.Drawing.Size(459, 43);
        textBoxBookAuthor.TabIndex = 21;
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(280, 15);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(261, 42);
        label7.TabIndex = 20;
        label7.Text = "Book`s Title";
        // 
        // textBoxBookTitle
        // 
        textBoxBookTitle.Location = new System.Drawing.Point(130, 60);
        textBoxBookTitle.Name = "textBoxBookTitle";
        textBoxBookTitle.Size = new System.Drawing.Size(459, 43);
        textBoxBookTitle.TabIndex = 15;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(110, 1081);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(121, 42);
        label2.TabIndex = 15;
        label2.Text = "Title:";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(508, 1081);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(121, 42);
        label3.TabIndex = 16;
        label3.Text = "Author:";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(854, 1081);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(139, 42);
        label4.TabIndex = 17;
        label4.Text = "Quantity:";
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(1285, 1081);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(121, 42);
        label5.TabIndex = 18;
        label5.Text = "Price:";
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(1463, 1081);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(208, 42);
        label6.TabIndex = 19;
        label6.Text = "Published Year:";
        // 
        // label8
        // 
        label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label8.Location = new System.Drawing.Point(79, 198);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(175, 42);
        label8.TabIndex = 21;
        label8.Text = "Search by:";
        // 
        // label9
        // 
        label9.Location = new System.Drawing.Point(1050, 1081);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(121, 42);
        label9.TabIndex = 23;
        label9.Text = "Genre:";
        // 
        // textBoxGenre
        // 
        textBoxGenre.Location = new System.Drawing.Point(1050, 1126);
        textBoxGenre.Name = "textBoxGenre";
        textBoxGenre.Size = new System.Drawing.Size(196, 43);
        textBoxGenre.TabIndex = 22;
        // 
        // textBoxSearch
        // 
        textBoxSearch.Location = new System.Drawing.Point(79, 248);
        textBoxSearch.Name = "textBoxSearch";
        textBoxSearch.Size = new System.Drawing.Size(207, 43);
        textBoxSearch.TabIndex = 24;
        // 
        // radioButtonTitle
        // 
        radioButtonTitle.Location = new System.Drawing.Point(309, 177);
        radioButtonTitle.Name = "radioButtonTitle";
        radioButtonTitle.Size = new System.Drawing.Size(113, 39);
        radioButtonTitle.TabIndex = 25;
        radioButtonTitle.TabStop = true;
        radioButtonTitle.Text = "Title";
        radioButtonTitle.UseVisualStyleBackColor = true;
        // 
        // radioButtonAuthor
        // 
        radioButtonAuthor.Location = new System.Drawing.Point(309, 222);
        radioButtonAuthor.Name = "radioButtonAuthor";
        radioButtonAuthor.Size = new System.Drawing.Size(140, 39);
        radioButtonAuthor.TabIndex = 26;
        radioButtonAuthor.TabStop = true;
        radioButtonAuthor.Text = "Author";
        radioButtonAuthor.UseVisualStyleBackColor = true;
        // 
        // radioButtonYear
        // 
        radioButtonYear.Location = new System.Drawing.Point(309, 271);
        radioButtonYear.Name = "radioButtonYear";
        radioButtonYear.Size = new System.Drawing.Size(113, 39);
        radioButtonYear.TabIndex = 27;
        radioButtonYear.TabStop = true;
        radioButtonYear.Text = "Year";
        radioButtonYear.UseVisualStyleBackColor = true;
        // 
        // buttonSearch
        // 
        buttonSearch.Location = new System.Drawing.Point(475, 189);
        buttonSearch.Name = "buttonSearch";
        buttonSearch.Size = new System.Drawing.Size(165, 51);
        buttonSearch.TabIndex = 28;
        buttonSearch.Text = "Search";
        buttonSearch.UseVisualStyleBackColor = true;
        buttonSearch.Click += buttonSearch_Click;
        // 
        // buttonRefresh
        // 
        buttonRefresh.Location = new System.Drawing.Point(475, 248);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new System.Drawing.Size(165, 51);
        buttonRefresh.TabIndex = 29;
        buttonRefresh.Text = "Refresh";
        buttonRefresh.UseVisualStyleBackColor = true;
        buttonRefresh.Click += buttonRefresh_Click;
        // 
        // MainView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.ButtonHighlight;
        ClientSize = new System.Drawing.Size(2344, 1355);
        Controls.Add(buttonRefresh);
        Controls.Add(buttonSearch);
        Controls.Add(radioButtonYear);
        Controls.Add(radioButtonAuthor);
        Controls.Add(radioButtonTitle);
        Controls.Add(textBoxSearch);
        Controls.Add(label9);
        Controls.Add(textBoxGenre);
        Controls.Add(label8);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(buttonDelete);
        Controls.Add(buttonUpdate);
        Controls.Add(buttonAdd);
        Controls.Add(textBoxYear);
        Controls.Add(textBoxPrice);
        Controls.Add(textBoxQuantity);
        Controls.Add(textBoxAuthor);
        Controls.Add(textBoxTitle);
        Controls.Add(listViewBooks);
        Controls.Add(panel1);
        Controls.Add(panel2);
        Text = "MainView";
        panel1.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button buttonSearchAvailable;

    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;

    private System.Windows.Forms.Button buttonRefresh;

    private System.Windows.Forms.TextBox textBoxSearch;
    private System.Windows.Forms.RadioButton radioButtonTitle;
    private System.Windows.Forms.RadioButton radioButtonAuthor;
    private System.Windows.Forms.RadioButton radioButtonYear;
    private System.Windows.Forms.Button buttonSearch;

    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox textBoxBookAuthor;

    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox textBoxGenre;

    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ColumnHeader columnHeader6;
    private System.Windows.Forms.TextBox textBoxTitle;
    private System.Windows.Forms.TextBox textBoxAuthor;
    private System.Windows.Forms.TextBox textBoxQuantity;
    private System.Windows.Forms.TextBox textBoxPrice;
    private System.Windows.Forms.TextBox textBoxYear;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.Button buttonUpdate;
    private System.Windows.Forms.Button buttonDelete;
    private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
    private System.Windows.Forms.DateTimePicker dateTimePickerTo;
    private System.Windows.Forms.Button buttonLend;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox textBoxBookTitle;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.ColumnHeader columnHeader1;

    private System.Windows.Forms.ListView listViewBooks;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.Label label1;

    #endregion
}