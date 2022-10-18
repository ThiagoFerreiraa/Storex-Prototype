using System.Data;
using System.Data.SqlClient;

namespace DataBaseConnection
{
    public class DatabaseConnection
    {
        public string SetResultConnection(DataTable table, string query, string sqlDataSource)
        {
            try
            {
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }

                string result = "Added Successfully";

                return result;

            }
            catch (Exception ex)
            {
                string error = ex.Message;

                return error;
            }


        }


        public string PutResultConnection(DataTable table, string query, string sqlDataSource)
        {
            try
            {
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }

                string result = "Updated Successfully";

                return result;

            }
            catch (Exception ex)
            {
                string error = ex.Message;

                return error;
            }


        }

        public string DeleteResultConnection(DataTable table, string query, string sqlDataSource)
        {
            try
            {
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }

                string result = "Updated Successfully";

                return result;

            }
            catch (Exception ex)
            {
                string error = ex.Message;

                return error;
            }


        }

        public DataTable GetResultConnection(DataTable table, string query, string sqlDataSource)
        {
            try
            {

                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return table;

        }
    }
}
