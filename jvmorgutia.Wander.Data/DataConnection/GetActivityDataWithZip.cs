using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using jvmorgutia.Wander.Contract.Models;

namespace jvmorgutia.Wander.Data.DataConnection
{
    public class GetActivityDataWithZip : IDataConnection
    {
        public string StoredProcedureConnectionString { get; set; }

        public GetActivityDataWithZip()
        {
            StoredProcedureConnectionString = "Location.WanderActivityZip_Select";
        }

        #region Procedure Parameters

        private int ZipCode { get; set; }
        private int Radius { get; set; }

        #endregion

        public GetActivityDataWithZip SetParameters(int zipCode, int radius)
        {
            ZipCode = zipCode;
            Radius = radius;

            return this;
        }

        public List<WanderActivity> ExecuteDataModelList()
        {
            using (var sqlConnection = new SqlConnection())
            {
                var sqlCommand = CreateCommand(sqlConnection);

                sqlConnection.Open();
                var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                var activityList = new List<WanderActivity>();
                while (reader.Read())
                {
                    activityList.Add(CreateWanderActivity(reader));
                }
                reader.Close();
                return activityList;
            }
        }

        private WanderActivity CreateWanderActivity(SqlDataReader reader)
        {
            var titleOrdinal = reader.GetOrdinal("Title");
            var subtitleOrdinal = reader.GetOrdinal("SubTitle");
            var descriptionOrdinal = reader.GetOrdinal("Description");
            var imageBytesOrdinal = reader.GetOrdinal("ImageBytes");
            var wanderAddressIdOrdinal = reader.GetOrdinal("WanderAddressID");

            var wanderActivity = new WanderActivity();
            if (!reader.IsDBNull(titleOrdinal)) wanderActivity.Title = reader.GetFieldValue<string>(titleOrdinal);
            if (!reader.IsDBNull(subtitleOrdinal)) wanderActivity.Subtitle = reader.GetFieldValue<string>(subtitleOrdinal);
            if (!reader.IsDBNull(descriptionOrdinal)) wanderActivity.Description = reader.GetFieldValue<string>(descriptionOrdinal);
            if (!reader.IsDBNull(imageBytesOrdinal)) wanderActivity.Image = CreateImageFromByteArray(reader.GetFieldValue<byte[]>(imageBytesOrdinal));
            if (!reader.IsDBNull(wanderAddressIdOrdinal)) wanderActivity.Address = new WanderAddress(reader.GetFieldValue<int>(wanderAddressIdOrdinal));

            return wanderActivity;
        }

        private Image CreateImageFromByteArray(byte[] bytes)
        {
            Image image = null;
            try
            {
                image = (Image) new ImageConverter().ConvertFrom(bytes);
            }
            catch
            {
                // ignored
            }
            return image;
        }

        public SqlCommand CreateCommand(SqlConnection sqlConnection)
        {
            var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            AddParameters(sqlCommand);

            return sqlCommand;
        }

        private void AddParameters(SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.Add("returnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            AddParameter(sqlCommand, "@ZipCode", ZipCode, ParameterDirection.Input, 50, SqlDbType.Int);
            AddParameter(sqlCommand, "@Radius", Radius, ParameterDirection.Input, 50, SqlDbType.Int);
        }

        private void AddParameter(SqlCommand sqlCommand, string paramName, object value, ParameterDirection direction, int? size, SqlDbType dbType)
        {
            var param = new SqlParameter(paramName, value);
            if (size != null) param.Size = size.Value;
            param.Direction = direction;
            param.SqlDbType = dbType;
            sqlCommand.Parameters.Add(param);
        }
    }
}
