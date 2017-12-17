//
// BusinessTier:  business logic, acting as interface between UI and data store.
//

using System;
using System.Collections.Generic;
using System.Data;


namespace BusinessTier
{

  //
  // Business:
  //
  public class Business
  {
    //
    // Fields:
    //
    private string _DBFile;
    private DataAccessTier.Data dataTier;


    //
    // Constructor:
    //
    public Business(string DatabaseFilename)
    {
      _DBFile = DatabaseFilename;

      dataTier = new DataAccessTier.Data(DatabaseFilename);
    }


    //
    // TestConnection:
    //
    // Returns true if we can establish a connection to the database, false if not.
    //
    public bool TestConnection()
    {
      return dataTier.TestConnection();
    }


    //
    // GetUser:
    //
    // Retrieves User object based on USER ID; returns null if user is not
    // found.
    //
    // NOTE: if the user exists in the Users table, then a meaningful name and 
    // occupation are returned in the User object.  If the user does not exist 
    // in the Users table, then the user id has to be looked up in the Reviews 
    // table to see if he/she has submitted 1 or more reviews as an "anonymous"
    // user.  If the id is found in the Reviews table, then the user is an
    // "anonymous" user, so a User object with name = "<UserID>" and no occupation
    // ("") is returned.  In other words, name = the user’s id surrounded by < >.
    //
    public User GetUser(int UserID)
    {
            //
            // TODO!
            //
            string sql = string.Format("Select * From Users Where UserID = {0}", UserID);

           DataSet ds= dataTier.ExecuteNonScalarQuery(sql);

            //check if the user was found in the user file ... if found cerat new user object and return;
            if (ds.Tables["TABLE"].Rows.Count != 0)
            {
                object ID = ds.Tables["TABLE"].Rows[0]["UserID"];
                int uID = Convert.ToInt32(ID);

                string name = Convert.ToString(ds.Tables["TABLE"].Rows[0]["UserName"]);
                string Occupation = Convert.ToString(ds.Tables["TABLE"].Rows[0]["Occupation"]);

                User u = new User(uID, name, Occupation);
                return u;
            }
            // not found now look in the review...
            else {

                sql = string.Format(@"Select UserID From Reviews
                                        Where UserID = '{0}'
                                        Group by UserID", UserID);
                    object result = dataTier.ExecuteScalarQuery(sql);
                
                if (result != null)
                {
                    string name = string.Format("<{0}>", UserID);

                    User u = new User(UserID, name, "Unknown");

                    return u;
                }



            }


            return null;
    }

        //
        //
        //Get all the names and ID's of the movies arranged in alphabetical order..
        //
        //
        public IReadOnlyList<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            string sql = string.Format(@"Select MovieID, MovieName as Name From Movies
                                         Order by MovieName ASC;");

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);

            int ID;
            string name;
            foreach (DataRow row in ds.Tables["Table"].Rows)
            {
                ID = Convert.ToInt32(row["MovieID"]);
                name = string.Format(Convert.ToString(row["Name"]));

                Movie newMovie = new Movie(ID, name);

                movies.Add(newMovie);


            }



            return movies;
        }






        //
        // GetNamedUser:
        //
        // Retrieves User object based on USER NAME; returns null if user is not
        // found.
        //
        // NOTE: there are "named" users from the Users table, and anonymous users
        // that only exist in the Reviews table.  This function only looks up "named"
        // users from the Users table.
        //
        public User GetNamedUser(string UserName)
    {
            //
            // TODO!
            //
            string sql = string.Format("Select * From Users Where UserName = '{0}'", UserName);

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);

            //check if the user was found in the user file ... if found cerat new user object and return;
            if (ds.Tables["TABLE"].Rows.Count != 0)
            {
                object ID = ds.Tables["TABLE"].Rows[0]["UserID"];
                int uID = Convert.ToInt32(ID);

                string name = Convert.ToString(ds.Tables["TABLE"].Rows[0]["UserName"]);
                string Occupation = Convert.ToString(ds.Tables["TABLE"].Rows[0]["UserID"]);

                User u = new User(uID, name, Occupation);
                return u;
            }
            return null;
    }


    //
    // GetAllNamedUsers:
    //
    // Returns a list of all the users in the Users table ("named" users), sorted 
    // by user name.
    //
    // NOTE: the database also contains lots of "anonymous" users, which this 
    // function does not return.
    //
    public IReadOnlyList<User> GetAllNamedUsers()
    {
      List<User> users = new List<User>();

            //
            // TODO!
            //
            string sql;

            sql = @"
            SELECT * 
            From Users
            Order By UserName;
            ";

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                object ID = row["UserID"];
                int uID = Convert.ToInt32(ID);

                string name = Convert.ToString(row["UserName"]);
                string Occupation = Convert.ToString(row["Occupation"]);

                User u = new User(uID, name, Occupation);
                users.Add(u);


            }



            return users;
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE ID; returns null if movie is not
    // found.
    //
    public Movie GetMovie(int MovieID)
    {
            //
            // TODO!
            //
            string sql = string.Format("Select * From Movies Where MovieID = {0}", MovieID);

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);

            //check if the user was found in the user file ... if found cerat new user object and return;
            if (ds.Tables["TABLE"].Rows.Count != 0)
            {
                object ID = ds.Tables["TABLE"].Rows[0]["MovieID"];
                int mID = Convert.ToInt32(ID);

                string name = Convert.ToString(ds.Tables["TABLE"].Rows[0]["MovieName"]);
               

                Movie movieObject = new Movie(mID, name);
                return movieObject;
            }



            return null;      
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE NAME; returns null if movie is not
    // found.
    //
    public Movie GetMovie(string MovieName)
    {
            //
            // TODO!
            //

            //
            string valueMovie = MovieName.Replace("'", "''");

            string sql = string.Format("Select * From Movies Where MovieName = '{0}'", valueMovie);

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);

            //check if the user was found in the user file ... if found cerat new user object and return;
            if (ds.Tables["TABLE"].Rows.Count != 0)
            {
                object ID = ds.Tables["TABLE"].Rows[0]["MovieID"];
                int mID = Convert.ToInt32(ID);

                string name = Convert.ToString(ds.Tables["TABLE"].Rows[0]["MovieName"]);


                Movie movieObject = new Movie(mID, name);
                return movieObject;
            }



            return null;
    }


    //
    // AddReview:
    //
    // Adds review based on MOVIE ID, returning a Review object containing
    // the review, review's id, etc.  If the add failed, null is returned.
    //
    public Review AddReview(int MovieID, int UserID, int Rating)
    {
            //
            // TODO!
            //
            string sql = string.Format(@"INSERT INTO Reviews ( MovieID, UserID,Rating)  
                                            VALUES ({0}, {1},{2})",MovieID,UserID,Rating);
            int result = dataTier.ExecuteActionQuery(sql);
            if (result > 0)
            {
                string sql1 = string.Format(@"Select * From Reviews
                                            Where MovieID ='{0}' And UserID='{1}';",MovieID,UserID);
                DataSet ds = dataTier.ExecuteNonScalarQuery(sql1);
                object ID = ds.Tables["TABLE"].Rows[0]["MovieID"];
                int mID = Convert.ToInt32(ID);
                int UID = Convert.ToInt32(ds.Tables["TABLE"].Rows[0]["UserID"]);
                int RID = Convert.ToInt32(ds.Tables["TABLE"].Rows[0]["ReviewID"]);
                int rate = Convert.ToInt32(ds.Tables["TABLE"].Rows[0]["Rating"]);

                Review newReview = new Review(RID, mID, UID, rate);
                return newReview;
            }

            return null;
    }


    //
    // GetMovieDetail:
    //
    // Given a MOVIE ID, returns detailed information about this movie --- all
    // the reviews, the total number of reviews, average rating, etc.  If the 
    // movie cannot be found, null is returned.
    //
    public MovieDetail GetMovieDetail(int MovieID)
    {
            //
            // TODO!
            //


            Movie movie = GetMovie(MovieID);

            if (movie == null)
            {
                return null;
            }

            string AvgSql = string.Format(@"Select Round (Avg(convert (float,Rating)),4) As Average From Reviews
                                Where MovieID={0};",MovieID);
            object avgResult = dataTier.ExecuteScalarQuery(AvgSql);
            double average = Convert.ToDouble(avgResult);
            string numReviewsSql = string.Format(@"Select count (*) From Reviews
                                                  Where MovieID = '{0}'", MovieID);
            int TotalReviews = Convert.ToInt32(dataTier.ExecuteScalarQuery(numReviewsSql));

            string allReviewsSql = string.Format(@"Select * From Reviews 
                                                  Where MovieID = '{0}'
                                                  Order by Rating DESC", MovieID);

            DataSet ds = dataTier.ExecuteNonScalarQuery(allReviewsSql);

            List<Review> newList = new List<Review>() ;
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                int RID = Convert.ToInt32(row["ReviewID"]);
                int MID = Convert.ToInt32(row["MovieID"]);
                int UID = Convert.ToInt32(row["UserID"]);
                int Rate = Convert.ToInt32(row["Rating"]);
                Review newReview = new Review(RID, MID, UID, Rate);

                newList.Add(newReview);

            }





            MovieDetail MD = new MovieDetail(movie, average, TotalReviews, newList);








      return MD;
    }


    //
    // GetUserDetail:
    //
    // Given a USER ID, returns detailed information about this user --- all
    // the reviews submitted by this user, the total number of reviews, average 
    // rating given, etc.  If the user cannot be found, null is returned.
    //
    public UserDetail GetUserDetail(int UserID)
    {
            //
            // TODO!
            //

           User user = GetUser(UserID);

            //if (user == null)
            //{
            //    return null;
            //}

            string AvgSql = string.Format(@"Select Round(Avg(convert (float,Rating)),4) As Average From Reviews
                                Where UserID={0};", UserID);
            object avgResult = dataTier.ExecuteScalarQuery(AvgSql);
            double average = Convert.ToDouble(avgResult);
            string numReviewsSql = string.Format(@"Select count (*) From Reviews
                                                  Where UserID = '{0}'", UserID);
            int TotalReviews = Convert.ToInt32(dataTier.ExecuteScalarQuery(numReviewsSql));

            string allReviewsSql = string.Format(@"Select * From Reviews 
                                                  Where UserID = '{0}'", UserID);

            DataSet ds = dataTier.ExecuteNonScalarQuery(allReviewsSql);

            List<Review> newList = new List<Review>();
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                int RID = Convert.ToInt32(row["ReviewID"]);
                int MID = Convert.ToInt32(row["MovieID"]);
                int UID = Convert.ToInt32(row["UserID"]);
                int Rate = Convert.ToInt32(row["Rating"]);
                Review newReview = new Review(RID, MID, UID, Rate);

                newList.Add(newReview);

            }

            UserDetail UD = new UserDetail(user, average, TotalReviews, newList);


            return UD;
    }


    //
    // GetTopMoviesByAvgRating:
    //
    // Returns the top N movies in descending order by average rating.  If two
    // movies have the same rating, the movies are presented in ascending order
    // by name.  If N < 1, an EMPTY LIST is returned.
    //
    public IReadOnlyList<Movie> GetTopMoviesByAvgRating(int N)
    {
      List<Movie> movies = new List<Movie>();

            //
            // TODO!
            //



            string sql;

            sql = string.Format(@"Select top {0} Movies.MovieName, ROUND(AVG(CONVERT(float,Rating)), 4) as Average From  Reviews, Movies
                                    Where Movies.MovieID = Reviews.MovieID
                                    Group by Movies.MovieName
                                    Order by Average DESC;", N);

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in ds.Tables["Table"].Rows)
            {
                string movieName = Convert.ToString(row["MovieName"]);
                Movie movie = GetMovie(movieName);
                movies.Add(movie);

            }


            return movies;
    }


    //
    // GetTopMoviesByNumReviews
    //
    // Returns the top N movies in descending order by number of reviews.  If
    // two movies have the same number of reviews, the movies are presented in
    // ascending order by name.  If N < 1, an EMPTY LIST is returned.
    //
    public IReadOnlyList<Movie> GetTopMoviesByNumReviews(int N)
    {
      List<Movie> movies = new List<Movie>();

            //
            // TODO!
            //


            string sql;

            sql = string.Format(@"Select top {0} Movies.MovieName, count(*) As TotalReviews From  Reviews, Movies
                                    Where Movies.MovieID = Reviews.MovieID
                                    Group by Movies.MovieName
                                    Order by TotalReviews DESC;", N);

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in ds.Tables["Table"].Rows)
            {
                string movieName = Convert.ToString(row["MovieName"]);
                Movie movie = GetMovie(movieName);
                movies.Add(movie);

            }


            return movies;
    }


    //
    // GetTopUsersByNumReviews
    //
    // Returns the top N users in descending order by number of reviews.  If two
    // users have the same number of reviews, the users are presented in ascending
    // order by user id.  If N < 1, an EMPTY LIST is returned.
    //
    // NOTE: not all user ids map to users in the Users table.  User ids that don't
    // map are considered "anonymous" users, and returned with their name = to their
    // userid ("<UserID>") and no occupation ("").
    //
    public IReadOnlyList<User> GetTopUsersByNumReviews(int N)
    {
      List<User> users = new List<User>();

      //
      // execute query to rank users:
      //
      // NOTE: some reviews are anonymous, i.e. don't have an entry in the Users
      // table.  So we use a "RIGHT JOIN" to capture those as well.
      //
      string sql = string.Format(@"SELECT TOP {0} Temp.UserID, Users.UserName, Users.Occupation
            FROM Users
            RIGHT JOIN
            (
              SELECT UserID, COUNT(*) AS RatingCount
              FROM Reviews
              GROUP BY UserID
            ) AS Temp
            On Temp.UserID = Users.UserID
            ORDER BY Temp.RatingCount DESC, Users.UserName Asc;",
        N);

            //
            // Now execute this query...  In the resulting dataset, the anonymous users will
            // have a UserName of "" because the result of the join was NULL.  So when you
            // come across a user with "" as their name, create a new User based on their user
            // id, i.e. string.Format("<{0}>", userid);
            //

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);
            string name;
            string occupation;
            int UID;
            foreach (DataRow row in ds.Tables["Table"].Rows)
            {
                 UID = Convert.ToInt32(row["UserID"]);
                name = Convert.ToString(row["UserName"]);
                if (name == "") {
                     name = string.Format(string.Format("<{0}>", row["UserID"]));
                    User newUser = new User(UID, name, "");
                    users.Add(newUser);

                }

                else {
                    name =string.Format( Convert.ToString(row["UserName"]));
                    occupation = string.Format(Convert.ToString(row["Occupation"]));

                   User  newUser = new User(UID, name, occupation);

                    users.Add(newUser);
                }

            }

      
      //
      // TODO:
      //


      return users;
    }

    


  }//class
}//namespace
