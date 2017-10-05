using ORA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_DAL.DAL
{
    class PositionsDAL
    {
        /// <summary>
        /// Basic CRUD methods for Position information. PositionsDM is the model being used here.
        /// </summary>
        /// 

        #region POSITION DAL METHODS

        public void CreatePosition(PositionsDM _position)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_POSITION", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Position_Name", _position.PositionName);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                        SqlConnect.Connection.Close();
                    }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public List<PositionsDM> ReadPosition()
        {
            List<PositionsDM> _positionList = new List<PositionsDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_POSITION", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _position = new PositionsDM();
                                    _position.PositionName = (string)reader["Position_Name"];
                                    _positionList.Add(_position);
                                }
                            }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_positionList);
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public void UpdatePosition(PositionsDM _position)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_POSITION", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Position_ID", _position.PositionId);
                        cmd.Parameters.AddWithValue("@Position_Name", _position.PositionName);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public void DeletePosition(PositionsDM _position)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_POSITION", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Position_ID", _position.PositionId);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        #endregion
    }
}
