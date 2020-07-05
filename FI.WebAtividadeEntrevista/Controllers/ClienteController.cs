using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;

namespace WebAtividadeEntrevista.Controllers
{
    public class ClienteController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Incluir
        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(ClienteModel model)
        {
            BoCliente bo = new BoCliente();
            
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                
                model.Id = bo.Incluir(Cliente.Create
                (
                    nome: model.Nome,
                    sobrenome: model.Sobrenome,
                    cpf: model.CPF,
                    cep: model.CEP,
                    cidade: model.Cidade,
                    email: model.Email,
                    estado: model.Estado,
                    logradouro: model.Logradouro,
                    nacionalidade: model.Nacionalidade,
                    telefone: model.Telefone
                ));

                if (bo.HasError)
                {
                    Response.StatusCode = bo.ErrorCode;
                    return Json(bo.ErrorMessage);                    
                }
                else return Json("Cadastro efetuado com sucesso");
            }
        }
        #endregion

        #region Alterar
        [HttpPost]
        public JsonResult Alterar(ClienteModel model)
        {
            BoCliente bo = new BoCliente();
       
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var cli = Cliente.Create
                (
                    nome: model.Nome,
                    sobrenome: model.Sobrenome,
                    cpf: model.CPF,
                    cep: model.CEP,
                    cidade: model.Cidade,
                    email: model.Email,
                    estado: model.Estado,
                    logradouro: model.Logradouro,
                    nacionalidade: model.Nacionalidade,
                    telefone: model.Telefone
                );
                cli.Id = model.Id;

                bo.Alterar(cli);

                if (bo.HasError)
                {
                    Response.StatusCode = bo.ErrorCode;
                    return Json(bo.ErrorMessage);
                }
                else return Json("Cadastro alterado com sucesso");                
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoCliente bo = new BoCliente();
            Cliente cliente = bo.Consultar(id);
            Models.ClienteModel model = null;

            if (cliente != null)
            {
                model = new ClienteModel()
                {
                    Id = cliente.Id,
                    CEP = cliente.CEP,
                    Cidade = cliente.Cidade,
                    Email = cliente.Email,
                    Estado = cliente.Estado,
                    Logradouro = cliente.Logradouro,
                    Nacionalidade = cliente.Nacionalidade,
                    Nome = cliente.Nome,
                    Sobrenome = cliente.Sobrenome,
                    CPF = cliente.CPF,
                    Telefone = cliente.Telefone
                };

            
            }

            return View(model);
        }
        #endregion

        #region Listar Clientes
        [HttpPost]
        public JsonResult ClienteList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int qtd = 0;
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');

                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<Cliente> clientes = new BoCliente().Pesquisa(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

                //Return result to jTable
                return Json(new { Result = "OK", Records = clientes, TotalRecordCount = qtd });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion
    }
}