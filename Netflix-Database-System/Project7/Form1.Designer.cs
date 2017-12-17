namespace Project7
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Load = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AllMovies = new System.Windows.Forms.Button();
            this.allUseres = new System.Windows.Forms.Button();
            this.GetMovieRiviews = new System.Windows.Forms.Button();
            this.GetUserReviews = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AverageRating = new System.Windows.Forms.Button();
            this.EachRating = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.txtMovieID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LookUpMovieID = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.LookUpUserID = new System.Windows.Forms.Button();
            this.TopNReviewedMovies = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(363, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(388, 316);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(13, 13);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(81, 39);
            this.Load.TabIndex = 1;
            this.Load.Text = "Load Data Base";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(363, 325);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(388, 26);
            this.txtFileName.TabIndex = 2;
            this.txtFileName.Text = "netflix.mdf";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Select Movie"});
            this.comboBox1.Location = new System.Drawing.Point(141, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Select User"});
            this.comboBox2.Location = new System.Drawing.Point(141, 74);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Movies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Users";
            // 
            // AllMovies
            // 
            this.AllMovies.Location = new System.Drawing.Point(13, 58);
            this.AllMovies.Name = "AllMovies";
            this.AllMovies.Size = new System.Drawing.Size(75, 23);
            this.AllMovies.TabIndex = 7;
            this.AllMovies.Text = "All Movies";
            this.AllMovies.UseVisualStyleBackColor = true;
            this.AllMovies.Click += new System.EventHandler(this.AllMovies_Click);
            // 
            // allUseres
            // 
            this.allUseres.Location = new System.Drawing.Point(13, 85);
            this.allUseres.Name = "allUseres";
            this.allUseres.Size = new System.Drawing.Size(75, 23);
            this.allUseres.TabIndex = 8;
            this.allUseres.Text = "All Users";
            this.allUseres.UseVisualStyleBackColor = true;
            this.allUseres.Click += new System.EventHandler(this.allUseres_Click);
            // 
            // GetMovieRiviews
            // 
            this.GetMovieRiviews.Location = new System.Drawing.Point(13, 115);
            this.GetMovieRiviews.Name = "GetMovieRiviews";
            this.GetMovieRiviews.Size = new System.Drawing.Size(75, 39);
            this.GetMovieRiviews.TabIndex = 9;
            this.GetMovieRiviews.Text = "Get Movie Reviews";
            this.GetMovieRiviews.UseVisualStyleBackColor = true;
            this.GetMovieRiviews.Click += new System.EventHandler(this.GetMovieRiviews_Click);
            // 
            // GetUserReviews
            // 
            this.GetUserReviews.Location = new System.Drawing.Point(13, 161);
            this.GetUserReviews.Name = "GetUserReviews";
            this.GetUserReviews.Size = new System.Drawing.Size(75, 44);
            this.GetUserReviews.TabIndex = 10;
            this.GetUserReviews.Text = "Get User Reviews";
            this.GetUserReviews.UseVisualStyleBackColor = true;
            this.GetUserReviews.Click += new System.EventHandler(this.GetUserReviews_Click);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(13, 212);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(75, 23);
            this.Insert.TabIndex = 11;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Select Number",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox3.Location = new System.Drawing.Point(141, 131);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rating";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 14;
            this.button1.Text = "Top-N Movies";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Top-N Users";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 298);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AverageRating
            // 
            this.AverageRating.Location = new System.Drawing.Point(115, 168);
            this.AverageRating.Name = "AverageRating";
            this.AverageRating.Size = new System.Drawing.Size(94, 37);
            this.AverageRating.TabIndex = 17;
            this.AverageRating.Text = "Average Rating";
            this.AverageRating.UseVisualStyleBackColor = true;
            this.AverageRating.Click += new System.EventHandler(this.AverageRating_Click);
            // 
            // EachRating
            // 
            this.EachRating.Location = new System.Drawing.Point(115, 212);
            this.EachRating.Name = "EachRating";
            this.EachRating.Size = new System.Drawing.Size(94, 37);
            this.EachRating.TabIndex = 18;
            this.EachRating.Text = "Each Rating";
            this.EachRating.UseVisualStyleBackColor = true;
            this.EachRating.Click += new System.EventHandler(this.EachRating_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(115, 255);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(94, 24);
            this.Clear.TabIndex = 19;
            this.Clear.Text = "Clear ";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // txtMovieID
            // 
            this.txtMovieID.Location = new System.Drawing.Point(234, 184);
            this.txtMovieID.Name = "txtMovieID";
            this.txtMovieID.Size = new System.Drawing.Size(100, 20);
            this.txtMovieID.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Enter Movie ID";
            // 
            // LookUpMovieID
            // 
            this.LookUpMovieID.Location = new System.Drawing.Point(234, 211);
            this.LookUpMovieID.Name = "LookUpMovieID";
            this.LookUpMovieID.Size = new System.Drawing.Size(100, 38);
            this.LookUpMovieID.TabIndex = 22;
            this.LookUpMovieID.Text = "Look Up Movie By ID";
            this.LookUpMovieID.UseVisualStyleBackColor = true;
            this.LookUpMovieID.Click += new System.EventHandler(this.LookUpMovieID_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Enter User ID";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(234, 272);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 24;
            // 
            // LookUpUserID
            // 
            this.LookUpUserID.Location = new System.Drawing.Point(234, 294);
            this.LookUpUserID.Name = "LookUpUserID";
            this.LookUpUserID.Size = new System.Drawing.Size(100, 40);
            this.LookUpUserID.TabIndex = 25;
            this.LookUpUserID.Text = "Look Up User By ID";
            this.LookUpUserID.UseVisualStyleBackColor = true;
            this.LookUpUserID.Click += new System.EventHandler(this.LookUpUserID_Click);
            // 
            // TopNReviewedMovies
            // 
            this.TopNReviewedMovies.Location = new System.Drawing.Point(115, 285);
            this.TopNReviewedMovies.Name = "TopNReviewedMovies";
            this.TopNReviewedMovies.Size = new System.Drawing.Size(85, 49);
            this.TopNReviewedMovies.TabIndex = 26;
            this.TopNReviewedMovies.Text = "Top-N Reviewed Movies";
            this.TopNReviewedMovies.UseVisualStyleBackColor = true;
            this.TopNReviewedMovies.Click += new System.EventHandler(this.TopNReviewedMovies_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Top-N";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(763, 355);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TopNReviewedMovies);
            this.Controls.Add(this.LookUpUserID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LookUpMovieID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMovieID);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.EachRating);
            this.Controls.Add(this.AverageRating);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.GetUserReviews);
            this.Controls.Add(this.GetMovieRiviews);
            this.Controls.Add(this.allUseres);
            this.Controls.Add(this.AllMovies);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AllMovies;
        private System.Windows.Forms.Button allUseres;
        private System.Windows.Forms.Button GetMovieRiviews;
        private System.Windows.Forms.Button GetUserReviews;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AverageRating;
        private System.Windows.Forms.Button EachRating;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox txtMovieID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LookUpMovieID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button LookUpUserID;
        private System.Windows.Forms.Button TopNReviewedMovies;
        private System.Windows.Forms.Label label6;
    }
}

