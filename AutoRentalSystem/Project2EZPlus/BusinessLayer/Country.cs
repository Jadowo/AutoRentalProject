using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Country
    {
        public int m_CountryID;
        public string m_CountryCode;
        public string m_CountryName;
        public int CountryID { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }


        public Country()
        {
            this.CountryID = 0;
            this.CountryCode = "";
            this.CountryName = "";
        }

        public Country(int SID, string SCode, string SName)
        {
            this.CountryID = SID;
            this.CountryCode = SCode;
            this.CountryName = SName;
        }
        ~Country()
        {
            Console.WriteLine("Country is being destroyed and destructor is being called");
        }

        public void Print()
        {
            try
            {
                StreamWriter printer = new StreamWriter("Network_Printer.txt");
                printer.WriteLine("US Country Information: " +
                    "\nUS Country ID = " + m_CountryID +
                    "\nUS Country Code = " + m_CountryCode +
                    "\nUS Country Name= " + m_CountryName);
                printer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public bool Load(int key)
        {
            return DataAccessLayer_Load(key);
        }
        public bool Insert()
        {
            return DataAccessLayer_Insert();
        }
        public bool Update()
        {
            return DataAccessLayer_Update();
        }
        public bool Delete(int key)
        {
            return DataAccessLayer_Delete(key);
        }
        public static List<Country> GetAllCountrys()
        {
            return DataAccessLayer_GetAllCountrys();
        }
        protected bool DataAccessLayer_Load(int key)
        {
            try
            {
                //Step 1-Use DAL object Factory to get the SQL Server FACTORY Data Access Object 
                //using POLYMORPHISM. 
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the sql FACTORY data access object  
                //call the correct Data Access Object to perform the Data Access 
                CountryDAO objCountryDAO = objDAOFactory.GetCountryDAO();

                //Step 3-Call DATA ACCESS LAYER CountryDAO Data Access Object to do the work 
                CountryDTO objCountryDTO = objCountryDAO.GetRecordByID(key);

                //Step 4- test if DTO object exists & populate this object with DTO object's properties 
                //and return a true or return a False if no DTO object exists. 
                if (objCountryDTO != null)
                {
                    //Step 4a-get the data from the Data Transfer Object 
                    this.CountryID = objCountryDTO.CountryID;
                    this.CountryCode = objCountryDTO.CountryCode;
                    this.CountryName = objCountryDTO.CountryName;

                    //Step 4c-Returns a true since this class object has been populated. 
                    return true;
                }
                else
                {
                    //Step 5- No object returned from DALayer, return a false 
                    return false;
                }

            }//End of try 
             //Step B-Traps for general exception.   
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions 
                throw new Exception("Unexpected Error in DALayer_Load(key) Method: {0} " + objE.Message);
            }

        }
        protected bool DataAccessLayer_Insert()
        {
            try
            {
                //Step 1-Use DAL object Factory to get the SQL Server FACTORY Data Access Object 
                //using POLYMORPHISM. 
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the sql FACTORY data access object  
                //call the correct Data Access Object to perform the Data Access 
                CountryDAO objCountryDAO = objDAOFactory.GetCountryDAO();

                //Step 3-Call DATA ACCESS LAYER CountryDAO Data Access Object to do the work 
                CountryDTO objCountryDTO = new CountryDTO();

                //Step 4- POPULATE the Data Transfer Object with data from THIS OBJECT to send to database 
                objCountryDTO.CountryID = this.CountryID;
                objCountryDTO.CountryCode = this.CountryCode;
                objCountryDTO.CountryName = this.CountryName;

                //Step 5-Call DATA ACCESS LAYER CountryDAO Data Access Object to do the work 
                bool inserted = objCountryDAO.Insert(objCountryDTO);

                //Step 6- test if insert to database was successful return true, 
                //otherwise return false 
                if (inserted == true)
                {

                    //Step 6b-Returns a true since this class object has been inserted & marked as old. 
                    return true;
                }
                else
                {
                    //Step 7- No record inserted, return a false 
                    return false;

                }



            }//End of try 
             //Step B-Traps for general exception.   
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions 
                throw new Exception("Unexpected Error in DALayer_Insert() Method: {0} " + objE.Message);

            }
        }
        protected bool DataAccessLayer_Update()
        {
            try
            {
                //Step 1-Use DAL object Factory to get the SQL Server FACTORY Data Access Object 
                //using POLYMORPHISM. 
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the sql FACTORY data access object  
                //call the correct Data Access Object to perform the Data Access 
                CountryDAO objCountryDAO = objDAOFactory.GetCountryDAO();

                //Step 3-Call DATA ACCESS LAYER CountryDAO Data Access Object to do the work 
                CountryDTO objCountryDTO = new CountryDTO();

                //Step 4- POPULATE the Data Transfer Object with data from THIS OBJECT to send to database 
                objCountryDTO.CountryID = this.CountryID;
                objCountryDTO.CountryCode = this.CountryCode;
                objCountryDTO.CountryName = this.CountryName;


                //Step 5-Call DATA ACCESS LAYER CountryDAO Data Access Object to do the work 
                bool updated = objCountryDAO.Update(objCountryDTO);

                //Step 6- test if update to database was successful & MARK the object as old return true, 
                //otherwise return false 
                if (updated == true)
                {

                    //Step 6b-Returns a true since this class object has been updated. 
                    return true;
                }
                else
                {
                    //Step 7- No record updated, return a false 
                    return false;

                }

            }//End of try 
             //Step B-Traps for general exception.   
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions 
                throw new Exception("Unexpected Error in DALayer_Update() Method: {0} " + objE.Message);

            }
        }
        protected bool DataAccessLayer_Delete(int key)
        {
            try
            {
                //Step 1-Use DAL object Factory to get the SQL Server FACTORY Data Access Object 
                //using POLYMORPHISM. 
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the sql FACTORY data access object  
                //call the correct Data Access Object to perform the Data Access 
                CountryDAO objCountryDAO = objDAOFactory.GetCountryDAO();

                //Step 3-Call DATA ACCESS LAYER CountryDAO Data Access Object to do the work 
                bool deleted = objCountryDAO.Delete(key);


                //Step 4- Test if delete to database was successful & MARK the object as NEW since 
                //deleted from database and NEW in memory and return a true, otherwise return false 
                if (deleted == true)
                {

                    //Step 4b-Returns a true since this class object has been deleted & marked as NEW. 
                    return true;
                }
                else
                {
                    //Step 5-No record deleted, return a false 
                    return false;

                }

            }//End of try 
             //Step B-Traps for general exception.   
            catch (Exception objE)
            {
                //Step C-Re-Throw an general exceptions 
                throw new Exception("Unexpected Error in DALayer_Delete() Method: {0} " + objE.Message);

            }
        }
        static List<Country> DataAccessLayer_GetAllCountrys()
        {
            try
            {
                //Step 1-Use DAL object Factory to get the SQL Server FACTORY Data Access Object 
                //using POLYMORPHISM. 
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the SQL FACTORY object GET DAO object to do the work 
                CountryDAO objCountryDAO = objDAOFactory.GetCountryDAO();

                //Step 3-call CountryDAO DAO to do the work & return COLLECTION of Data Transfer Objects 
                List<CountryDTO> objCountryDTOList = objCountryDAO.GetAllRecords();


                //Step 4- test if List<CountryDTO> DTO collection exists  
                if (objCountryDTOList != null)
                {

                    //Step 5-Create a LIST Collection of Country object to get copy of DTO collection 
                    List<Country> objCountryList = new List<Country>();

                    //Step 6-Loop through List<CountryDTO> objCountryDTOList collection 
                    foreach (CountryDTO objDTO in objCountryDTOList)
                    {

                        //Step 6a-Create new Country object 
                        Country objCountry = new Country();


                        //Step 6b-get the data from DTO object and SET Country object 
                        objCountry.CountryID = objDTO.CountryID;
                        objCountry.CountryCode = objDTO.CountryCode;
                        objCountry.CountryName = objDTO.CountryName;

                        //Step 6c-Add Country Object to the objCountryList List<Country> COLLECTION   
                        objCountryList.Add(objCountry);

                    }//End of foreach 

                    //Step 6d-once copy process ends, Return objCountryList List<Country> COLLECTION 
                    return objCountryList;

                }
                else
                {
                    //Step 6e- No DTO collection object returned from DALayer, return a null 
                    return null;
                }

            }//End of try 

            //Step B-Traps for general exception.   
            catch (Exception objE)
            {
                //Step C-Re-Throw a general exceptions 
                throw new Exception("Unexpected Error in DALayer_GetAllCountrys(key) Method: {0} " +
                objE.Message);

            }
        }
    }
}

