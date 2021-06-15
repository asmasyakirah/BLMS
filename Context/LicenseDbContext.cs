using BLMS.v2.Models.License;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BLMS.v2.Context
{
    public class LicenseDbContext
    {
        //readonly string connectionstring = "Data Source=EGBS11N10043471;Database=BLMS;User ID = sa; Password=P@ss1234; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        readonly string connectionstring = "Data Source = 10.249.1.125; Database=BLMSDev;User ID = Appsa; Password=Opuswebsql2017;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region LicenseHQ
        //List All License HQ
        public IEnumerable<LicenseHQ> LicenseHQGetAll()
        {
            var licenseHQList = new List<LicenseHQ>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseHQGetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var licenseHQ = new LicenseHQ();

                    licenseHQ.LicenseID = Convert.ToInt32(dr["LicenseID"].ToString());
                    licenseHQ.LicenseName = dr["LicenseName"].ToString();
                    licenseHQ.CategoryName = dr["CategoryName"].ToString();
                    licenseHQ.UnitName = dr["UnitName"].ToString();
                    licenseHQ.IssuedDT = dr["IssuedDT"].ToString();
                    licenseHQ.ExpiredDT = dr["ExpiredDT"].ToString();
                    licenseHQ.PIC1Name = dr["PIC1Name"].ToString();
                    licenseHQ.PIC2Name = dr["PIC2Name"].ToString();
                    licenseHQ.PIC3Name = dr["PIC3Name"].ToString();
                    licenseHQ.isRequested = Convert.ToBoolean(dr["isRequested"].ToString());
                    licenseHQ.isApproved = Convert.ToBoolean(dr["isApproved"].ToString());
                    licenseHQ.isRegistered = Convert.ToBoolean(dr["isRegistered"].ToString());
                    licenseHQ.isRenewed = Convert.ToBoolean(dr["isRenewed"].ToString());

                    licenseHQ.RenewReminderDT = Convert.ToDateTime(dr["RenewReminderDT"].ToString());

                    licenseHQList.Add(licenseHQ);
                }

                conn.Close();
            }

            return licenseHQList;
        }

        //License Request
        public void RequestLicenseHQ(LicenseHQ licenseHQ)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseHQRequest", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CategoryID", licenseHQ.CategoryID);
                cmd.Parameters.AddWithValue("DivID", licenseHQ.DivID);
                cmd.Parameters.AddWithValue("UnitID", licenseHQ.UnitID);
                cmd.Parameters.AddWithValue("LicenseName", licenseHQ.LicenseName);
                cmd.Parameters.AddWithValue("PIC2StaffNo", licenseHQ.PIC2StaffNo);
                cmd.Parameters.AddWithValue("PIC3StaffNo", licenseHQ.PIC3StaffNo);
                cmd.Parameters.AddWithValue("Remarks", licenseHQ.Remarks);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Get License HQ By ID
        public LicenseHQ GetLicenseHQByID(int? id)
        {
            var licenseHQ = new LicenseHQ();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseHQGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("LicenseID", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    licenseHQ.LicenseName = dr["LicenseName"].ToString();
                    licenseHQ.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    licenseHQ.CategoryName = dr["CategoryName"].ToString();
                    licenseHQ.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    licenseHQ.DivName = dr["DivName"].ToString();
                    licenseHQ.UnitID = Convert.ToInt32(dr["UnitID"].ToString());
                    licenseHQ.UnitName = dr["UnitName"].ToString();

                    licenseHQ.RegistrationNo = dr["RegistrationNo"].ToString();
                    licenseHQ.SerialNo = dr["SerialNo"].ToString();

                    licenseHQ.PIC1StaffNo = dr["PIC1StaffNo"].ToString();
                    licenseHQ.PIC1Name = dr["PIC1Name"].ToString();
                    licenseHQ.PIC1Email = dr["PIC1Email"].ToString();

                    licenseHQ.PIC2StaffNo = dr["PIC2StaffNo"].ToString();
                    licenseHQ.PIC2Name = dr["PIC2Name"].ToString();
                    licenseHQ.PIC2Email = dr["PIC2Email"].ToString();
                    licenseHQ.PIC3StaffNo = dr["PIC3StaffNo"].ToString();
                    licenseHQ.PIC3Name = dr["PIC3Name"].ToString();
                    licenseHQ.PIC3Email = dr["PIC3Email"].ToString();
                    licenseHQ.Remarks = dr["Remarks"].ToString();

                    licenseHQ.isRequested = Convert.ToBoolean(dr["isRequested"].ToString());
                    licenseHQ.isApproved = Convert.ToBoolean(dr["isApproved"].ToString());
                    licenseHQ.isRegistered = Convert.ToBoolean(dr["isRegistered"].ToString());
                    licenseHQ.isRenewed = Convert.ToBoolean(dr["isRenewed"].ToString());
                }

                conn.Close();
            }

            return licenseHQ;
        }
        #endregion

        #region LicenseSite
        //List All License HQ
        public IEnumerable<LicenseSite> LicenseSiteGetAll()
        {
            var licenseSiteList = new List<LicenseSite>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseSiteGetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var licenseSite = new LicenseSite();

                    licenseSite.LicenseID = Convert.ToInt32(dr["LicenseID"].ToString());
                    licenseSite.LicenseName = dr["LicenseName"].ToString();
                    licenseSite.CategoryName = dr["CategoryName"].ToString();
                    licenseSite.UnitName = dr["UnitName"].ToString();
                    licenseSite.IssuedDT = dr["IssuedDT"].ToString();
                    licenseSite.ExpiredDT = dr["ExpiredDT"].ToString();
                    licenseSite.PIC2Name = dr["PIC2Name"].ToString();
                    licenseSite.PIC3Name = dr["PIC3Name"].ToString();
                    licenseSite.isRegistered = Convert.ToBoolean(dr["isRegistered"].ToString());
                    licenseSite.isRenewed = Convert.ToBoolean(dr["isRenewed"].ToString());

                    licenseSite.RenewReminderDT = Convert.ToDateTime(dr["RenewReminderDT"].ToString());

                    licenseSiteList.Add(licenseSite);
                }

                conn.Close();
            }

            return licenseSiteList;
        }

        //License Register
        public void RegisterLicenseSite(LicenseSite licenseSite)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseSiteRegister", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CategoryID", licenseSite.CategoryID);
                cmd.Parameters.AddWithValue("DivID", licenseSite.DivID);
                cmd.Parameters.AddWithValue("UnitID", licenseSite.UnitID);
                cmd.Parameters.AddWithValue("LicenseName", licenseSite.LicenseName);
                cmd.Parameters.AddWithValue("RegistrationNo", licenseSite.RegistrationNo);
                cmd.Parameters.AddWithValue("SerialNo", licenseSite.SerialNo);
                cmd.Parameters.AddWithValue("IssuedDT", licenseSite.IssuedDT);
                cmd.Parameters.AddWithValue("ExpiredDT", licenseSite.ExpiredDT);
                cmd.Parameters.AddWithValue("PIC2StaffNo", licenseSite.PIC2StaffNo);
                cmd.Parameters.AddWithValue("PIC3StaffNo", licenseSite.PIC3StaffNo);
                cmd.Parameters.AddWithValue("Remarks", licenseSite.Remarks);

                //License File
                cmd.Parameters.AddWithValue("LicenseFileName", licenseSite.LicenseFileName);
                cmd.Parameters.AddWithValue("FileType", licenseSite.FileType);
                cmd.Parameters.AddWithValue("Extension", licenseSite.Extension);
                cmd.Parameters.AddWithValue("Data", licenseSite.Data);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Renewal License
        public void RenewalLicenseSite(LicenseSite licenseSite)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseSiteRenewal", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("LicenseName", licenseSite.LicenseName);
                cmd.Parameters.AddWithValue("CategoryID", licenseSite.CategoryID);
                cmd.Parameters.AddWithValue("RegistrationNo", licenseSite.RenewalRegistrationNo);
                cmd.Parameters.AddWithValue("SerialNo", licenseSite.RenewalSerialNo);
                cmd.Parameters.AddWithValue("DivID", licenseSite.DivID);
                cmd.Parameters.AddWithValue("UnitID", licenseSite.UnitID);
                cmd.Parameters.AddWithValue("IssuedDT", licenseSite.RenewalIssuedDT);
                cmd.Parameters.AddWithValue("ExpiredDT", licenseSite.RenewalExpiredDT);
                cmd.Parameters.AddWithValue("PIC2StaffNo", licenseSite.PIC2StaffNo);
                cmd.Parameters.AddWithValue("PIC3StaffNo", licenseSite.PIC3StaffNo);
                cmd.Parameters.AddWithValue("Remarks", licenseSite.Remarks);

                //License File (New)
                cmd.Parameters.AddWithValue("LicenseFileName", licenseSite.RenewalLicenseFileName);
                cmd.Parameters.AddWithValue("FileType", licenseSite.RenewalFileType);
                cmd.Parameters.AddWithValue("Extension", licenseSite.RenewalExtension);
                cmd.Parameters.AddWithValue("Data", licenseSite.RenewalData);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //License By ID
        public LicenseSite GetLicenseSiteByID(int? id)
        {
            var licenseSite = new LicenseSite();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseSiteGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("LicenseID", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    licenseSite.LicenseName = dr["LicenseName"].ToString();
                    licenseSite.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    licenseSite.CategoryName = dr["CategoryName"].ToString();
                    licenseSite.RegistrationNo = dr["RegistrationNo"].ToString();
                    licenseSite.SerialNo = dr["SerialNo"].ToString();
                    licenseSite.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    licenseSite.DivName = dr["DivName"].ToString();
                    licenseSite.UnitID = Convert.ToInt32(dr["UnitID"].ToString());
                    licenseSite.UnitName = dr["UnitName"].ToString();
                    licenseSite.IssuedDT = dr["IssuedDT"].ToString();
                    licenseSite.ExpiredDT = dr["ExpiredDT"].ToString();
                    licenseSite.PIC2StaffNo = dr["PIC2StaffNo"].ToString();
                    licenseSite.PIC2Name = dr["PIC2Name"].ToString();
                    licenseSite.PIC2Email = dr["PIC2Email"].ToString();
                    licenseSite.PIC3StaffNo = dr["PIC3StaffNo"].ToString();
                    licenseSite.PIC3Name = dr["PIC3Name"].ToString();
                    licenseSite.PIC3Email = dr["PIC3Email"].ToString();
                    licenseSite.Remarks = dr["Remarks"].ToString();
                    licenseSite.isRegistered = Convert.ToBoolean(dr["isRegistered"].ToString());
                    licenseSite.isRenewed = Convert.ToBoolean(dr["isRenewed"].ToString());

                    licenseSite.LicenseFileName = dr["LicenseFileName"].ToString();
                    licenseSite.FileType = dr["FileType"].ToString();
                    licenseSite.Extension = dr["Extension"].ToString();
                    licenseSite.Data = (byte[])dr["Data"];

                    licenseSite.RenewReminderDT = Convert.ToDateTime(dr["RenewReminderDT"].ToString());
                }

                conn.Close();
            }

            return licenseSite;
        }
        #endregion

        #region LicenseAdmin
        public IEnumerable<LicenseAdmin> LicenseAdminGetAll()
        {
            var licenseAdminList = new List<LicenseAdmin>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseAdminGetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var licenseAdmin = new LicenseAdmin();

                    licenseAdmin.LicenseID = Convert.ToInt32(dr["LicenseID"].ToString());
                    licenseAdmin.LicenseName = dr["LicenseName"].ToString();
                    licenseAdmin.CategoryName = dr["CategoryName"].ToString();
                    licenseAdmin.RegistrationNo = dr["RegistrationNo"].ToString();
                    licenseAdmin.SerialNo = dr["SerialNo"].ToString();
                    licenseAdmin.DivName = dr["DivName"].ToString();
                    licenseAdmin.UnitName = dr["UnitName"].ToString();
                    licenseAdmin.IssuedDT = dr["IssuedDT"].ToString();
                    licenseAdmin.ExpiredDT = dr["ExpiredDT"].ToString();
                    licenseAdmin.PIC2Name = dr["PIC2Name"].ToString();
                    licenseAdmin.PIC3Name = dr["PIC3Name"].ToString();
                    licenseAdmin.Remarks = dr["Remarks"].ToString();
                    licenseAdmin.isRequested = Convert.ToBoolean(dr["isRequested"].ToString());
                    licenseAdmin.isApproved = Convert.ToBoolean(dr["isApproved"].ToString());
                    licenseAdmin.isRegistered = Convert.ToBoolean(dr["isRegistered"].ToString());
                    licenseAdmin.isRenewed = Convert.ToBoolean(dr["isRenewed"].ToString());

                    licenseAdminList.Add(licenseAdmin);
                }

                conn.Close();
            }

            return licenseAdminList;
        }

        //License by ID
        public LicenseAdmin GetLicenseRegisterAdminByID(int? id)
        {
            var licenseAdmin = new LicenseAdmin();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseAdminGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("LicenseID", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    licenseAdmin.LicenseName = dr["LicenseName"].ToString();
                    licenseAdmin.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    licenseAdmin.CategoryName = dr["CategoryName"].ToString();
                    licenseAdmin.RegistrationNo = dr["RegistrationNo"].ToString();
                    licenseAdmin.SerialNo = dr["SerialNo"].ToString();
                    licenseAdmin.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    licenseAdmin.DivName = dr["DivName"].ToString();
                    licenseAdmin.UnitID = Convert.ToInt32(dr["UnitID"].ToString());
                    licenseAdmin.UnitName = dr["UnitName"].ToString();
                    licenseAdmin.PIC2StaffNo = dr["PIC2StaffNo"].ToString();
                    licenseAdmin.PIC2Name = dr["PIC2Name"].ToString();
                    licenseAdmin.PIC2Email = dr["PIC2Email"].ToString();
                    licenseAdmin.PIC3StaffNo = dr["PIC3StaffNo"].ToString();
                    licenseAdmin.PIC3Name = dr["PIC3Name"].ToString();
                    licenseAdmin.PIC3Email = dr["PIC3Email"].ToString();
                    licenseAdmin.Remarks = dr["Remarks"].ToString();
                    licenseAdmin.isRequested = Convert.ToBoolean(dr["isRequested"].ToString());
                    licenseAdmin.isApproved = Convert.ToBoolean(dr["isApproved"].ToString());
                    licenseAdmin.isRegistered = Convert.ToBoolean(dr["isRegistered"].ToString());
                    licenseAdmin.isRenewed = Convert.ToBoolean(dr["isRenewed"].ToString());

                    licenseAdmin.LicenseFileName = dr["LicenseFileName"].ToString();
                    licenseAdmin.FileType = dr["FileType"].ToString();
                    licenseAdmin.Extension = dr["Extension"].ToString();
                    licenseAdmin.Data = (byte[])dr["Data"];
                }

                conn.Close();
            }

            return licenseAdmin;
        }

        //Request License ID
        public LicenseAdmin GetLicenseRequestAdminByID(int? id)
        {
            var licenseAdmin = new LicenseAdmin();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLicenseAdminRequestGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("LicenseID", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    licenseAdmin.LicenseName = dr["LicenseName"].ToString();
                    licenseAdmin.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    licenseAdmin.CategoryName = dr["CategoryName"].ToString();
                    licenseAdmin.RegistrationNo = dr["RegistrationNo"].ToString();
                    licenseAdmin.SerialNo = dr["SerialNo"].ToString();
                    licenseAdmin.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    licenseAdmin.DivName = dr["DivName"].ToString();
                    licenseAdmin.UnitID = Convert.ToInt32(dr["UnitID"].ToString());
                    licenseAdmin.UnitName = dr["UnitName"].ToString();
                    licenseAdmin.PIC2StaffNo = dr["PIC2StaffNo"].ToString();
                    licenseAdmin.PIC2Name = dr["PIC2Name"].ToString();
                    licenseAdmin.PIC2Email = dr["PIC2Email"].ToString();
                    licenseAdmin.PIC3StaffNo = dr["PIC3StaffNo"].ToString();
                    licenseAdmin.PIC3Name = dr["PIC3Name"].ToString();
                    licenseAdmin.PIC3Email = dr["PIC3Email"].ToString();
                    licenseAdmin.Remarks = dr["Remarks"].ToString();
                    licenseAdmin.isRequested = Convert.ToBoolean(dr["isRequested"].ToString());
                    licenseAdmin.isApproved = Convert.ToBoolean(dr["isApproved"].ToString());
                    licenseAdmin.isRegistered = Convert.ToBoolean(dr["isRegistered"].ToString());
                    licenseAdmin.isRenewed = Convert.ToBoolean(dr["isRenewed"].ToString());
                }

                conn.Close();
            }

            return licenseAdmin;
        }
        #endregion
    }
}
