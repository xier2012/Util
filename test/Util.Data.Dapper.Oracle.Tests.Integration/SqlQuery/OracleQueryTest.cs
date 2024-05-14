using Util.Data.Sql;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// Oracle Sql��ѯ�������
    /// </summary>
    public partial class OracleQueryTest {
        /// <summary>
        /// Sqlִ����
        /// </summary>
        private readonly ISqlExecutor _sqlExecutor;
        /// <summary>
        /// Sql��ѯ����
        /// </summary>
        private readonly ISqlQuery _sqlQuery;

        /// <summary>
        /// ���Գ�ʼ��
        /// </summary>
        public OracleQueryTest( ISqlExecutor sqlExecutor, ISqlQuery sqlQuery ) {
            _sqlExecutor = sqlExecutor;
            _sqlQuery = sqlQuery;
        }
    }
}
