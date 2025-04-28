using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using ACCMS_AGH.DB;
using ACCMS_AGH.Models.Accms;
using Oracle.ManagedDataAccess.Client;

namespace ACCMS_AGH.Repositories
{
    public class AccmsRepositories
    {
        private readonly DbConnection _dbconnection;

        public AccmsRepositories(IConfiguration configuration)
        {
            _dbconnection = new DbConnection(configuration);
        }

        // Public method to get ledger information by group code
        public List<AccountLedger> GetLedgerInformationGridByGroupCode(string strControl)
        {
            if (string.IsNullOrEmpty(strControl))
            {
                throw new ArgumentException("Group Code is required.", nameof(strControl));
            }

            string packageName = "AGH_ACCMS.PKG_ACCOUNT_CHEQUE.GetLedgerInformationGridByGroupCode";
            OracleParameter[] parameterList = new OracleParameter[]
            {
                new OracleParameter("cur_01", OracleDbType.RefCursor, ParameterDirection.Output),
                new OracleParameter("Pcontrol", OracleDbType.Varchar2, 100) { Value = strControl }
            };

            return GetLedgerInformationGridByGroupCode(packageName, parameterList);
        }

        // Private method to execute the stored procedure and fetch results
        private List<AccountLedger> GetLedgerInformationGridByGroupCode(string packageName, OracleParameter[] parameterList)
        {
            List<AccountLedger> objLedger = new List<AccountLedger>();

            // Use 'using' to ensure the connection is disposed properly
            using (var con = _dbconnection.GetConnection())
            {
                // Ensure the connection is opened only once
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                // Create the command and set up parameters
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = packageName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameterList);

                    // Execute the command and read the results
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            AccountLedger oLedger = new AccountLedger
                            {
                                L_NAME = rdr["PartyName"]?.ToString(),
                                L_CODE = rdr["l_code"]?.ToString(),
                                L_CODE_ALLOC = rdr["codeallocation"]?.ToString() ?? string.Empty
                            };

                            objLedger.Add(oLedger);
                        }
                    }
                }
            }

            return objLedger;
        }


     public short SaveChequeAllotment(
     string LCode,
     string? Lname,
     string ChqNo,
     string? Amount,
     string? Chqdate,
     string? ValidDate,
     string? Payment_Type,
     string? Remarks,
     string? EntryBy,
     string? CompanyID,
     string? LocationID,
     string? MachineID)
        {
            string packageName = "AGH_ACCMS.PKG_ACCOUNT_CHEQUE.SaveChequeAllotment";

            OracleParameter[] parameterList = new OracleParameter[]
            {
                   new OracleParameter("P_LCode", OracleDbType.Varchar2, 25) { Value = LCode ?? string.Empty },
                   new OracleParameter("P_Lname", OracleDbType.Varchar2, 1000) { Value = Lname ?? string.Empty },
                   new OracleParameter("P_ChqNo", OracleDbType.Varchar2, 25) { Value = ChqNo ?? string.Empty },
                   new OracleParameter("P_Amount", OracleDbType.Varchar2, 25) { Value = Amount ?? string.Empty },
                   new OracleParameter("P_Chqdate", OracleDbType.Varchar2, 25) { Value = Chqdate ?? string.Empty },
                   new OracleParameter("P_ValidDate", OracleDbType.Varchar2, 25) { Value = ValidDate ?? string.Empty },
                   new OracleParameter("P_Payment_Type", OracleDbType.Varchar2, 250) { Value = Payment_Type ?? string.Empty },
                   new OracleParameter("P_Remarks", OracleDbType.Varchar2, 250) { Value = Remarks ?? string.Empty },
                   new OracleParameter("PEntryby", OracleDbType.Varchar2, 60) { Value = EntryBy ?? string.Empty },
                   new OracleParameter("PcomID", OracleDbType.Varchar2, 10) { Value = CompanyID ?? string.Empty },
                   new OracleParameter("PlocID", OracleDbType.Varchar2, 10) { Value = LocationID ?? string.Empty },
                   new OracleParameter("PmacID", OracleDbType.Varchar2, 30) { Value = MachineID ?? string.Empty },
                   new OracleParameter("P_Error_Code", OracleDbType.Varchar2, 300) { Direction = ParameterDirection.Output },
                   new OracleParameter("P_Error_Msg", OracleDbType.Varchar2, 300) { Direction = ParameterDirection.Output }
            };

            try
            {
                using (var con = _dbconnection.GetConnection())
                {
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = packageName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameterList);

                        cmd.ExecuteNonQuery();

                        string? errorCode = cmd.Parameters["P_Error_Code"].Value?.ToString();
                        string? errorMsg = cmd.Parameters["P_Error_Msg"].Value?.ToString();

                        if (errorCode == "0" || string.IsNullOrEmpty(errorCode))
                        {
                            return 1; // Success
                        }

                        throw new Exception($"Database error: {errorMsg} (Code: {errorCode})");
                    }
                }
            }
            catch (OracleException ex)
            {
                throw new Exception($"Oracle error occurred while saving cheque allotment: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving cheque allotment: {ex.Message}", ex);
            }
        }
        public List<ChequeRegisterDetails> GetCheqInformationGrid(string strControl)
        {
            if (string.IsNullOrEmpty(strControl))
            {
                throw new ArgumentException("Group Code is required.", nameof(strControl));
            }

            string packageName = "AGH_ACCMS.PKG_ACCOUNT_CHEQUE.GetCheqInformationGrid";
            OracleParameter[] parameterList = new OracleParameter[]
            {
        new OracleParameter("cur_01", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output),
        new OracleParameter("Pcontrol", OracleDbType.Varchar2, 100, strControl, ParameterDirection.Input),
            };

            return GetChequeInformation(packageName, parameterList);
        }

        public List<ChequeRegisterDetails> GetChequeInformation(string packageName, OracleParameter[] parameterList)
        {
            List<ChequeRegisterDetails> cheques = new List<ChequeRegisterDetails>();

            try
            {
                using (var con = _dbconnection.GetConnection())
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = packageName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameterList);

                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                var cheque = new ChequeRegisterDetails
                                {
                                    BankName = rdr["BANK_NAME"]?.ToString() ?? string.Empty,
                                    AccountNumber = rdr["ACC_NO"]?.ToString() ?? string.Empty,
                                    CHQ_NO = rdr["CHQ_NO"]?.ToString() ?? string.Empty,

                                };

                                cheques.Add(cheque);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you might want to use a logging framework)
                throw new Exception("Error retrieving cheque information", ex);
            }

            return cheques;
        }

        public List<ChequeRegisterDetailsModel> GetList(string pPrint)
        {
            if (string.IsNullOrEmpty(pPrint))
            {
                pPrint = ""; // Default to empty string if null or empty
            }

            string packageName = "AGH_ACCMS.PKG_ACCOUNT_CHEQUE.Get_LoadInitialAllotment";   

            return GetRegList(packageName, pPrint);
        }

        private List<ChequeRegisterDetailsModel> GetRegList(string packageName, string pPrint)
        {
            List<ChequeRegisterDetailsModel> objCollection = new List<ChequeRegisterDetailsModel>();

            using (var con = _dbconnection.GetConnection())
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = packageName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_cur", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("p_Print", OracleDbType.Varchar2).Value = pPrint ??  " ";

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ChequeRegisterDetailsModel coll = new ChequeRegisterDetailsModel
                            {
                                SL = Convert.ToInt32(rdr["SL"]),
                                LEDGERNO = rdr["LEDGERNO"]?.ToString(),
                                PARTY_NAME = rdr["PARTY_NAME"]?.ToString(),
                                CHEQ_NO = rdr["CHEQ_NO"]?.ToString(),
                                CHEQ_DATE = rdr["CHEQ_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["CHEQ_DATE"]),
                                CHEQ_AMOUNT = Convert.ToDecimal(rdr["CHEQ_AMOUNT"]),
                                SIGNBY = rdr["SIGNBY"]?.ToString(),
                                ALLOTMENTBY = rdr["ALLOTMENTBY"]?.ToString(),
                                VALIDTILL = rdr["VALIDTILL"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["VALIDTILL"]),
                                REMARKS = rdr["REMARKS"]?.ToString(),
                                PAYMENTTYPE = rdr["PAYMENTTYPE"]?.ToString(),
                                ENTRY_DATE = rdr["ENTRY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["ENTRY_DATE"]),
                                TRNSNO = rdr["TRNSNO"]?.ToString(),
                                TNS_TYPE = rdr["TNS_TYPE"]?.ToString(),
                                TRNS_DATE = rdr["TRNS_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["TRNS_DATE"]),
                                BANK_ID = Convert.ToInt32(rdr["BANK_ID"]),
                                BANK_NAME = rdr["BANK_NAME"]?.ToString(),
                                ACC_NO = rdr["ACC_NO"]?.ToString(),
                                ROUTING_NO = rdr["ROUTING_NO"]?.ToString(),
                                BEF_NAME = rdr["BEF_NAME"]?.ToString(),
                                NOTE = rdr["NOTE"]?.ToString()
                            };

                            objCollection.Add(coll);
                        }
                    }
                }
            }

            return objCollection;
        }


        public List<ChequePrintDetails> GetChequeRegisterPrintReport(int Where, string cp_ChequeNo)
        {

            if (string.IsNullOrEmpty(cp_ChequeNo))
            {
                throw new ArgumentException("Group Code is required.", nameof(cp_ChequeNo));
            }


            string packageName = " ";

            OracleParameter[] parameterList = new OracleParameter[]
               {
                    new OracleParameter("cur_01",OracleDbType.RefCursor,DBNull.Value,ParameterDirection.Output),
                    new OracleParameter("pwhere",OracleDbType.Int16,2,Where,ParameterDirection.Input),
                    new OracleParameter("Pcp_ChequeNo",OracleDbType.Varchar2,60,cp_ChequeNo,ParameterDirection.Input),
               };

            return GetChequeRegisterPrintReportList(packageName, parameterList);
        }

        private List<ChequePrintDetails> GetChequeRegisterPrintReportList(string packageName, OracleParameter[] parameterList)
        {
            List<ChequePrintDetails> objCollection = new List<ChequePrintDetails>();

            using (var con = _dbconnection.GetConnection())
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = packageName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameterList);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ChequePrintDetails coll = new ChequePrintDetails
                            {
                                cp_LedgerNo = rdr["LEDGERNO"] == DBNull.Value ? "N/A" : rdr["LEDGERNO"].ToString(),
                                cp_Party_Name = rdr["PARTY_NAME"] == DBNull.Value ? "N/A" : rdr["PARTY_NAME"].ToString(),
                                Cheque_No = rdr["CHQ_NO"] == DBNull.Value ? "N/A" : rdr["CHQ_NO"].ToString(),
                                cp_ChequeDate = rdr["CHEQ_DATE"] == DBNull.Value ? null : Convert.ToDateTime(rdr["CHEQ_DATE"]),
                                cp_Amount = rdr["CHEQ_AMOUNT"] == DBNull.Value ? 0.0 : Convert.ToDouble(rdr["CHEQ_AMOUNT"]),
                                cp_SignBy = rdr["SIGNBY"] == DBNull.Value ? "N/A" : rdr["SIGNBY"].ToString(),
                                cp_AllotmentBy = rdr["ALLOTMENTBY"] == DBNull.Value ? "N/A" : rdr["ALLOTMENTBY"].ToString(),
                                cp_ValidTill = rdr["VALIDTILL"] == DBNull.Value ? null : Convert.ToDateTime(rdr["VALIDTILL"]),
                                cp_Remarks = rdr["REMARKS"] == DBNull.Value ? "N/A" : rdr["REMARKS"].ToString(),
                                PAYMENTTYPE = rdr["PAYMENTTYPE"] == DBNull.Value ? "N/A" : rdr["PAYMENTTYPE"].ToString(),
                                cp_Entrydate = rdr["entry_Date"] == DBNull.Value ? null : Convert.ToDateTime(rdr["entry_Date"]),
                                cp_trnsNo = rdr["TRNS_NO"] == DBNull.Value ? "N/A" : rdr["TRNS_NO"].ToString(),
                                cp_trnsType = rdr["TNS_TYPE"] == DBNull.Value ? "N/A" : rdr["TNS_TYPE"].ToString(),
                                cp_trns_Date = rdr["TRNS_DATE"] == DBNull.Value ? null : Convert.ToDateTime(rdr["TRNS_DATE"]),
                                BankID = rdr["BANK_ID"] == DBNull.Value ? "N/A" : rdr["BANK_ID"].ToString(),
                                BANK_NAME = rdr["BANK_NAME"] == DBNull.Value ? "N/A" : rdr["BANK_NAME"].ToString(),
                                ACC_No = rdr["ACC_No"] == DBNull.Value ? "N/A" : rdr["ACC_No"].ToString(),
                                ROUTING_NO = rdr["ROUTING_NO"] == DBNull.Value ? "N/A" : rdr["ROUTING_NO"].ToString(),
                                BEF_NAME = rdr["BEF_NAME"] == DBNull.Value ? "N/A" : rdr["BEF_NAME"].ToString()
                            };

                            objCollection.Add(coll);
                        }
                    }
                }
            }

            return objCollection;
        }







    }
}
