using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

/// <summary>
/// Summary description for ConnectDB
/// </summary>
public class ConnectDB
{
    public static OleDbConnection getConStr()
    {
        return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+HttpContext.Current.Server.MapPath("data.mdb"));
    }
	public ConnectDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}