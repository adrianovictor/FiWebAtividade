namespace FI.AtividadeEntrevista.Web.Results
{
    /// <summary>
    /// Implementa a interface <code>IDataResult</code> como uma abstração
    /// </summary>
    public abstract class DataResult : IDataResult
    {
        #region Properties
        public int ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public bool HasError { get; protected set; }
        public dynamic Data { get; protected set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gera um erro durante uma operação de inserção, alteração ou remoção de dados
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public void GenerateLocalError(int errorCode, string message = null)
        {
            HasError = true;
            ErrorCode = errorCode;
            ErrorMessage = message ?? "Desculpe o transtorno, mas houve um erro inesperado. Por favor, tente novamente mais tarde";
        }
        #endregion
    }
}
