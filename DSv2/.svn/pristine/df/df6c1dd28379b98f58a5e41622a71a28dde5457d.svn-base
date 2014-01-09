using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    internal class DbReader
    {
        internal static void Read(DbReadable callback)
        {
            DbDataReader reader = null;
            try
            {
                callback.GetConnectionToBase().Open();
                DbCommand cmd = callback.GetDbCommand();
                reader = cmd.ExecuteReader();
                int Columns = reader.FieldCount;
                for (int i = 0; i < Columns; ++i)
                {
                    callback.GetParserCore().SetColumnName(reader.GetName(i));
                }
                callback.GetParserCore().GotoStart();
                while (reader.Read())
                {
                    for (int i = 0; i < Columns; ++i)
                    {
                        callback.GetParserCore().AddCellInRowAndGoToNextColumn(Convert.ToString(reader.GetValue(i)));
                    }
                    callback.GetParserCore().GotoNextRow();
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (callback.GetConnectionToBase() != null)
                {
                    callback.GetConnectionToBase().Close();
                }
            }
        }
    }
}
