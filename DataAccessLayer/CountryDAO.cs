using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CountryDAO : IUserInterfaceDAO<CountryDTO>
    {
        public bool Delete(int key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                objConn.Open();

                string strSQL = "DELETE FROM Country WHERE CountryID = @CountryID;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@CountryID", SqlDbType.VarChar).Value = key;
                int intRecordsAffected = objCmd.ExecuteNonQuery();

                if (intRecordsAffected == 1)
                {
                    return true;
                }

                objCmd.Dispose();
                objCmd = null;

                return false;

            }
            catch (Exception objE)
            {
                throw new Exception("Unexpected Error in CountryDAO Delete(key) Method: {0} " + objE.Message);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public List<CountryDTO> GetAllRecords()
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());

            try
            {
                objConn.Open();

                string strSQL = "SELECT * FROM Country;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    List<CountryDTO> colRecordList = new List<CountryDTO>();

                    while (objDR.Read())
                    {
                        CountryDTO objDTO = new CountryDTO();

                        objDTO.CountryID = objDR.GetByte(0);
                        objDTO.CountryCode = objDR.GetString(1);
                        objDTO.CountryName = objDR.GetString(3);

                        colRecordList.Add(objDTO);

                    }

                    return colRecordList;
                }
                else
                {
                    objDR.Close();
                    objDR = null;
                    objCmd.Dispose();
                    objCmd = null;

                    return null;
                }
            }
            catch (Exception objE)
            {
                throw new Exception("Unexpected Error in CountryDAO GetAllRecords() Method: {0} " + objE.Message);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public CountryDTO GetRecordByID(int key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                //Open connection 
                objConn.Open();

                //Create SQL string 
                string strSQL = "SELECT * FROM Country WHERE CountryID = @CountryID;";

                //Create Command object, pass query and connection object 
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                //For stored procedures syntax is objCmd.CommandType = CommandType.StoredProcedure; 
                objCmd.CommandType = CommandType.Text;

                //Add Parameter to. NOTE WE ARE ASSIGNING METHOD PARAMETER 
                objCmd.Parameters.Add("@CountryID", SqlDbType.VarChar).Value = key;

                //COMMAND OBJECT ExecuteReader Method which returns a populated 
                //DATAREADER OBJECT with the results of the query 
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    //Create Data Transfer Object 
                    CountryDTO objDTO = new CountryDTO();

                    //read the first record 
                    objDR.Read();

                    //Extract data 
                    objDTO.CountryID = objDR.GetInt32(0);
                    objDTO.CountryCode = objDR.GetString(1);
                    objDTO.CountryName = objDR.GetString(2);

                    //Return Data Transfer Object 
                    return objDTO;
                }
                //Terminate ADO Objects 
                objDR.Close();
                objDR = null;
                objCmd.Dispose();
                objCmd = null;

                //return null since no data found 
                return null;
            }
            catch (Exception objE)
            {
                //throw system exception since run time error has occurred. 
                throw new Exception("Unexpected Error in CountryDAO GetRecordByID(key) Method: {0} " + objE.Message);
            }
            finally
            {
                //Terminate connection 
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public bool Insert(CountryDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                //Open connection 
                objConn.Open();
                //Create SQL string 
                string strSQL;
                strSQL = "INSERT INTO Country (CountryID,CountryCode,CountryName";
                strSQL = strSQL + "VALUES(@CountryID,@CountryCode,@CountryName);";

                //Create Command object, pass query and connection object 
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@CountryID", SqlDbType.TinyInt).Value = objDTO.CountryID;
                objCmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = objDTO.CountryCode;
                objCmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = objDTO.CountryName;


                //Execute ACTION-Query, Test result and throw exception if failed 
                int intRecordsAffected = objCmd.ExecuteNonQuery();

                //validate if INSERT QUERY was successful 
                if (intRecordsAffected == 1)
                { return true; }

                //Terminate ADO Objects 
                objCmd.Dispose();
                objCmd = null;
                return false;
            }
            catch (Exception objE)
            {
                throw new Exception("Unexpected Error in CountryDAO Insert(CountryDTO objDTO) Method: {0} " + objE.Message);
            }
            finally
            {
                //Terminate connection 
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public bool Update(CountryDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                objConn.Open();

                string strSQL;

                strSQL = "UPDATE Country";
                strSQL = strSQL + " SET CountryCode=@CountryCode,";
                strSQL = strSQL + "CountryName=@CountryName";
                strSQL = strSQL + " WHERE CountryID=@CountryID;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = objDTO.CountryCode;
                objCmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = objDTO.CountryName;
                int intRecordsAffected = objCmd.ExecuteNonQuery();

                if (intRecordsAffected == 1)
                {
                    return true;
                }

                objCmd.Dispose();
                objCmd = null;

                return false;

            }
            catch (Exception objE)
            {
                throw new Exception("Unexpected Error in CountryDAO Update(CountryDTO objDTO) Method: {0} " + objE.Message);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }
    }
}
