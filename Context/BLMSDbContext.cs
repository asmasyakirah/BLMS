using BLMS.v2.Models.Admin;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLMS.v2.Context
{
    public class BLMSDbContext : DbContext
    {
        //readonly string connectionstring = "Data Source=EGBS11N10043471;Database=BLMS;User ID = sa; Password=P@ss1234; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        readonly string connectionstring = "Data Source = 10.249.1.125; Database=BLMSDev;User ID = Appsa; Password=Opuswebsql2017;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region Admin/Registration/BusinessDiv
        //List All Business Division
        public IEnumerable<BusinessDiv> BusinessDivGetAll()
        {
            var businessDivList = new List<BusinessDiv>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessDivGetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    var businessDiv = new BusinessDiv();

                    businessDiv.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    businessDiv.DivName = dr["DivName"].ToString();

                    businessDivList.Add(businessDiv);
                }

                conn.Close();
            }

            return businessDivList;
        }

        //Create Business Division
        public void AddBusinessDiv(BusinessDiv businessDiv)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessDivAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("DivName", businessDiv.DivName);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Edit Business Division
        public void EditBusinessDiv(BusinessDiv businessDiv)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessDivEdit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("DivID", businessDiv.DivID);
                cmd.Parameters.AddWithValue("DivName", businessDiv.DivName);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Delete Business Division
        public void DeleteBusinessDiv(int? id)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessDivDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("DivID", id);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Get Business Division By ID
        public BusinessDiv GetBusinessDivByID(int? id)
        {
            var businessDiv = new BusinessDiv();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessDivGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("DivID", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    businessDiv.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    businessDiv.DivName = dr["DivName"].ToString();
                }

                conn.Close();
            }

            return businessDiv;
        }

        //Check Duplication in Create New Entry
        public BusinessDiv CheckBusinessDivByName(string DivName)
        {
            var businessDiv = new BusinessDiv();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessDivCheck", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("DivName", DivName);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    businessDiv.ExistData = Convert.ToInt32(dr["ExistData"].ToString());
                }

                conn.Close();
            }

            return businessDiv;
        }

        //Check linked Business Unit before delete
        public BusinessDiv CheckLinkedBusinessUnitByName(string DivName)
        {
            var businessDiv = new BusinessDiv();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessDivCheckLinkedBusinessUnit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("DivName", DivName);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    businessDiv.LinkedData = Convert.ToInt32(dr["LinkedData"].ToString());
                }

                conn.Close();
            }

            return businessDiv;
        }
        #endregion

        #region Admin/Registration/BusinessUnit
        //List All Business Unit
        public IEnumerable<BusinessUnit> BusinessUnitGetAll()
        {
            var businessUnitList = new List<BusinessUnit>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessUnitGetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var businessUnit = new BusinessUnit();

                    businessUnit.UnitID = Convert.ToInt32(dr["UnitID"].ToString());
                    businessUnit.DivName = dr["DivName"].ToString();
                    businessUnit.UnitName = dr["UnitName"].ToString();
                    businessUnit.HoCName = dr["HoCName"].ToString();

                    businessUnitList.Add(businessUnit);
                }

                conn.Close();
            }

            return businessUnitList;
        }

        //Create Business Unit
        public void AddBusinessUnit(BusinessUnit businessUnit)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessUnitAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("DivID", businessUnit.DivID);
                cmd.Parameters.AddWithValue("UnitName", businessUnit.UnitName);
                cmd.Parameters.AddWithValue("HoCName", businessUnit.HoCName);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Edit Business Unit
        public void EditBusinessUnit(BusinessUnit businessUnit)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessUnitEdit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UnitID", businessUnit.UnitID);
                cmd.Parameters.AddWithValue("DivID", businessUnit.DivID);
                cmd.Parameters.AddWithValue("UnitName", businessUnit.UnitName);
                cmd.Parameters.AddWithValue("HoCName", businessUnit.HoCName);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Delete Business Unit
        public void DeleteBusinessUnit(int? id)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessUnitDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UnitID", id);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Get Business Unit By ID
        public BusinessUnit GetBusinessUnitByID(int? id)
        {
            var businessUnit = new BusinessUnit();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessUnitGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UnitID", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    businessUnit.UnitID = Convert.ToInt32(dr["UnitID"].ToString());
                    businessUnit.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    businessUnit.DivName = dr["DivName"].ToString();
                    businessUnit.UnitName = dr["UnitName"].ToString();
                    businessUnit.HoCName = dr["HoCName"].ToString();
                }

                conn.Close();
            }

            return businessUnit;
        }

        //Check Duplication in Create New Entry
        public BusinessUnit CheckBusinessUnitByName(string UnitName)
        {
            var businessUnit = new BusinessUnit();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spBusinessUnitCheck", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UnitName", UnitName);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    businessUnit.ExistData = Convert.ToInt32(dr["ExistData"].ToString());
                }

                conn.Close();
            }

            return businessUnit;
        }
        #endregion

        #region Admin/Registration/Category
        //List All Category
        public IEnumerable<Category> CategoryGetAll()
        {
            var categoryList = new List<Category>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spCategoryGetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var category = new Category();

                    category.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    category.CategoryName = dr["CategoryName"].ToString();
                    category.Description = dr["Description"].ToString();

                    categoryList.Add(category);
                }

                conn.Close();
            }

            return categoryList;
        }

        //Create Category
        public void AddCategory(Category category)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spCategoryAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("Description", category.Description);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Edit Category
        public void EditCategory(Category category)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spCategoryEdit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CategoryID", category.CategoryID);
                cmd.Parameters.AddWithValue("CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("Description", category.Description);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Delete Category
        public void DeleteCategory(int? id)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spCategoryDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CategoryID", id);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Get Category By ID
        public Category GetCategoryByID(int? id)
        {
            var category = new Category();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spCategoryGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CategoryID", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    category.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    category.CategoryName = dr["CategoryName"].ToString();
                    category.Description = dr["Description"].ToString();
                }

                conn.Close();
            }

            return category;
        }

        //Check Duplication in Create New Entry
        public Category CheckCategoryByName(string CategoryName)
        {
            var category = new Category();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spCategoryCheck", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CategoryName", CategoryName);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    category.ExistData = Convert.ToInt32(dr["ExistData"].ToString());
                }

                conn.Close();
            }

            return category;
        }
        #endregion

        #region Admin/Registration/PIC
        //List All PIC
        public IEnumerable<PIC> PICGetAll()
        {
            var PICList = new List<PIC>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spPICGetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var pic = new PIC();

                    pic.PICID = Convert.ToInt32(dr["PICID"].ToString());
                    pic.PICStaffNo = dr["PICStaffNo"].ToString();
                    pic.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    pic.UnitID = Convert.ToInt32(dr["UnitID"].ToString());
                    pic.UserTypeID = Convert.ToInt32(dr["UserTypeID"].ToString());
                    pic.PICName = dr["PICName"].ToString();
                    pic.PICEmail = dr["PICEmail"].ToString();
                    pic.DivName = dr["DivName"].ToString();
                    pic.UnitName = dr["UnitName"].ToString();
                    pic.UserType = dr["UserType"].ToString();

                    PICList.Add(pic);
                }

                conn.Close();
            }

            return PICList;
        }

        //Create PIC
        public void AddPIC(PIC pic)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spPICAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("DivID", pic.DivID);
                cmd.Parameters.AddWithValue("UnitID", pic.UnitID);
                cmd.Parameters.AddWithValue("UserTypeID", pic.UserTypeID);
                cmd.Parameters.AddWithValue("PICStaffNo", pic.PICStaffNo);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Edit PIC
        public void EditPIC(PIC pic)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spPICEdit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("PICID", pic.PICID);
                cmd.Parameters.AddWithValue("DivID", pic.DivID);
                cmd.Parameters.AddWithValue("UnitID", pic.UnitID);
                cmd.Parameters.AddWithValue("UserTypeID", pic.UserTypeID);
                cmd.Parameters.AddWithValue("PICStaffNo", pic.PICStaffNo);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Delete PIC
        public void DeletePIC(int? id)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spPICDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("PICID", id);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Get PIC
        public PIC GetPICByID(int? id)
        {
            var pic = new PIC();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spPICGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("PICID", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    pic.PICID = Convert.ToInt32(dr["PICID"].ToString());
                    pic.DivID = Convert.ToInt32(dr["DivID"].ToString());
                    pic.UnitID = Convert.ToInt32(dr["UnitID"].ToString());
                    pic.UserTypeID = Convert.ToInt32(dr["UserTypeID"].ToString());
                    pic.PICStaffNo = dr["PICStaffNo"].ToString();
                    pic.PICName = dr["PICName"].ToString();
                    pic.PICEmail = dr["PICEmail"].ToString();
                    pic.DivName = dr["DivName"].ToString();
                    pic.UnitName = dr["UnitName"].ToString();
                    pic.UserType = dr["UserType"].ToString();
                }

                conn.Close();
            }

            return pic;
        }
        #endregion

        #region Admin/Registration/AuthorityLink
        //List All into gridview
        public IEnumerable<Authority> AuthorityGetAll()
        {
            var AuthorityList = new List<Authority>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spAuthorityGetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var authority = new Authority();

                    authority.AuthorityID = Convert.ToInt32(dr["AuthorityId"].ToString());
                    authority.AuthorityName = dr["AuthorityName"].ToString();
                    authority.AuthorityLink = dr["AuthorityLink"].ToString();

                    AuthorityList.Add(authority);
                }

                conn.Close();
            }

            return AuthorityList;
        }

        //Create Business Division
        public void AddAuthority(Authority authority)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spAuthorityLinkAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("AuthorityName", authority.AuthorityName);
                cmd.Parameters.AddWithValue("AuthorityLink", authority.AuthorityLink);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Edit Business Unit
        public void EditAuthorityLink(Authority authority)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spAuthoritylinkEdit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("AuthorityID", authority.AuthorityID);
                cmd.Parameters.AddWithValue("AuthorityName", authority.AuthorityName);
                cmd.Parameters.AddWithValue("AuthorityLink", authority.AuthorityLink);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //Delete Authority Link
        public void DeleteAuthorityLink(int? AuthorityID)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spAuthorityLinkDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("AuthorityID", AuthorityID);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public Authority GetAuthorityLinkByID(int? AuthorityID)
        {
            var authority = new Authority();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spAuthorityLinkById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("AuthorityID", AuthorityID);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    authority.AuthorityID = Convert.ToInt32(dr["AuthorityID"].ToString());
                    authority.AuthorityName = dr["AuthorityName"].ToString();
                    authority.AuthorityLink = dr["AuthorityLink"].ToString();

                }

                conn.Close();
            }

            return authority;
        }

        //Check Duplication in Create New Entry
        public Authority CheckAuthorityByName(string AuthorityName)
        {
            var authority = new Authority();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spAuthorityLinkCheck", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("AuthorityName", AuthorityName);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    authority.ExistData = Convert.ToInt32(dr["ExistData"].ToString());
                }

                conn.Close();
            }

            return authority;
        }
        #endregion
    }
}
