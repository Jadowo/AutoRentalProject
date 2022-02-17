using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class USStateDAO : IUserInterfaceDAO<USStateDTO>
    {
        public bool Delete(int key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                objConn.Open();

                string strSQL = "DELETE FROM USState WHERE StateID = @StateID;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@StateID", SqlDbType.VarChar).Value = key;
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
                throw new Exception("Unexpected Error in USStateDAO Delete(key) Method: {0} " + objE.Message);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public List<USStateDTO> GetAllRecords()
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                objConn.Open();

                string strSQL = "SELECT * FROM USState;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    List<USStateDTO> colRecordList = new List<USStateDTO>();

                    while (objDR.Read())
                    {
                        USStateDTO objDTO = new USStateDTO();

                        objDTO.StateID = objDR.GetByte(0);
                        objDTO.StateCode = objDR.GetString(1);
                        objDTO.StateName = objDR.GetString(2);

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
                throw new Exception("Unexpected Error in USStateDAO GetAllRecords() Method: {0} " + objE.Message);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public USStateDTO GetRecordByID(int key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                //Open connection 
                objConn.Open();

                //Create SQL string 
                string strSQL = "SELECT * FROM USState WHERE StateID = @StateID;";

                //Create Command object, pass query and connection object 
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                //For stored procedures syntax is objCmd.CommandType = CommandType.StoredProcedure; 
                objCmd.CommandType = CommandType.Text;

                //Add Parameter to. NOTE WE ARE ASSIGNING METHOD PARAMETER 
                objCmd.Parameters.Add("@StateID", SqlDbType.VarChar).Value = key;

                //COMMAND OBJECT ExecuteReader Method which returns a populated 
                //DATAREADER OBJECT with the results of the query 
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    //Create Data Transfer Object 
                    USStateDTO objDTO = new USStateDTO();

                    //read the first record 
                    objDR.Read();

                    //Extract data 
                    objDTO.StateID = objDR.GetInt32(0);
                    objDTO.StateCode = objDR.GetString(1);
                    objDTO.StateName = objDR.GetString(2);

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
                throw new Exception("Unexpected Error in USStateDAO GetRecordByID(key) Method: {0} " + objE.Message);
            }
            finally
            {
                //Terminate connection 
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public bool Insert(USStateDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                //Open connection 
                objConn.Open();
                //Create SQL string 
                string strSQL;
                strSQL = "INSERT INTO USState (StateID,StateCode,StateName";
                strSQL = strSQL + "VALUES(@StateID,@StateCode,@StateName);";

                //Create Command object, pass query and connection object 
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@StateID", SqlDbType.TinyInt).Value = objDTO.StateID;
                objCmd.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = objDTO.StateCode;
                objCmd.Parameters.Add("@StateName", SqlDbType.VarChar).Value = objDTO.StateName;


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
                throw new Exception("Unexpected Error in USStateDAO Insert(USStateDTO objDTO) Method: {0} " + objE.Message);
            }
            finally
            {
                //Terminate connection 
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public bool Update(USStateDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                objConn.Open();

                string strSQL;

                strSQL = "UPDATE USState";
                strSQL = strSQL + " SET StateCode=@StateCode,";
                strSQL = strSQL + "StateName=@StateName";
                strSQL = strSQL + " WHERE StateID=@StateID;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = objDTO.StateCode;
                objCmd.Parameters.Add("@StateName", SqlDbType.VarChar).Value = objDTO.StateName;
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
                throw new Exception("Unexpected Error in USStateDAO Update(USStateDTO objDTO) Method: {0} " + objE.Message);
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
