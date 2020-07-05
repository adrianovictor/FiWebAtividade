using System;
using System.Collections.Generic;
namespace FI.AtividadeEntrevista.Web.Results
{
    /// <summary>
    /// Interface resposável por disponibilizar a estrutura de dados que 
    /// será utilizada para validar o resultado da operação.
    /// </summary>
    public interface IDataResult
    {
        /// <summary>
        /// Contém o código de erro
        /// </summary>
        int ErrorCode { get; }

        /// <summary>
        /// Contém a mensagem de erro
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Indica se gerou algum erro
        /// </summary>
        bool HasError { get; }

        /// <summary>
        /// Contém os dados resultantes de uma operação
        /// </summary>
        dynamic Data { get; }
    }
}
