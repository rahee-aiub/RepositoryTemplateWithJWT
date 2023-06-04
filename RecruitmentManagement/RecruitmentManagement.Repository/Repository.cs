using RecruitmentManagement.DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManagement.DAL
{
    public class Repository
    {
        public string dbConnection;
        public FIK.DAL.SQL _sql;
        public string msg = "";
        public string baseQuery = "";
        public string whereClause = "";
    }
}
