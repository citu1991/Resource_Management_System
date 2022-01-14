using DTS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DTS.App_Start
{
    public class DataBaseAccess
    {

        SqlConnection con = null;
        private String conStr;
        public DataBaseAccess()
        {           
            conStr = ConfigurationManager.ConnectionStrings["DTSConnection"].ToString();

        }
        //=========================================Circle Start==============================================
        public CircleModel AddCircle(CircleModel crl)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spCircle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddCircle");
                    cmd.Parameters.AddWithValue("@CircleName", crl.CircleName.Trim());
                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListCircle());
                    }
                    else
                    {
                        return (ListCircle());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListCircle());
            }
        }

        public CircleModel ListCircle()
        {
            CircleModel CIRCLE = new CircleModel();
            List<CircleModel> list_circle = new List<CircleModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spCircle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "CircleList");
                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            CircleModel circle = new CircleModel();
                            circle.CircleId = int.Parse(dt.Rows[i]["CircleId"].ToString());
                            circle.CircleName = dt.Rows[i]["CircleName"].ToString();
                            list_circle.Add(circle);
                        }
                        CIRCLE.LIST_CIRCLE = list_circle;
                    }
                    else
                    {
                        CircleModel circle = new CircleModel();
                        circle.CircleId = 0;
                        circle.CircleName = "";
                        list_circle.Add(circle);
                        CIRCLE.LIST_CIRCLE = list_circle;
                    }
                }

            }
            catch (Exception ex)
            {
                CircleModel circle = new CircleModel();
                circle.CircleId = 0;
                circle.Error = ex.Message.ToString();
                list_circle.Add(circle);
                CIRCLE.LIST_CIRCLE = list_circle;
            }
            return CIRCLE;
        }
        //===================================Circle End========================================================

        //=========================================EquipmentType Start==============================================
        public EquipmentTypeModel AddEquipmentType(EquipmentTypeModel eqp)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spEquipmentType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddEquipment");
                    cmd.Parameters.AddWithValue("@EquipmentName", eqp.EquipmentName.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListEquipmentType());
                    }
                    else
                    {
                        return (ListEquipmentType());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListEquipmentType());
            }
        }

        public EquipmentTypeModel ListEquipmentType()
        {
            EquipmentTypeModel EQUIPMENT = new EquipmentTypeModel();
            List<EquipmentTypeModel> list_equipment = new List<EquipmentTypeModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spEquipmentType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "EquipmentList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            EquipmentTypeModel equipment = new EquipmentTypeModel();
                            equipment.EquipmentId = int.Parse(dt.Rows[i]["EquipmentId"].ToString());
                            equipment.EquipmentName = dt.Rows[i]["EquipmentName"].ToString();
                            list_equipment.Add(equipment);
                        }
                        EQUIPMENT.LIST_EQUIPMENTTYPE = list_equipment;
                    }
                    else
                    {
                        EquipmentTypeModel equipment = new EquipmentTypeModel();
                        equipment.EquipmentId = 0;
                        equipment.EquipmentName = "";
                        list_equipment.Add(equipment);
                        EQUIPMENT.LIST_EQUIPMENTTYPE = list_equipment;
                    }
                }

            }
            catch (Exception ex)
            {
                EquipmentTypeModel equipment = new EquipmentTypeModel();
                equipment.EquipmentId = 0;
                equipment.Error = ex.Message.ToString();
                list_equipment.Add(equipment);
                EQUIPMENT.LIST_EQUIPMENTTYPE = list_equipment;
            }
            return EQUIPMENT;
        }
        //===================================EquipmentType End========================================================

        //=========================================Maker Start==============================================
        public MakerModel AddMaker(MakerModel maker)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spMaker", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddMaker");
                    cmd.Parameters.AddWithValue("@MakerName", maker.MakerName.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListMaker());
                    }
                    else
                    {
                        return (ListMaker());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListMaker());
            }
        }

        public MakerModel ListMaker()
        {
            MakerModel MAKER = new MakerModel();
            List<MakerModel> list_maker = new List<MakerModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spMaker", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "MakerList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            MakerModel maker = new MakerModel();
                            maker.MakerId = int.Parse(dt.Rows[i]["MakerId"].ToString());
                            maker.MakerName = dt.Rows[i]["MakerName"].ToString();
                            list_maker.Add(maker);
                        }
                        MAKER.LIST_MAKER = list_maker;
                    }
                    else
                    {
                        MakerModel maker = new MakerModel();
                        maker.MakerId = 0;
                        maker.MakerName = "";
                        list_maker.Add(maker);
                        MAKER.LIST_MAKER = list_maker;
                    }
                }

            }
            catch (Exception ex)
            {
                MakerModel maker = new MakerModel();
                maker.MakerId = 0;
                maker.Error = ex.Message.ToString();
                list_maker.Add(maker);
                MAKER.LIST_MAKER = list_maker;
            }
            return MAKER;
        }
        //===================================Maker End========================================================
        //=========================================Device Model Start==============================================
        public DeviceModelModel AddDeviceModel(DeviceModelModel devicemodel)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeviceModel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddDeviceModel");
                    cmd.Parameters.AddWithValue("@EquipmentId", devicemodel.EquipmentId);
                    cmd.Parameters.AddWithValue("@DeviceModel", devicemodel.Device_Model.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListDeviceModel());
                    }
                    else
                    {
                        return (ListDeviceModel());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListDeviceModel());
            }
        }

        public DeviceModelModel ListDeviceModel()
        {
            DeviceModelModel DEVICEMODEL = new DeviceModelModel();
            List<SelectListItem> items = new List<SelectListItem>();
            List<DeviceModelModel> list_devicemodel = new List<DeviceModelModel>();
            List<EquipmentTypeModel> list_equipment = new List<EquipmentTypeModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spDeviceModel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "DeviceModelList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();

                    if (ds.Tables.Count != 0)
                    {

                        for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DeviceModelModel devicemodel = new DeviceModelModel();
                            devicemodel.DeviceModelId = int.Parse(ds.Tables[0].Rows[i]["DeviceModelId"].ToString());
                            devicemodel.EquipmentId = int.Parse(ds.Tables[0].Rows[i]["EquipmentId"].ToString());
                            devicemodel.Device_Model = ds.Tables[0].Rows[i]["DeviceModel"].ToString();
                            list_devicemodel.Add(devicemodel);
                        }
                        for (var i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            EquipmentTypeModel equipment = new EquipmentTypeModel();
                            equipment.EquipmentId = int.Parse(ds.Tables[1].Rows[i]["EquipmentId"].ToString());
                            equipment.EquipmentName = ds.Tables[1].Rows[i]["EquipmentName"].ToString();
                            list_equipment.Add(equipment);
                        }
                        DEVICEMODEL.LIST_DEVICEMODEL = list_devicemodel;
                        DEVICEMODEL.LIST_EQUIPMENTTYPE = list_equipment;
                    }
                    else
                    {
                        DeviceModelModel DM = new DeviceModelModel();
                        DM.LIST_EQUIPMENTTYPE[0].EquipmentId = 0;
                        return DM;
                    }
                }

            }
            catch (Exception ex)
            {
                DeviceModelModel DMEX = new DeviceModelModel();
                DMEX.LIST_EQUIPMENTTYPE[0].Error = ex.Message.ToString();
                DMEX.LIST_EQUIPMENTTYPE[0].EquipmentId = 0;
                return DMEX;
            }
            return DEVICEMODEL;
        }
        //===================================Device Model End========================================================



        //=========================================Processor Start==============================================
        public ProcessorModel AddProcessorModel(ProcessorModel processor)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spProcessor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddProcessor");
                    cmd.Parameters.AddWithValue("@ProcessorType", processor.ProcessorType.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListProcessorModel());
                    }
                    else
                    {
                        return (ListProcessorModel());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListProcessorModel());
            }
        }

        public ProcessorModel ListProcessorModel()
        {
            ProcessorModel PROCESSOR = new ProcessorModel();
            List<ProcessorModel> list_processor = new List<ProcessorModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spProcessor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "ProcessorList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            ProcessorModel processor = new ProcessorModel();
                            processor.ProcessorId = int.Parse(dt.Rows[i]["ProcessorId"].ToString());
                            processor.ProcessorType = dt.Rows[i]["ProcessorType"].ToString();
                            list_processor.Add(processor);
                        }
                        PROCESSOR.LIST_PROCESSOR = list_processor;
                    }
                    else
                    {
                        ProcessorModel processor = new ProcessorModel();
                        processor.ProcessorId = 0;
                        processor.ProcessorType = "";
                        list_processor.Add(processor);
                        PROCESSOR.LIST_PROCESSOR = list_processor;
                    }
                }

            }
            catch (Exception ex)
            {
                ProcessorModel processor = new ProcessorModel();
                processor.ProcessorId = 0;
                processor.Error = ex.Message.ToString();
                list_processor.Add(processor);
                PROCESSOR.LIST_PROCESSOR = list_processor;
            }
            return PROCESSOR;
        }
        //===================================Processor End========================================================


        //=========================================RAM Size Start==============================================
        public RAMSizeModel AddRAMSizeModel(RAMSizeModel ramsize)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spRAMSize", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddRAMSize");
                    cmd.Parameters.AddWithValue("@RAMSize", ramsize.RAMCapacity.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListRAMSizeModel());
                    }
                    else
                    {
                        return (ListRAMSizeModel());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListRAMSizeModel());
            }
        }

        public RAMSizeModel ListRAMSizeModel()
        {
            RAMSizeModel RAMSIZE = new RAMSizeModel();
            List<RAMSizeModel> list_ramsize = new List<RAMSizeModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spRAMSize", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "RAMSizeList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            RAMSizeModel ramsize = new RAMSizeModel();
                            ramsize.RAMId = int.Parse(dt.Rows[i]["RAMId"].ToString());
                            ramsize.RAMCapacity = dt.Rows[i]["RAMSize"].ToString();
                            list_ramsize.Add(ramsize);
                        }
                        RAMSIZE.LIST_RAMSIZE = list_ramsize;
                    }
                    else
                    {
                        RAMSizeModel ramsize = new RAMSizeModel();
                        ramsize.RAMId = 0;
                        ramsize.RAMCapacity = "";
                        list_ramsize.Add(ramsize);
                        RAMSIZE.LIST_RAMSIZE = list_ramsize;
                    }
                }

            }
            catch (Exception ex)
            {
                RAMSizeModel ramsize = new RAMSizeModel();
                ramsize.RAMId = 0;
                ramsize.Error = ex.Message.ToString();
                list_ramsize.Add(ramsize);
                RAMSIZE.LIST_RAMSIZE = list_ramsize;
            }
            return RAMSIZE;
        }
        //===================================RAM Size End========================================================


        public string Registration(UserRegistration user)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spRegistration", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "Registration");
                    cmd.Parameters.AddWithValue("@UserFname", user.UserFname);
                    cmd.Parameters.AddWithValue("@UserLname", user.UserLname);
                    cmd.Parameters.AddWithValue("@UserEmailId", user.UserEmailId);
                    cmd.Parameters.AddWithValue("@UserMobNo", user.UserMobNo);
                    cmd.Parameters.AddWithValue("@UserPwd", Encrypt(user.UserPwd.Trim()));
                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i >= 0)
                    {
                        return cmd.Parameters["@Result"].Value.ToString();  //success 
                    }
                    else
                    {
                        return cmd.Parameters["@Result"].Value.ToString(); // error
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();//Exception
            }

        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Login(UserLogin users)
        {
            //User user = new User();
            //UserRepo userRepo = new UserRepo();
            //user = userRepo.CheckLogin(user);
            //if (user.UserId > 0)
            //    httpContext.s // ye dot net h ya fr dot net core? .net hi h ok
            //return user.UserEmailId;

            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spRegistration", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "Login");
                    cmd.Parameters.AddWithValue("@UserEmailId", users.UserEmailId);
                    cmd.Parameters.AddWithValue("@UserPwd", Encrypt(users.UserPwd.Trim()));
                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {
                        bool val = Convert.ToBoolean(dt.Rows[0]["IsActiveUser"].ToString());
                        if (val)
                        {
                            HttpContext.Current.Session["UserFullName"] = dt.Rows[0]["UserFullName"].ToString();
                            HttpContext.Current.Session["UserType"] = dt.Rows[0]["UserType"].ToString();
                            HttpContext.Current.Session["CircleName"] = dt.Rows[0]["CircleName"].ToString();
                            HttpContext.Current.Session["CircleId"] = dt.Rows[0]["CircleId"].ToString();
                            HttpContext.Current.Session["UserId"] = dt.Rows[0]["UserId"].ToString();
                            if (int.Parse(dt.Rows[0]["UserTypeId"].ToString()) == 1)//1 for Admin page
                            {
                                return "Admin";
                            }
                            else if (int.Parse(dt.Rows[0]["UserTypeId"].ToString()) == 2)//1 for User page
                            {
                                return "User";
                            }
                            else
                            {
                                return "No Such User Exists.";
                            }
                        }
                        else
                        {
                            return "In-Active User Please Contact Admin.";
                        }

                    }
                    else
                    {
                        return "Invalid Email and Password.";
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();//Exception
            }

        }

        public Active_InActiveUsers GetActiveUsers()
        {
            Active_InActiveUsers ACT_INACT = new Active_InActiveUsers();


            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spRegistration", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "Active_Users");
                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    List<Active_InActiveUsers> list_act_inact = new List<Active_InActiveUsers>();
                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            Active_InActiveUsers act_inact = new Active_InActiveUsers();
                            act_inact.UserId = int.Parse(dt.Rows[i]["UserId"].ToString());
                            act_inact.CircleId = int.Parse(dt.Rows[i]["CircleId"].ToString());
                            act_inact.FullName = dt.Rows[i]["UserFullName"].ToString();
                            act_inact.UserMobNo = dt.Rows[i]["UserMobNo"].ToString();
                            act_inact.CircleName = dt.Rows[i]["CircleName"].ToString();
                            act_inact.UserEmailId = dt.Rows[i]["UserEmailId"].ToString();
                            act_inact.DistrictOfficeString = dt.Rows[i]["DistrictOfficeString"].ToString();
                            list_act_inact.Add(act_inact);
                        }
                        ACT_INACT.LISTACT_INACT = list_act_inact;
                    }
                    else
                    {
                        Active_InActiveUsers act_inact = new Active_InActiveUsers();
                        act_inact.UserId = 0;
                        act_inact.CircleId = 0;
                        act_inact.FullName = "";
                        act_inact.UserMobNo = "";
                        act_inact.CircleName = "";
                        act_inact.UserEmailId = "";
                        list_act_inact.Add(act_inact);
                        ACT_INACT.LISTACT_INACT = list_act_inact;
                    }
                }

            }
            catch (Exception ex)
            {
                Active_InActiveUsers act_inact = new Active_InActiveUsers();
                List<Active_InActiveUsers> list_act_inact = new List<Active_InActiveUsers>();
                act_inact.UserId = 0;
                act_inact.Exception = ex.Message.ToString();
                list_act_inact.Add(act_inact);
                ACT_INACT.LISTACT_INACT = list_act_inact;//Exception
            }
            return ACT_INACT;
        }


        public Active_InActiveUsers GetInActiveUsers()
        {
            Active_InActiveUsers ACT_INACT = new Active_InActiveUsers();


            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spRegistration", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "In_Active_Users");
                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    List<Active_InActiveUsers> list_act_inact = new List<Active_InActiveUsers>();
                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            Active_InActiveUsers act_inact = new Active_InActiveUsers();
                            act_inact.UserId = int.Parse(dt.Rows[i]["UserId"].ToString());
                            act_inact.CircleId = int.Parse(dt.Rows[i]["CircleId"].ToString());
                            act_inact.FullName = dt.Rows[i]["UserFullName"].ToString();
                            act_inact.UserMobNo = dt.Rows[i]["UserMobNo"].ToString();
                            act_inact.CircleName = dt.Rows[i]["CircleName"].ToString();
                            act_inact.UserEmailId = dt.Rows[i]["UserEmailId"].ToString();
                            act_inact.DistrictOfficeString = dt.Rows[i]["DistrictOfficeString"].ToString();
                            list_act_inact.Add(act_inact);

                        }
                        ACT_INACT.LISTACT_INACT = list_act_inact;
                    }
                    else
                    {
                        Active_InActiveUsers act_inact = new Active_InActiveUsers();
                        act_inact.UserId = 0;
                        act_inact.CircleId = 0;
                        act_inact.FullName = "";
                        act_inact.UserMobNo = "";
                        act_inact.CircleName = "";
                        act_inact.UserEmailId = "";
                        list_act_inact.Add(act_inact);
                        ACT_INACT.LISTACT_INACT = list_act_inact;
                    }
                }

            }
            catch (Exception ex)
            {
                Active_InActiveUsers act_inact = new Active_InActiveUsers();
                List<Active_InActiveUsers> list_act_inact = new List<Active_InActiveUsers>();
                act_inact.UserId = 0;
                act_inact.Exception = ex.Message.ToString();
                list_act_inact.Add(act_inact);
                ACT_INACT.LISTACT_INACT = list_act_inact;//Exception
            }
            return ACT_INACT;
        }

        public bool ConfirmUserAction(int UserId, string ActionOnUser)
        {
            try
            {
                Active_InActiveUsers ACT_INACT = new Active_InActiveUsers();
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spRegistration", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ActionOnUser.Equals("UserActivation"))
                    {
                        cmd.Parameters.AddWithValue("@mode", "UserActivation");
                    }
                    else if (ActionOnUser.Equals("UserDeactivation"))
                    {
                        cmd.Parameters.AddWithValue("@mode", "UserDeactivation");
                    }
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output; cmd.ExecuteNonQuery();
                    con.Close();

                    if (cmd.Parameters["@Result"].Value.ToString() == "Activated")
                    {
                        return true;
                    }
                    else if (cmd.Parameters["@Result"].Value.ToString() == "De-Activated")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //======================================================Assign Circle Start===================================================

        public UserCircleViewModel ListAssignCircletoUser()
        {
            UserCircleViewModel UCVM = new UserCircleViewModel();
            List<SelectListItem> items = new List<SelectListItem>();
            using (con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("spAssignCircle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "ListAssignCircletoUser");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<CircleModel> circlelist = new List<CircleModel>();
                List<UserCircleViewModel> usercirclelist = new List<UserCircleViewModel>();
                if (ds.Tables.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CircleModel cir = new CircleModel();
                        cir.CircleId = Convert.ToInt32(ds.Tables[0].Rows[i]["CircleId"].ToString());
                        cir.CircleName = ds.Tables[0].Rows[i]["CircleName"].ToString();
                        circlelist.Add(cir);
                    }

                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        UserCircleViewModel usercircle = new UserCircleViewModel();
                        usercircle.UserId = Convert.ToInt32(ds.Tables[1].Rows[i]["UserId"].ToString());
                        usercircle.UserandCircle = ds.Tables[1].Rows[i]["UserandCircle"].ToString();
                        usercirclelist.Add(usercircle);
                    }
                    UCVM.LIST_CIRCLE = circlelist;
                    UCVM.LIST_USERCIRCLEVM = usercirclelist;
                }
            }
            con.Close();
            return UCVM;
        }

        public UserCircleViewModel AssignCircleToUser(int circleid, int userid)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spAssignCircle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AssignCircletoUser");
                    cmd.Parameters.AddWithValue("@CircleId", circleid);
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListAssignCircletoUser());
                    }
                    else
                    {
                        return (ListAssignCircletoUser());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListAssignCircletoUser());
            }
        }
        //=============================================================Assign Circle End============================================

        //=======================================================District Start=========================================================
        public CircleDistrictModel ListDistrict()
        {
            CircleDistrictModel DISTRICT = new CircleDistrictModel();
            List<SelectListItem> items = new List<SelectListItem>();

            using (con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("spDistrict", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DistrictList");
                cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                List<CircleModel> circlelist = new List<CircleModel>();
                List<CircleDistrictModel> districtlist = new List<CircleDistrictModel>();
                if (ds.Tables.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CircleModel cir = new CircleModel();
                        cir.CircleId = Convert.ToInt32(ds.Tables[0].Rows[i]["CircleId"].ToString());
                        cir.CircleName = ds.Tables[0].Rows[i]["CircleName"].ToString();
                        circlelist.Add(cir);
                    }

                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        CircleDistrictModel dis = new CircleDistrictModel();
                        dis.CircleId = Convert.ToInt32(ds.Tables[1].Rows[i]["CircleId"].ToString());
                        dis.DistrictId = Convert.ToInt32(ds.Tables[1].Rows[i]["DistrictId"].ToString());
                        dis.DistrictName = ds.Tables[1].Rows[i]["DistrictName"].ToString();
                        districtlist.Add(dis);
                    }
                    DISTRICT.LIST_CIRCLE = circlelist;
                    DISTRICT.LIST_DISTRICT = districtlist;
                }

            }
            con.Close();
            return DISTRICT;
        }

        public CircleDistrictModel AddDistrict(CircleDistrictModel crlDist)
        {
            try
            {
                if (crlDist.CircleId > 0 && crlDist.DistrictName != "")
                {
                    using (con = new SqlConnection(conStr))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("spDistrict", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mode", "AddDistrict");
                        cmd.Parameters.AddWithValue("@CircleId", crlDist.CircleId);
                        cmd.Parameters.AddWithValue("@DistrictName", crlDist.DistrictName.Trim());
                        cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        int success = cmd.ExecuteNonQuery();
                        con.Close();
                        if (success > 0)
                        {
                            return (ListDistrict());
                        }
                        else
                        {
                            return (ListDistrict());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListDistrict());
            }
            return (ListDistrict());
        }
        //===================================================District End===========================================================



        //======================================================Storage Start===================================================


        public StorageModel ListStorage()
        {
            StorageModel STORAGE = new StorageModel();
            List<StorageModel> list_storage = new List<StorageModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spStorage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "ListStorage");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            StorageModel storage = new StorageModel();
                            storage.StorageId = int.Parse(dt.Rows[i]["StorageId"].ToString());
                            storage.StorageSize = dt.Rows[i]["Storage"].ToString();
                            list_storage.Add(storage);
                        }
                        STORAGE.LIST_STORAGE = list_storage;
                    }
                    else
                    {
                        StorageModel storage = new StorageModel();
                        storage.StorageId = 0;
                        storage.StorageSize = "";
                        list_storage.Add(storage);
                        STORAGE.LIST_STORAGE = list_storage;
                    }
                }

            }
            catch (Exception ex)
            {
                StorageModel storage = new StorageModel();
                storage.StorageId = 0;
                storage.Error = ex.Message.ToString();
                list_storage.Add(storage);
                STORAGE.LIST_STORAGE = list_storage;
            }
            return STORAGE;
        }

        public StorageModel AddStorage(StorageModel stg)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spStorage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddStorage");
                    cmd.Parameters.AddWithValue("@Storage", stg.StorageSize);
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListStorage());
                    }
                    else
                    {
                        return (ListStorage());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListStorage());
            }
        }
        //=============================================================Storage End============================================


        //=================================================================Add Component Start====================================

        public ComponentViewModel FillDropDown()
        {
            ComponentViewModel COMPONENT = new ComponentViewModel();
            List<SelectList> item = new List<SelectList>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spComponent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "GetDropDown");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    List<EquipmentTypeModel> list_Equipment = new List<EquipmentTypeModel>();
                    List<MakerModel> list_Makermodel = new List<MakerModel>();
                    List<WarrantyModel> list_WarrantyModel = new List<WarrantyModel>();

                    List<ProcessorModel> list_Processor = new List<ProcessorModel>();
                    List<RAMSizeModel> list_RamSize = new List<RAMSizeModel>();
                    List<StorageModel> list_Storage = new List<StorageModel>();

                    List<DisplaySizeModel> list_Display = new List<DisplaySizeModel>();
                    List<PortModel> list_Port = new List<PortModel>();
                    List<BatteryTypeModel> list_Battery = new List<BatteryTypeModel>();


                    List<PrinterTypeModel> list_PrinterType = new List<PrinterTypeModel>();
                    List<PrinterTechModel> list_PrinterTech = new List<PrinterTechModel>();
                    List<PrinterColorModel> list_PrinterColor = new List<PrinterColorModel>();

                    if (ds.Tables.Count > 0)
                    {

                        for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            EquipmentTypeModel equip = new EquipmentTypeModel();
                            equip.EquipmentId = int.Parse(ds.Tables[0].Rows[i]["EquipmentId"].ToString());
                            equip.EquipmentName = ds.Tables[0].Rows[i]["EquipmentName"].ToString();
                            list_Equipment.Add(equip);

                        }
                        for (var i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            MakerModel makermodel = new MakerModel();
                            makermodel.MakerId = int.Parse(ds.Tables[1].Rows[i]["MakerId"].ToString());
                            makermodel.MakerName = ds.Tables[1].Rows[i]["MakerName"].ToString();
                            list_Makermodel.Add(makermodel);

                        }

                        for (var i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            WarrantyModel warrantymodel = new WarrantyModel();
                            warrantymodel.WarrantyId = int.Parse(ds.Tables[2].Rows[i]["WarrantyId"].ToString());
                            warrantymodel.Warranty = int.Parse(ds.Tables[2].Rows[i]["Warranty"].ToString());
                            list_WarrantyModel.Add(warrantymodel);

                        }

                        for (var i = 0; i < ds.Tables[3].Rows.Count; i++)
                        {
                            RAMSizeModel ram = new RAMSizeModel();
                            ram.RAMId = int.Parse(ds.Tables[3].Rows[i]["RAMId"].ToString());
                            ram.RAMCapacity = ds.Tables[3].Rows[i]["RAMSize"].ToString();
                            list_RamSize.Add(ram);

                        }
                        for (var i = 0; i < ds.Tables[4].Rows.Count; i++)
                        {
                            StorageModel storage = new StorageModel();
                            storage.StorageId = int.Parse(ds.Tables[4].Rows[i]["StorageId"].ToString());
                            storage.StorageSize = ds.Tables[4].Rows[i]["Storage"].ToString();
                            list_Storage.Add(storage);

                        }

                        for (var i = 0; i < ds.Tables[5].Rows.Count; i++)
                        {
                            ProcessorModel processor = new ProcessorModel();
                            processor.ProcessorId = int.Parse(ds.Tables[5].Rows[i]["ProcessorId"].ToString());
                            processor.ProcessorType = ds.Tables[5].Rows[i]["ProcessorType"].ToString();
                            list_Processor.Add(processor);

                        }

                        for (var i = 0; i < ds.Tables[6].Rows.Count; i++)
                        {
                            DisplaySizeModel display = new DisplaySizeModel();
                            display.DisplaySizeId = int.Parse(ds.Tables[6].Rows[i]["DisplaySizeId"].ToString());
                            display.DisplaySize = ds.Tables[6].Rows[i]["DisplaySize"].ToString();
                            list_Display.Add(display);

                        }

                        for (var i = 0; i < ds.Tables[7].Rows.Count; i++)
                        {
                            PortModel portmodel = new PortModel();
                            portmodel.PortId = int.Parse(ds.Tables[7].Rows[i]["PortId"].ToString());
                            portmodel.Port = int.Parse(ds.Tables[7].Rows[i]["Port"].ToString());
                            list_Port.Add(portmodel);

                        }

                        for (var i = 0; i < ds.Tables[8].Rows.Count; i++)
                        {
                            BatteryTypeModel batterymodel = new BatteryTypeModel();
                            batterymodel.BatteryTypeId = int.Parse(ds.Tables[8].Rows[i]["BatteryTypeId"].ToString());
                            batterymodel.BatteryType = ds.Tables[8].Rows[i]["BatteryType"].ToString();
                            list_Battery.Add(batterymodel);
                        }

                        for (var i = 0; i < ds.Tables[9].Rows.Count; i++)
                        {
                            PrinterTypeModel printertypemodel = new PrinterTypeModel();
                            printertypemodel.PrinterTypeId = int.Parse(ds.Tables[9].Rows[i]["PrinterTypeId"].ToString());
                            printertypemodel.PrinterType = ds.Tables[9].Rows[i]["PrinterType"].ToString();
                            list_PrinterType.Add(printertypemodel);

                        }

                        for (var i = 0; i < ds.Tables[10].Rows.Count; i++)
                        {
                            PrinterTechModel printertechmodel = new PrinterTechModel();
                            printertechmodel.PrinterTechId = int.Parse(ds.Tables[10].Rows[i]["PrinterTechId"].ToString());
                            printertechmodel.PrinterTech = ds.Tables[10].Rows[i]["PrinterTech"].ToString();
                            list_PrinterTech.Add(printertechmodel);

                        }

                        for (var i = 0; i < ds.Tables[11].Rows.Count; i++)
                        {
                            PrinterColorModel printercolormodel = new PrinterColorModel();
                            printercolormodel.PrinterColorId = int.Parse(ds.Tables[11].Rows[i]["PrinterColorId"].ToString());
                            printercolormodel.PrinterColor = ds.Tables[11].Rows[i]["PrinterColor"].ToString();
                            list_PrinterColor.Add(printercolormodel);

                        }


                        COMPONENT.LIST_EQUIPMENT = list_Equipment;
                        COMPONENT.LIST_MAKER = list_Makermodel;
                        COMPONENT.LIST_WARRANTY = list_WarrantyModel;

                        COMPONENT.LIST_PROCESSOR = list_Processor;
                        COMPONENT.LIST_RAM = list_RamSize;
                        COMPONENT.LIST_STORAGE = list_Storage;

                        COMPONENT.LIST_DISPLAYSIZE = list_Display;
                        COMPONENT.LIST_PORT = list_Port;
                        COMPONENT.LIST_BATTERYTYPE = list_Battery;

                        COMPONENT.LIST_PRINTERTYPE = list_PrinterType;
                        COMPONENT.LIST_PRINTERTECH = list_PrinterTech;
                        COMPONENT.LIST_PRINTERCOLOR = list_PrinterColor;

                    }
                    else
                    {
                        ComponentViewModel COMP = new ComponentViewModel();
                        COMP.LIST_EQUIPMENT[0].EquipmentId = 0;
                        COMP.LIST_MAKER[0].MakerId = 0;
                        COMP.LIST_PROCESSOR[0].ProcessorId = 0;
                        COMP.LIST_RAM[0].RAMId = 0;
                        COMP.LIST_STORAGE[0].StorageId = 0;
                        COMP.LIST_DISPLAYSIZE[0].DisplaySizeId = 0;
                        COMP.LIST_PORT[0].PortId = 0;
                        COMP.LIST_BATTERYTYPE[0].BatteryTypeId = 0;
                        COMP.LIST_PRINTERTYPE[0].PrinterTypeId = 0;
                        COMP.LIST_PRINTERTECH[0].PrinterTechId = 0;
                        COMP.LIST_PRINTERCOLOR[0].PrinterColorId = 0;

                        return COMP;
                    }
                }
            }
            catch (Exception ex)
            {
                ComponentViewModel Ex_COMP = new ComponentViewModel();
                Ex_COMP.LIST_EQUIPMENT[0].EquipmentId = 0;
                Ex_COMP.LIST_MAKER[0].MakerId = 0;
                Ex_COMP.LIST_PROCESSOR[0].ProcessorId = 0;
                Ex_COMP.LIST_RAM[0].RAMId = 0;
                Ex_COMP.LIST_STORAGE[0].StorageId = 0;
                Ex_COMP.LIST_DISPLAYSIZE[0].DisplaySizeId = 0;
                Ex_COMP.LIST_PORT[0].PortId = 0;
                Ex_COMP.LIST_BATTERYTYPE[0].BatteryTypeId = 0;
                Ex_COMP.LIST_PRINTERTYPE[0].PrinterTypeId = 0;
                Ex_COMP.LIST_PRINTERTECH[0].PrinterTechId = 0;
                Ex_COMP.LIST_PRINTERCOLOR[0].PrinterColorId = 0;
                Ex_COMP.Message = ex.Message.ToString();
                return Ex_COMP;

            }
            return COMPONENT;

        }
        public ComponentViewModel AddComponent(ComponentViewModel model)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spComponent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddComponent");
                    cmd.Parameters.AddWithValue("@EquipmentId", model.EquipmentId);
                    cmd.Parameters.AddWithValue("@DeviceModelId", model.DeviceModelId);
                    cmd.Parameters.AddWithValue("@MakerId", model.MakerId);
                    cmd.Parameters.AddWithValue("@WarrantyId", model.WarrantyId);
                    cmd.Parameters.AddWithValue("@DOPurchase", model.DateofPurchase);
                    cmd.Parameters.AddWithValue("@SerialNo", model.SerialNo);
                    cmd.Parameters.AddWithValue("@Remarks", model.Remarks);
                    if (model.EquipmentId == 1) //cpu All in One Laptop
                    {
                        cmd.Parameters.AddWithValue("@ProcessorId", model.ProcessorId);
                        cmd.Parameters.AddWithValue("@RAMId", model.RAMId);
                        cmd.Parameters.AddWithValue("@StorageId", model.StorageId);
                        //cmd.Parameters.AddWithValue("@CPUSerialNo", model.SerialNo);
                        //cmd.Parameters.AddWithValue("@CPURemarks", model.Remarks);
                    }
                    else if (model.EquipmentId == 5) //Printer
                    {
                        cmd.Parameters.AddWithValue("@PrinterTypeId", model.PrinterTypeId);
                        cmd.Parameters.AddWithValue("@PrinterColorId", model.PrinterColorId);
                        cmd.Parameters.AddWithValue("@PrinterTechId", model.PrinterTechId);
                        //cmd.Parameters.AddWithValue("@PrinterSerialNo", model.SerialNo);
                        //cmd.Parameters.AddWithValue("@PrinterRemarks", model.Remarks);
                    }

                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (FillDropDown());
                    }
                    else
                    {
                        return (FillDropDown());
                    }
                }

            }
            catch (Exception ex)
            {
                return (FillDropDown());
            }
        }

        public DataSet CPUList()
        {
            DataSet ds = get_DataSet("spComponent", "CPUList");
            return ds;
            //DataTable dt = new DataTable();           
            //using (con = new SqlConnection(conStr))
            //{
            //    SqlCommand cmd = new SqlCommand("spComponent", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    cmd.Parameters.AddWithValue("@mode", "CPUList");
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr != null)
            //    {
            //        dt.Load(dr);
            //        dr.Close();
            //    }

            //    return dt;

            //}
        }
       
        // =================================================================Add Component End======================================

        //===================================Warranty Start========================================================
        public WarrantyModel AddWarranty(WarrantyModel warranty)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spWarranty", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddWarranty");
                    cmd.Parameters.AddWithValue("@Warranty", warranty.Warranty);
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListWarranty());
                    }
                    else
                    {
                        return (ListWarranty());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListWarranty());
            }
        }

        public WarrantyModel ListWarranty()
        {
            WarrantyModel WARRANTY = new WarrantyModel();
            List<WarrantyModel> list_Warranty = new List<WarrantyModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spWarranty", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "WarrantyList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            WarrantyModel Warranty = new WarrantyModel();
                            Warranty.WarrantyId = int.Parse(dt.Rows[i]["WarrantyId"].ToString());
                            Warranty.Warranty = int.Parse(dt.Rows[i]["Warranty"].ToString());
                            list_Warranty.Add(Warranty);
                        }
                        WARRANTY.LIST_WARRANTY = list_Warranty;
                    }
                    else
                    {
                        WarrantyModel Warranty = new WarrantyModel();
                        Warranty.WarrantyId = 0;
                        Warranty.Warranty = 0;
                        list_Warranty.Add(Warranty);
                        WARRANTY.LIST_WARRANTY = list_Warranty;
                    }
                }

            }
            catch (Exception ex)
            {
                WarrantyModel Warranty = new WarrantyModel();
                Warranty.WarrantyId = 0;
                Warranty.Message = ex.Message.ToString();
                list_Warranty.Add(Warranty);
                WARRANTY.LIST_WARRANTY = list_Warranty;
            }
            return WARRANTY;
        }
        //===================================Warranty End========================================================

        //===================================Port Start========================================================
        public PortModel AddPort(PortModel port)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spPort", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddPort");
                    cmd.Parameters.AddWithValue("@Port", port.Port);
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListPort());
                    }
                    else
                    {
                        return (ListPort());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListPort());
            }
        }

        public PortModel ListPort()
        {
            PortModel PORT = new PortModel();
            List<PortModel> list_Port = new List<PortModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spPort", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "PortList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            PortModel port = new PortModel();
                            port.PortId = int.Parse(dt.Rows[i]["PortId"].ToString());
                            port.Port = int.Parse(dt.Rows[i]["Port"].ToString());
                            list_Port.Add(port);
                        }
                        PORT.LIST_PORT = list_Port;
                    }
                    else
                    {
                        PortModel Port = new PortModel();
                        Port.PortId = 0;
                        Port.Port = 0;
                        list_Port.Add(Port);
                        PORT.LIST_PORT = list_Port;
                    }
                }

            }
            catch (Exception ex)
            {
                PortModel Port = new PortModel();
                Port.PortId = 0;
                Port.Message = ex.Message.ToString();
                list_Port.Add(Port);
                PORT.LIST_PORT = list_Port;
            }
            return PORT;
        }
        //===================================Port End========================================================
        //===================================DisplaySize Start========================================================
        public DisplaySizeModel AddDisplaySize(DisplaySizeModel displaysize)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDisplaySize", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddDisplaySize");
                    cmd.Parameters.AddWithValue("@DisplaySize", displaysize.DisplaySize);
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListDisplaySize());
                    }
                    else
                    {
                        return (ListDisplaySize());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListDisplaySize());
            }
        }

        public DisplaySizeModel ListDisplaySize()
        {
            DisplaySizeModel DISPLAYSIZE = new DisplaySizeModel();
            List<DisplaySizeModel> list_DisplaySize = new List<DisplaySizeModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spDisplaySize", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "DisplaySizeList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            DisplaySizeModel DisplaySize = new DisplaySizeModel();
                            DisplaySize.DisplaySizeId = int.Parse(dt.Rows[i]["DisplaySizeId"].ToString());
                            DisplaySize.DisplaySize = dt.Rows[i]["DisplaySize"].ToString();
                            list_DisplaySize.Add(DisplaySize);
                        }
                        DISPLAYSIZE.LIST_DISPLAYSIZE = list_DisplaySize;
                    }
                    else
                    {
                        DisplaySizeModel DisplaySize = new DisplaySizeModel();
                        DisplaySize.DisplaySizeId = 0;
                        DisplaySize.DisplaySize = "";
                        list_DisplaySize.Add(DisplaySize);
                        DISPLAYSIZE.LIST_DISPLAYSIZE = list_DisplaySize;
                    }
                }

            }
            catch (Exception ex)
            {
                DisplaySizeModel DisplaySize = new DisplaySizeModel();
                DisplaySize.DisplaySizeId = 0;
                DisplaySize.Message = ex.Message.ToString();
                list_DisplaySize.Add(DisplaySize);
                DISPLAYSIZE.LIST_DISPLAYSIZE = list_DisplaySize;
            }
            return DISPLAYSIZE;
        }
        //===================================DisplaySize End========================================================


        //===================================BatteryType Start========================================================
        public BatteryTypeModel AddBatteryType(BatteryTypeModel batteryType)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spBatteryType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddBatteryType");
                    cmd.Parameters.AddWithValue("@BatteryType", batteryType.BatteryType.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListBatteryType());
                    }
                    else
                    {
                        return (ListBatteryType());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListBatteryType());
            }
        }

        public BatteryTypeModel ListBatteryType()
        {
            BatteryTypeModel BATTERYTYPE = new BatteryTypeModel();
            List<BatteryTypeModel> list_BatteryType = new List<BatteryTypeModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spBatteryType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "BatteryTypeList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            BatteryTypeModel BatteryType = new BatteryTypeModel();
                            BatteryType.BatteryTypeId = int.Parse(dt.Rows[i]["BatteryTypeId"].ToString());
                            BatteryType.BatteryType = dt.Rows[i]["BatteryType"].ToString();
                            list_BatteryType.Add(BatteryType);
                        }
                        BATTERYTYPE.LIST_BATTERYTYPE = list_BatteryType;
                    }
                    else
                    {
                        BatteryTypeModel BatteryType = new BatteryTypeModel();
                        BatteryType.BatteryTypeId = 0;
                        BatteryType.BatteryType = "";
                        list_BatteryType.Add(BatteryType);
                        BATTERYTYPE.LIST_BATTERYTYPE = list_BatteryType;
                    }
                }

            }
            catch (Exception ex)
            {
                BatteryTypeModel BatteryType = new BatteryTypeModel();
                BatteryType.BatteryTypeId = 0;
                BatteryType.Message = ex.Message.ToString();
                list_BatteryType.Add(BatteryType);
                BATTERYTYPE.LIST_BATTERYTYPE = list_BatteryType;
            }
            return BATTERYTYPE;
        }
        //===================================BatteryType End========================================================


        //===================================PrinterType Start========================================================
        public PrinterTypeModel AddPrinterType(PrinterTypeModel printerType)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spPrinterType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddPrinterType");
                    cmd.Parameters.AddWithValue("@PrinterType", printerType.PrinterType.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListPrinterType());
                    }
                    else
                    {
                        return (ListPrinterType());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListPrinterType());
            }
        }

        public PrinterTypeModel ListPrinterType()
        {
            PrinterTypeModel PRINTERTYPE = new PrinterTypeModel();
            List<PrinterTypeModel> list_PrinterType = new List<PrinterTypeModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spPrinterType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "PrinterTypeList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            PrinterTypeModel PrinterType = new PrinterTypeModel();
                            PrinterType.PrinterTypeId = int.Parse(dt.Rows[i]["PrinterTypeId"].ToString());
                            PrinterType.PrinterType = dt.Rows[i]["PrinterType"].ToString();
                            list_PrinterType.Add(PrinterType);
                        }
                        PRINTERTYPE.LIST_PRINTERTYPE = list_PrinterType;
                    }
                    else
                    {
                        PrinterTypeModel PrinterType = new PrinterTypeModel();
                        PrinterType.PrinterTypeId = 0;
                        PrinterType.PrinterType = "";
                        list_PrinterType.Add(PrinterType);
                        PRINTERTYPE.LIST_PRINTERTYPE = list_PrinterType;
                    }
                }

            }
            catch (Exception ex)
            {
                PrinterTypeModel PrinterType = new PrinterTypeModel();
                PrinterType.PrinterTypeId = 0;
                PrinterType.Message = ex.Message.ToString();
                list_PrinterType.Add(PrinterType);
                PRINTERTYPE.LIST_PRINTERTYPE = list_PrinterType;
            }
            return PRINTERTYPE;
        }
        //===================================PrinterType End========================================================

        //===================================PrinterColor Start========================================================
        public PrinterColorModel AddPrinterColor(PrinterColorModel printerColor)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spPrinterColor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddPrinterColor");
                    cmd.Parameters.AddWithValue("@PrinterColor", printerColor.PrinterColor.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListPrinterColor());
                    }
                    else
                    {
                        return (ListPrinterColor());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListPrinterColor());
            }
        }

        public PrinterColorModel ListPrinterColor()
        {
            PrinterColorModel PRINTERCOLOR = new PrinterColorModel();
            List<PrinterColorModel> list_PrinterColor = new List<PrinterColorModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spPrinterColor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "PrinterColorList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            PrinterColorModel PrinterColor = new PrinterColorModel();
                            PrinterColor.PrinterColorId = int.Parse(dt.Rows[i]["PrinterColorId"].ToString());
                            PrinterColor.PrinterColor = dt.Rows[i]["PrinterColor"].ToString();
                            list_PrinterColor.Add(PrinterColor);
                        }
                        PRINTERCOLOR.LIST_PRINTERCOLOR = list_PrinterColor;
                    }
                    else
                    {
                        PrinterColorModel PrinterColor = new PrinterColorModel();
                        PrinterColor.PrinterColorId = 0;
                        PrinterColor.PrinterColor = "";
                        list_PrinterColor.Add(PrinterColor);
                        PRINTERCOLOR.LIST_PRINTERCOLOR = list_PrinterColor;
                    }
                }

            }
            catch (Exception ex)
            {
                PrinterColorModel PrinterColor = new PrinterColorModel();
                PrinterColor.PrinterColorId = 0;
                PrinterColor.Message = ex.Message.ToString();
                list_PrinterColor.Add(PrinterColor);
                PRINTERCOLOR.LIST_PRINTERCOLOR = list_PrinterColor;
            }
            return PRINTERCOLOR;
        }
        //===================================PrinterColor End========================================================

        //===================================PrinterTech Start========================================================
        public PrinterTechModel AddPrinterTech(PrinterTechModel printerTech)
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spPrinterTech", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "AddPrinterTech");
                    cmd.Parameters.AddWithValue("@PrinterTech", printerTech.PrinterTech.Trim());
                    int success = cmd.ExecuteNonQuery();
                    con.Close();
                    if (success > 0)
                    {
                        return (ListPrinterTech());
                    }
                    else
                    {
                        return (ListPrinterTech());
                    }
                }

            }
            catch (Exception ex)
            {
                return (ListPrinterTech());
            }
        }

        public PrinterTechModel ListPrinterTech()
        {
            PrinterTechModel PRINTERTECH = new PrinterTechModel();
            List<PrinterTechModel> list_PrinterTech = new List<PrinterTechModel>();
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spPrinterTech", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "PrinterTechList");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (int.Parse(dt.Rows[0][0].ToString()) != 0)
                    {

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            PrinterTechModel PrinterTech = new PrinterTechModel();
                            PrinterTech.PrinterTechId = int.Parse(dt.Rows[i]["PrinterTechId"].ToString());
                            PrinterTech.PrinterTech = dt.Rows[i]["PrinterTech"].ToString();
                            list_PrinterTech.Add(PrinterTech);
                        }
                        PRINTERTECH.LIST_PRINTERTECH = list_PrinterTech;
                    }
                    else
                    {
                        PrinterTechModel PrinterTech = new PrinterTechModel();
                        PrinterTech.PrinterTechId = 0;
                        PrinterTech.PrinterTech = "";
                        list_PrinterTech.Add(PrinterTech);
                        PRINTERTECH.LIST_PRINTERTECH = list_PrinterTech;
                    }
                }

            }
            catch (Exception ex)
            {
                PrinterTechModel PrinterTech = new PrinterTechModel();
                PrinterTech.PrinterTechId = 0;
                PrinterTech.Message = ex.Message.ToString();
                list_PrinterTech.Add(PrinterTech);
                PRINTERTECH.LIST_PRINTERTECH = list_PrinterTech;
            }
            return PRINTERTECH;
        }
        //===================================PrinterTech End========================================================

        //======================================================Json Start===============================================================

        public IEnumerable<DeviceModelModel> GetModelFromEquipmentId(int ID_Eqp)
        {
            List<DeviceModelModel> DEVICE = new List<DeviceModelModel>();
            using (con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("spDeviceModel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "FillModelList");
                cmd.Parameters.AddWithValue("@EquipmentId", ID_Eqp);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();

                if (ds.Tables.Count != 0)
                {

                    for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DeviceModelModel devicemodel = new DeviceModelModel();
                        devicemodel.DeviceModelId = int.Parse(ds.Tables[0].Rows[i]["DeviceModelId"].ToString());
                        devicemodel.EquipmentId = int.Parse(ds.Tables[0].Rows[i]["EquipmentId"].ToString());
                        devicemodel.Device_Model = ds.Tables[0].Rows[i]["DeviceModel"].ToString();
                        DEVICE.Add(devicemodel);
                    }

                }
            }
            con.Close();
            return DEVICE;

        }

        public int AssignCPUtoCircle(int CircleId, string CPUIds, int verificationcode)
        {
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAssignComponent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AssignCPUtoCircle");
                cmd.Parameters.AddWithValue("@CircleId", CircleId);
                cmd.Parameters.AddWithValue("@VerificationCode", verificationcode);
                cmd.Parameters.AddWithValue("@CheckboxCheckedIds", CPUIds+",");
                int success = cmd.ExecuteNonQuery();               
                if (success > 0)
                {
                    return verificationcode;
                }
                else
                {
                    return 0;
                }
            }          
           
        }

        public int AssignCPUtoDistOffice(int DistrictId, string CPUIds)
        {
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAssignComponent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AssignCPUtoDistrictOffice");
                cmd.Parameters.AddWithValue("@DistrictId", DistrictId);
                cmd.Parameters.AddWithValue("@CheckboxCheckedIds", CPUIds + ",");
                int success = cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public int AssignCPUtoDistStaff(int StaffPersonId, string CPUIds)
        {
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAssignComponent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AssignCPUtoDistrictStaff");
                cmd.Parameters.AddWithValue("@DistrictId", StaffPersonId);
                cmd.Parameters.AddWithValue("@CheckboxCheckedIds", CPUIds + ",");
                int success = cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public int AssignCPUtoStaff(int AssignedId, int CPUId, string PayeeCode, string Designation, string EmpName, string EmpMobile)
        {
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAllocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AssignCPUtoStaff");
                cmd.Parameters.AddWithValue("@AssignedId", AssignedId);
                cmd.Parameters.AddWithValue("@CPUId", CPUId);
                cmd.Parameters.AddWithValue("@PayeeCode", PayeeCode);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmployeeName", EmpName);
                cmd.Parameters.AddWithValue("@MobileNo", EmpMobile);                
                int success = cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public int InboxVerifyCPU(int CPUId, string verificationcode)
        {
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spComponent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "inboxverifycpu");
                cmd.Parameters.AddWithValue("@CPUId", CPUId);
                cmd.Parameters.AddWithValue("@VerificationCode", verificationcode);
                int success = cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public int VerifyPayeeCode(string PayeeCode,int CPU_Id)
        {
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAllocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "VerifyPayeeCode");
                cmd.Parameters.AddWithValue("@PayeeCode", PayeeCode);
                cmd.Parameters.AddWithValue("@CPUId", CPU_Id);               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);              

                if (dt.Rows.Count>0)
                {
                    string v=dt.Rows[0]["Result"].ToString();
                    if (v== "New Payee Code")
                    {
                        return 1;
                    }
                    else if(v=="Old Payee Code")
                    {
                        return 0;
                    }
                }              
                return 0;
            }

        }

        public int DeallocateDevice(int AssignId, int CPU_Id)
        {
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAllocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeallocateDevice");
                cmd.Parameters.AddWithValue("@AssignedId", AssignId);
                cmd.Parameters.AddWithValue("@CPUId", CPU_Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string v = dt.Rows[0]["Result"].ToString();
                    if (v == "Deallocated")
                    {
                        return 1;
                    }
                    else if (v == "Not Deallocated")
                    {
                        return 0;
                    }
                }
                return 0;
            }

        }
        //=====================================================Json END=====================================================================

        public DataTable get_DataTable( string proc,string mode,int CircleId=0)
        {
            DataTable dt = new DataTable();
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(proc, con);
                cmd.Parameters.AddWithValue("@mode", mode);
                cmd.Parameters.AddWithValue("@CircleId", CircleId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    dt.Load(dr);
                    dr.Close();
                }
                return dt;
            }
          }
        public DataSet get_DataSet(string proc, string mode,int CircleId=0)
        {
            DataSet ds = new DataSet();           
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(proc, con);
                cmd.Parameters.AddWithValue("@mode", mode);
                cmd.Parameters.AddWithValue("@CircleId", CircleId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (da != null)
                {
                    
                    da.Fill(ds);
                }
                return ds;
            }
        }
                
        public DataSet get_DataSetStaffName(string proc, string mode, int CircleId,int AssignedId,int CPUId)
        {
            DataSet ds = new DataSet();
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(proc, con);
                cmd.Parameters.AddWithValue("@mode", mode);
                cmd.Parameters.AddWithValue("@CircleId", CircleId);
                cmd.Parameters.AddWithValue("@AssignedId", AssignedId);
                cmd.Parameters.AddWithValue("@CPUId", CPUId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (da != null)
                {

                    da.Fill(ds);
                }
                return ds;
            }
        }
        public DataSet get_DataSetStaffNameLog(string proc, string mode, int CPUId)
        {
            DataSet ds = new DataSet();
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(proc, con);
                cmd.Parameters.AddWithValue("@mode", mode);                
                cmd.Parameters.AddWithValue("@CPUId", CPUId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (da != null)
                {

                    da.Fill(ds);
                }
                return ds;
            }
        }
        public DataSet get_DataSetComponents(string proc, string mode, int CircleId = 0,int AssignedId=0,int ComponentId=0)
        {
            DataSet ds = new DataSet();
            using (con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(proc, con);
                cmd.Parameters.AddWithValue("@mode", mode);
                cmd.Parameters.AddWithValue("@CircleId", CircleId);
                cmd.Parameters.AddWithValue("@AssignedId", AssignedId);
                cmd.Parameters.AddWithValue("@ComponentId", ComponentId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (da != null)
                {

                    da.Fill(ds);
                }
                return ds;
            }
        }


    }
}