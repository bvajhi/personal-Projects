
//
// GUI database app working with Netflix movie data.
//
// Bilal Vajhi NetID: bvajhi2
// U. of Illinois, Chicago
// CS341, Spring 2017
// Project 08
//  
    
    
    
    
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;

namespace Project7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listBox1.Items.Add("\t***READ ME***");
            listBox1.Items.Add("Before you run any queries please press 'Load Data Base'");
            listBox1.Items.Add("button to load the database and check the connection");
            listBox1.Items.Add("");
            listBox1.Items.Add("\t*** IMPORTANT ***");
            listBox1.Items.Add("Once the database is loded all the movie name will be in the movies drop down menu,");
            listBox1.Items.Add("and all the user names will be in the users dropd down menue users ");
            listBox1.Items.Add("have to select the movies and the users from their.");
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;

            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");

        }
         private bool fileExists(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                string msg = string.Format("Input file not found: '{0}'",
                  filename);

                MessageBox.Show(msg);
                return false;
            }

            // exists!
            return true;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//clear the list box...
            string filename = this.txtFileName.Text;

            BusinessTier.Business bizTear = new BusinessTier.Business(filename);


            if (bizTear.TestConnection()==true)
            {
                this.listBox1.Items.Add("Connection Succesfull");
            }
            else {
                this.listBox1.Items.Add("Problem occured while establishng connection");

            }

           var userList = bizTear.GetAllNamedUsers();

            foreach(var user in userList)
            {
                comboBox2.Items.Add(user.UserName);
            }
            listBox1.Items.Add("User Names Added");



           var movieList= bizTear.GetAllMovies();

            foreach (var movie in movieList)
            {

                comboBox1.Items.Add(movie.MovieName);


            }


     
            listBox1.Items.Add("Movie Names Added");

            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");





        }


        // dispalys all the movies in ascending order by name with their movie ID...
        private void AllMovies_Click(object sender, EventArgs e)
        {

            string filename = this.txtFileName.Text;
           // listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            BusinessTier.Business bizTear = new BusinessTier.Business(filename);


            var movieList = bizTear.GetAllMovies();

            string display;

            foreach (var movie in movieList)
            {
                display = string.Format("{0} --- {1} ", movie.MovieID, movie.MovieName);

                listBox1.Items.Add(display);

            }



            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");

        }

        private void allUseres_Click(object sender, EventArgs e)
        {
            string filename = this.txtFileName.Text;
            string display;
            BusinessTier.Business bizTiar = new BusinessTier.Business(filename);
            var users = bizTiar.GetAllNamedUsers();
            foreach (var user in users)
            {
                display = string.Format("{0} -- {1} -- {2}", user.UserID, user.UserName, user.Occupation);
                this.listBox1.Items.Add(display);

            }

            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetMovieRiviews_Click(object sender, EventArgs e)
        {
            string name = this.comboBox1.Text;
           // this.listBox1.Items.Clear();
            if (name == "Select Movie")
            {
                MessageBox.Show("Please Select a valid Movie Name if no movie name is available in the movies drop down menue press the 'Load Data Base' button");
                return;
            }
            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            var bizTier = new BusinessTier.Business(filename);

            var movieID = bizTier.GetMovie(name);

            if (movieID == null)
            {
                MessageBox.Show("Please Select a valid Movie Name if no movie name is available in the movies drop down menue press the 'Load Data Base' button");
                return;

            }

            int mID=0;

                 mID = Convert.ToInt32(movieID.MovieID);
           
            var movieDetails = bizTier.GetMovieDetail(mID);

           // listBox1.Items.Add(movieDetails.Reviews[0].UserID);


            string display;
            foreach (var movie in movieDetails.Reviews)
            {
                display = string.Format("{0} -- {1}", movie.UserID, movie.Rating);
                listBox1.Items.Add(display);

            }

            //listBox1.Items.Add(count); //for debugging puposes..
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");







        }

        private void GetUserReviews_Click(object sender, EventArgs e)
        {
            string name = this.comboBox2.Text;
            // this.listBox1.Items.Clear();
            if (name == "Select User")
            {
               
                MessageBox.Show("Please Select a valid User Name if no user name is available in the users drop down menue, press the 'Load Data Base' button");
                return;
            }

            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            var bizTier = new BusinessTier.Business(filename);



            var user = bizTier.GetNamedUser(name);

            if (user == null)
            {
                MessageBox.Show("Please Select a valid Movie Name if no movie name is available in the movies drop down menue press the 'Load Data Base' button");
                return;

            }

            var userDetails = bizTier.GetUserDetail(user.UserID);
            this.listBox1.Items.Add(name);
            string display;
            foreach (var user1 in userDetails.Reviews)
            {
                var movie = bizTier.GetMovie(user1.MovieID);
                var movieName = movie.MovieName;
                display = string.Format("{0} -- {1}", movieName, user1.Rating);
                listBox1.Items.Add(display);

            }


            // listBox1.Items.Add(count); //For debugging
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");






        }

        private void Insert_Click(object sender, EventArgs e)
        {
            //get movie name from the combo box...
            string movieName = this.comboBox1.Text;

            if (movieName == "Select Movie")
            {
                MessageBox.Show("Please Select a valid Movie Name if no movie name is available in the movies drop down menue press the 'Load Data Base' button");
                return;
            }
           

            //get the user name
            string userName = this.comboBox2.Text;
            if (userName == "Select User")
            {
                MessageBox.Show("Please Select a valid User Name if no user name is available in the users drop down menue, press the 'Load Data Base' button");
                return;
            }

          

            string rating = this.comboBox3.Text;
            int rate=0;
            try
            {
                rate = Convert.ToInt32(rating);
            }
            catch (FormatException s)
            {
                MessageBox.Show("Please Select a valid number...");
                return;
            }


            if (rate<=0 || rate>5)
            {
                MessageBox.Show("Please Select a valid number...");
                return;
            }

       
            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            var bizTier = new BusinessTier.Business(filename);

             var user = bizTier.GetNamedUser(userName);

            if (user == null)
            {
                MessageBox.Show("Please Select a valid User Name if no User name is available in the User drop down menue press the 'Load Data Base' button");
                return;

            }

            int userID = user.UserID;

         

            var movie= bizTier.GetMovie(movieName);

            if (movie == null)
            {
                MessageBox.Show("Please Select a valid Movie Name if no movie name is available in the movies drop down menue press the 'Load Data Base' button");
                return;

            }
            int movieID = movie.MovieID;
            var result = bizTier.AddReview(movieID, userID, rate);

            if (result == null)
            {

                MessageBox.Show("The input was not successfull");
                return;

            }

            else {
                
                string disply = string.Format("{0} -- {1} -- {2} -- {3}", result.ReviewID,result.UserID,result.MovieID,result.Rating);
                this.listBox1.Items.Add("Review Added...");
                this.listBox1.Items.Add(disply);

            }




            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }


        //get the top N movies...
        private void button1_Click_1(object sender, EventArgs e)
        {
            string N = this.textBox1.Text;
            int n;
            try
            {
                 n = Convert.ToInt32(N);
            }
            catch {
                MessageBox.Show("Enter a valid number");
                return;

            }


            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            var bizTier = new BusinessTier.Business(filename);

            var topNMovies = bizTier.GetTopMoviesByAvgRating(n);


            this.listBox1.Items.Add("Top "+n+" Movies by Average");
            string display;
            
            foreach(var movie in topNMovies)
            {
                var details = bizTier.GetMovieDetail(movie.MovieID);
                display = string.Format("{0} -- {1}", movie.MovieName, details.AvgRating);
                this.listBox1.Items.Add(display);
            }

            // listBox1.Items.Add(count);
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");


        }


        // Get top N users....
        private void button2_Click(object sender, EventArgs e)
        {

            string N = this.textBox1.Text;
            int n;
            try
            {
                n = Convert.ToInt32(N);
            }
            catch
            {
                MessageBox.Show("Enter a valid number");
                return;

            }

            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;
            var bizTier = new BusinessTier.Business(filename);

            var topNUsers = bizTier.GetTopUsersByNumReviews(n);

            this.listBox1.Items.Add("Top " + n + " User by Reviews");
            string display;

            foreach (var user in topNUsers)
            {
                var details = bizTier.GetUserDetail(user.UserID);
                display = string.Format("{0} -- {1}",user.UserName, details.NumReviews);
                this.listBox1.Items.Add(display);
            }


            // listBox1.Items.Add(count);
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");






        }

       

        

        private void AverageRating_Click(object sender, EventArgs e)
        {
            string name = this.comboBox1.Text;
            // this.listBox1.Items.Clear();
            if (name == "Select Movie")
            {
                MessageBox.Show("Please Select a valid Movie Name if no movie name is available in the movies drop down menue press the 'Load Data Base' button");
                return;
            }
            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;
            var bizTier = new BusinessTier.Business(filename);

            var movie = bizTier.GetMovie(name);

            var movieDetail = bizTier.GetMovieDetail(movie.MovieID);
            
            string display =string.Format ("{0} -- {1}", movie.MovieName, movieDetail.AvgRating);
            this.listBox1.Items.Add(display);



            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");




        }

        private void EachRating_Click(object sender, EventArgs e)
        {
            string name = this.comboBox1.Text;
            // this.listBox1.Items.Clear();
            if (name == "Select Movie")
            {
                MessageBox.Show("Please Select a valid Movie Name if no movie name is available in the movies drop down menue press the 'Load Data Base' button");
                return;
            }
            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            var bizTier = new BusinessTier.Business(filename);

            var movie = bizTier.GetMovie(name);
            if (movie == null)
            {
                MessageBox.Show("Please Select a valid Movie Name if no movie name is available in the movies drop down menue press the 'Load Data Base' button");
                return;
            }
            var movieDetails = bizTier.GetMovieDetail(movie.MovieID);

            int num1Star = 0, num2Star = 0, num3Star = 0, num4Star = 0, num5Star = 0;

            foreach (var review in movieDetails.Reviews)
            {
                if (review.Rating == 1)
                { num1Star++; }
                else if (review.Rating == 2)
                {
                    num2Star++;
                }
                else if (review.Rating == 3)
                {
                    num3Star++;
                }
                else if (review.Rating == 4)
                {
                    num4Star++;
                }
                else
                {
                    num5Star++;
                }
            }


          
            string display = string.Format("5: {0}", num5Star);
            listBox1.Items.Add(name);
            listBox1.Items.Add(display);
            display = string.Format("4: {0}", num4Star);
            listBox1.Items.Add(display);
            display = string.Format("3: {0}", num3Star);
            listBox1.Items.Add(display);
            display = string.Format("2: {0}", num2Star);
            listBox1.Items.Add(display);
            display = string.Format("1: {0}", num1Star);
            listBox1.Items.Add(display);

            display = string.Format("Total: {0}", movieDetails.NumReviews);
            listBox1.Items.Add(display);

         

            //listBox1.Items.Add(count);
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");









        }

        private void Clear_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private void LookUpMovieID_Click(object sender, EventArgs e)
        {
            int ID=0;

            try
            {
                 ID = Convert.ToInt32(this.txtMovieID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The ID Has to be an integer");
                return;
            }
            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            var bizTier = new BusinessTier.Business(filename);

            var move = bizTier.GetMovie(ID);

            if (move == null)
            {
                MessageBox.Show("There is no movie with this movie ID");
                return;
            }

            string display = string.Format("Movie Name: {0}", move.MovieName);

            listBox1.Items.Add(display);

            //listBox1.Items.Add(count);
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");


        }

        private void LookUpUserID_Click(object sender, EventArgs e)
        {
            int ID = 0;

            try
            {
                ID = Convert.ToInt32(this.txtUserID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The ID Has to be an integer");
                return;
            }
            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            var bizTier = new BusinessTier.Business(filename);

            var user = bizTier.GetUser(ID);

            if (user == null)
            {
                MessageBox.Show("There is no User with this User ID");
                return;
            }

            string display = string.Format("Name: {0}", user.UserName);
            listBox1.Items.Add(display);

            //listBox1.Items.Add(count);
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");




        }

        private void TopNReviewedMovies_Click(object sender, EventArgs e)
        {
            string N = this.textBox1.Text;
            int n;
            try
            {
                n = Convert.ToInt32(N);
            }
            catch
            {
                MessageBox.Show("Enter a valid number");
                return;

            }


            string filename = this.txtFileName.Text;
            //listBox1.Items.Clear();

            if (!fileExists(filename))
                return;

            var bizTier = new BusinessTier.Business(filename);

            var topNMovies = bizTier.GetTopMoviesByNumReviews(n);


            this.listBox1.Items.Add("Top " + n + " Movies by Number Of Reviews");
            string display;

            foreach (var movie in topNMovies)
            {
                var details = bizTier.GetMovieDetail(movie.MovieID);
                display = string.Format("{0} -- {1}", movie.MovieName, details.NumReviews);
                this.listBox1.Items.Add(display);
            }

            // listBox1.Items.Add(count);
            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("");
        }
    }
}
