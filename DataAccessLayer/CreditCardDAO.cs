using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CreditCardDAO : ICreditCardDAO
    {
        public bool Delete(string key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                objConn.Open();

                string strSQL = "DELETE FROM CreditCard WHERE CreditCardNumber = @CreditCardNumber;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = key;
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
                throw new Exception("Unexpected Error in CreditCardDAO Delete(key) Method: {0} " + objE.Message);
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public List<CreditCardDTO> GetAllRecords()
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());

            try
            {
                objConn.Open();

                string strSQL = "SELECT * FROM CreditCard;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    List<CreditCardDTO> colRecordList = new List<CreditCardDTO>();

                    while (objDR.Read())
                    {
                        CreditCardDTO objDTO = new CreditCardDTO();

                        objDTO.CreditCardNumber = objDR.GetString(0);
                        objDTO.CreditCardOwnerName = objDR.GetString(1);
                        objDTO.MerchantName = objDR.GetString(2);
                        objDTO.ExpDate = objDR.GetDateTime(3);
                        objDTO.AddressLine1 = objDR.GetString(4);
                        objDTO.AddressLine2 = objDR.GetString(5);
                        objDTO.City = objDR.GetString(6);
                        objDTO.StateCode = objDR.GetString(7);
                        objDTO.ZipCode = objDR.GetString(8);
                        objDTO.Country = objDR.GetString(9);
                        objDTO.CreditCardLimit = objDR.GetDecimal(10);
                        objDTO.CreditCardBalance = objDR.GetDecimal(11);
                        objDTO.ActivationStatus = objDR.GetBoolean(12);

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
            }catch (Exception objE)
            {
                throw new Exception("Unexpected Error in CreditCardDAO GetAllRecords() Method: {0} " + objE.Message);
            }finally
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public CreditCardDTO GetRecordByID(string key)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                //Open connection 
                objConn.Open();

                //Create SQL string 
                string strSQL = "SELECT * FROM CreditCard WHERE CreditCardNumber = @CreditCardNumber;";

                //Create Command object, pass query and connection object 
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                //For stored procedures syntax is objCmd.CommandType = CommandType.StoredProcedure; 
                objCmd.CommandType = CommandType.Text;

                //Add Parameter to. NOTE WE ARE ASSIGNING METHOD PARAMETER 
                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = key;

                //COMMAND OBJECT ExecuteReader Method which returns a populated 
                //DATAREADER OBJECT with the results of the query 
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows)
                {
                    //Create Data Transfer Object 
                    CreditCardDTO objDTO = new CreditCardDTO();

                    //read the first record 
                    objDR.Read();

                    //Extract data 
                    objDTO.CreditCardNumber = objDR.GetString(0);
                    objDTO.CreditCardOwnerName = objDR.GetString(1);
                    objDTO.MerchantName = objDR.GetString(2);
                    objDTO.ExpDate = objDR.GetDateTime(3);
                    objDTO.AddressLine1 = objDR.GetString(4);
                    objDTO.AddressLine2 = objDR.GetString(5);
                    objDTO.City = objDR.GetString(6);
                    objDTO.StateCode = objDR.GetString(7);
                    objDTO.ZipCode = objDR.GetString(8);
                    objDTO.Country = objDR.GetString(9);
                    objDTO.CreditCardLimit = objDR.GetDecimal(10);
                    objDTO.CreditCardBalance = objDR.GetDecimal(11);
                    objDTO.ActivationStatus = objDR.GetBoolean(12);

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
                throw new Exception("Unexpected Error in CreditCardDAO GetRecordByID(key) Method: {0} " + objE.Message);
            }
            finally
            {
                //Terminate connection 
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public bool Insert(CreditCardDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                //Open connection 
                objConn.Open();
                //Create SQL string 
                string strSQL;
                strSQL = "INSERT INTO CreditCard (CreditCardNumber,OwnerName,MerchantName,ExpDate,";
                strSQL = strSQL + "AddressLine1,AddressLine2,City,StateCode,ZipCode,Country,";
                strSQL = strSQL + "CreditCardBalance,CreditCardLimit,ActivationStatus)";
                strSQL = strSQL + "VALUES(@CreditCardNumber,@OwnerName,@MerchantName,@ExpDate,";
                strSQL = strSQL + "@AddressLine1,@AddressLine2,@City,@StateCode,@ZipCode,@Country,";
                strSQL = strSQL + "@CreditCardLimit,@CreditCardBalance,@ActivationStatus);";

                //Create Command object, pass query and connection object 
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = objDTO.CreditCardNumber;
                objCmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = objDTO.CreditCardOwnerName;
                objCmd.Parameters.Add("@MerchantName", SqlDbType.VarChar).Value = objDTO.MerchantName;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.DateTime).Value = objDTO.ExpDate;
                objCmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = objDTO.AddressLine1;
                objCmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = objDTO.AddressLine2;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@StateCode", SqlDbType.Char).Value = objDTO.StateCode.ToCharArray();
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@CreditCardLimit", SqlDbType.Decimal).Value = objDTO.CreditCardLimit;
                objCmd.Parameters.Add("@CreditCardBalance", SqlDbType.Decimal).Value = objDTO.CreditCardBalance;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDTO.ActivationStatus;

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
                throw new Exception("Unexpected Error in CreditCardDAO Insert(CreditCardDTO objDTO) Method: {0} " + objE.Message);
            }
            finally
            {
                //Terminate connection 
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public bool Update(CreditCardDTO objDTO)
        {
            SqlConnection objConn = new SqlConnection(SQLServerDAOFactory.ConnectionString());
            try
            {
                objConn.Open();

                string strSQL;

                strSQL = "UPDATE CreditCard";
                strSQL = strSQL + " SET OwnerName=@OwnerName,";
                strSQL = strSQL + "MerchantName=@MerchantName,";
                strSQL = strSQL + "ExpDate=@ExpDate,";
                strSQL = strSQL + "AddressLine1=@AddressLine1,";
                strSQL = strSQL + "AddressLine2=@AddressLine2,";
                strSQL = strSQL + "City=@City,";
                strSQL = strSQL + "StateCode=@StateCode,";
                strSQL = strSQL + "ZipCode=@ZipCode,";
                strSQL = strSQL + "Country=@Country,";
                strSQL = strSQL + "CreditCardLimit=@CreditCardLimit,";
                strSQL = strSQL + "CreditCardBalance=@CreditCardBalance,";
                strSQL = strSQL + "ActivationStatus=@ActivationStatus";
                strSQL = strSQL + " WHERE CreditCardNumber=@CreditCardNumber;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);

                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = objDTO.CreditCardOwnerName;
                objCmd.Parameters.Add("@MerchantName", SqlDbType.VarChar).Value = objDTO.MerchantName;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.VarChar).Value = objDTO.ExpDate;
                objCmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = objDTO.AddressLine1;
                objCmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = objDTO.AddressLine2;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDTO.City;
                objCmd.Parameters.Add("@StateCode", SqlDbType.Char).Value = objDTO.StateCode.ToCharArray();
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDTO.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDTO.Country;
                objCmd.Parameters.Add("@CreditCardLimit", SqlDbType.Decimal).Value = objDTO.CreditCardLimit;
                objCmd.Parameters.Add("@CreditCardBalance", SqlDbType.Decimal).Value = objDTO.CreditCardBalance;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDTO.ActivationStatus;
                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = objDTO.CreditCardNumber;
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
                throw new Exception("Unexpected Error in CreditCardDAO Update(CreditCardDTO objDTO) Method: {0} " + objE.Message);
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
