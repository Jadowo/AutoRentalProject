using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataAccessLayer;

namespace BusinessLayer
{
    public class CreditCard
    {
        private string m_CreditCardNumber;
        private string m_CreditCardOwnerName;
        private string m_MerchantName;
        private DateTime m_ExpDate;
        private string m_AddressLine1;
        private string m_AddressLine2;
        private string m_City;
        private string m_StateCode;
        private string m_ZipCode;
        private string m_Country;
        private decimal m_CreditCardLimit;
        private decimal m_CreditCardBalance;
        private bool m_ActivationStatus;

        public string CreditCardNumber { get => m_CreditCardNumber; set => m_CreditCardNumber = value; }
        public string CreditCardOwnerName { get => m_CreditCardOwnerName; set => m_CreditCardOwnerName = value; }
        public string MerchantName { get => m_MerchantName; set => m_MerchantName = value; }
        public DateTime ExpDate { get => m_ExpDate; set => m_ExpDate = value; }
        public string AddressLine1 { get => m_AddressLine1; set => m_AddressLine1 = value; }
        public string AddressLine2 { get => m_AddressLine2; set => m_AddressLine2 = value; }
        public string City { get => m_City; set => m_City = value; }
        public string StateCode { get => m_StateCode; set => m_StateCode = value; }
        public string ZipCode { get => m_ZipCode; set => m_ZipCode = value; }
        public string Country { get => m_Country; set => m_Country = value; }
        public decimal CreditCardLimit { get => m_CreditCardLimit; set => m_CreditCardLimit = value; }
        public decimal CreditCardBalance { get => m_CreditCardBalance; set => m_CreditCardBalance = value; }
        public bool ActivationStatus { get => m_ActivationStatus;}

        public CreditCard()
        {
            m_CreditCardNumber = "";
            m_CreditCardOwnerName = "";
            m_MerchantName = "";
            m_ExpDate = new DateTime().Date;
            m_AddressLine1 = "";
            m_AddressLine2 = "";
            m_City = "";
            m_StateCode = "";
            m_ZipCode = "";
            m_Country = "";
            m_CreditCardLimit = 3000.0M;
            m_CreditCardBalance = 3000.0M;
            m_ActivationStatus = true;
        }
        public CreditCard(string CCNumber, string CCOName, string MName, string ExpDate, string ALine1, string ALine2,
            string City, string StateCode, string ZipCode, string Country, decimal CCLimit = 3000.0M, decimal CCBalance = 3000.0M)
        {
            this.m_CreditCardNumber = CCNumber;
            this.m_CreditCardOwnerName = CCOName;
            this.m_MerchantName = MName;
            this.m_ExpDate = Convert.ToDateTime(ExpDate);
            this.m_AddressLine1 = ALine1;
            this.m_AddressLine2 = ALine2;
            this.m_City = City;
            this.m_StateCode = StateCode;
            this.m_ZipCode = ZipCode;
            this.m_Country = Country;
            this.m_CreditCardLimit = CCLimit;
            this.m_CreditCardBalance = CCBalance;
            this.m_ActivationStatus = true;
        }
        ~CreditCard()
        {
            Console.WriteLine("CreditCard is being destroyed and destructor is being called");
        }

        public void Print()
        {
            try
            {
                StreamWriter printer = new StreamWriter("Network_Printer.txt");
                printer.WriteLine("Credit Card Information: " +
                    "\nCredit Card Number = " + this.m_CreditCardNumber +
                    "\nCredit Card Owner Name = " + this.m_CreditCardOwnerName +
                    "\nMerchant Name = " + this.m_MerchantName +
                    "\nExpiration Date = " + this.ExpDate.ToShortDateString() +
                    "\nAddress Line 1 = " + this.m_AddressLine1 +
                    "\nAddress Line 2 = " + this.m_AddressLine2 +
                    "\nCity = " + this.m_City +
                    "\nState Code = " + this.m_StateCode +
                    "\nZipcode = " + this.m_ZipCode +
                    "\nCountry = " + this.m_Country +
                    "\nCredit Card Limit = " + this.m_CreditCardLimit +
                    "\nCredit Card Balance = " + this.m_CreditCardBalance +
                    "\nActivation Status = " + this.m_ActivationStatus);
                printer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public bool Activate()
        {

            return this.m_ActivationStatus = true;
        }
        public bool Deactivate()
        {
            return this.m_ActivationStatus = false;
        }
        public bool Load(string key)
        {
            return DataAccessLayer_Load(key);
        }
        public bool Insert()
        {
            return DataAccessLayer_Insert();
        }
        public bool InsertCreditCardOfACustomer(string customerKey)
        {
            return DataAccessLayer_InsertCreditCardOfACustomer(customerKey);
        }
        public bool Update()
        {
            return DataAccessLayer_Update();
        }
        public bool Delete(string key)
        {
            return DataAccessLayer_Delete(key);
        }
        public static List<CreditCard> GetAllCreditCards()
        {
            return DataAccessLayer_GetAllCreditCards();
        }
        protected bool DataAccessLayer_Load(string key)
        {
            try
            {
                
                //Step 1-Use DAL object Factory to get the SQL Server FACTORY Data Access Object 
                //using POLYMORPHISM. 
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the sql FACTORY data access object  
                //call the correct Data Access Object to perform the Data Access 
                CreditCardDAO objCreditCardDAO = objDAOFactory.GetCreditCardDAO();

                //Step 3-Call DATA ACCESS LAYER CreditCardDAO Data Access Object to do the work 
                CreditCardDTO objCreditCardDTO = objCreditCardDAO.GetRecordByID(key);

                //Step 4- test if DTO object exists & populate this object with DTO object's properties 
                //and return a true or return a False if no DTO object exists. 
                if (objCreditCardDTO != null)
                {
                    //Step 4a-get the data from the Data Transfer Object 
                    this.CreditCardNumber = objCreditCardDTO.CreditCardNumber;
                    this.CreditCardOwnerName = objCreditCardDTO.CreditCardOwnerName;
                    this.MerchantName = objCreditCardDTO.MerchantName;
                    this.ExpDate = objCreditCardDTO.ExpDate;
                    this.AddressLine1 = objCreditCardDTO.AddressLine1;
                    this.AddressLine2 = objCreditCardDTO.AddressLine2;
                    this.City = objCreditCardDTO.City;
                    this.StateCode = objCreditCardDTO.StateCode;
                    this.ZipCode = objCreditCardDTO.ZipCode;
                    this.Country = objCreditCardDTO.Country;
                    this.CreditCardLimit = objCreditCardDTO.CreditCardLimit;
                    this.CreditCardBalance = objCreditCardDTO.CreditCardBalance;

                    //Handle activation status accordingly using methods 
                    //since ActivationStutus property is read only 
                    if (objCreditCardDTO.ActivationStatus == true)
                        this.Activate();
                    else
                        this.Deactivate();
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

                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                CreditCardDAO objCreditCardDAO = objDAOFactory.GetCreditCardDAO();

                CreditCardDTO objCreditCardDTO = new CreditCardDTO();

                objCreditCardDTO.CreditCardNumber = this.CreditCardNumber;
                objCreditCardDTO.CreditCardOwnerName = this.CreditCardOwnerName;
                objCreditCardDTO.MerchantName = this.MerchantName;
                if(this.ExpDate.Year >= 1753)
                {
                    objCreditCardDTO.ExpDate = this.ExpDate;
                }
                else
                {
                    objCreditCardDTO.ExpDate = DateTime.Now;
                }
                objCreditCardDTO.AddressLine1 = this.AddressLine1;
                objCreditCardDTO.AddressLine2 = this.AddressLine2;
                objCreditCardDTO.City = this.City;
                objCreditCardDTO.StateCode = this.StateCode;
                objCreditCardDTO.ZipCode = this.ZipCode;
                objCreditCardDTO.Country = this.Country;
                objCreditCardDTO.CreditCardLimit = this.CreditCardLimit;
                objCreditCardDTO.CreditCardBalance = this.CreditCardBalance;
                objCreditCardDTO.ActivationStatus = true;

                //Step 5-Call DATA ACCESS LAYER CreditCardDAO Data Access Object to do the work 
                bool inserted = objCreditCardDAO.Insert(objCreditCardDTO);

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
        protected bool DataAccessLayer_InsertCreditCardOfACustomer(string customerKey)
        {
            try
            {
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the sql FACTORY data access object  
                //call the correct Data Access Object to perform the Data Access 
                CreditCardDAO objCreditCardDAO = objDAOFactory.GetCreditCardDAO();

                //Step 3-Create new Data Transfer Object to send to DA Later for DATA ACCESS LAYER 
                CreditCardDTO objCreditCardDTO = objCreditCardDAO.GetRecordByID(customerKey);

                //Step 4- POPULATE the Data Transfer Object with data from THIS OBJECT to send to database 
                objCreditCardDTO.CreditCardNumber = this.CreditCardNumber;
                objCreditCardDTO.CreditCardOwnerName = this.CreditCardOwnerName;
                objCreditCardDTO.MerchantName = this.MerchantName;
                objCreditCardDTO.ExpDate = this.ExpDate;
                objCreditCardDTO.AddressLine1 = this.AddressLine1;
                objCreditCardDTO.AddressLine2 = this.AddressLine2;
                objCreditCardDTO.City = this.City;
                objCreditCardDTO.StateCode = this.StateCode;
                objCreditCardDTO.ZipCode = this.ZipCode;
                objCreditCardDTO.Country = this.Country;
                objCreditCardDTO.CreditCardLimit = this.CreditCardLimit;
                objCreditCardDTO.CreditCardBalance = this.CreditCardBalance;
                objCreditCardDTO.ActivationStatus = this.ActivationStatus;

                //Step 5-Call DATA ACCESS LAYER CreditCardDAO Data Access Object to do the work 
                bool inserted = objCreditCardDAO.Insert(objCreditCardDTO);

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
                throw new Exception("Unexpected Error in DALayer_InsertCreditCardOfACustomer() Method: {0} " + objE.Message);
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
                CreditCardDAO objCreditCardDAO = objDAOFactory.GetCreditCardDAO();

                //Step 3-Create new Data Transfer Object to send to DA Later for DATA ACCESS LAYER 
                CreditCardDTO objCreditCardDTO = new CreditCardDTO();

                //Step 4- POPULATE the Data Transfer Object with data from THIS OBJECT to send to database 
                objCreditCardDTO.CreditCardNumber = this.CreditCardNumber;
                objCreditCardDTO.CreditCardOwnerName = this.CreditCardOwnerName;
                objCreditCardDTO.MerchantName = this.MerchantName;
                objCreditCardDTO.ExpDate = this.ExpDate;
                objCreditCardDTO.AddressLine1 = this.AddressLine1;
                objCreditCardDTO.AddressLine2 = this.AddressLine2;
                objCreditCardDTO.City = this.City;
                objCreditCardDTO.StateCode = this.StateCode;
                objCreditCardDTO.ZipCode = this.ZipCode;
                objCreditCardDTO.Country = this.Country;
                objCreditCardDTO.CreditCardLimit = this.CreditCardLimit;
                objCreditCardDTO.CreditCardBalance = this.CreditCardBalance;
                objCreditCardDTO.ActivationStatus = this.ActivationStatus;


                //Step 5-Call DATA ACCESS LAYER CreditCardDAO Data Access Object to do the work 
                bool updated = objCreditCardDAO.Update(objCreditCardDTO);

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
        protected bool DataAccessLayer_Delete(string key)
        {
            try
            {
                //Step 1-Use DAL object Factory to get the SQL Server FACTORY Data Access Object 
                //using POLYMORPHISM. 
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the sql FACTORY data access object  
                //call the correct Data Access Object to perform the Data Access 
                CreditCardDAO objCreditCardDAO = objDAOFactory.GetCreditCardDAO();

                //Step 3-Call DATA ACCESS LAYER CreditCardDAO Data Access Object to do the work 
                bool deleted = objCreditCardDAO.Delete(key);


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
        static List<CreditCard> DataAccessLayer_GetAllCreditCards()
        {
            try
            {
                //Step 1-Use DAL object Factory to get the SQL Server FACTORY Data Access Object 
                //using POLYMORPHISM. 
                DALObjectFactoryBase objDAOFactory =
                DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);

                //Step 2-now that you have the SQL FACTORY object GET DAO object to do the work 
                CreditCardDAO objCreditCardDAO = objDAOFactory.GetCreditCardDAO();

                //Step 3-call CreditCardDAO DAO to do the work & return COLLECTION of Data Transfer Objects 
                List<CreditCardDTO> objCreditCardDTOList = objCreditCardDAO.GetAllRecords();


                //Step 4- test if List<CreditCardDTO> DTO collection exists  
                if (objCreditCardDTOList != null)
                {

                    //Step 5-Create a LIST Collection of CreditCard object to get copy of DTO collection 
                    List<CreditCard> objCreditCardList = new List<CreditCard>();

                    //Step 6-Loop through List<CreditCardDTO> objCreditCardDTOList collection 
                    foreach (CreditCardDTO objDTO in objCreditCardDTOList)
                    {

                        //Step 6a-Create new CreditCard object 
                        CreditCard objCreditCard = new CreditCard();


                        //Step 6b-get the data from DTO object and SET CreditCard object 
                        objCreditCard.CreditCardNumber = objDTO.CreditCardNumber;
                        objCreditCard.CreditCardOwnerName = objDTO.CreditCardOwnerName;
                        objCreditCard.MerchantName = objDTO.MerchantName;
                        objCreditCard.ExpDate = objDTO.ExpDate;
                        objCreditCard.AddressLine1 = objDTO.AddressLine1;
                        objCreditCard.AddressLine2 = objDTO.AddressLine2;
                        objCreditCard.City = objDTO.City;
                        objCreditCard.StateCode = objDTO.StateCode;
                        objCreditCard.ZipCode = objDTO.ZipCode;
                        objCreditCard.Country = objDTO.Country;
                        objCreditCard.CreditCardLimit = objDTO.CreditCardLimit;
                        objCreditCard.CreditCardBalance = objDTO.CreditCardBalance;

                        //Handle activation status accordingly since ActivationStutus property is read only 
                        if (objDTO.ActivationStatus == true)
                            objCreditCard.Activate();
                        else
                            objCreditCard.Deactivate();

                        //Step 6c-Add CreditCard Object to the objCreditCardList List<CreditCard> COLLECTION   
                        objCreditCardList.Add(objCreditCard);

                    }//End of foreach 

                    //Step 6d-once copy process ends, Return objCreditCardList List<CreditCard> COLLECTION 
                    return objCreditCardList;

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
                throw new Exception("Unexpected Error in DALayer_GetAllCreditCards(key) Method: {0} " +
                objE.Message);

            }
        }
    }
}
